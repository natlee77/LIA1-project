using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorApp.Services
{
    public class ParkingService : IParkingService
    {
        private readonly HttpClient http;
        private readonly ILocalStorageService _localStorage;
        public event Action OnChange;
       
        public ParkingService(HttpClient http, ILocalStorageService localStorage)
        {
            this.http = http;
            this._localStorage = localStorage;
        }

        public async Task AddToCartAdress(AdressCartModel adressCart)
        {
           
            var parkingCart = await _localStorage.GetItemAsync<List<AdressCartModel>>("ParkingCart");
            if (parkingCart == null)
            {
                parkingCart = new List<AdressCartModel>();
            }
            var sameItem = parkingCart.Find(c => c.ParkingCategoryId == adressCart.ParkingCategoryId);
            if (sameItem == null)
                parkingCart.Add(adressCart);            
            else
            {
                //sameItem.QuantityByUser += shoppingCart.QuantityByUser;
                sameItem.QuantityByUser =  1;
            }
            await _localStorage.SetItemAsync("ParkingCart", parkingCart);
            OnChange.Invoke();          
        }
        public async Task DeleteItem(AdressCartModel item)
        {
            var parkingCart = await _localStorage.GetItemAsync<List<AdressCartModel>>("ParkingCart");
            if (parkingCart == null)
            {
                return;
            }

            var cartItem = parkingCart.Find(x => x.ParkingCategoryId == item.ParkingCategoryId);
            parkingCart.Remove(cartItem);

            await _localStorage.SetItemAsync("ParkingCart", parkingCart);
            OnChange.Invoke();
        }
        public void UpdateComponents()
        {
            OnChange.Invoke();
        }


        //-------------parkingLot
        public async Task<AdressModel> GetAdressByIdAsync(int id)
        {
           return await http.GetFromJsonAsync<AdressModel>($"https://localhost:44343/api/ParkingLots/{id}");
        }
        


        //-------------ParkingCategory
        public async Task<ParkingCategoryModel> GetParkingByIdAsync(int id)
        {
            return await http.GetFromJsonAsync<ParkingCategoryModel>($"https://localhost:44343/api/ParkingCategories/{id}");
        }
        
        public async Task<IEnumerable<ParkingCategoryModel>> GetParkingPlatsByTypeAsync(string parking)
        {
            return await http.GetFromJsonAsync<List<ParkingCategoryModel>>($"https://localhost:44343/api/ParkingCategories/GetByString?parkingType={parking}");
        }
        public async Task<IEnumerable<ParkingCategoryModel>> GetParkingPlatsByCityAsync(string city)
        {
            return await http.GetFromJsonAsync<List<ParkingCategoryModel>>($"https://localhost:44343/api/ParkingCategories/GetByCity?cityType={city}");
        }
        //---------------ContractParking
        public async Task<ContractParkingResponseModel> PlaceContract( AdressCartModel  parking )
        {
            var Content = JsonConvert.SerializeObject(parking );
            var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await http.PostAsync("https://localhost:44343/api/Database/CreateContractParking", byteContent);

            if (response.IsSuccessStatusCode)
                return new ContractParkingResponseModel() { Message = "Your Contract placement was successful!", Succeeded = true };
            else
                return new ContractParkingResponseModel() { Message = "Your Contract placement failed!", Succeeded = false };

        }

        
    }
}








//https://localhost:44343/api/ParkingCategories/GetByString?parkingType=parkering
//private async Task<ParkingCategoryModel> GetParkingPlatsByTypeAsync(string parking)//hämta adress from DB ParkingLot by ParkingType
//{


//    //parkingplats = await Http.GetFromJsonAsync<ParkingCategoryModel>($"api/ParkingCategories/GetByString?parkingType={parking}");

//}