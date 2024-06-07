using DreemDay_Core.DTOs.WishListDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface IWishListService
    {
        Task<List<WishListCardDto>> GetAllWishList();
        Task<WishListByIdDto> GetWishList(int id);
        Task<int> CreateWishList(CreateWishListDto createWishListDto);
        Task UpdateWishList(UpdateWishListDto updateWishListDto);
        Task DeleteWishList(int id);
    }
}
