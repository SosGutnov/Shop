using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class EditRightsViewModel
    {
        public int UserId { get; set; }

        public string SelectedRoleName { get; set; }

        public List<SelectListItem> RolesSelectList { get; set; }
    }
}
