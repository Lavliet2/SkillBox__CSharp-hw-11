// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework_10
{
    public class Repository : INotifyPropertyChanged
    {
        private List<ClientData> clients;

        public List<ClientData> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Repository()
        {
            clients = GetAllClients<List<ClientData>>();
        }

        /// <summary>
        /// Парсинг файла (база данных)
        /// </summary>
        /// <returns>Массив сотрудников</returns>
        public T GetAllClients<T>()
        {
            return JsonManager.LoadFromJson<T>();
        }

        /// <summary>
        /// Обновление списка клиентов из файла
        /// </summary>
        public void Update()
        {
            clients = JsonManager.LoadFromJson<List<ClientData>>();
        }

        public void AddClient(ClientData data) 
        {
            Clients.Add(data);
            SaveJson();
            OnPropertyChanged(nameof(Clients));
        }

        /// <summary>
        /// Удаление клиента из списка по индексу
        /// </summary>
        /// <param name="index">Индекс клиента для удаления</param>
        public void RemoveClientAt(int index)
        {
            if (index >= 0 && index < clients.Count)
            {
                clients.RemoveAt(index);
                SaveJson();
            }
            else
            {
                Console.WriteLine("Index is out of range.");
            }
        }
        public void RemoveClientItems(List<ClientData> items)
        {
            foreach (ClientData item in items)
            {
                if (item == null) continue;
                clients.Remove(item);
            }
            SaveJson();
        }

        public void SaveJson()
        {
            JsonManager.SaveToJson(clients);
            Update();
            OnPropertyChanged(nameof(Clients));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
