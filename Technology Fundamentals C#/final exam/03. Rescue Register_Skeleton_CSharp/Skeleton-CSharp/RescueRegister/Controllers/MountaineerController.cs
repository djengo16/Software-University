using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            // TODO: Implement me
            return null;
        }

        [HttpGet]
        public IActionResult Create()
        {
            // TODO: Implement me
            return null;
        }

        [HttpPost]
        public IActionResult Create(Mountaineer mountaineer)
        {
            // TODO: Implement me
            return null;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // TODO: Implement me
            return null;
        }

        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            // TODO: Implement me
            return null;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // TODO: Implement me
            return null;
        }

        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            // TODO: Implement me
            return null;
        }
    }
}