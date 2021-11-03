using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorApp.Pages;
using SharedLibrary.Models;

namespace BlazorApp.Services
{
    interface IParkingService
    {
        event Action OnChange;

        Task AddToCartAdress(AdressCartModel adressCartModel);
        Task DeleteItem(AdressCartModel item);
        void UpdateComponents();
        Task<AdressModel> GetAdressByIdAsync(int id);
  
       
        Task<IEnumerable<ParkingCategoryModel>> GetParkingPlatsByTypeAsync(string parking);
        Task<IEnumerable<ParkingCategoryModel>> GetParkingPlatsByCityAsync(string city);
        Task<ParkingCategoryModel> GetParkingByIdAsync(int id);
        Task<ContractParkingResponseModel> PlaceContract(  AdressCartModel parking );
        
    }
}
