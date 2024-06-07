using DreemDay_Core.DTOs.WishListDTOs;
using DreemDay_Core.IRepository;
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
        private readonly IWishListRepos _repos;
        public WishListService(IWishListRepos repos)
        {
            _repos = repos;
        }

        public async Task<int> CreateWishList(CreateWishListDto createWishListDto)
        {
            return await _repos.CreateWishList(createWishListDto);
        }

        public async Task DeleteWishList(int id)
        {
            await _repos.DeleteWishList(id);
        }

        public async Task<List<WishListCardDto>> GetAllWishList()
        {
            return await _repos.GetAllWishList();
        }

        public async Task<WishListByIdDto> GetWishList(int id)
        {
            return await _repos.GetWishList(id);
        }

        public async Task UpdateWishList(UpdateWishListDto updateWishListDto)
        {
            await _repos.UpdateWishList(updateWishListDto);
        }
    }
}
