using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.BL.DTO;

namespace Task5.Models
{
    public class InfoView
    {
        public IEnumerable<OrderDTO> Orders { get; set; }

        [Display(Name = "менеджер")]
        public SelectList Managers { get; set; }

        [Display(Name = "товар")]
        public SelectList Products { get; set; }

        [Display(Name = "клиент")]
        public SelectList Clients { get; set; }

        [Display(Name = "дата заказа")]
        public SelectList Dates { get; set; }
    }
}