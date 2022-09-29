# Development process

## 22_09_12 : First steps dev meeting
* Movement 
    * Movement on the map
    * Map
* UI
* Damage basics

## Movement
### Moba-like movement.
* Two typpes of movement: 
    * Hack & Slash based movement : on Right mouse button down character moves towards the mouse coords.
    * RTS based movement : on Right mouse click character moves to the coords of the last mouse click.

### Character facing.
* For now only 4 directional sprites, round to the nearest 90° .
    * Character prioritizes Mouse position *WHILE CASTING*, in every other instance he/she faces last direction.
### Camera Follow. 
* Complete Camera follow (for now), player is always in the middle of the screen.
* (Later on We can implement unlocked camera)
* No zoom allowed, complete camera follow
* Fog of war: only for zones you dont have vision on. (Raycasting tiles to check vision?) (not prio)

### Map
* Tile based (with tilemap)
* Code-first approach
* Map is procedurally generated from room-sized tiles (See : Carcassone boardgame, jigsaw puzzle)
* Every "Room" has multiple "connectors", to which other "Rooms" can connect.
* "Rooms" are stored in a .json format.
* Room creator application (WPF).

### Movement on the map
* Player moves on coordinates 
* Player cant move on disabled grid tiles (I.E walls, boxes, columns etc.)
* Characters can move through eachothers' space (NPC's will try to avoid doing so, if given the option - NO PRIO )
* NPC's move on grid (huge help for A*)
* Tiles are more- or less the same size as the characters (Question for Large Creatures (2x2 in size) for later.)

## UI
* No minimap (Normal Map with visible road options as an item later on ? - NO PRIO)
* A slot bar for the gained items, new items can be drag and dropped
* Healthbar on character and on screen
* Spell slot Bar, with CD's 
* Secondary resource bar (Mana, runic power, combo power, rage, etc.) on screen and character
* Bars on character are toggleable (Every UI element should be toggleable - Same Parent class ?)
* Damage numbers (hitting npc's and getting hit)
* Cast bar 
* Dropped Abilities (from treasure, boss drop, etc) can be drag and dropped to spell slot 
* All items, abilities have a tooltip on hover
* Consumable slots bar ? 

## Damage basics
* Items and Abilities have the same parent class
* Items have passive (on trigger), abilities have active effects.
* Action - Item and Ability parent class
* Actions get the Characters affected by their effect as an Array (List), and they modify their attributes - there should be no code on the character side.
* Actions should have events like:
    * Ontrigger
    * OnCollision
    * OnActionEnd
    * etc.
  

