namespace GildedRose;

public class Generic : Item {
        public override void UpdateItem(){
            Quality--;
            SellIn--;
            if(SellIn < 0){
                Quality--;
            }
            if(Quality < 0){
                Quality = 0;
            }
        }
}