namespace Alix.WebTester.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Alix.WebTester.ViewModels.Equipment;

    public class EquipmentController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult UnEquip(int equipmentId)
        {
            var chosenEquipment = Equipment.FirstTest.Equipment.First(x => x.Id == equipmentId);
            Equipment.FirstTest.Player.UnEquip(chosenEquipment.Slot);

            return this.RedirectToAction("FirstTest");
        }

        public ActionResult Equip(int equipmentId)
        {
            var chosenEquipment = Equipment.FirstTest.Equipment.First(x => x.Id == equipmentId);
            Equipment.FirstTest.Player.Equip(chosenEquipment);

            return this.RedirectToAction("FirstTest");
        }

        public ActionResult FirstTest()
        {
            var viewModel = new FirstTestViewModel
            {
                Player = Equipment.FirstTest.Player,
                Equipment = Equipment.FirstTest.Equipment
            };

            return this.View(viewModel);
        }
    }
}