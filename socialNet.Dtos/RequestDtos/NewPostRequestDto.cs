using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace socialNet.Dtos.RequestDtos
{
    public class NewPostRequestDto
    {
        public string PostContent { get; set; }
        public string PostImage { get; set; }
    }
}
