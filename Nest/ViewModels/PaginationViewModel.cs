﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class PaginationViewModel {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get { return (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage); } }
    }
}
