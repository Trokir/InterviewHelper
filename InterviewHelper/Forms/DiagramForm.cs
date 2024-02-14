﻿
using InterviewHelper.Core.Models.DTOs;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Services;

namespace InterviewHelper.Forms
{
    public partial class DiagramForm : Form
    {
        private readonly IMessageService _messageService;
        private readonly IMongoDbService _mongoDbService;
        private IEnumerable<PngImage> _images;


        public DiagramForm(IMessageService messageService,
            IMongoDbService mongoDbService)
        {
            InitializeComponent();
            _mongoDbService = mongoDbService;
            _messageService = messageService;

        }



        private async Task RefreshData(IEnumerable<PngImage> images)
        {

            cmbFiles.Items.Clear();

            cmbFiles.ValueMember = "Id";
            cmbFiles.DisplayMember = "Description";
            this.Invoke((MethodInvoker)delegate
            {

                cmbFiles.Items.Clear();
                foreach (var image in images)
                {
                    cmbFiles.Items.Add(image);
                }

            });
            cmbFiles.Refresh();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            var openFileDialog = _mongoDbService.SelectAndSavePngFile();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var dialog = _messageService.ShowCustomMessage("Save this file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    await _mongoDbService.CreateImageAsync(filePath, fileName);
                    _images = await _mongoDbService.GetAllImagesAsync();
                    await RefreshData(_images);
                }
                else if (dialog == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private async void cmbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbFiles.SelectedItem as PngImage;
            if (value != null)
            {
                var image = await _mongoDbService.GetImageByIdAsync(value.Id);
                if (image is not null)
                {
                    using (var ms = new MemoryStream(image.ImageData))
                    {
                        pcbImage.Image = Image.FromStream(ms);
                    }
                }
                txtInfo.Text = value.Description;
                pcbImage.Refresh();
            }
        }

        private async void DiagramForm_Load(object sender, EventArgs e)
        {
            _images = await _mongoDbService.GetAllImagesAsync();
            cmbFiles.ValueMember = "Id";
            cmbFiles.DisplayMember = "Description";
            this.Invoke((MethodInvoker)delegate
            {

                cmbFiles.Items.Clear();
                foreach (var category in _images)
                {
                    cmbFiles.Items.Add(category);
                }

            });
            cmbFiles.Refresh();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var value = cmbFiles.SelectedItem as PngImage;
            if (value != null)
            {
                var dialog = _messageService.ShowCustomMessage("Delete this file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    await _mongoDbService.DeleteImageAsync(value.Id);
                }
            }
        }

        private async void cmbFiles_TextUpdate(object sender, EventArgs e)
        {
            if (cmbFiles.Text.Length > 2)
            {
                var filter = cmbFiles.Text.Trim();
                var filteredCollection = _images.Where(f => f.Description.Contains(filter, StringComparison.CurrentCultureIgnoreCase));

                await RefreshData(filteredCollection);
                cmbFiles.DroppedDown = true;
            }
            else
            {
                cmbFiles.DroppedDown = false;
                await RefreshData(_images);
            }
            cmbFiles.SelectionStart = cmbFiles.Text.Length;
            cmbFiles.SelectionLength = 0;
        }
    }
}
