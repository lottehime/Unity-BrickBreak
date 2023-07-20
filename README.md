<!-- HEADER -->
<p align="center">
<a href="#">
<img src="https://custom-icon-badges.demolab.com/badge/-BRICK_BREAK-6e130c?style=for-the-badge&logo=zap&logoColor=white" height="90"/>
</a>
</p>

<h3>
<p align="center">
A simple Unity implementation for breakable objects.
</p>
</h3>

---

<!-- BODY -->
## What does it do?
An object can be set to be breakable by another objects velocity, or by click.
<br>
<i>(the script can be easily modified so that the trigger click event could be replaced with any event your game requires)</i>

On trigger, it is then destroyed and a new object is spawned in it's place that is your "broken" version (usually made of your pre cut up mesh and any physics components you require).

A one shot audio file is played at time of triggering.

The spawned objects can be set to be able to break other objects in the system or not <i>(for instance; in the demo the broken brick pieces can break the glass below them via their velocity).</i>

## Usage:

```Main_Demo.unity``` demonstrates a mix of all settings for the different objects/scenarios.

```Click_Break_Demo.unity``` demonstrates only the click to break and piece expiry.

### 1. Breakable Object:
* ```Breakable.cs``` can be placed on an object that you want to be breakable. You then set it up as follows:
  * ```Velocity Breaks Object``` is enabled or disabled to your preference. ```Required Velocity``` is set to your preference (e.g. 2).
  * ```Click Breaks Object``` is enabled or disabled to your preference.
  * ```Broken Pieces Expire``` is enabled or disabled to your preference. If enabled, the broken pieces spawned in will time out and be destroyed. You can adjust the timing of this within ```Breakable.cs```.
  * ```Break Sound``` is enabled or disabled to your preference. If enabled it will play the one shot audio attached below.
  * ```Break Audio One Shot``` attach a one shot audio prefab to this for the above option.
  * ```One Shot Audio Lifetime``` can be set to specify a lifetime for the one shot audio before it is destroyed.
  * ```Broken Object Variants``` attach your broken object prefabs here.
* Add a ```Mesh Collider``` and set it up appropriately.
* Add a ```Rigidbody``` and set it's mass and drag, enable ```Use Gravity``` and ```Is Kinematic```.

The project includes example prefabs for above under the names: ```Wooden_Post_01.prefab, Glass_Pane_01.prefab, Brick_01.prefab, Brick_Can_Break_01.prefab```.

### 2: Broken Piece Objects:
* Create a prefab that is made of the cut up individual broken mesh pieces for your object and setup the physics the way you would prefer.
* If you would like the broken pieces to be able to break other unbroken objects, attach ```CanBreak.cs``` to each pieces mesh and ensure that each mesh game object has a ```Rigidbody``` and ```Mesh Collider``` setup properly.

The project includes example prefabs for above under the names: ```Wooden_Post_Broken_01.prefab, Glass_Pane_Broken_01.prefab, Brick_Broken_01.prefab, Brick_Broken_Can_Break_01.prefab```.
Prefabs with ```Can_Break``` in their names (the other brick prefabs) are setup to demonstrate how you enable the broken pieces to further interact with other breakables.

### 3: Other Objects
* To setup other objects that can break things via velocity, set them up with the appropriate physics components (```Collider```, ```Rigidbody```) and attach ```CanBreak.cs``` to them.

The project includes example prefabs for above under the names: ```Ball.prefab```.

### 4: Audio One Shots
* Create a prefab with an ```Audio Source``` and attach your one shot audio clip for the objects break sound.
* Make sure ```Play On Awake``` is enabled.
* Setup any other options as required for your project.

The project includes example prefabs for above under the names: ```OneShotBrick.prefab, OneShotGlass.prefab, OneShotWood.prefab, ```.

#### NOTE:
The models and audio files are of placeholder quality. I would not recommend using them.

## Ideas For Extending:

1. Code could be added to the broken object expiry that instead of destroying them, disables their physics components and makes them static objects, so that you can have them become parts of the level but not chew up physics headroom.
2. Procedural mesh cutting (via realtime cg / dynamic bools) could be added if your project requires this kind of simulated effect (think Metal Gear Rising: Revengeance, Crysis, Afro Samurai, etc.).
3. Fork the repo, add a feature you think is cool and make a pull request! 😉

---

<!-- BUY ME A COFFEE -->
## Help Support More Like This

<a href="https://www.buymeacoffee.com/lottehime" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>

<!-- LICENSE -->
## License

Distributed under the GNU General Public License v3. See `LICENSE.txt` for more information.
