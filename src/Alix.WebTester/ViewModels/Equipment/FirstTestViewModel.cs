namespace Alix.WebTester.ViewModels.Equipment
{
    using System.Collections.Generic;
    using Alix.Core.Interfaces;

    public class FirstTestViewModel
    {
        public IPlayer Player { get; set; }
        public IList<IEquipment> Equipment { get; set; }
        public int ChosenEquipmentId { get; set; }
    }
}