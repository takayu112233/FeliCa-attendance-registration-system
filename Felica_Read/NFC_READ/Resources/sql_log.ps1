echo "log監視を開始します"
Get-Content -Path C:\xampp\mysql\data\kpc-018c1031.log -Tail 0 -Wait -Encoding UTF8