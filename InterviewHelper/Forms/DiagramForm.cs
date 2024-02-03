using InterviewHelper.Core.Models;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterviewHelper.Forms
{
    public partial class DiagramForm : Form
    {
        private readonly IImageService _imageService;
        private readonly IMessageService _messageService;

        private IEnumerable<ImageEntity> _images;
        public DiagramForm(ImageService imageService, IMessageService messageService)
        {
            InitializeComponent();
            _imageService = imageService;
            _messageService = messageService;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            var openFileDialog = _imageService.SelectAndSavePngFile();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var dialog = _messageService.ShowCustomMessage("Save this file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    await _imageService.SavePngFileContentToDb(filePath, fileName);
                }
                else if (dialog == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private async void cmbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbFiles.SelectedItem as ImageEntity;
            if (value != null)
            {
                var image = await _imageService.GetImageEntityById(value.Id);
                if (image is not null)
                {
                    using (var ms = new MemoryStream(image.Content))
                    {
                        pcbImage.Image = Image.FromStream(ms);
                    }
                }
                txtInfo.Text = value.FileName;
                pcbImage.Refresh();
            }
        }

        private async void DiagramForm_Load(object sender, EventArgs e)
        {
            _images = await _imageService.GetAllEntitiesAsync();
            cmbFiles.ValueMember = "Id";
            cmbFiles.DisplayMember = "FileName";
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
            var value = cmbFiles.SelectedItem as ImageEntity;
            if (value != null)
            {
                var dialog = _messageService.ShowCustomMessage("Delete this file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    await _imageService.DeleteImageAsync(value);
                }
            }
        }
    }
}
