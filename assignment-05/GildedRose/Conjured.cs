namespace GildedRose;

public class Conjured : Item {
        public override void UpdateItem(){
            Quality = Quality - 2;
            SellIn--;
            if(SellIn < 0){
                Quality = Quality - 2;
            }
            if(Quality < 0){
                Quality = 0;
            }
            base.UpdateItem();
        }
}