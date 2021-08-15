public interface IItemContainer
{
    bool AddItem(Item item);
    int ItemCount(string itemID);
    Item RemoveItem(string itemID);
    bool RemoveItem(Item item);
    bool InvIsFull();
}
