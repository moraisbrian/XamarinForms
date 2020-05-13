using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App11_PCLStorage.Util
{
    public class StorageManager
    {
        public async static void SalvarArquivo(string arquivo, string conteudo)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Arquivos", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(arquivo, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(conteudo);
        }

        public async static Task<string> LerArquivo(string nomeArquivo)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Arquivos", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync(nomeArquivo);

            return await file.ReadAllTextAsync();
        }
    }
}
