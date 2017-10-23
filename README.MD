## Game Jam

One afternoon, in a sweet fall day, I decided my friends & I would do a game jam. It's been too long. I fed them pizzas.

## Requirements

* generate up to four concurrent maze paths overlapping, removing all walls that interfere with any path.
* four player, controller-based gameplay, web-based, racing through levels from a segregated-yet-nearby start areas, to a single finishing area that holds all players.
* Accelerated gameplay that completes levels in approximately 10 seconds of gameplay, where you rapidly bash into walls, with a resounding thud & squishing animation.
* ability to bash players, but costs you let's say 1 second, and holds them for 2 seconds? to experiment to see what's fun. perhaps grant immunity after? 
* ability to grab & pull items, though uncertain what benefits this confers. perhaps a sword, a shield. but i want there to be a slow-down pentalty for having this powerup tethered following behind you.
* cutesy animations & sound effects. Going for a vibe here that's engaging. To experiment.


## Implementation details (Design really)

* Greeting screen to select players who will play & detect gamepads, showing in UI.
    * One single empty game object named Managers has one single class at compile-time: *"GameManager"*.
    * The hierarchy goes like this:  **GameManager --> BoardManager --> MazeManager, UIManager**
        * **singleton GameManager** creates a *BoardManager* instance 
            * **BoardManager** governs both *UI managment (UIManager)* and *maze managment (MazeManager)*
                * **UIManager** responsibile for displaying panes, such as for textual updates, and one core responsibility it has is to recieve messages to showing in a particular message popup. If UI anchors are insufficient, then code would govern UI element positions & scale, so this class would also detect resolution width & height and adjust them.
                * **MazeManager** controls generation of layers of mazes, breaks down walls of overlapping paths. Also, controls which sprites are used for which maze elements, e.g. wall, etc.  At most, a completed maze gets passed back to the *"parent" BoardManager*
                * **GamepadManager** handles detection of gamepads (in a method), and pushes these updates to the *UIManager* (somehow via messaging...)
                * **EventManager** handles passing messages around.
    * _UI elements_ are in a canvas and consist of panels & buttons. At jam-creation time they are only absolutely positioned to get the ball rolling fast. 
        * **UIExposure** provides a one-to-one mapping of methods to each _the screen's buttons_ (iterate design, later have multiple screens with different buttons, so maybe I'll do inner classes or an abstract interface that gets implemented by several child classes, or something else).
* As a *design philosophy*, the bare minimum amount of controls will be added via drag-and-drop, pushing the majority of control of components & game objects into code instead. Exception will be UI elements, as they are unfamiliar since Unity 4.6 and this is just at a jam-pace.
    * As another design philosophy, _tags_ will be uesd together with the call _GameObject.FindObjectWithTag("tag")_ to bridge the gap between code-instantitaion dependencies & Editor-created dependencies, such as for the _Canvas_ game object, as it is more efficient than brute-force searching all of Unity complete Game Object set with _Find_, and it preserves the ability to _create some things_ in-Editor, like the nested Canvas element structure... I doubt that's "worth" the effort of creating via code.
* As a *styling guide*, any variable of the type GameObject but semantically is named another keyword, will be named with _Go_ appended to the end, like so: _anotherKeywordGo_. E.g. canvasGo.


#### Legend
* **Bold** is class name, used at beginning of bullets, and is followed in plaintext by a description of that class's responsibility. Ideally I'm striving for all definitions to completely true always.
* *Emphasis* is often a class name or some key words in the design, and often appears later in the bullet as the subject of that sentence.


## Attributions (Asset Pool Collected)

#### Art

* Candies artwork from author Lumi Mae, found on OpenGameArt.org here: https://opengameart.org/content/candy-pack-1 and author's website here: https://lumimae.carbonmade.com/
* Platform artwork from author Kenney, found on OpenGameArt.org here: https://opengameart.org/content/platformer-tiles and author's website here: http://www.kenney.nl/

#### UI

* Modern UI Pack v1.0 by Michsky, channel: https://www.youtube.com/c/michsky, pack video: https://www.youtube.com/watch?v=tI-jYv1X-Ro, google drive link: https://drive.google.com/drive/folders/0B5VB8XBg88YDdlZ5Yjc4UXFUUVU

#### Music

* "Patakas World" https://www.dl-sounds.com/royalty-free/patakas-world/
* "Retro1" https://www.dl-sounds.com/royalty-free/retro1-140/
* By "CheDDer Nardz (Jon Byrum)" ReMix: Tetris "CheDDer"  https://ocremix.org/remix/OCR00094
* By "Sine (Will Pett)" ReMix: Super Mario RPG: Legend of the Seven Stars "Seeking Heat"  https://ocremix.org/remix/OCR01027

#### Sound effects

* "Feed 2" http://www.noiseforfun.com/2012-sound-effects/feed-2/
* "Twitch" http://www.noiseforfun.com/2014-sound-effects/twitch/ 
* "Mutate 2" http://www.noiseforfun.com/2012-sound-effects/mutate-02/
* "Whizz"  http://www.noiseforfun.com/2014-sound-effects/whizz/
* "Splurge" http://www.noiseforfun.com/2012-sound-effects/splurge/
* "Rasp" http://www.noiseforfun.com/2014-sound-effects/rasp/ 
* "Slowdown" http://www.noiseforfun.com/2012-sound-effects/slowdown/
* "Moving Block" http://www.noiseforfun.com/2013-sound-effects/moving-block/
* "Spit" http://www.noiseforfun.com/2012-sound-effects/spit/ 


## References

* Unity UI - https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-canvas?playlist=17111
* Unity messaging - https://www.youtube.com/watch?v=0AqG1fDhPT8 