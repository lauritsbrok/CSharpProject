namespace GildedRose;

public class AgedBrie : Item {
        public override void UpdateItem(){
            if (Quality < 50) {
                Quality = Quality + 1;
            }

            SellIn = SellIn - 1;
            if (SellIn < 0) {
                Quality = Quality + 1;
            }

            base.UpdateItem();
        }
}