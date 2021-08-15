# Master-s_Project

This is a Mechanical Prototype for a Crafting and Inventory System that is portable and can be used in many different projects.

In this project file, there is a sample scene which allows you to move around and experience all the different aspects of the level.
The sample scene shows the inventory, and can have items added to it by pressing the Add Item key. This can be configurable in the inspector but currently set to "E".
Accessing the inventory is simple by just pressing the correct key, which is currently set to "TAB" but again can be configurable to the key of your choosing.
When accessing the different crafting stations, the window is shown when pressing the "F" key for the forge and the "C" key for the table.
To craft the items at the stations, you need to have the correct materials that are shown in the specific recipe and also have enough room in the inventory.
Pressing the craft button without both requirements being met, will resort in an error message explaining which requirement is absent.
After crafing the materials, they can be equipped to the player by Right-Clicking on the item and then unequipping the item in the same manner.

When using this project scripts for your own games, the sample scene can be used to demonstrate how each script is linked to each of the different objects.
This allows for the project to run seemlessly and will fit perfectly in your own project.
To create your own items and crafting recipes, they are created in teh assets by right-clicking and going to create, and they are at the top of the list.
The Item is an item that can be used in crafting, but cannot be equipped.
The Equippable Item is an item that requires a gear slot to create the item, which corresponds to the different slots in the gear section.
The Crafting Recipe takes in any multiple of items that arer used to create the resulting item.

Controls:
Moving in Sample Scene: W, A, S, D
Looking Around: Mouse
Add Items for Chests: E
Open Inventory: TAB
Open Forge Crafting (When In Range): F
Open Table Crafting (When In Range): C
Equip Item: Right-Click in Inventory
Unequip Item: Right-Click in Gear