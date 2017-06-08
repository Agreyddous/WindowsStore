using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;
using WindowsStore.Entities;
using WindowsStore.Exceptions;

namespace WindowsStore.Handlers
{
    public static class FilesHandler
    {
        public static async Task<bool> StoreUser(User user)
        {
            bool success = true;

            try
            {
                string json = JsonConvert.SerializeObject(user);

                StorageFolder userFolder = ApplicationData.Current.LocalFolder;
                StorageFile userFile = await userFolder.CreateFileAsync(user.Username + ".user", CreationCollisionOption.ReplaceExisting);

                await FileIO.WriteTextAsync(userFile, json);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public static async Task<bool> StoreProduct(Product product)
        {
            bool success = true;

            try
            {
                string json = JsonConvert.SerializeObject(product);

                StorageFolder userFolder = ApplicationData.Current.LocalFolder;
                StorageFile userFile = await userFolder.CreateFileAsync(product.Name + ".prod", CreationCollisionOption.ReplaceExisting);

                await FileIO.WriteTextAsync(userFile, json);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public static async Task<bool> StoreList(ObservableCollection<Product> list)
        {
            bool success = true;

            try
            {
                string json = JsonConvert.SerializeObject(list);

                StorageFolder userFolder = ApplicationData.Current.LocalFolder;
                StorageFile userFile = await userFolder.CreateFileAsync("list.li", CreationCollisionOption.ReplaceExisting);

                await FileIO.WriteTextAsync(userFile, json);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public static async Task<bool> CheckIfExistsFile(string fileName)
        {
            bool exists = true;
            try
            {
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.GetFileAsync(fileName);
                if (file == null)
                    throw new FileMissingCustomException(fileName);
            }
            catch (Exception)
            {
                exists = false;
            }

            return exists;
        }

        public static async Task<User> RetrieveUserContent(string fileName)
        {
            User user = null;

            try
            {
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.GetFileAsync(fileName);
                user = JsonConvert.DeserializeObject<User>(File.ReadAllText(file.Path));
            }
            catch (Exception)
            {
                user = null;
            }

            return user;
        }

        public static async Task<Product> RetrieveProductContent(string fileName)
        {
            Product product = null;

            try
            {
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.GetFileAsync(fileName);
                product = JsonConvert.DeserializeObject<Product>(File.ReadAllText(file.Path));
            }
            catch (Exception)
            {
                product = null;
            }

            return product;
        }

        public static async Task<ObservableCollection<Product>> RetrieveListContent(string fileName)
        {
            ObservableCollection<Product> list = null;

            try
            {
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.GetFileAsync(fileName);
                list = JsonConvert.DeserializeObject<ObservableCollection<Product>>(File.ReadAllText(file.Path));
            }
            catch (Exception)
            {
                list = null;
            }

            return list;
        }
    }
}