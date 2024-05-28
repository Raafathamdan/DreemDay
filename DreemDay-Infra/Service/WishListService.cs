using DreemDay_Core.DTOs.WishListDTOs;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class WishListService : IWishListService
    {
        public Task CreateWishList(CreateWishListDto createWishListDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWishList(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WishListCardDto>> GetAllWishList()
        {
            throw new NotImplementedException();
        }

        public Task<WishListByIdDto> GetWishList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWishList(UpdateWishListDto updateWishListDto)
        {
            throw new NotImplementedException();
        }
    }
}
