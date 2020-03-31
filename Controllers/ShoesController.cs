using System;
using Microsoft.AspNetCore.Mvc;


namespace shoestoore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoesController : ControllerBase
    {
        private readonly ShoesService _ss
        public ShoesController(ShoesService ss)
        {
            _ss = ss;
        }
    }
}
