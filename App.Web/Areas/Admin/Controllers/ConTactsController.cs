using App.Data.Entities;
using App.Data.Repositories;
using App.Share.Consts;
using App.Web.Areas.Admin.ViewModels.Contact;
using App.Web.Common;
using App.Web.WebConfig;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Web.Areas.Admin.Controllers
{
	public class ConTactsController : AppControllerBase
	{
		readonly GenericRepository _repository;
		public ConTactsController(GenericRepository repository, IMapper mapper) : base(mapper)
		{
			_repository = repository;
		}
        [AppAuthorize()]
        public async Task<IActionResult> Contacts(int page = 1, int size = DEFAULT_PAGE_SIZE)
		{
			var data = (await _repository
			.GetAll<AppContact>()
			.ProjectTo<ListItemContactVM>(AutoMapperProfile.ContactConf)
			.ToPagedListAsync(page, size))
			.GenRowIndex();
			return View(data);
		}
        [AppAuthorize(AuthConst.AppContact.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _repository.FindAsync<AppContact>(id);
            if (contact == null)
            {
                SetErrorMesg("Liên hệ này không tồn tại hoặc đã được xóa trước đó");
                return RedirectToAction(nameof(Contacts));
            }
            await _repository.DeleteAsync(contact);
            SetSuccessMesg($"Liên hệ của '{contact.FullName}' được xóa thành công");
            return RedirectToAction(nameof(Contacts));
        }
    }
}
