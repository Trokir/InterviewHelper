@echo off
for /f "tokens=5" %%a in ('netstat -aon ^| findstr 3000') do (
  taskkill /f /pid %%a
)
echo Node.js process on port 3000 has been stopped.
