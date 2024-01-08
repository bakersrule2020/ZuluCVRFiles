﻿using BTKUILib;
using BTKUILib.UIObjects;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using ZuluClientCVR;
using ABI_RC;
using ABI_RC.Core.Player;
using ABI.Core;
using DarkRift;
using Shapes;
//using System.re
using CurvedUI;
using System.Diagnostics;
using ABI_RC.Systems.MovementSystem;
using ABI_RC.Core.IO;
using ABI_RC.Core.Networking.IO.UserGeneratedContent;
using ABI.CCK.Components;
using UnityEngine.Networking;
using ABI_RC.Core.InteractionSystem;
using ABI_RC.Core.Savior;
using ABI_RC.Core.Networking.IO.Instancing;
using ABI_RC.Core.Networking.IO.GameKit;
using ABI_RC.Core.Networking;
using ABI_RC.Core.Networking.IO.Global;
using ABI_RC.Systems.Camera.VisualMods;
using Michsky.UI.ModernUIPack;
using System.Net;
using RTG;
using UnityEngine.SceneManagement;
using System.Text;
using ABI_RC.Core.Player;
using SimpleJSON;
using ABI_RC.Core.Networking.IO.Self;
using ABI_RC.Core.UI;
using static ABI_RC.Systems.GameEventSystem.CVRGameEventSystem;
using ABI_RC.Core.EventSystem;
using Object = UnityEngine.Object;
using System.Collections;
using ABI_RC.Core.Networking.Guardian;
using Unity.Services.Vivox;
using VivoxUnity;
using TTSMessage = Unity.Services.Vivox.TTSMessage;
using static RootMotion.FinalIK.InteractionObject;
using Message = DarkRift.Message;
using ABI_RC.Systems.RuntimeDebug;
using UnityEngine.UI;
//using System.Windows.Controls;
using Canvas = UnityEngine.Canvas;
using System.IO;
using TMPro;
using Unity.Properties.UI;
using Unity.Collections;
using HighlightPlus;
using UnityEngine.ProBuilder.Shapes;
using Image = UnityEngine.UI.Image;
using ThreadState = System.Threading.ThreadState;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.InputSystem;
//using System.Windows.Controls;

namespace CVRClient
{
   
    public class CVRClient : MelonMod
    {
        Thread animthread;
        public static Page subPage;
        public static Category muscat;
        public static bool drawclickgui;
        public static bool drawconsolegui;
        public static string plrsel = String.Empty;
        private static AudioSource QMMusicSource;
        public static List<CVRPlayerEntity> plrs = new List<CVRPlayerEntity>();


        public List<string[]> plList = new List<string[]>();
        public static GameObject QM;
        
        public static Page consolepg;
        private static bool Fly;
        private static bool ESP;
        private static bool CustomUIInit;
        private static bool IsQMMusicInit;
        private static string beescript = @"According to all known laws of aviation there is no way that a bee should be able to fly Its wings are too small to get its fat little body off the ground The bee of course flies anyway Because bees dont care what humans think is impossible SEQ 75  INTRO TO BARRY INT BENSON HOUSE  DAY ANGLE ON Sneakers on the ground Camera PANS UP to reveal BARRY BENSONS BEDROOM ANGLE ON Barrys hand flipping through different sweaters in his closet BARRY Yellow black yellow black yellow black yellow black yellow black yellow blackoohh black and yellow ANGLE ON Barry wearing the sweater he picked looking in the mirror BARRY CONTD Yeah lets shake it up a little He picks the black and yellow one He then goes to the sink takes the top off a CONTAINER OF HONEY and puts some honey into his hair He squirts some in his mouth and gargles Then he takes the lid off the bottle and rolls some on like deodorant CUT TO INT BENSON HOUSE KITCHEN  CONTINUOUS Barrys mother JANET BENSON yells up at Barry JANET BENSON Barry breakfast is ready CUT TO Bee Movie  JS REVISIONS 81307 1 INT BARRYS ROOM  CONTINUOUS BARRY Coming SFX Phone RINGING Barrys antennae vibrate as they RING like a phone Barrys hands are wet He looks around for a towel BARRY CONTD Hang on a second He wipes his hands on his sweater and pulls his antennae down to his ear and mouth BARRY CONTD Hello His best friend ADAM FLAYMAN is on the other end ADAM Barry BARRY Adam ADAM Can you believe this is happening BARRY Cant believe it Ill pick you up Barry sticks his stinger in a sharpener SFX BUZZING AS HIS STINGER IS SHARPENED He tests the sharpness with his finger SFX Bing BARRY CONTD Looking sharp ANGLE ON Barry hovering down the hall sliding down the staircase bannister Barrys mother JANET BENSON is in the kitchen JANET BENSON Barry why dont you use the stairs Your father paid good money for those Bee Movie  JS REVISIONS 81307 2 BARRY Sorry Im excited Barrys father MARTIN BENSON ENTERS Hes reading a NEWSPAPER with the HEADLINE Queen gives birth to thousandtuplets Resting Comfortably MARTIN BENSON Heres the graduate Were very proud of you Son And a perfect report card all Bs JANET BENSON mushing Barrys hair Very proud BARRY Ma Ive got a thing going here Barry readjusts his hair starts to leave JANET BENSON Youve got some lint on your fuzz She picks it off BARRY Ow thats me MARTIN BENSON Wave to us Well be in row 118000 Barry zips off BARRY Bye JANET BENSON Barry I told you stop flying in the house CUT TO SEQ 750  DRIVING TO GRADUATION EXT BEE SUBURB  MORNING A GARAGE DOOR OPENS Barry drives out in his CAR Bee Movie  JS REVISIONS 81307 3 ANGLE ON Barrys friend ADAM FLAYMAN standing by the curb Hes reading a NEWSPAPER with the HEADLINE Frisbee Hits Hive Internet Down Beestander I heard a sound and next thing I knewwhamo Barry drives up stops in front of Adam Adam jumps in BARRY Hey Adam ADAM Hey Barry pointing at Barrys hair Is that fuzz gel BARRY A little Its a special day Finally graduating ADAM I never thought Id make it BARRY Yeah three days of grade school three days of high school ADAM Those were so awkward BARRY Three days of college Im glad I took off one day in the middle and just hitchhiked around the hive ADAM You did come back different They drive by a bee whos jogging ARTIE Hi Barry BARRY to a bee pedestrian Hey Artie growing a mustache Looks good Barry and Adam drive from the suburbs into the city ADAM Hey did you hear about Frankie Bee Movie  JS REVISIONS 81307 4 BARRY Yeah ADAM You going to his funeral BARRY No Im not going to his funeral Everybody knows you sting someone you die you dont waste it on a squirrel He was such a hot head ADAM Yeah I guess he couldve just gotten out of the way The DRIVE through a loop de loop BARRY AND ADAM WhoaWhooowheee ADAM I love this incorporating the amusement park right into our regular day BARRY I guess thats why they say we dont need vacations CUT TO SEQ 95  GRADUATION EXT GRADUATION CEREMONY  CONTINUOUS Barry and Adam come to a stop They exit the car and fly over the crowd to their seats  BARRY  re graduation ceremony  Boy quite a bit of pompunder  the circumstances  They land in their seats BARRY CONTD Well Adam today we are men Bee Movie  JS REVISIONS 81307 5 ADAM We are BARRY Beemen ADAM Amen BARRY Hallelujah Barry hits Adams forehead Adam goes into the rapture An announcement comes over the PA ANNOUNCER VO Students faculty distinguished beesplease welcome Dean Buzzwell ANGLE ON DEAN BUZZWELL steps up to the podium The podium has a sign that reads Welcome Graduating Class of with trainstation style flipping numbers after it BUZZWELL Welcome New Hive City graduating class of The numbers on the podium change to 915 BUZZWELL CONTD 915 he clears his throat And that concludes our graduation ceremonies And begins your career at Honex Industries BARRY Are we going to pick our job today ADAM I heard its just orientation The rows of chairs change in transformerlike mechanical motion to Universal Studios type tour trams Buzzwell walks off stage BARRY re trams Whoa heads up Here we go Bee Movie  JS REVISIONS 81307 6 SEQ 125  FACTORY FEMALE VOICE VO Keep your hands and antennas inside the tram at all times in Spanish Dejen las manos y antennas adentro del tram a todos tiempos BARRY I wonder what its going to be like ADAM A little scary Barry shakes Adam BARRY AND ADAM AAHHHH The tram passes under SIGNS READING Honex A Division of Honesco A Part of the Hexagon Group TRUDY Welcome to Honex a division of Honesco and a part of the Hexagon group BARRY This is it The Honex doors OPEN revealing the factory BARRY CONTD Wow TRUDY We know that you as a bee have worked your whole life to get to the point where you can work for your whole life Honey begins when our valiant pollen jocks bring the nectar to the hive where our top secret formula is automatically colorcorrected scent adjusted and bubble contoured into this Trudy GRABS a TEST TUBE OF HONEY from a technician Bee Movie  JS REVISIONS 81307 7 TRUDY CONTD soothing sweet syrup with its distinctive golden glow you all know as EVERYONE ON THE TRAM in unison Honey Trudy flips the flask into the crowd and laughs as they all scramble for it ANGLE ON A GIRL BEE catching the honey ADAM sotto That girl was hot BARRY sotto Shes my cousin ADAM She is BARRY Yes were all cousins ADAM Right Youre right TRUDY At Honex we also constantly strive to improve every aspect of bee existence These bees are stress testing a new helmet technology ANGLE ON A STUNT BEE in a HELMET getting hit with a NEWSPAPER then a SHOE then a FLYSWATTER He gets up and gives a thumbs up The graduate bees APPLAUD ADAM re stunt bee What do you think he makes BARRY Not enough TRUDY And here we have our latest advancement the Krelman Bee Movie  JS REVISIONS 81307 8 BARRY Wow what does that do TRUDY Catches that little strand of honey that hangs after you pour it Saves us millions ANGLE ON The Krelman machine Bees with handshaped hats on rotating around a wheel to catch drips of honey Adams hand shoots up ADAM Can anyone work on the Krelman TRUDY Of course Most bee jobs are small ones But bees know that every small job if its done well means a lot There are over 3000 different bee occupations But choose carefully because youll stay in the job that you pick for the rest of your life The bees CHEER ANGLE ON Barrys smile dropping slightly BARRY The same job for the rest of your life I didnt know that ADAM Whats the difference TRUDY And youll be happy to know that bees as a species havent had one day off in 27 million years BARRY So youll just work us to death TRUDY laughing Well sure try Everyone LAUGHS except Barry Bee Movie  JS REVISIONS 81307 9 The tram drops down a logflume type steep drop Cameras flash as all the bees throw up their hands The frame freezes into a snapshot Barry looks concerned The tram continues through 2 doors FORM DISSOLVE TO SEQ 175  WALKING THE HIVE INT HONEX LOBBY ANGLE ON The logflume photo as Barry looks at it ADAM Wow That blew my mind BARRY annoyed Whats the difference Adam how could you say that One job forever Thats an insane choice to have to make ADAM Well Im relieved Now we only have to make one decision in life BARRY But Adam how could they never have told us that ADAM Barry why would you question anything Were bees Were the most perfectly functioning society on Earth They walk by a newspaper stand with A SANDWICH BOARD READING Bee Goes Berserk Stings Seven Then Self ANGLE ON A BEE filling his cars gas tank from a honey pump He fills his car some then takes a swig for himself NEWSPAPER BEE to the bee guzzling gas Hey Barry and Adam begin to cross the street Bee Movie  JS REVISIONS 81307 10 BARRY Yeah but Adam did you ever think that maybe things work a little too well around here They stop in the middle of the street The traffic moves perfectly around them ADAM Like what Give me one example BARRY thinks I dont know But you know what Im talking about They walk off SEQ 400  MEET THE JOCKS SFX The SOUND of Pollen Jocks PAN DOWN from the Honex statue JGATE ANNOUNCER Please clear the gate Royal Nectar Force on approach Royal Nectar Force on approach BARRY Wait a second Check it out Hey hey those are Pollen jocks ADAM Wow FOUR PATROL BEES FLY in through the hives giant Gothic entrance The Patrol Bees are wearing fighter pilot helmets with black visors ADAM CONTD Ive never seen them this close BARRY They know what its like to go outside the hive ADAM Yeah but some of them dont come back Bee Movie  JS REVISIONS 81307 11 The nectar from the pollen jocks is removed from their backpacks and loaded into trucks on their way to Honex A SMALL CROWD forms around the Patrol Bees Each one has a PIT CREW that takes their nectar Lou Loduca hurries a pit crew along LOU LODUCA You guys did great Youre monsters Youre sky freaks I love it I love it SCHOOL GIRLS are jumping up and down and squealing nearby BARRY I wonder where those guys have just been ADAM I dont know BARRY Their days not planned Outside the hive flying whoknowswhere doing whoknowswhat ADAM You cant just decide one day to be a Pollen Jock You have to be bred for that BARRY Right Pollen Jocks cross in close proximity to Barry and Adam Some pollen falls off onto Barry and Adam BARRY CONTD Look at that Thats more pollen than you and I will ever see in a lifetime ADAM playing with the pollen Its just a status symbol I think bees make too big a deal out of it BARRY Perhaps unless youre wearing it and the ladies see you wearing it ANGLE ON Two girl bees Bee Movie  JS REVISIONS 81307 12 ADAM Those ladies Arent they our cousins too BARRY Distant distant ANGLE ON TWO POLLEN JOCKS JACKSON Look at these two SPLITZ Couple of Hive Harrys JACKSON Lets have some fun with them The pollen jocks approach Barry and Adam continue to talk to the girls GIRL 1 It must be so dangerous being a pollen jock BARRY Oh yeah one time a bear had me pinned up against a mushroom He had one paw on my throat and with the other he was slapping me back and forth across the face GIRL 1 Oh my BARRY I never thought Id knock him out GIRL 2 to Adam And what were you doing during all of this ADAM Obviously I was trying to alert the authorities The girl swipes some pollen off of Adam with a finger BARRY re pollen I can autograph that if you want Bee Movie  JS REVISIONS 81307 13 JACKSON Little gusty out there today wasnt it comrades BARRY Yeah Gusty BUZZ You know were going to hit a sunflower patch about six miles from here tomorrow BARRY Six miles huh ADAM whispering Barry BUZZ Its a puddlejump for us But maybe youre not up for it BARRY Maybe I am ADAM whispering louder You are not BUZZ Were going ohnine hundred at JGate ADAM re jgate Whoa BUZZ leaning in on top of Barry What do you think Buzzy Boy Are you bee enough BARRY I might be It all depends on what ohnine hundred means CUT TO SEQ 450  THE BALCONY Bee Movie  JS REVISIONS 81307 14 INT BENSON HOUSE BALCONY  LATER Barry is standing on the balcony alone looking out over the city Martin Benson ENTERS sneaks up behind Barry and gooses him in his ribs MARTIN BENSON Honex BARRY Oh Dad You surprised me MARTIN BENSON laughing Have you decided what youre interested in Son BARRY Well theres a lot of choices MARTIN BENSON But you only get one Martin LAUGHS BARRY Dad do you ever get bored doing the same job every day MARTIN BENSON Son let me tell you something about stirring making the stirring motion You grab that stick and you just move it around and you stir it around You get yourself into a rhythm its a beautiful thing BARRY You know dad the more I think about it maybe the honey field just isnt right for me MARTIN BENSON And you were thinking of what making balloon animals Thats a bad job for a guy with a stinger Bee Movie  JS REVISIONS 81307 15 BARRY Well no MARTIN BENSON Janet your sons not sure he wants to go into honey JANET BENSON Oh Barry you are so funny sometimes BARRY Im not trying to be funny MARTIN BENSON Youre not funny youre going into honey Our son the stirrer JANET BENSON Youre going to be a stirrer BARRY No ones listening to me MARTIN BENSON Wait until you see the sticks I have for you BARRY I can say anything I want right now Im going to get an ant tattoo JANET BENSON Lets open some fresh honey and celebrate BARRY Maybe Ill pierce my thorax MARTIN BENSON toasting To honey BARRY Shave my antennae JANET BENSON To honey Bee Movie  JS REVISIONS 81307 16 BARRY Shack up with a grasshopper get a gold tooth and start calling everybody Dawg CUT TO SEQ 760  JOB PLACEMENT EXT HONEX LOBBY  CONTINUOUS ANGLE ON A BEE BUS STOP One group of bees stands on the pavement as another group hovers above them A doubledecker bus pulls up The hovering bees get on the top level and the standing bees get on the bottom Barry and Adam pull up outside of Honex ADAM I cant believe were starting work today BARRY Todays the day Adam jumps out of the car ADAM OC Come on All the good jobs will be gone BARRY Yeah right ANGLE ON A BOARD READING JOB PLACEMENT BOARD Buzzwell the Bee Processor is at the counter Another BEE APPLICANT SANDY SHRIMPKIN is EXITING SANDY SHRIMPKIN Is it still available BUZZWELL Hang on he looks at changing numbers on the board Two left Andone of thems yours Congratulations Son step to the side please Bee Movie  JS REVISIONS 81307 17 SANDY SHRIMPKIN Yeah ADAM to Sandy leaving What did you get SANDY SHRIMPKIN Picking the crud out That is stellar ADAM Wow BUZZWELL to Adam and Barry Couple of newbies ADAM Yes Sir Our first day We are ready BUZZWELL Well step up and make your choice ANGLE ON A CHART listing the different sectors of Honex Heating Cooling Viscosity Krelman Pollen Counting Stunt Bee Pouring Stirrer Humming Regurgitating Front Desk Hair Removal Inspector No 7 Chef Lint Coordinator Stripe Supervisor Antennaeball polisher Mite Wrangler Swatting Counselor Wax Monkey Wing Brusher Hive Keeper Restroom Attendant ADAM to Barry You want to go first BARRY No you go ADAM Oh my Whats available BUZZWELL Restroom attendant is always open and not for the reason you think ADAM Any chance of getting on to the Krelman Sir BUZZWELL Sure youre on Bee Movie  JS REVISIONS 81307 18 He plops the KRELMAN HAT onto Adams head ANGLE ON The job board THE COLUMNS READ OCCUPATION POSITIONS AVAILABLE and STATUS The middle column has numbers and the right column has job openings flipping between open pending and closed BUZZWELL CONTD Oh Im sorry The Krelman just closed out ADAM Oh He takes the hat off Adam BUZZWELL Wax Monkeys always open The Krelman goes from Closed to Open BUZZWELL CONTD And the Krelman just opened up again ADAM What happened BUZZWELL Well whenever a bee dies thats an opening pointing at the board See that Hes dead dead another dead one deady deadified two more dead Dead from the neck up dead from the neck down But thats life ANGLE ON Barrys disturbed expression ADAM feeling pressure to decide Oh this is so hard Heating cooling stunt bee pourer stirrer humming inspector no 7 lint coordinator stripe supervisor antennaball polisher mite wrangler Barry Barry what do you think I should Barry Barry Bee Movie  JS REVISIONS 81307 19 Barry is gone CUT TO SEQ 775  LOU LODUCA SPEECH EXT JGATE  SAME TIME Splitz Jackson Buzz Lou and two other BEES are going through final preflight checks Barry ENTERS LOU LODUCA Alright weve got the sunflower patch in quadrant nine Geranium window box on Sutton Place Barrys antennae rings like a phone ADAM VO What happened to you Where are you Barry whispers throughout BARRY Im going out ADAM VO Out Out where BARRY Out there ADAM VO putting it together Oh no BARRY I have to before I go to work for the rest of my life ADAM VO Youre going to die Youre crazy Hello BARRY Oh another call coming in Bee Movie  JS REVISIONS 81307 20 ADAM VO Youre cra Barry HANGS UP ANGLE ON Lou Loduca LOU LODUCA If anyones feeling brave theres a Korean Deli on 83rd that gets their roses today BARRY timidly Hey guys BUZZ Well look at that SPLITZ Isnt that the kid we saw yesterday LOU LODUCA to Barry Hold it son flight decks restricted JACKSON Its okay Lou were going to take him up Splitz and Jackson CHUCKLE LOU LODUCA Really Feeling lucky are ya A YOUNGER SMALLER BEE THAN BARRY CHET runs up with a release waiver for Barry to sign CHET Sign here Here Just initial that Thank you LOU LODUCA Okay you got a rain advisory today and as you all know bees cannot fly in rain So be careful As always reading off clipboard watch your brooms hockey sticks dogs birds bears and bats Bee Movie  JS REVISIONS 81307 21 Also I got a couple reports of root beer being poured on us Murphys in a home because of it just babbling like a cicada BARRY Thats awful LOU LODUCA And a reminder for all you rookies bee law number one absolutely no talking to humans Alright launch positions The Jocks get into formation chanting as they move LOU LODUCA CONTD Black and Yellow JOCKS Hello SPLITZ to Barry Are you ready for this hot shot BARRY Yeah Yeah bring it on Barry NODS terrified BUZZ Wind  CHECK JOCK 1 Antennae  CHECK JOCK 2 Nectar pack  CHECK JACKSON Wings  CHECK SPLITZ Stinger  CHECK BARRY Scared out of my shorts  CHECK LOU LODUCA Okay ladies lets move it out Everyone FLIPS their goggles down Pit crew bees CRANK their wings and remove the starting blocks We hear loud HUMMING Bee Movie  JS REVISIONS 81307 22 LOU LODUCA CONTD LOU LODUCA CONTD Pound those petunias you striped stemsuckers All of you drain those flowers A FLIGHT DECK GUY in deep crouch handsignals them out the archway as the backwash from the bee wings FLUTTERS his jump suit Barry follows everyone SEQ 800  FLYING WITH THE JOCKS The bees climb above tree tops in formation Barry is euphoric BARRY Whoa Im out I cant believe Im out So blue Ha ha ha a beat I feel so fastand free re kites in the sky Box kite Wow They fly by several bicyclists and approach a patch of flowers BARRY CONTD Flowers SPLITZ This is blue leader We have roses visual Bring it around thirty degrees and hold BARRY sotto Roses JACKSON Thirty degrees roger bringing it around Many pollen jocks break off from the main group They use their equipment to collect nectar from flowers Barry flies down to watch the jocks collect the nectar JOCK Stand to the side kid its got a bit of a kick The jock fires the gun and recoils Barry watches the gun fill up with nectar Bee Movie  JS REVISIONS 81307 23 BARRY Oh that is one Nectar Collector JOCK You ever see pollination up close BARRY No Sir He takes off and the excess pollen dust falls causing the flowers to come back to life JOCK as he pollinates I pick some pollen up over here sprinkle it over here maybe a dash over there pinch on that onesee that Its a little bit of magic aint it The FLOWERS PERK UP as he pollinates BARRY Wow Thats amazing Why do we do that JOCK thats pollen power Kid More pollen more flowers more nectar more honey for us BARRY Cool The Jock WINKS at Barry Barry rejoins the other jocks in the sky They swoop in over a pond kissing the surface We see their image reflected in the water theyre really moving They fly over a fountain BUZZ Im picking up a lot of bright yellow could be daisies Dont we need those SPLITZ Copy that visual We see what appear to be yellow flowers on a green field Bee Movie  JS REVISIONS 81307 24 They go into a deep bank and dive BUZZ Hold on one of these flowers seems to be on the move SPLITZ Say againAre you reporting a moving flower BUZZ Affirmative SEQ 900  TENNIS GAME The pollen jocks land It is a tennis court with dozens of tennis balls A COUPLE VANESSA and KEN plays tennis The bees land right in the midst of a group of balls KEN OC That was on the line The other bees start walking around amongst the immense yellow globes SPLITZ This is the coolest What is it They stop at a BALL on a white line and look up at it JACKSON I dont know but Im loving this color SPLITZ smelling tennis ball Smells good Not like a flower But I like it JACKSON Yeah fuzzy BUZZ Chemicaly JACKSON Careful guys its a little grabby Barry LANDS on a ball and COLLAPSES Bee Movie  JS REVISIONS 81307 25 BARRY Oh my sweet lord of bees JACKSON Hey candy brain get off there Barry attempts to pulls his legs off but they stick BARRY Problem A tennis shoe and a hand ENTER FRAME The hand picks up the ball with Barry underneath it BARRY CONTD Guys BUZZ This could be bad JACKSON Affirmative Vanessa walks back to the service line BOUNCES the ball Each time it BOUNCES the other bees cringe and GASP ANGLE ON Barry terrified Pure dumb luck hes not getting squished BARRY with each bounce Very closeGonna HurtMammas little boy SPLITZ You are way out of position rookie ANGLE ON Vanessa serving We see Barry and the ball up against the racket as she brings it back She tosses the ball into the air Barrys eyes widen The ball is STRUCK and the rally is on KEN Coming in at you like a missile Ken HITS the ball back Barry feels the gforces ANGLE ON The Pollen Jocks watching Barry pass by them in SLOW MOTION Bee Movie  JS REVISIONS 81307 26 BARRY in slow motion Help me JACKSON You know I dont think these are flowers SPLITZ Should we tell him JACKSON I think he knows BARRY OS What is this Vanessa HITS a high arcing lob Ken waits poised for the return We see Barry having trouble maneuvering the ball from fatigue KEN overly confident Match point ANGLE ON Ken running up He has a killer look in his eyes Hes going to hit the ultimate overhead smash KEN CONTD You can just start packing up Honey because I believe youre about to eat it ANGLE ON Pollen Jocks JACKSON Ahem Ken is distracted by the jock KEN What No He misses badly The ball rockets into oblivion Barry is still hanging on ANGLE ON Ken berating himself KEN CONTD Oh you cannot be serious We hear the ball WHISTLING and Barry SCREAMING Bee Movie  JS REVISIONS 81307 27 BARRY Yowser SEQ 1000  SUV The ball flies through the air and lands in the middle of the street It bounces into the street again and sticks in the grille of an SUV INT CAR ENGINE  CONTINUOUS BARRYS POV the grille of the SUV sucks him up He tumbles through a black tunnel whirling vanes and pistons BARRY AHHHHHHHHHHH OHHHH EECHHH AHHHHHH Barry gets chilled by the AC system and sees a frozen grasshopper BARRY CONTD re grasshopper Eww gross CUT TO INT CAR  CONTINUOUS The car is packed with a typical suburban family MOTHER FATHER eightyear old BOY LITTLE GIRL in a car seat and a GRANDMOTHER A big slobbery DOG is behind a grate Barry pops into the passenger compartment hitting the Mothers magazine MOTHER Theres a bee in the car They all notice the bee and start SCREAMING BARRY Aaahhhh Barry tumbles around the car We see the faces from his POV MOTHER Do something Bee Movie  JS REVISIONS 81307 28 FATHER Im driving Barry flies by the little girl in her CAR SEAT She waves hello LITTLE GIRL Hi bee SON Hes back here Hes going to sting me The car SWERVES around the road Barry flies into the back where the slobbery dog SNAPS at him Barry deftly avoids the jaws and gross flying SPITTLE MOTHER Nobody move If you dont move he wont sting you Freeze Everyone in the car freezes Barry freezes They stare at each other eyes going back and forth waiting to see who will make the first move Barry blinks GRANNY He blinked Granny pulls out a can of HAIR SPRAY SON Spray him Granny Granny sprays the hair spray everywhere FATHER What are you doing GRANNY Its hair spray Extra hold MOTHER Kill it Barry gets sprayed back by the hair spray then sucked out of the sunroof CUT TO Bee Movie  JS REVISIONS 81307 29 EXT CITY STREET  CONTINUOUS BARRY Wow The tension level out here is unbelievable Ive got to get home As Barry flies down the street it starts to RAIN He nimbly avoids the rain at first BARRY CONTD Whoa Whoa Cant fly in rain Cant fly in rain Cant fly in A couple of drops hit him his wings go limp and he starts falling BARRY CONTD Mayday Mayday Bee going down Barry sees a window ledge and aims for it and just makes it Shivering and exhausted he crawls into an open window as it CLOSES SEQ 1100  VANESSA SAVES BARRY INT VANESSAS APARTMENT  CONTINUOUS Inside the window Barry SHAKES off the rain like a dog Vanessa Ken Andy and Anna ENTER the apartment VANESSA Ken can you close the window please KEN Huh Oh to Andy Hey check out my new resume I made it into a foldout brochure You see It folds out Ken holds up his brochure with photos of himself and a resume in the middle ANGLE ON Barry hiding behind the curtains as Ken CLOSES THE WINDOW Bee Movie  JS REVISIONS 81307 30 BARRY Oh no more humans I dont need this Barry HOVERS up into the air and THROWS himself into the glass BARRY CONTD dazed Ow What was that He does it again and then multiple more times BARRY CONTD Maybe this timethis time this time this time this time this time this time this time Barry JUMPS onto the drapes BARRY CONTD out of breath Drapes then re glass That is diabolical KEN Its fantastic Its got all my special skills even my top ten favorite movies ANDY Whats your number one Star Wars KEN Ah I dont go for that makes Star Wars noises kind of stuff ANGLE ON Barry BARRY No wonder were not supposed to talk to them Theyre out of their minds KEN When I walk out of a job interview theyre flabbergasted They cant believe the things I say Barry looks around and sees the LIGHT BULB FIXTURE in the middle of the ceiling Bee Movie  JS REVISIONS 81307 31 BARRY re light bulb Oh theres the sun Maybe thats a way out Barry takes off and heads straight for the light bulb His POV The seventyfive watt label grows as he gets closer BARRY CONTD I dont remember the sun having a big seventy five on it Barry HITS the bulb and is KNOCKED SILLY He falls into a BOWL OF GUACAMOLE Andy dips his chip in the guacamole taking Barry with it ANGLE ON Ken and Andy KEN Ill tell you what You know what I predicted global warming I could feel it getting hotter At first I thought it was just me Barrys POV Giant human mouth opening KEN CONTD Wait Stop Beeeeeee ANNA Kill it Kill it They all JUMP up from their chairs Andy looks around for something to use Ken comes in for the kill with a big TIMBERLAND BOOT on each hand KEN Stand back These are winter boots Vanessa ENTERS and stops Ken from squashing Barry VANESSA grabs Kens arm Wait Dont kill him CLOSE UP on Barrys puzzled face KEN You know Im allergic to them This thing could kill me Bee Movie  JS REVISIONS 81307 32 VANESSA Why does his life have any less value than yours She takes a GLASS TUMBLER and places it over Barry KEN Why does his life have any less value than mine Is that your statement VANESSA Im just saying all life has value You dont know what hes capable of feeling Barry looks up through the glass and watches this conversation astounded Vanessa RIPS Kens resume in half and SLIDES it under the glass KEN wistful My brochure Theres a moment of eye contact as she carries Barry to the window She opens it and sets him free VANESSA There you go little guy KEN OC Im not scared of them But you know its an allergic thing ANDY OC  Hey why dont you put that on your  resumebrochure  KEN OC Its not funny my whole face could puff up ANDY OC Make it one of your Special Skills KEN OC You know knocking someone out is also a special skill CUT TO Bee Movie  JS REVISIONS 81307 33 EXT WINDOWSILL  CONTINUOUS Barry stares over the window frame He cant believe whats just happened It is still RAINING DISSOLVE TO SEQ 1200  BARRY SPEAKS EXT WINDOWSILL  LATER Barry is still staring through the window Inside everyones saying their goodbyes KEN Vanessa next week Yogurt night VANESSA Uh yeah sure Ken You know whatever KEN You can put carob chips on there VANESSA Good night KEN as he exits Supposed to be less calories or something VANESSA Bye She shuts the door Vanessa starts cleaning up BARRY Ive got to say something She saved my life Ive got to say something Alright here it goes Barry flies in Bee Movie  JS REVISIONS 81307 34 INT VANESSAS APARTMENT  CONTINUOUS Barry hides himself on different PRODUCTS placed along the kitchen shelves He hides on a Bumblebee Tuna can and a Greetings From Coney Island MUSCLEMAN POSTCARD on the fridge BARRY on fridge What would I say landing on a bottle I could really get in trouble He stands looking at Vanessa BARRY CONTD Its a bee law Youre not supposed to talk to a human I cant believe Im doing this Ive got to Oh I cant do it Come on No yes no do it I cant How should I start it You like jazz No thats no good Here she comes Speak you fool As Vanessa walks by Barry takes a DEEP BREATH BARRY CONTD cheerful Ummhi Vanessa DROPS A STACK OF DISHES and HOPS BACK BARRY CONTD Im sorry VANESSA Youre talking BARRY Yes I know I know VANESSA Youre talking BARRY I know Im sorry Im so sorry VANESSA Its okay Its fine Its just I know Im dreaming but I dont recall going to bed Bee Movie  JS REVISIONS 81307 35 BARRY Well you know Im sure this is very disconcerting VANESSA Well yeah I mean this is a bit of a surprise to me I meanyoure a bee BARRY Yeah I am a bee and you know Im not supposed to be doing this but they were all trying to kill me and if it wasnt for youI mean I had to thank you Its just the way I was raised Vanessa intentionally JABS her hand with a FORK VANESSA Ow BARRY That was a little weird VANESSA to herself Im talking to a bee BARRY Yeah VANESSA Im talking to a bee BARRY Anyway VANESSA And a bee is talking to me BARRY I just want you to know that Im grateful and Im going to leave now VANESSA Wait wait wait wait how did you learn to do that BARRY What Bee Movie  JS REVISIONS 81307 36 VANESSA The talking thing BARRY Same way you did I guess Mama Dada honey you pick it up VANESSA Thats very funny BARRY Yeah Bees are funny If we didnt laugh wed cry With what we have to deal with Vanessa LAUGHS BARRY CONTD Anyway VANESSA Can I uh get you something BARRY Like what VANESSA I dont know I mean I dont know Coffee BARRY Well uh I dont want to put you out VANESSA Its no trouble BARRY Unless youre making anyway VANESSA Oh it takes two minutes BARRY Really VANESSA Its just coffee BARRY I hate to impose Bee Movie  JS REVISIONS 81307 37 VANESSA Dont be ridiculous BARRY Actually I would love a cup VANESSA Hey you want a little rum cake BARRY I really shouldnt VANESSA Have a little rum cake BARRY No no no I cant VANESSA Oh come on BARRY You know Im trying to lose a couple micrograms here VANESSA Where BARRY Well These stripes dont help VANESSA You look great BARRY I dont know if you know anything about fashion Vanessa starts POURING the coffee through an imaginary cup and directly onto the floor BARRY CONTD Are you alright VANESSA No DISSOLVE TO SEQ 1300  ROOFTOP COFFEE Bee Movie  JS REVISIONS 81307 38 EXT VANESSAS ROOF  LATER Barry and Vanessa are drinking coffee on her roof terrace He is perched on her keychain BARRY He cant get a taxi Hes making the tie in the cab as theyre flying up Madison So he finally gets there VANESSA Uh huh BARRY He runs up the steps into the church the wedding is on VANESSA Yeah BARRY and he says watermelon I thought you said Guatemalan VANESSA Uh huh BARRY Why would I marry a watermelon Barry laughs Vanessa doesnt VANESSA Oh Is that uh a bee joke BARRY Yeah thats the kind of stuff that we do VANESSA Yeah different A BEAT VANESSA CONTD So anywaywhat are you going to do Barry Bee Movie  JS REVISIONS 81307 39 BARRY About work I dont know I want to do my part for the hive but I cant do it the way they want VANESSA I know how you feel BARRY You do VANESSA Sure my parents wanted me to be a lawyer or doctor but I wanted to be a florist BARRY Really VANESSA My only interest is flowers BARRY Our new queen was just elected with that same campaign slogan VANESSA Oh BARRY Anyway see theres my hive right there You can see it VANESSA Oh youre in Sheep Meadow BARRY excited Yes You know the turtle pond VANESSA Yes BARRY Im right off of that VANESSA Oh no way I know that area Do you know I lost a toering there once BARRY Really Bee Movie  JS REVISIONS 81307 40 VANESSA Yes BARRY Why do girls put rings on their toes VANESSA Why not BARRY I dont know Its like putting a hat on your knee VANESSA Really Okay A JANITOR in the background changes a LIGHTBULB To him it appears that Vanessa is talking to an imaginary friend JANITOR You all right maam VANESSA Oh yeah fine Just having two cups of coffee BARRY Anyway this has been great wiping his mouth Thanks for the coffee Barry gazes at Vanessa VANESSA Oh yeah its no trouble BARRY Sorry I couldnt finish it Vanessa giggles BARRY CONTD re coffee If I did Id be up the rest of my life Ummm Can I take a piece of this with me VANESSA Sure Here have a crumb She takes a CRUMB from the plate and hands it to Barry Bee Movie  JS REVISIONS 81307 41 BARRY a little dreamy Oh thanks VANESSA Yeah There is an awkward pause BARRY Alright well then I guess Ill see you around or not or VANESSA Okay Barry BARRY And thank you so much again for before VANESSA Oh that BARRY Yeah VANESSA Oh that was nothing BARRY Well not nothing but anyway Vanessa extends her hand and shakes Barrys gingerly The Janitor watches The lightbulb shorts out The Janitor FALLS CUT TO SEQ 1400  HONEX INT HONEX BUILDING  NEXT DAY ANGLE ON A TEST BEE WEARING A PARACHUTE is in a wind tunnel hovering through increasingly heavy wind SIGNS UNDER A FLASHING LIGHT READ Test In Progress  Hurricane Survival Test 2 BEES IN A LAB COATS are observing behind glass Bee Movie  JS REVISIONS 81307 42 LAB COAT BEE 1 This cant possibly work LAB COAT BEE 2 Well hes all set to go we may as well try it into the mic Okay Dave pull the chute The test bee opens his parachute Hes instantly blown against the rear wall Adam and Barry ENTER ADAM Sounds amazing BARRY Oh it was amazing It was the scariest happiest moment of my life ADAM Humans Humans I cant believe you were with humans Giant scary humans What were they like BARRY Huge and crazy They talk crazy they eat crazy giant things They drive around real crazy ADAM And do they try and kill you like on TV BARRY Some of them But some of them dont ADAM Howd you get back BARRY Poodle ADAM Look you did it And Im glad You saw whatever you wanted to see out there you had your experience and now youre back you can pick out your job and everything can be normal Bee Movie  JS REVISIONS 81307 43 ANGLE ON LAB BEES examining a CANDY CORN through a microscope BARRY Well ADAM Well BARRY Well I met someone ADAM You met someone Was she Beeish BARRY Mmm ADAM Not a WASP Your parents will kill you BARRY No no no not a wasp ADAM Spider BARRY You know Im not attracted to the spiders I know to everyone else its like the hottest thing with the eight legs and all I cant get by that face Barry makes a spider face ADAM So who is she BARRY Shes a human ADAM Oh no no no no That didnt happen You didnt do that That is a bee law You wouldnt break a bee law BARRY Her names Vanessa Bee Movie  JS REVISIONS 81307 44 ADAM Oh oh boy BARRY Shes soo nice And shes a florist ADAM Oh no No no no Youre dating a human florist BARRY Were not dating ADAM Youre flying outside the hive Youre talking to human beings that attack our homes with power washers and M80s Thats 18 of a stick of dynamite BARRY She saved my life And she understands me ADAM This is over Barry pulls out the crumb BARRY Eat this Barry stuffs the crumb into Adams face ADAM This is not over What was that BARRY They call it a crumb ADAM That was SO STINGING STRIPEY BARRY And thats not even what they eat That just falls off what they eat Do you know what a Cinnabon is ADAM No Bee Movie  JS REVISIONS 81307 45 BARRY Its bread ADAM Come in here BARRY and cinnamon ADAM Be quiet BARRY and frostingthey heat it up ADAM Sit down INT ADAMS OFFICE  CONTINUOUS BARRY Really hot ADAM Listen to me We are not them Were us Theres us and theres them BARRY Yes but who can deny the heart that is yearning Barry rolls his chair down the corridor ADAM Theres no yearning Stop yearning Listen to me You have got to start thinking bee my friend ANOTHER BEE JOINS IN ANOTHER BEE Thinking bee WIDER SHOT AS A 3RD BEE ENTERS popping up over the cubicle wall 3RD BEE Thinking bee EVEN WIDER SHOT AS ALL THE BEES JOIN IN Bee Movie  JS REVISIONS 81307 46 OTHER BEES Thinking bee Thinking bee Thinking bee CUT TO SEQ 1500  POOLSIDE NAGGING EXT BACKYARD PARENTS HOUSE  DAY Barry sits on a RAFT in a hexagon honey pool legs dangling into the water Janet Benson and Martin Benson stand over him wearing big sixties sunglasses and cabanatype outfits The sun shines brightly behind their heads JANET BENSON OC There he is Hes in the pool MARTIN BENSON You know what your problem is Barry BARRY Ive got to start thinking bee MARTIN BENSON Barry how much longer is this going to go on Its been three days I dont understand why youre not working BARRY Well Ive got a lot of big life decisions Im thinking about MARTIN BENSON What life You have no life You have no job Youre barely a bee Barry throws his hands in the air BARRY Augh JANET BENSON Would it kill you to just make a little honey Barry ROLLS off the raft and SINKS to the bottom of the pool We hear his parents MUFFLED VOICES from above the surface Bee Movie  JS REVISIONS 81307 47 JANET BENSON CONTD muffled Barry come out from under there Your fathers talking to you Martin would you talk to him MARTIN BENSON Barry Im talking to you DISSOLVE TO EXT PICNIC AREA  DAY MUSIC Sugar Sugar by the Archies Barry and Vanessa are having a picnic A MOSQUITO lands on Vanessas leg She SWATS it violently Barrys head whips around aghast They stare at each other awkwardly in a frozen moment then BURST INTO HYSTERICAL LAUGHTER Vanessa GETS UP VANESSA You coming BARRY Got everything VANESSA All set Vanessa gets into a oneman Ultra Light plane with a black and yellow paint scheme She puts on her helmet BARRY You go ahead Ill catch up VANESSA come hither wink Dont be too long The Ultra Light takes off Barry catches up They fly sidebyside VANESSA CONTD Watch this Vanessa does a loop and FLIES right into the side of a mountain BURSTING into a huge ball of flames Bee Movie  JS REVISIONS 81307 48 BARRY yelling anguished Vanessa EXT BARRYS PARENTS HOUSE  CONTINUOUS ANGLE ON Barrys face bursting through the surface of the pool GASPING for air eyes opening in horror MARTIN BENSON Were still here Barry JANET BENSON I told you not to yell at him He doesnt respond when you yell at him MARTIN BENSON Then why are you yelling at me JANET BENSON Because you dont listen MARTIN BENSON Im not listening to this Barry is toweling off putting on his sweater BARRY Sorry Mom Ive got to go JANET BENSON Where are you going BARRY Nowhere Im meeting a friend Barry JUMPS off the balcony and EXITS JANET BENSON calling after him A girl Is this why you cant decide BARRY Bye JANET BENSON I just hope shes Beeish CUT TO Bee Movie  JS REVISIONS 81307 49 SEQ 1700  STREETWALKSUPERMARKET EXT VANESSAS FLORIST SHOP  DAY Vanessa FLIPS the sign to say Sorry We Missed You and locks the door ANGLE ON A POSTER on Vanessas door for the Tournament of Roses Parade in Pasadena BARRY So they have a huge parade of just flowers every year in Pasadena VANESSA Oh to be in the Tournament of Roses thats every florists dream Up on a float surrounded by flowers crowds cheering BARRY Wow a tournament Do the roses actually compete in athletic events VANESSA No Alright Ive got one How come you dont fly everywhere BARRY Its exhausting Why dont you run everywhere VANESSA Hmmm BARRY Isnt that faster VANESSA Yeah okay I see I see Alright your turn Barry and Vanessa walkfly down a New York side street no other pedestrians near them BARRY Ah Tivo You can just freeze live TV Thats insane Bee Movie  JS REVISIONS 81307 50 VANESSA What you dont have anything like that BARRY We have Hivo but its a disease Its a horrible horrible disease VANESSA Oh my They turn the corner onto a busier avenue and people start to swat at Barry MAN Dumb bees VANESSA You must just want to sting all those jerks BARRY We really try not to sting Its usually fatal for us VANESSA So you really have to watch your temper They ENTER a SUPERMARKET CUT TO INT SUPERMARKET BARRY Oh yeah very carefully You kick a wall take a walk write an angry letter and throw it out You work through it like any emotion anger jealousy under his breath lust Barry hops on top of some cardboard boxes in the middle of an aisle A stock boy HECTOR whacks him with a rolled up magazine VANESSA to Barry Oh my goodness Are you okay Bee Movie  JS REVISIONS 81307 51 BARRY Yeah Whew Vanessa WHACKS Hector over the head with the magazine VANESSA to Hector What is wrong with you HECTOR Its a bug VANESSA Well hes not bothering anybody Get out of here you creep Vanessa pushes him and Hector EXITS muttering BARRY shaking it off What was that a Pick and Save circular VANESSA Yeah it was How did you know BARRY It felt like about ten pages Seventyfives pretty much our limit VANESSA Boy youve really got that down to a science BARRY Oh we have to I lost a cousin to Italian Vogue VANESSA Ill bet Barry stops sees the wall of honey jars BARRY What in the name of Mighty Hercules is this How did this get here Cute Bee Golden Blossom Ray Liotta Private Select VANESSA Is he that actor Bee Movie  JS REVISIONS 81307 52 BARRY I never heard of him Why is this here VANESSA For people We eat it BARRY Why gesturing around the market You dont have enough food of your own VANESSA Well yes we BARRY How do you even get it VANESSA Well bees make it BARRY I know who makes it And its hard to make it Theres Heating and Cooling and Stirringyou need a whole Krelman thing VANESSA Its organic BARRY Its ourganic VANESSA Its just honey Barry BARRY Justwhat Bees dont know about this This is stealing A lot of stealing Youve taken our homes our schools our hospitals This is all we have And its on sale Im going to get to the bottom of this Im going to get to the bottom of all of this He RIPS the label off the Ray Liotta Private Select CUT TO Bee Movie  JS REVISIONS 81307 53 SEQ 1800  WINDSHIELD EXT BACK OF SUPERMARKET LOADING DOCK  LATER THAT DAY Barry disguises himself by blacking out his yellow lines with a MAGIC MARKER and putting on some war paint He sees Hector the stock boy with a knife CUTTING open cardboard boxes filled with honey jars MAN You almost done HECTOR Almost Barry steps in some honey making a SNAPPING noise Hector stops and turns HECTOR CONTD He is here I sense it Hector grabs his BOX CUTTER Barry REACTS hides himself behind the box again HECTOR CONTD talking too loud to no one in particular Well I guess Ill go home now and just leave this nice honey out with no one around A BEAT Hector pretends to exit He takes a couple of steps in place ANGLE ON The honey jar Barry steps out into a moody spotlight BARRY Youre busted box boy HECTOR Ah ha I knew I heard something So you can talk Barry flies up stinger out pushing Hector up against the wall As Hector backs up he drops his knife BARRY Oh I can talk And now youre going to start talking Bee Movie  JS REVISIONS 81307 54 Where are you getting all the sweet stuff Whos your supplier HECTOR I dont know what youre talking about I thought we were all friends The last thing we want to do is upset any of youbees Hector grabs a PUSHPIN Barry fences with his stinger HECTOR CONTD Youre too late Its ours now BARRY You sir have crossed the wrong sword HECTOR You sir are about to be lunch for my iguana Ignacio Barry and Hector get into a crossswords nosetonose confrontation BARRY Where is the honey coming from Barry knocks the pushpin out of his hand Barry puts his stinger up to Hectors nose BARRY CONTD Tell me where HECTOR pointing to a truck Honey Farms It comes from Honey Farms ANGLE ON A Honey Farms truck leaving the parking lot Barry turns takes off after the truck through an alley He follows the truck out onto a busy street dodging a bus and several cabs CABBIE Crazy person He flies through a metal pipe on the top of a truck BARRY OOOHHH Bee Movie  JS REVISIONS 81307 55 BARRY CONTD Barry grabs onto a bicycle messengers backpack The honey farms truck starts to pull away Barry uses the bungee cord to slingshot himself towards the truck He lands on the windshield where the wind plasters him to the glass He looks up to find himself surrounded by what appear to be DEAD BUGS He climbs across working his way around the bodies BARRY CONTD Oh my What horrible thing has happened here Look at these faces They never knew what hit them And now theyre on the road to nowhere A MOSQUITO opens his eyes MOOSEBLOOD Pssst Just keep still BARRY What Youre not dead MOOSEBLOOD Do I look dead Hey man they will wipe anything that moves Now where are you headed BARRY To Honey Farms I am onto something huge here MOOSEBLOOD Im going to Alaska Moose blood Crazy stuff Blows your head off LADYBUG Im going to Tacoma BARRY to fly What about you MOOSEBLOOD He really is dead BARRY Alright The WIPER comes towards them Bee Movie  JS REVISIONS 81307 56 MOOSEBLOOD Uh oh BARRY What is that MOOSEBLOOD Oh no Its a wiper triple blade BARRY Triple blade MOOSEBLOOD Jump on Its your only chance bee They hang on as the wiper goes back and forth MOOSEBLOOD CONTD yelling to the truck driver through the glass Why does everything have to be so doggone clean How much do you people need to see Open your eyes Stick your head out the window CUT TO INT TRUCK CAB SFX Radio RADIO VOICE For NPR News in Washington Im Carl Kasell EXT TRUCK WINDSHIELD MOOSEBLOOD But dont kill no more bugs The Mosquito is FLUNG off of the wiper MOOSEBLOOD CONTD Beeeeeeeeeeeeee BARRY Moose blood guy Bee Movie  JS REVISIONS 81307 57 Barry slides toward the end of the wiper is thrown off but he grabs the AERIAL and hangs on for dear life Barry looks across and sees a CRICKET on another vehicle in the exact same predicament They look at each other and SCREAM in unison BARRY AND CRICKET Aaaaaaaaaah ANOTHER BUG grabs onto the aerial and screams as well INT TRUCK CAB  SAME TIME DRIVER You hear something TRUCKER PASSENGER Like what DRIVER Like tiny screaming TRUCKER PASSENGER Turn off the radio The driver reaches down and PRESSES a button lowering the aerial EXT TRUCK WINDSHIELD  SAME TIME Barry and the other bug do a choose up to the bottom Barry wins BARRY Aha Then he finally has to let go and gets thrown into the truck horn atop cab Mooseblood is inside MOOSEBLOOD Hey whats up bee boy BARRY Hey Blood DISSOLVE TO Bee Movie  JS REVISIONS 81307 58 INT TRUCK HORN  LATER BARRY and it was just an endless row of honey jars as far as the eye could see MOOSEBLOOD Wow BARRY So Im just assuming wherever this honey truck goes thats where theyre getting it I mean that honeys ours MOOSEBLOOD Bees hang tight BARRY Well were all jammed in there Its a close community MOOSEBLOOD Not us man Were on our own Every mosquito is on his own BARRY But what if you get in trouble MOOSEBLOOD Trouble Youre a mosquito Youre in trouble Nobody likes us Theyre just all smacking People see a mosquito smack smack BARRY At least youre out in the world You must meet a lot of girls MOOSEBLOOD Mosquito girls try to trade up get with a moth dragonflymosquito girl dont want no mosquito A BLOOD MOBILE pulls up alongside MOOSEBLOOD CONTD Whoa you have got to be kidding me Moosebloods about to leave the building So long bee Bee Movie  JS REVISIONS 81307 59 Mooseblood EXITS the horn and jumps onto the blood mobile MOOSEBLOOD CONTD Hey guys I knew Id catch you all down here Did you bring your crazy straws CUT TO SEQ 1900  THE APIARY EXT APIARY  LATER Barry sees a SIGN Honey Farms The truck comes to a stop SFX The Honey farms truck blares its horn Barry flies out lands on the hood ANGLE ON Two BEEKEEPERS FREDDY and ELMO walking around to the back of the gift shop Barry follows them and lands in a nearby tree FREDDY then we throw it in some jars slap a label on it and its pretty much pure profit BARRY What is this place ELMO Bees got a brain the size of a pinhead FREDDY They are pinheads The both LAUGH ANGLE ON Barry REACTING They arrive at the back of the shop where one of them opens a SMOKER BOX FREDDY CONTD Hey check out the new smoker Bee Movie  JS REVISIONS 81307 60 ELMO Oh Sweet Thats the one you want FREDDY The Thomas 3000 BARRY Smoker FREDDY 90 puffs a minute semiautomatic Twice the nicotine all the tar They LAUGH again nefariously FREDDY CONTD Couple of breaths of this and it knocks them right out They make the honey and we make the money BARRY They make the honey and we make the money Barry climbs onto the netting of Freddys hat He climbs up to the brim and looks over the edge He sees the apiary boxes as Freddy SMOKES them BARRY CONTD Oh my As Freddy turns around Barry jumps into an open apiary box and into an apartment HOWARD and FRAN are just coming to from the smoking BARRY CONTD Whats going on Are you okay HOWARD Yeah it doesnt last too long HE COUGHS a few times BARRY How did you two get here Do you know youre in a fake hive with fake walls HOWARD pointing to a picture on the wall Bee Movie  JS REVISIONS 81307 61 Our queen was moved here we had no choice BARRY looking at a picture on the wall This is your queen Thats a man in womens clothes Thats a dragqueen The other wall opens Barry sees the hundreds of apiary boxes BARRY CONTD What is this Barry pulls out his camera and starts snapping BARRY CONTD Oh no Theres hundreds of them VO as Barry takes pictures Bee honey our honey is being brazenly stolen on a massive scale CUT TO SEQ 2100  BARRY TELLS FAMILY INT BARRYS PARENTS HOUSE  LIVING ROOM  LATER Barry has assembled his parents Adam and Uncle Carl BARRY This is worse than anything the bears have done to us And I intend to do something about it JANET BENSON Oh Barry stop MARTIN BENSON Who told you that humans are taking our honey Thats just a rumor BARRY Do these look like rumors Barry throws the PICTURES on the table Uncle Carl cleaning his glasses with his shirt tail digs through a bowl of nuts with his finger Bee Movie  JS REVISIONS 81307 62 HOWARD CONTD UNCLE CARL Thats a conspiracy theory These are obviously doctored photos JANET BENSON Barry how did you get mixed up in all this ADAM jumping up Because hes been talking to humans JANET BENSON Whaaat MARTIN BENSON Talking to humans Oh Barry ADAM He has a human girlfriend and they make out JANET BENSON Make out Barry BARRY We do not ADAM You wish you could BARRY Whos side are you on ADAM The bees Uncle Carl stands up and pulls his pants up to his chest UNCLE CARL I dated a cricket once in San Antonio Man those crazy legs kept me up all night Hotcheewah JANET BENSON Barry this is what you want to do with your life BARRY This is what I want to do for all our lives Nobody works harder than bees Bee Movie  JS REVISIONS 81307 63 Dad I remember you coming home some nights so overworked your hands were still stirring You couldnt stop them MARTIN BENSON Ehhh JANET BENSON to Martin I remember that BARRY What right do they have to our hardearned honey Were living on two cups a year Theyre putting it in lip balm for no reason whatsoever MARTIN BENSON Even if its true Barry what could one bee do BARRY Im going to sting them where it really hurts MARTIN BENSON In the face BARRY No MARTIN BENSON In the eye That would really hurt BARRY No MARTIN BENSON Up the nose Thats a killer BARRY No Theres only one place you can sting the humans One place where it really matters CUT TO SEQ 2300  HIVE AT 5 NEWSBEE LARRY KING Bee Movie  JS REVISIONS 81307 64 BARRY CONTD INT NEWS STUDIO  DAY DRAMATIC NEWS MUSIC plays as the opening news sequence rolls We see the Hive at Five logo followed by shots of past news events A BEE freeway chase a BEE BEARD protest rally and a BEAR pawing at the hive as the BEES flee in panic BOB BUMBLE VO Hive at Five the hives only full hour action news source SHOTS of NEWSCASTERS flash up on screen BOB BUMBLE VO CONTD With Bob Bumble at the anchor desk BOB has a big shock of anchorman hair gray temples and overly white teeth BOB BUMBLE VO CONTD weather with Storm Stinger sports with Buzz Larvi and Jeanette Chung JEANETTE is an Asian bee BOB BUMBLE CONTD Good evening Im Bob Bumble JEANETTE CHUNG And Im Jeanette Chung BOB BUMBLE Our top story a tricounty bee Barry Benson INSERT Barrys graduation picture BOB BUMBLE CONTD is saying he intends to sue the human race for stealing our honey packaging it and profiting from it illegally CUT TO Bee Movie  JS REVISIONS 81307 65 INT BEENN STUDIO  BEE LARRY KING LIVE BEE LARRY KING wearing suspenders and glasses is interviewing Barry A LOWERTHIRD CHYRON reads Bee Larry King Live BEE LARRY KING Dont forget tomorrow night on Bee Larry King we are going to have three former Queens all right here in our studio discussing their new book Classy Ladies out this week on Hexagon to Barry Tonight were talking to Barry Benson Did you ever think Im just a kid from the hive I cant do this BARRY Larry bees have never been afraid to change the world I mean what about BeeColumbus BeeGhandi Begeesus BEE LARRY KING Well where Im from you wouldnt think of suing humans We were thinking more like stick ball candy stores BARRY How old are you BEE LARRY KING I want you to know that the entire bee community is supporting you in this case which is certain to be the trial of the bee century BARRY Thank you Larry You know they have a Larry King in the human world too BEE LARRY KING Its a common name Next week on Bee Larry King Bee Movie  JS REVISIONS 81307 66 BARRY No I mean he looks like you And he has a show with suspenders and different colored dots behind him BEE LARRY KING Next week on Bee Larry King BARRY Old guy glasses and theres quotes along the bottom from the guest youre watching even though you just heard them BEE LARRY KING Bear week next week Theyre scary theyre hairy and theyre here live Bee Larry King EXITS BARRY Always leans forward pointy shoulders squinty eyes lights go out Very Jewish CUT TO SEQ 2400  FLOWER SHOP INT VANESSAS FLOWER SHOP  NIGHT Stacks of law books are piled up legal forms etc Vanessa is talking with Ken in the other room KEN Look in tennis you attack at the point of weakness VANESSA But it was my grandmother Ken Shes 81 KEN Honey her backhands a joke Im not going to take advantage of that Bee Movie  JS REVISIONS 81307 67 BARRY OC Quiet please Actual work going on here KEN Is that that same bee BARRY OC Yes it is VANESSA Im helping him sue the human race KEN What Barry ENTERS BARRY Oh hello KEN Hello Bee Barry flies over to Vanessa VANESSA This is Ken BARRY Yeah I remember you Timberland size 10 12 Vibram sole I believe KEN Why does he talk again Hun VANESSA to Ken sensing the tension Listen youd better go because were really busy working KEN But its our yogurt night VANESSA pushing him out the door Ohbye bye She CLOSES the door KEN Why is yogurt night so difficult Bee Movie  JS REVISIONS 81307 68 Vanessa ENTERS the back room carrying coffee VANESSA Oh you poor thing you two have been at this for hours BARRY Yes and Adam here has been a huge help ANGLE ON A EMPTY CINNABON BOX with Adam asleep inside covered in frosting VANESSA How many sugars BARRY Just one I try not to use the competition So why are you helping me anyway VANESSA Bees have good qualities BARRY rowing on the sugar cube like a gondola Si Certo VANESSA And it feels good to take my mind off the shop I dont know why instead of flowers people are giving balloon bouquets now BARRY Yeah those are greatif youre 3 VANESSA And artificial flowers BARRY re plastic flowers Oh they just get me psychotic VANESSA Yeah me too BARRY The bent stingers the pointless pollination Bee Movie  JS REVISIONS 81307 69 VANESSA Bees must hate those fake plastic things BARRY Theres nothing worse than a daffodil thats had work done VANESSA holding up the lawsuit documents Well maybe this can make up for it a little bit CUT TO EXT VANESSAS FLORIST SHOP They EXIT the store and cross to the mailbox VANESSA You know Barry this lawsuit is a pretty big deal BARRY I guess VANESSA Are you sure that you want to go through with it BARRY Am I sure kicking the envelope into the mailbox When Im done with the humans they wont be able to say Honey Im home without paying a royalty CUT TO SEQ 2700  MEET MONTGOMERY EXT MANHATTAN COURTHOUSE  DAY POV SHOT  A camera feed turns on revealing a newsperson Bee Movie  JS REVISIONS 81307 70 PRESS PERSON 2 talking to camera Sarah its an incredible scene here in downtown Manhattan where all eyes and ears of the world are anxiously waiting because for the first time in history were going to hear for ourselves if a honey bee can actually speak ANGLE ON Barry Vanessa and Adam getting out of the cab The press spots Barry and Vanessa and pushes in Adam sits on Vanessas shoulder INT COURTHOUSE  CONTINUOUS Barry Vanessa and Adam sit at the Plaintiffs Table VANESSA turns to Barry What have we gotten into here Barry BARRY I dont know but its pretty big isnt it ADAM I cant believe how many humans dont have to be at work during the day BARRY Hey you think these billion dollar multinational food companies have good lawyers CUT TO EXT COURTHOUSE STEPS  CONTINUOUS A BIG BLACK CAR pulls up ANGLE ON the grill filling the frame We see the LTM monogram on the hood ornament The defense lawyer LAYTON T MONTGOMERY comes out squashing a bug on the pavement CUT TO Bee Movie  JS REVISIONS 81307 71 INT COURTHOUSE  CONTINUOUS Barry SHUDDERS VANESSA Whats the matter BARRY I dont know I just got a chill Montgomery ENTERS He walks by Barrys table shaking a honey packet MONTGOMERY Well if it isnt the BTeam re the honey packet Any of you boys work on this He CHUCKLES The JUDGE ENTERS SEQ 3000  WITNESSES BAILIFF All rise The Honorable Judge Bumbleton presiding JUDGE shuffling papers AlrightCase number 4475 Superior Court of New York Barry Bee Benson vs the honey industry is now in session Mr Montgomery you are representing the five major food companies collectively ANGLE ON Montgomerys BRIEFCASE It has an embossed emblem of an EAGLE holding a gavel in one talon and a briefcase in the other MONTGOMERY A privilege JUDGE Mr Benson Barry STANDS JUDGE CONTD You are representing all bees of the world Bee Movie  JS REVISIONS 81307 72 Montgomery the stenographer and the jury lean in CUT TO EXT COURTHOUSE  CONTINUOUS The spectators outside freeze The helicopters angle forward to listen closely CUT TO INT COURTHOUSE BARRY Bzzz bzzz bzzzAhh Im kidding Im kidding Yes your honor We are ready to proceed ANGLE ON Courtroom hubbub JUDGE And Mr Montgomery your opening statement please Montgomery rises MONTGOMERY grumbles clears his throat Ladies and gentlemen of the jury My grandmother was a simple woman Born on a farm she believed it was mans divine right to benefit from the bounty of nature God put before us If we were to live in the topsyturvy world Mr Benson imagines just think of what it would mean Maybe I would have to negotiate with the silk worm for the elastic in my britches Talking bee How do we know this isnt some sort of holographic motion picture capture Hollywood wizardry They could be using laser beams robotics ventriloquism cloningfor all we know he could be on steroids Montgomery leers at Barry who moves to the stand Bee Movie  JS REVISIONS 81307 73 JUDGE Mr Benson Barry makes his opening statement BARRY Ladies and Gentlemen of the jury theres no trickery here Im just an ordinary bee And as a bee honeys pretty important to me Its important to all bees We invented it we make it and we protect it with our lives Unfortunately there are some people in this room who think they can take whatever they want from us cause were the little guys And what Im hoping is that after this is all over youll see how by taking our honey youre not only taking away everything we have but everything we are ANGLE ON Vanessa smiling ANGLE ON The BEE GALLERY wiping tears away CUT TO INT BENSON HOUSE Barrys family is watching the case on TV JANET BENSON Oh I wish he would dress like that all the time So nice CUT TO INT COURTROOM  LATER JUDGE Call your first witness CUT TO Bee Movie  JS REVISIONS 81307 74 INT COURTHOUSE  LATER BARRY So Mr Klauss Vanderhayden of Honey Farms Pretty big company you have there MR VANDERHAYDEN I suppose so BARRY And I see you also own HoneyBurton and HonRon MR VANDERHAYDEN Yes They provide beekeepers for our farms BARRY Beekeeper I find that to be a very disturbing term I have to say I dont imagine you employ any bee freeers do you MR VANDERHAYDEN No BARRY Im sorry I couldnt hear you MR VANDERHAYDEN louder No BARRY No Because you dont free bees You keep bees And not only that it seems you thought a bear would be an appropriate image for a jar of honey MR VANDERHAYDEN Well theyre very lovable creatures Yogibear Fozzybear Buildabear BARRY Yeah you mean like this Vanessa and the SUPERINTENDANT from her building ENTER with a GIANT FEROCIOUS GRIZZLY BEAR He has a neck collar and chains extending from either side Bee Movie  JS REVISIONS 81307 75 By pulling the chains they bring him directly in front of Vanderhayden The bear LUNGES and ROARS BARRY CONTD Bears kill bees How would you like his big hairy head crashing into your living room Biting into your couch spitting out your throwpillowsrowr rowr The bear REACTS BEAR Rowr BARRY Okay thats enough Take him away Vanessa and the Superintendant pull the bear out of the courtroom Vanderhayden TREMBLES The judge GLARES at him CUT TO INT COURTROOM A LITTLE LATER Barry questions STING BARRY So Mr Sting Thank you for being here Your name intrigues me I have to say Where have I heard it before STING I was with a band called The Police BARRY But youve never been a police officer of any kind have you STING No I havent Bee Movie  JS REVISIONS 81307 76 BARRY No you havent And so here we have yet another example of bee culture being casually stolen by a human for nothing more than a pranceabout stage name STING Oh please BARRY Have you ever been stung Mr Sting Because Im feeling a little stung Sting Or should I say looking in folder Mr Gordon M Sumner The jury GASPS MONTGOMERY to his aides Thats not his real name You idiots CUT TO INT COURTHOUSE LATER BARRY Mr Liotta first may I offer my belated congratulations on your Emmy win for a guest spot on ER in 2005 LIOTTA Thank you Thank you Liotta LAUGHS MANIACALLY BARRY I also see from your resume that youre devilishly handsome but with a churning inner turmoil thats always ready to blow LIOTTA I enjoy what I do Is that a crime Bee Movie  JS REVISIONS 81307 77 BARRY Not yet it isnt But is this what its come to for you Mr Liotta Exploiting tiny helpless bees so you dont have to rehearse your part and learn your lines Sir LIOTTA Watch it Benson I could blow right now BARRY This isnt a goodfella This is a badfella LIOTTA exploding trying to smash Barry with the Emmy Why doesnt someone just step on this little creep and we can all go home Youre all thinking it Say it JUDGE Order Order in this courtroom A MONTAGE OF NEWSPAPER HEADLINES FOLLOWS NEW YORK POST Bees to Humans Buzz Off NEW YORK TELEGRAM Sue Bee DAILY VARIETY Studio Dumps Liotta Project Slams Door on Unlawful Entry 2 CUT TO SEQ 3175  CANDLELIGHT DINNER INT VANESSAS APARTMENT Barry and Vanessa are having a candle light dinner Visible behind Barry is a LITTLE MISSY SET BOX with the flaps open BARRY Well I just think that was awfully nice of that bear to pitch in like that Bee Movie  JS REVISIONS 81307 78 VANESSA Im telling you I think the jurys on our side BARRY Are we doing everything rightyou know legally VANESSA Im a florist BARRY Right right Barry raises his glass BARRY CONTD Well heres to a great team VANESSA To a great team They toast Ken ENTERS KEN Well hello VANESSA OhKen BARRY Hello VANESSA I didnt think you were coming KEN No I was just late I tried to call But holding his cell phone the battery VANESSA I didnt want all this to go to waste so I called Barry Luckily he was free BARRY Yeah KEN gritting his teeth Oh that was lucky Bee Movie  JS REVISIONS 81307 79 VANESSA Well theres still a little left I could heat it up KEN Yeah heat it up Sure whatever Vanessa EXITS Ken and Barry look at each other as Barry eats BARRY So I hear youre quite a tennis player Im not much for the game myself I find the ball a little grabby KEN Thats where I usually sit Right there VANESSA OC Ken Barry was looking at your resume and he agreed with me that eating with chopsticks isnt really a special skill KEN to Barry You think I dont see what youre doing BARRY Hey look I know how hard it is trying to find the right job We certainly have that in common KEN Do we BARRY Well bees have 100 employment of course But we do jobs like taking the crud out KEN Thats just what I was thinking about doing Ken holds his table knife up It slips out of his hand He goes under the table to pick it up Bee Movie  JS REVISIONS 81307 80 VANESSA Ken I let Barry borrow your razor for his fuzz I hope that was alright Ken hits his head on the table BARRY Im going to go drain the old stinger KEN Yeah you do that Barry EXITS to the bathroom grabbing a small piece of a VARIETY MAGAZINE on the way BARRY Oh look at that Ken slams the champagne down on the table Ken closes his eyes and buries his face in his hands He grabs a magazine on the way into the bathroom SEQ 2800  BARRY FIGHTS KEN INT BATHROOM  CONTINUOUS Ken ENTERS closes the door behind him Hes not happy Barry is washing his hands He glances back at Ken KEN You know Ive just about had it with your little mind games BARRY Whats that KEN Italian Vogue BARRY Mamma Mia thats a lot of pages KEN Its a lot of ads BARRY Remember what Van said Why is your life any more valuable than mine Bee Movie  JS REVISIONS 81307 81 KEN Its funny I just cant seem to recall that Ken WHACKS at Barry with the magazine He misses and KNOCKS EVERYTHING OFF THE VANITY Ken grabs a can of AIR FRESHENER KEN CONTD I think something stinks in here He sprays at Barry BARRY I love the smell of flowers KEN Yeah How do you like the smell of flames Ken lights the stream BARRY Not as much Barry flies in a circle Ken trying to stay with him spins in place ANGLE ON Flames outside the bathroom door Ken slips on the Italian Vogue falls backward into the shower pulling down the shower curtain The can hits him in the head followed by the shower curtain rod and the rubber duck Ken reaches back grabs the handheld shower head He whips around looking for Barry ANGLE ON A WATERBUG near the drain WATERBUG Waterbug Not taking sides Barry is on the toilet tank He comes out from behind a shampoo bottle wearing a chapstick cap as a helmet BARRY Ken look at me Im wearing a chapstick hat This is pathetic ANGLE ON Ken turning the hand shower nozzle from GENTLE to TURBO to LETHAL Bee Movie  JS REVISIONS 81307 82 KEN Ive got issues Ken fires the water at Barry knocking him into the toilet The items from the vanity emory board lipstick eye curler etc are on the toilet seat Ken looks down at Barry KEN CONTD Well well well a royal flush BARRY Youre bluffing KEN Am I Ken flushes the toilet Barry grabs the Emory board and uses it to surf He puts his hand in the water while hes surfing Some water splashes on Ken BARRY Surfs up dude KEN Awww poo water He does some skate boardstyle halfpipe riding Barry surfs out of the toilet BARRY That bowl is gnarly Ken tries to get a shot at him with the toilet brush KEN Except for those dirty yellow rings Vanessa ENTERS VANESSA Kenneth What are you doing KEN You know what I dont even like honey I dont eat it VANESSA We need to talk Bee Movie  JS REVISIONS 81307 83 She pulls Ken out by his ear Ken glares at Barry CUT TO INT HALLWAY  CONTINUOUS VANESSA Hes just a little bee And he happens to be the nicest bee Ive met in a long time KEN Long time What are you talking about Are there other bugs in your life VANESSA No but there are other things bugging me in life And youre one of them KEN Fine Talking bees no yogurt nightmy nerves are fried from riding on this emotional rollercoaster VANESSA Goodbye Ken KEN Augh VANESSA Whew Ken EXITS then reenters frame KEN And for your information I prefer sugarfree artificial sweeteners made by man He EXITS again The DOOR SLAMS behind him VANESSA to Barry Im sorry about all that Ken REENTERS Bee Movie  JS REVISIONS 81307 84 KEN I know its got an aftertaste I like it BARRY re Ken I always felt there was some kind of barrier between Ken and me puts his hands in his pockets I couldnt overcome it Oh well VANESSA Are you going to be okay for the trial tomorrow BARRY Oh I believe Mr Montgomery is about out of ideas CUT TO SEQ 3300  ADAM STINGS MONTY INT COURTROOM  NEXT DAY ANGLE ON Medium shot of Montgomery standing at his table MONTGOMERY We would like to call Mr Barry Benson Bee to the stand ADAM whispering to Vanessa Now thats a good idea to Barry You can really see why hes considered one of the very best lawyers Oh Barry rolls his eyes He gets up takes the stand A juror in a striped shirt APPLAUDS MR GAMMIL whispering Layton youve got to weave some magic with this jury or its going to be all over Montgomery is holding a BOOK The Secret Life of Bees Bee Movie  JS REVISIONS 81307 85 MONTGOMERY confidently whispering Oh dont worry Mr Gammil The only thing I have to do to turn this jury around is to remind them of what they dont like about bees to Gammil You got the tweezers Mr Gammil NODS and pats his breast pocket MR GAMMIL Are you allergic MONTGOMERY Only to losing son Only to losing Montgomery approaches the stand MONTGOMERY CONTD Mr Benson Bee Ill ask you what I think wed all like to know What exactly is your relationship to that woman Montgomery points to Vanessa BARRY Were friends MONTGOMERY Good friends BARRY Yes MONTGOMERY softly in Barrys face How good BARRY What MONTGOMERY Do you live together BARRY Wait a minute this isnt about Bee Movie  JS REVISIONS 81307 86 MONTGOMERY Are you her little clearing throat  bed bug BARRY flustered Hey thats not the kind of MONTGOMERY Ive seen a bee documentary or two Now from what I understand doesnt your Queen give birth to all the bee children in the hive BARRY Yeah but MONTGOMERY So those arent even your real parents ANGLE ON Barrys parents MARTIN BENSON Oh Barry BARRY Yes they are ADAM Hold me back Vanessa holds him back with a COFFEE STIRRER Montgomery points to Barrys parents MONTGOMERY Youre an illegitimate bee arent you Benson ADAM Hes denouncing bees All the bees in the courtroom start to HUM Theyre agitated MONTGOMERY And dont yall date your cousins Bee Movie  JS REVISIONS 81307 87 VANESSA standing letting go of Adam Objection Adam explodes from the table and flies towards Montgomery ADAM Im going to pin cushion this guy Montgomery turns around and positions himself by the judges bench He sticks his butt out Montgomery winks at his team BARRY Adam dont Its what he wants Adam shoves Barry out of the way Adam STINGS Montgomery in the butt The jury REACTS aghast MONTGOMERY Ow Im hit Oh lordy I am hit The judge BANGS her gavel JUDGE Order Order Please Mr Montgomery MONTGOMERY The venom The venom is coursing through my veins I have been felled by a winged beast of destruction You see You cant treat them like equals Theyre striped savages Stingings the only thing they know Its their way ANGLE ON Adam collapsed on the floor Barry rushes to his side BARRY Adam stay with me ADAM I cant feel my legs Montgomery falls on the Bailiff BAILIFF Take it easy Bee Movie  JS REVISIONS 81307 88 MONTGOMERY Oh what angel of mercy will come forward to suck the poison from my heaving buttocks The JURY recoils JUDGE Please I will have order in this court Order Order please FADE TO SEQ 3400  ADAM AT HOSPITAL INT HOSPITAL  STREET LEVEL ROOM  DAY PRESS PERSON 1 VO The case of the honey bees versus the human race took a pointed turn against the bees yesterday when one of their legal team stung Layton T Montgomery Now heres Don with the 5day A NURSE lets Barry into the room Barry CARRIES a FLOWER BARRY Thank you Barry stands over Adam in a bed Barry lays the flower down next to him The TV is on BARRY CONTD Hey buddy ADAM Hey BARRY Is there much pain Adam has a BEESIZED PAINKILLER HONEY BUTTON near his head that he presses ADAM pressing the button YeahI blew the whole case didnt I Bee Movie  JS REVISIONS 81307 89 BARRY Oh it doesnt matter The important thing is youre alive You could have died ADAM Id be better off dead Look at me Adam THROWS the blanket off his lap revealing a GREEN SANDWICH SWORD STINGER ADAM CONTD voice cracking They got it from the cafeteria they got it from downstairs In a tuna sandwich Look theres a little celery still on it BARRY What was it like to sting someone ADAM I cant explain it It was all adrenalineand thenecstasy Barry looks at Adam BARRY Alright ADAM You think that was all a trap BARRY Of course Im sorry I flew us right into this What were we thinking Look at us were just a couple of bugs in this world ADAM What do you think the humans will do to us if they win BARRY I dont know ADAM I hear they put the roaches in motels That doesnt sound so bad Bee Movie  JS REVISIONS 81307 90 BARRY Adam they check in but they dont check out Adam GULPS ADAM Oh my ANGLE ON the hospital window We see THREE PEOPLE smoking outside on the sidewalk The smoke drifts in Adam COUGHS ADAM CONTD Say could you get a nurse to close that window BARRY Why ADAM The smoke Bees dont smoke BARRY Right Bees dont smoke Bees dont smoke But some bees are smoking Adam thats it Thats our case Adam starts putting his clothes on ADAM It is Its not over BARRY No Get up Get dressed Ive got to go somewhere You get back the court and stall Stall anyway you can CUT TO SEQ 3500  SMOKING GUN INT COURTROOM  THE NEXT DAY Adam is folding a piece of paper into a boat ADAM and assuming youve done step 29 correctly youre ready for the tub Bee Movie  JS REVISIONS 81307 91 ANGLE ON The jury all with paper boats of their own JURORS Ooh ANGLE ON Montgomery frustrated with Gammil whos making a boat also Monty crumples Gammils boat and throws it at him JUDGE Mr Flayman ADAM Yes Yes Your Honor JUDGE Where is the rest of your team ADAM fumbling with his swordstinger Well your honor its interesting You know Bees are trained to fly kind of haphazardly and as a result quite often we dont make very good time I actually once heard a pretty funny story about a bee MONTGOMERY Your Honor havent these ridiculous bugs taken up enough of this courts valuable time Montgomery rolls out from behind his table Hes suspended in a LARGE BABY CHAIR with wheels MONTGOMERY CONTD How much longer are we going to allow these absurd shenanigans to go on They have presented no compelling evidence to support their charges against my clients who have all run perfectly legitimate businesses I move for a complete dismissal of this entire case JUDGE Mr Flayman I am afraid I am going to have to consider Mr Montgomerys motion Bee Movie  JS REVISIONS 81307 92 ADAM But you cant We have a terrific case MONTGOMERY Where is your proof Where is the evidence Show me the smoking gun Barry bursts through the door BARRY Hold it your honor You want a smoking gun Here is your smoking gun Vanessa ENTERS holding a bee smoker Vanessa slams the beekeepers SMOKER onto the judges bench JUDGE What is that BARRY Its a Bee smoker Montgomery GRABS the smoker MONTGOMERY What this This harmless little contraption This couldnt hurt a fly let alone a bee He unintentionally points it towards the bee gallery KNOCKING THEM ALL OUT The jury GASPS The press SNAPS pictures of them BARRY Members of the jury look at what has happened to bees who have never been asked Smoking or Non Is this what nature intended for us To be forcibly addicted to these smoke machines in manmade wooden slat work camps Living out our lives as honey slaves to the white man Barry gestures dramatically towards Montgomerys racially mixed table The BLACK LAWYER slowly moves his chair away GAMMIL What are we going to do Bee Movie  JS REVISIONS 81307 93 MONTGOMERY to Pross Hes playing the species card Barry lands on the scale of justice by the judges bench It balances as he lands BARRY Ladies and gentlemen please FreeTheseBees ANGLE ON Jury chanting Free the bees JUDGE The court finds in favor of the bees The chaos continues Barry flies over to Vanessa with his hand up for a high 5 BARRY Vanessa we won VANESSA Yay I knew you could do it Highfive She high 5s Barry sending him crashing to the table He bounces right back up VANESSA CONTD Oh sorry BARRY Ow Im okay Vanessa do you know what this means All the honey is finally going to belong to the bees Now we wont have to work so hard all the time Montgomery approaches Barry surrounded by the press The cameras and microphones go to Montgomery MONTGOMERY waving a finger This is an unholy perversion of the balance of nature Benson Youll regret this ANGLE ON Barrys deer in headlights expression as the press pushes microphones in his face Bee Movie  JS REVISIONS 81307 94 PRESS PERSON 1 Barry how much honey do you think is out there BARRY Alright alright one at a time SARAH Barry who are you wearing BARRY Uhhh my sweater is Ralph Lauren and I have no pants The Press follows Barry as he EXITS ANGLE ON Adam and Vanessa ADAM putting papers away What if Montgomerys right VANESSA What do you mean ADAM Weve been living the bee way a long time 27 million years DISSOLVE TO SEQ 3600  HONEY ROUNDUP EXT HONEY FARMS APIARY  MONTAGE SARAH VO Congratulations on your victory What are you going to demand as a settlement BARRY VO over montage First were going to demand a complete shutdown of all bee work camps Then we want to get back all the honey that was ours to begin with Every last drop We demand an end to the glorification of the bear as anything more than a filthy smelly bigheaded bad breath stinkmachine Bee Movie  JS REVISIONS 81307 95 I believe were all aware of what they do in the woods We will no longer tolerate derogatory beenegative nicknames unnecessary inclusion of honey in bogus health products and ladeeda teatime human snack garnishments MONTAGE IMAGES Closeup on an ATF JACKET with the YELLOW LETTERS Camera pulls back We see an ARMY OF BEE AND HUMAN AGENTS wearing hastily made Alcohol Tobacco Firearms and Honey jackets Barry supervises The gate to Honey Farms is locked permanently All the smokers are collected and locked up All the bees leave the Apiary CUT TO EXT ATF OUTSIDE OF SUPERMARKET  MONTAGE Agents begin YANKING honey off the supermarket shelves and out of shopping baskets CUT TO EXT NEW HIVE CITY  MONTAGE The bees tear down a honeybear statue CUT TO EXT YELLOWSTONE FOREST  MONTAGE POV of a snipers crosshairs An animated BEAR character lookalike turns his head towards camera BARRY Wait for my signal ANGLE ON Barry lowering his binoculars BARRY CONTD Take him out The sniper SHOOTS the bear It hits him in the shoulder The bear looks at it He gets woozy and the honey jar falls out of his lap an ATFH agent catches it Bee Movie  JS REVISIONS 81307 96 BARRY VO CONTD ATFH AGENT to the bears pig friend Hell have a little nausea for a few hours then hell be fine CUT TO EXT STINGS HOUSE  MONTAGE ATFH agents SLAP CUFFS on Sting who is meditating STING But its just a pranceabout stage name CUT TO INT A WOMANS SHOWER  MONTAGE A WOMAN is taking a shower and using honey shampoo An ATFH agent pulls the shower curtain aside and grabs her bottle of shampoo The woman SCREAMS The agent turns to the 3 other agents and Barry ANGLE ON Barry looking at the label on the shampoo bottle shaking his head and writing in his clipboard CUT TO EXT SUPERMARKET CAFE  MONTAGE Another customer an old lady having her tea with a little jar of honey gets her face pushed down onto the table and turned to the side by two agents One of the agents has a gun on her OLD LADY Cant breathe CUT TO EXT CENTRAL PARK  MONTAGE An OIL DRUM of honey is connected to Barrys hive Bee Movie  JS REVISIONS 81307 97 BARRY Bring it in boys CUT TO SEQ 3650  NO MORE WORK INT HONEX  MONTAGE ANGLE ON The honey goes past the 3cup hashmark and begins to overflow A WORKER BEE runs up to Buzzwell WORKER BEE 1 Mr Buzzwell we just passed 3 cups and theres gallons mores coming I think we need to shutdown KEYCHAIN BEE to Buzzwell Shutdown Weve never shutdown ANGLE ON Buzzwell overlooking the factory floor BUZZWELL Shutdown honey production Stop making honey ANGLE ON TWO BEES each with a KEY BUZZWELL CONTD Turn your key Sir They turn the keys simultaneously War Gamesstyle shutting down the honey machines ANGLE ON the TaffyPull machine Centrifuge and Krelman all slowly come to a stop The bees look around bewildered WORKER BEE 5 What do we do now A BEAT WORKER BEE 6 Cannon ball He jumps into a HONEY VAT doesnt penetrate the surface He looks around and slowly sinks down to his waist Bee Movie  JS REVISIONS 81307 98 EXT HONEX FACTORY THE WHISTLE BLOWS and the bees all stream out the exit CUT TO INT JGATE  CONTINUOUS Lou Loduca gives orders to the pollen jocks LOU LODUCA Were shutting down honey production Mission abort CUT TO EXT CENTRAL PARK Jackson receives the orders midpollination JACKSON Aborting pollination and nectar detail Returning to base CUT TO EXT NEW HIVE CITY ANGLE ON Bees putting suntan lotion on their noses and antennae and sunning themselves on the balconies of the gyms CUT TO EXT CENTRAL PARK ANGLE ON THE FLOWERS starting to DROOP CUT TO INT JGATE JGate is deserted CUT TO Bee Movie  JS REVISIONS 81307 99 EXT NEW HIVE CITY ANGLE ON Bees sunning themselves A TIMER DINGS and they all turn over CUT TO EXT CENTRAL PARK TIME LAPSE of Central Park turning brown CUT TO EXT VANESSAS FLORIST SHOP CLOSEUP SHOT Vanessa writes Sorry No more flowers on a Closed sign an turns it facing out CUT TO SEQ 3700  IDLE HIVE EXT NEW HIVE CITY  DAY Barry flies at high speed TRACKING SHOT into the hive through the lobby of Honex and into Adams office CUT TO INT ADAMS OFFICE  CONTINUOUS Barry meets Adam in his office Adams office is in disarray There are papers everywhere Hes filling up his cardboard hexagon box BARRY out of breath Adam you wouldnt believe how much honey was out there ADAM Oh yeah BARRY Whats going on around here Where is everybody Are they out celebrating Bee Movie  JS REVISIONS 81307 100 ADAM exiting with a cardboard box of belongings No theyre just home They dont know what to do BARRY Hmmm ADAM Theyre laying out theyre sleeping in I heard your Uncle Carl was on his way to San Antonio with a cricket BARRY At least we got our honey back They walk through the empty factory ADAM Yeah but sometimes I think so what if the humans liked our honey Who wouldnt Its the greatest thing in the world I was excited to be a part of making it ANGLE ON Adams desk on its side in the hall ADAM CONTD This was my new desk This was my new job I wanted to do it really well And nowand now I cant Adam EXITS CUT TO SEQ 3900  WORLD WITHOUT BEES INT STAIRWELL Vanessa and Barry are walking up the stairs to the roof BARRY I dont understand why theyre not happy We have so much now I thought their lives would be better Bee Movie  JS REVISIONS 81307 101 VANESSA Hmmm BARRY Theyre doing nothing Its amazing honey really changes people VANESSA You dont have any idea whats going on do you BARRY What did you want to show me VANESSA This They reach the top of the stairs Vanessa opens the door CUT TO EXT VANESSAS ROOFTOP  CONTINUOUS Barry sees Vanessas flower pots and small garden have all turned brown BARRY What happened here VANESSA That is not the half of it Vanessa turns Barry around with her two fingers revealing the view of Central Park which is also all brown BARRY Oh no Oh my Theyre all wilting VANESSA Doesnt look very good does it BARRY No VANESSA And whos fault do you think that is Bee Movie  JS REVISIONS 81307 102 BARRY Mmmmyou know Im going to guess bees VANESSA Bees BARRY Specifically me I guess I didnt think that bees not needing to make honey would affect all these other things VANESSA And its not just flowers Fruits vegetablesthey all need bees BARRY Well thats our whole SAT test right there VANESSA So you take away the produce that affects the entire animal kingdom And then of course BARRY The human species VANESSA clearing throat Ahem BARRY Oh So if theres no more pollination it could all just go south here couldnt it VANESSA And I know this is also partly my fault Barry takes a long SIGH BARRY How about a suicide pact VANESSA not sure if hes joking How would we do it BARRY Ill sting you you step on me Bee Movie  JS REVISIONS 81307 103 VANESSA That just kills you twice BARRY Right right VANESSA Listen Barry Sorry but Ive got to get going She EXITS BARRY looking out over the park Had to open my mouth and talk looking back Vanessa Vanessa is gone CUT TO SEQ 3935  GOING TO PASADENA EXT NY STREET  CONTINUOUS Vanessa gets into a cab Barry ENTERS BARRY Vanessa Why are you leaving Where are you going VANESSA To the final Tournament of Roses parade in Pasadena They moved it up to this weekend because all the flowers are dying Its the last chance Ill ever have to see it BARRY Vanessa I just want to say Im sorry I never meant it to turn out like this VANESSA I know Me neither Vanessa cab drives away Bee Movie  JS REVISIONS 81307 104 BARRY chuckling to himself Tournament of Roses Roses cant do sports Wait a minuteroses Roses Roses Vanessa Barry follows shortly after He catches up to it and he pounds on the window Barry follows shortly after Vanessas cab He catches up to it and he pounds on the window INT TAXI  CONTINUOUS Barry motions for her to roll the window down She does so BARRY Roses VANESSA Barry BARRY as he flies next to the cab Roses are flowers VANESSA Yes they are BARRY Flowers bees pollen VANESSA I know Thats why this is the last parade BARRY Maybe not The cab starts pulling ahead of Barry BARRY CONTD re driver Could you ask him to slow down VANESSA Could you slow down The cabs slows Barry flies in the window and lands in the change box which closes on him Bee Movie  JS REVISIONS 81307 105 VANESSA CONTD Barry Vanessa lets him out Barry stands on the change box in front of the drivers license BARRY Okay I made a huge mistake This is a total disaster and its all my fault VANESSA Yes it kind of is BARRY Ive ruined the planet And I wanted to help with your flower shop Instead Ive made it worse VANESSA Actually its completely closed down BARRY Oh I thought maybe you were remodeling Nonetheless I have another idea And its greater than all my previous great ideas combined VANESSA I dont want to hear it Vanessa closes the change box on Barry BARRY opening it again Alright heres what Im thinking They have the roses the roses have the pollen I know every bee plant and flower bud in this park All weve got to do is get what theyve got back here with what weve got VANESSA Bees BARRY Park VANESSA Pollen Bee Movie  JS REVISIONS 81307 106 BARRY Flowers VANESSA Repollination BARRY on luggage handle going up Across the nation CUT TO SEQ 3950  ROSE PARADE EXT PASADENA PARADE BARRY VO Alright Tournament of Roses Pasadena California Theyve got nothing but flowers floats and cotton candy Security will be tight VANESSA I have an idea CUT TO EXT FLOAT STAGING AREA ANGLE ON Barry and Vanessa approaching a HEAVILY ARMED GUARD in front of the staging area VANESSA Vanessa Bloome FTD Official floral business He leans in to look at her badge She SNAPS IT SHUT VANESSA CONTD Oh its real HEAVILY ARMED GUARD Sorry maam Thats a nice brooch by the way VANESSA Thank you It was a gift Bee Movie  JS REVISIONS 81307 107 They ENTER the staging area BARRY VO Then once were inside we just pick the right float VANESSA How about the Princess and the Pea BARRY Yeah VANESSA I can be the princess and BARRY yes I think VANESSA You could be BARRY Ive VANESSA The pea BARRY Got it CUT TO EXT FLOAT STAGING AREA  A FEW MOMENTS LATER Barry dressed as a PEA flies up and hovers in front of the princess on the Princess and the Pea float The float is sponsored by Inflatabed and a SIGN READS Inflatabed If it blows its ours BARRY Sorry Im late Where should I sit PRINCESS What are you BARRY I believe Im the pea PRINCESS The pea Its supposed to be under the mattresses Bee Movie  JS REVISIONS 81307 108 BARRY Not in this fairy tale sweetheart PRINCESS Im going to go talk to the marshall BARRY You do that This whole parade is a fiasco She EXITS Vanessa removes the stepladder The princess FALLS Barry and Vanessa take off in the float BARRY CONTD Lets see what this baby will do ANGLE ON Guy with headset talking to drivers HEADSET GUY Hey The float ZOOMS by A young CHILD in the stands TIMMY cries CUT TO EXT FLOAT STAGING AREA  A FEW MOMENTS LATER ANGLE ON Vanessa putting the princess hat on BARRY VO Then all we do is blend in with traffic without arousing suspicion CUT TO EXT THE PARADE ROUTE  CONTINUOUS The floats go flying by the crowds Barry and Vanessas float CRASHES through the fence CUT TO Bee Movie  JS REVISIONS 81307 109 EXT LA FREEWAY Vanessa and Barry speed dodging and weaving down the freeway BARRY VO And once were at the airport theres no stopping us CUT TO EXT LAX AIRPORT Barry and Vanessa pull up to the curb in front of an TSA AGENT WITH CLIPBOARD TSA AGENT Stop Security Did you and your insect pack your own float VANESSA OC Yes TSA AGENT Has this float been in your possession the entire time VANESSA OC Since the paradeyes ANGLE ON Barry holding his shoes TSA AGENT Would you remove your shoes and everything in your pockets Can you remove your stinger Sir BARRY Thats part of me TSA AGENT I know Just having some fun Enjoy your flight CUT TO EXT RUNWAY Barry and Vanessas airplane TAKES OFF Bee Movie  JS REVISIONS 81307 110 BARRY OC Then if were lucky well have just enough pollen to do the job DISSOLVE TO SEQ 4025  COCKPIT FIGHT INT AIRPLANE Vanessa is on the aisle Barry is on a laptop calculating flowers pollen number of bees airspeed etc He does a Stomp dance on the keyboard BARRY Can you believe how lucky we are We have just enough pollen to do the job I think this is going to work Vanessa VANESSA Its got to work PILOT VO Attention passengers This is Captain Scott Im afraid we have a bit of bad weather in the New York area And looks like were going to be experiencing a couple of hours delay VANESSA Barry these are cut flowers with no water Theyll never make it BARRY Ive got to get up there and talk to these guys VANESSA Be careful Barry flies up to the cockpit door CUT TO INT COCKPIT  CONTINUOUS A female flight attendant ANGELA is in the cockpit with the pilots Bee Movie  JS REVISIONS 81307 111 Theres a KNOCK at the door BARRY CO Hey can I get some help with this Sky Mall Magazine Id like to order the talking inflatable travel pool filter ANGELA to the pilots irritated Excuse me CUT TO EXT CABIN  CONTINUOUS Angela opens the cockpit door and looks around She doesnt see anybody ANGLE ON Barry hidden on the yellow and black caution stripe As Angela looks around Barry zips into the cockpit CUT TO INT COCKPIT BARRY Excuse me Captain I am in a real situation here PILOT pulling an earphone back to the copilot What did you say Hal COPILOT I didnt say anything PILOT he sees Barry Ahhh Bee BARRY No no Dont freak out Theres a chance my entire species COPILOT taking off his earphones Ahhh Bee Movie  JS REVISIONS 81307 112 The pilot grabs a DUSTBUSTER vacuum cleaner He aims it around trying to vacuum up Barry The copilot faces camera as the pilot tries to suck Barry up Barry is on the other side of the copilot As they doseydo the toupee of the copilot begins to come up still attached to the front COPILOT CONTD What are you doing Stop The toupee comes off the copilots head and sticks in the Dustbuster Barry runs across the bald head BARRY Wait a minute Im an attorney COPILOT Whos an attorney PILOT Dont move The pilot uses the Dustbuster to try and mash Barry who is hovering in front of the copilots nose and knocks out the copilot who falls out of his chair hitting the life raft release button The life raft inflates hitting the pilot knocking him into a wall and out cold Barry surveys the situation BARRY Oh Barry CUT TO INT AIRPLANE CABIN Vanessa studies her laptop looking serious SFX PA CRACKLE BARRY VO in captain voice Good afternoon passengers this is your captain speaking Would a Miss Vanessa Bloome in 24F please report to the cockpit And please hurry Bee Movie  JS REVISIONS 81307 113 ANGLE ON The aisle and Vanessa head popping up CUT TO INT COCKPIT Vanessa ENTERS VANESSA What happened here BARRY I tried to talk to them but then there was a Dustbuster a toupee a life raft explodedNow ones bald ones in a boat and theyre both unconscious VANESSA Is that another bee joke BARRY No No ones flying the plane The AIR TRAFFIC CONTROLLER BUD speaks over the radio BUD This is JFK control tower Flight 356 whats your status Vanessa presses a button and the intercom comes on VANESSA This is Vanessa Bloome Im a florist from New York BUD Wheres the pilot VANESSA Hes unconscious and so is the copilot BUD Not good Is there anyone onboard who has flight experience A BEAT BARRY As a matter of fact there is Bee Movie  JS REVISIONS 81307 114 BUD Whos that VANESSA Barry Benson BUD From the honey trial Oh great BARRY Vanessa this is nothing more than a big metal bee Its got giant wings huge engines VANESSA I cant fly a plane BARRY Why not Isnt John Travolta a pilot VANESSA Yes BARRY How hard could it be VANESSA Wait a minute Barry were headed into some lightning CUT TO Vanessa shrugs and takes the controls SEQ 4150  BARRY FLIES PLANE INT BENSON HOUSE The family is all huddled around the TV at the Benson house ANGLE ON TV Bob Bumble is broadcasting BOB BUMBLE This is Bob Bumble We have some latebreaking news from JFK airport where a very suspenseful scene is developing Barry Benson fresh off his stunning legal victory Bee Movie  JS REVISIONS 81307 115 Adam SPRAYS a can of HONEYWHIP into his mouth ADAM Thats Barry BOB BUMBLE is now attempting to land a plane loaded with people flowers and an incapacitated flight crew EVERYONE Flowers CUT TO INT AIR TRAFFIC CONTROL TOWER BUD Well we have an electrical storm in the area and two individuals at the controls of a jumbo jet with absolutely no flight experience JEANETTE CHUNG Just a minute Mr Ditchwater theres a honey bee on that plane BUD Oh Im quite familiar with Mr Bensons work and his noaccount compadres Havent they done enough damage already JEANETTE CHUNG But isnt he your only hope right now BUD Come on technically a bee shouldnt be able to fly at all CUT TO INT COCKPIT Barry REACTS BUD The wings are too small their bodies are too big Bee Movie  JS REVISIONS 81307 116 BARRY over PA Hey hold on a second Havent we heard this million times The surface area of the wings and the body mass doesnt make sense JEANETTE CHUNG Get this on the air CAMERAMAN You got it CUT TO INT BEE TV CONTROL ROOM An engineer throws a switch BEE ENGINEER Stand by Were going live The ON AIR sign illuminates CUT TO INT VARIOUS SHOTS OF NEW HIVE CITY The news report plays on TV The pollen jocks are sitting around playing paddleball Wheelo and one of them is spinning his helmet on his finger Buzzwell is in an office cubicle playing computer solitaire Barrys family and Adam watch from their living room Bees sitting on the street curb turn around to watch the TV BARRY Mr Ditchwater the way we work may be a mystery to you because making honey takes a lot of bees doing a lot of small jobs But let me tell you something about a small job If you do it really well it makes a big difference More than we realized To us to everyone Thats why I want to get bees back to doing what we do best Bee Movie  JS REVISIONS 81307 117 Working together Thats the bee way Were not made of Jello We get behind a fellow Black and yellow CROWD OF BEES Hello CUT TO INT COCKPIT Barry is giving orders to Vanessa BARRY Left right down hover VANESSA Hover BARRY Forget hover VANESSA You know what This isnt so hard Vanessa pretends to HONK THE HORN VANESSA CONTD Beep beep Beep beep A BOLT OF LIGHTNING HITS the plane The plane takes a sharp dip VANESSA CONTD Barry what happened BARRY noticing the control panel Wait a minute I think we were on autopilot that whole time VANESSA That may have been helping me BARRY And now were not VANESSA VO folding her arms Well then it turns out I cannot fly a plane Bee Movie  JS REVISIONS 81307 118 BARRY CONTD Vanessa struggles with the yoke CUT TO EXT AIRPLANE The airplane goes into a steep dive CUT TO SEQ 4175  CRASH LANDING INT JGATE An ALERT SIGN READING Hive Alert We Need Then the SIGNAL goes from Two Bees Some Bees Every Bee There Is Lou Loduca gathers the pollen jocks at JGate LOU LODUCA All of you lets get behind this fellow Move it out The bees follow Lou Loduca and EXIT JGate CUT TO INT AIRPLANE COCKPIT BARRY Our only chance is if I do what I would do and you copy me with the wings of the plane VANESSA You dont have to yell BARRY Im not yelling We happen to be in a lot of trouble here VANESSA Its very hard to concentrate with that panicky tone in your voice BARRY Its not a tone Im panicking CUT TO Bee Movie  JS REVISIONS 81307 119 EXT JFK AIRPORT ANGLE ON The bees arriving and massing at the airport CUT TO INT COCKPIT Barry and Vanessa alternately SLAP EACH OTHER IN THE FACE VANESSA I dont think I can do this BARRY Vanessa pull yourself together Listen to me you have got to snap out of it VANESSA You snap out of it BARRY You snap out of it VANESSA You snap out of it BARRY You snap out of it VANESSA You snap out of it CUT TO EXT AIRPLANE A GIGANTIC SWARM OF BEES flies in to hold the plane up CUT TO INT COCKPIT  CONTINUOUS BARRY You snap out of it VANESSA You snap out of it Bee Movie  JS REVISIONS 81307 120 BARRY You snap VANESSA Hold it BARRY about to slap her again Why Come on its my turn VANESSA How is the plane flying Barrys antennae ring BARRY I dont know answering Hello CUT TO EXT AIRPLANE ANGLE ON The underside of the plane The pollen jocks have massed all around the underbelly of the plane and are holding it up LOU LODUCA Hey Benson have you got any flowers for a happy occasion in there CUT TO INT COCKPIT Lou Buzz Splitz and Jackson come up alongside the cockpit BARRY The pollen jocks VANESSA They do get behind a fellow BARRY Black and yellow LOU LODUCA over headset Hello Bee Movie  JS REVISIONS 81307 121 Alright you two what do you say we drop this tin can on the blacktop VANESSA What blacktop Where I cant see anything Can you BARRY No nothing Its all cloudy CUT TO EXT RUNWAY Adam SHOUTS ADAM Come on youve got to think bee Barry Thinking bee thinking bee ANGLE ON Overhead shot of runway The bees are in the formation of a flower In unison they move causing the flower to FLASH YELLOW AND BLACK BEES chanting Thinking bee thinking bee CUT TO INT COCKPIT We see through the swirling mist and clouds A GIANT SHAPE OF A FLOWER is forming in the middle of the runway BARRY Wait a minute I think Im feeling something VANESSA What BARRY I dont know but its strong And its pulling me like a 27 million year old instinct Bring the nose of the plane down Bee Movie  JS REVISIONS 81307 122 LOU LODUCA CONTD EXT RUNWAY All the bees are on the runway chanting Thinking Bee CUT TO INT CONTROL TOWER RICK What in the world is on the tarmac ANGLE ON Dave OTS onto runway seeing a flower being formed by millions of bees BUD Get some lights on that CUT TO EXT RUNWAY ANGLE ON AIRCRAFT LANDING LIGHT SCAFFOLD by the side of the runway illuminating the bees in their flower formation INT COCKPIT BARRY Vanessa aim for the flower VANESSA Oh okay BARRY Cut the engines VANESSA Cut the engines BARRY Were going in on bee power Ready boys LOU LODUCA Affirmative CUT TO Bee Movie  JS REVISIONS 81307 123 INT AIRPLANE COCKPIT BARRY Good good easy now Land on that flower Ready boys Give me full reverse LOU LODUCA Spin it around The plane attempts to land on top of an Aloha Airlines plane with flowers painted on it BARRY VO I mean the giant black and yellow pulsating flower made of millions of bees VANESSA Which flower BARRY That flower VANESSA Im aiming at the flower The plane goes after a FAT GUY IN A HAWAIIAN SHIRT BARRY VO Thats a fat guy in a flowered shirt The other other flower The big one He snaps a photo and runs away BARRY CONTD Full forward Ready boys Nose down Bring your tail up Rotate around it VANESSA Oh this is insane Barry BARRY This is the only way I know how to fly CUT TO Bee Movie  JS REVISIONS 81307 124 AIR TRAFFIC CONTROL TOWER BUD Am I kookoo kachoo or is this plane flying in an insectlike pattern CUT TO EXT RUNWAY BARRY VO Get your nose in there Dont be afraid of it Smell it Full reverse Easy just drop it Be a part of it Aim for the center Now drop it in Drop it in woman The plane HOVERS and MANEUVERS landing in the center of the giant flower like a bee The FLOWERS from the cargo hold spill out onto the runway INT AIPLANE CABIN The passengers are motionless for a beat PASSENGER Come on already They hear the ding ding and all jump up to grab their luggage out of the overheads SEQ 4225  RUNWAY SPEECH EXT RUNWAY  CONTINUOUS The INFLATABLE SLIDES pop out the side of the plane The passengers escape Barry and Vanessa slide down out of the cockpit Barry and Vanessa exhale a huge breath VANESSA Barry we did it You taught me how to fly Vanessa raises her hand up for a high five Bee Movie  JS REVISIONS 81307 125 BARRY Yes No high five VANESSA Right ADAM Barry it worked Did you see the giant flower BARRY What giant flower Where Of course I saw the flower That was genius man Genius ADAM Thank you BARRY But were not done yet Barry flies up to the wing of the plane and addresses the bee crowd BARRY CONTD Listen everyone This runway is covered with the last pollen from the last flowers available anywhere on Earth That means this is our last chance Were the only ones who make honey pollinate flowers and dress like this If were going to survive as a species this is our moment So what do you all say Are we going to be bees or just Museum of Natural History key chains BEES Were bees KEYCHAIN BEE Keychain BARRY Then follow me Except Keychain BUZZ Hold on Barry Youve earned this Buzz puts a pollen jock jacket and helmet with Barrys name on it on Barry Bee Movie  JS REVISIONS 81307 126 BARRY Im a pollen jock looking at the jacket The sleeves are a little long And its a perfect fit All Ive got to do are the sleeves The Pollen Jocks toss Barry a gun BARRY CONTD Oh yeah ANGLE ON Martin and Janet Benson JANET BENSON Thats our Barry All the bees descend upon the flowers on the tarmac and start collecting pollen CUT TO SEQ 4250  REPOLLINATION EXT SKIES  CONTINUOUS The squadron FLIES over the city REPOLLINATING trees and flowers as they go Barry breaks off from the group towards Vanessas flower shop CUT TO EXT VANESSAS FLOWER SHOP  CONTINUOUS Barry REPOLLINATES Vanessas flowers CUT TO EXT CENTRAL PARK  CONTINUOUS ANGLE ON Timmy with a frisbee as the bees fly by TIMMY Mom the bees are back Bee Movie  JS REVISIONS 81307 127 Central Park is completely repollinated by the bees DISSOLVE TO INT HONEX  CONTINUOUS Honex is back to normal and everyone is busily working ANGLE ON Adam putting his Krelman hat on ADAM If anyone needs to make a call nows the time Ive got a feeling well be working late tonight The bees CHEER CUT TO SEQ 4355 EXT VANESSAS FLOWER SHOP With a new sign out front Vanessa  Barry Flowers Honey Legal Advice DISSOLVE TO INT FLOWER COUNTER Vanessa doing a brisk trade with many customers CUT TO INT FLOWER SHOP  CONTINUOUS Vanessa is selling flowers In the background there are SHELVES STOCKED WITH HONEY VANESSA OC Dont forget these Have a great afternoon Yes can I help whos next Whos next Would you like some honey with that It is beeapproved SIGN ON THE BACK ROOM DOOR READS Barry Benson Insects at Law Bee Movie  JS REVISIONS 81307 128 Camera moves into the back room ANGLE ON Barry ANGLE ON Barrys COW CLIENT COW Milk cream cheeseits all me And I dont see a nickel BARRY Uh huh Uh huh COW breaking down Sometimes I just feel like a piece of meat BARRY I had no idea VANESSA Barry Im sorry have you got a moment BARRY Would you excuse me My mosquito associate here will be able to help you Mooseblood ENTERS MOOSEBLOOD Sorry Im late COW Hes a lawyer too MOOSEBLOOD Maam I was already a bloodsucking parasite All I needed was  a briefcase  ANGLE ON Flower Counter VANESSA to customer Have a great afternoon to Barry Barry I just got this huge tulip order for a wedding and I cant get them anywhere Bee Movie  JS REVISIONS 81307 129 BARRY Not a problem Vannie Just leave it to me Vanessa turns back to deal with a customer VANESSA Youre a lifesaver Barry to the next customer Can I help whos next Whos next ANGLE ON Vanessa smiling back at Barry Barry smiles too then snaps himself out of it BARRY speaks into his antennae Alright Scramble jocks its time to fly VANESSA Thank you Barry EXT FLOWER SHOP  CONTINUOUS ANGLE ON Ken and Andy walking down the street KEN noticing the new sign Augh What in the world Its that bee again ANDY guiding Ken protectively Let it go Kenny KEN That bee is living my life When will this nightmare end ANDY Let it all go They dont break stride ANGLE ON Camera in front of Barry as he flies out the door and up into the sky Pollen jocks fold in formation behind him as they zoom into the park BARRY to Splitz Beautiful day to fly Bee Movie  JS REVISIONS 81307 130 JACKSON Sure is BARRY Between you and me I was dying to get out of that office FADE OUT Bee Movie  JS REVISIONS 81307 131";
        private static bool ClickTP;
        private static bool InfJump;
        GameObject cont;
        private static Page ourRoot;
        private static bool Prop;
        private static bool propspam;
        private static bool autostaffdis = false;

        private static GameObject UIHolder;

        public static void QueueToast(string msg)
        {
            QuickMenuAPI.ShowAlertToast(msg, 5);
        }
        public static void togglevoid(bool togglestate)
        {
            if (togglestate)
            {
                RPCHelper.StartRPC();

            }
            else
            {
                RPCHelper.StopRPC();
            }
        }
        
        static void initqmobjs()
        {
            UnityWebRequest unityWebRequest = UnityWebRequest.Get("https://raw.githubusercontent.com/bakersrule2020/InfiniteCVR/main/thankyou.mp3");

            DownloadHandlerAudioClip dh = new DownloadHandlerAudioClip(unityWebRequest.url, AudioType.MPEG);
            unityWebRequest.downloadHandler = dh;

            unityWebRequest.SendWebRequest().completed += operation =>
            {
                if (unityWebRequest.result == UnityWebRequest.Result.Success)
                {
                    dh.streamAudio = true;

                    AudioClip QMMusic = dh.audioClip;
                    var DDOL = GetDontDestroyOnLoad();
                    GameObject qm = GameObject.CreatePrimitive(PrimitiveType.Cube);
                   
                    foreach (var obj in DDOL.GetRootGameObjects()){
                        if(obj.name == "Cohtml")
                        {
                            foreach(var qmobj in obj.GetAllChildren())
                            {
                                if (qmobj.name == "QuickMenu")
                                {
                                    MelonLogger.Msg("Got QuickMenu object!");
                                    GameObject.DestroyImmediate(qm);
                                    qm = qmobj;
                                }
                            }
                        }
                    }
                    QMMusicSource = qm.AddComponent<AudioSource>();
                    
                   
                    if (QMMusicSource != null)
                    { 
                        QMMusicSource.clip = QMMusic;
                        QMMusicSource.volume = 0.8f;
                        QMMusicSource.loop = true;
                        
                        IsQMMusicInit = true;
                    }
                    else
                    {
                        MelonLogger.Warning("QMMusicSource is null.");
                        MelonLogger.Msg("QMMusicSource Name: " + QMMusicSource.name);
                    }
                }
                else
                {
                    MelonLogger.Warning("MenuBG Init Failure: " + unityWebRequest.error);
                }
            };
        }

        static List<GameObject> GetAllObjectsInScene()
        {
            List<GameObject> objectsInScene = new List<GameObject>();

            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                Thread.Sleep(1);

                objectsInScene.Add(go);
            }

            return objectsInScene;
        }
        static Scene GetDontDestroyOnLoad()
        {
            var test = GameObject.CreatePrimitive(PrimitiveType.Cube);
            DontDestroyOnLoad.DontDestroyOnLoad(test);
            var ddol = test.scene;
            GameObject.DestroyImmediate(test);
            return ddol;
            
        }
        static void SendHudNotif(string title, string message)
        {
            CohtmlHud.Instance.ViewDropText(title, message);
        }
        public static GameObject objpub;
        
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName != "Login" && sceneName != "Preparation" && sceneName != "Init" && sceneName != "HeadQuarters")
            {
                MusicPlayer.CreateMusicFolder();
                initqmobjs();
                MusicPlayer.InitMusic();
                QM = GameObject.Find("QuickMenu");
                //PlayerListUI.InitPlayerList();
                //InitCustomUI();
            }
        }
        public void ClearRAM()
        {
            GC.Collect();
            Resources.UnloadUnusedAssets();
        }
        public void SpawnFunnyOnTarget()
        {
            string wcid = "998c3706-0d99-498d-bcc6-f5f4183058f2";
            Vector3 targetpos = GameObject.Find(plrsel + "/[PlayerAvatar]/_CVRAvatar(Clone)").transform.position;
            PlayerSetup.Instance.SpawnProp(wcid, GameObject.Find(plrsel + "/[PlayerAvatar]/_CVRAvatar(Clone)").transform.position);
        }
        private void AddBoxCollider(GameObject gameObject)
        {
            RectTransform component = gameObject.GetComponent<RectTransform>();
            bool flag = component != null;
            if (flag)
            {
                var boxCollider = gameObject.AddComponent<BoxCollider>();
                boxCollider.size = new Vector3(component.rect.width, component.rect.height, 0.01f);
                boxCollider.isTrigger = true;
            }
        }
        private void PopulateListWithItems(GameObject content)
        {
            GameObject cont = this.cont;
            if (cont != null)
                return;
            Transform transform = cont.transform;
            foreach (Component component in transform)
                GameObject.Destroy(component.gameObject);
            if (plList != null)
            {
                foreach (string[] pl in plList)
                {
                    if (pl[1].ToLower() == "true")
                        CreateTextItem("[Friend] " + pl[0], transform, new Color?(Color.blue));
                    else
                        CreateTextItem(pl[0], transform.transform);
                }
            }
            else
                MelonLogger.Error("plList is null!");
        }
        private void CreateTextItem(string text, Transform parent, Color? col = null)
        {
            Color color = col ?? Color.white;
            GameObject gameObject = new GameObject("ListItem - " + text);
            gameObject.transform.SetParent(parent, false);
            gameObject.AddComponent<HighlightEffect>();
            RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(200f, 35f);
            TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
            TMP_FontAsset tmp_FontAsset = Resources.FindObjectsOfTypeAll<TMP_FontAsset>()[0];
            bool flag = tmp_FontAsset == null;
            if (flag)
            {
                MelonLogger.Error("Failed to load TMP_FontAsset.");
            }
            textMeshProUGUI.font = tmp_FontAsset;
            textMeshProUGUI.fontSize = 4f;
            textMeshProUGUI.color = color;
            textMeshProUGUI.text = text;
            gameObject.SetActive(true);
        }

        public void InitCustomUI()
        {
            if (!CustomUIInit)
            {
                CustomUIInit = true;
                GameObject cont;
                UIHolder = new GameObject("Infinite_UIHolder");
                UIHolder.SetActive(false);
                Material bmat = new Material(Shader.Find("UI/Default"));
                Canvas canvas = UIHolder.AddComponent<Canvas>();
                GameObject sr = new GameObject();

                sr.transform.SetParent(canvas.transform, false);
                UIHolder.AddComponent<CanvasScaler>();
                UIHolder.AddComponent<GraphicRaycaster>();
                UIHolder.transform.localScale = new Vector3(0.005f, 0.01f, 1f);
                UIHolder.transform.localPosition = new Vector3(-0.62f, 0f, 0f);
                UIHolder.transform.SetParent(QM.transform, false);
                canvas.renderMode = RenderMode.WorldSpace;

                GameObject bg = new GameObject("Background");
                bg.transform.SetParent(UIHolder.transform, false);
                UnityEngine.UI.Image bgImage = bg.AddComponent<UnityEngine.UI.Image>();
                Assembly asm = Assembly.GetExecutingAssembly();
                //Material bmat = new Material(Shader.Find("UI/Default"));
                bgImage.material = bmat;
                bmat.mainTexture = UITextureHelper.LoadTextureFromAssembly(asm, "ZuluClientCVR.Resources.menubg.png");
                RectTransform bgRect = bg.GetComponent<RectTransform>();
                bgRect.anchorMin = new Vector2(0, 0);
                bgRect.anchorMax = new Vector2(1, 1);
                bgRect.sizeDelta = UIHolder.transform.localScale;


                bool flag = UIHolder == null;
                if (flag)
                {
                    MelonLogger.Error("canvasGO is not set. Please ensure it is initialized and active before populating the list container.");
                }
                else
                {
                    UIHolder.AddComponent<HighlightEffect>();
                    Rigidbody rigidbody = UIHolder.AddComponent<Rigidbody>();
                    rigidbody.isKinematic = true;
                    rigidbody.detectCollisions = true;
                    GameObject gameObject = new GameObject("ListContainer");
                    gameObject.transform.SetParent(UIHolder.transform, false);
                    gameObject.transform.localPosition = new Vector3(5f, -3f, 0f);
                    gameObject.transform.transform.localScale = new Vector3(1f, 0.9f, 1f);
                    GameObject gameObject2 = new GameObject("ScrollView");
                    gameObject2.transform.SetParent(gameObject.transform, false);
                    gameObject2.AddComponent<RectTransform>();
                    CVRClient idk = new CVRClient();
                    idk.AddBoxCollider(gameObject2);
                    ScrollRect scrollRect = gameObject2.AddComponent<ScrollRect>();
                    gameObject2.AddComponent<CVRInteractable>();
                    GameObject gameObject3 = new GameObject("Viewport");
                    gameObject3.transform.localScale = new Vector3(gameObject3.transform.localScale.x, gameObject3.transform.localScale.y, gameObject3.transform.localScale.z + 1f);
                    gameObject3.transform.SetParent(gameObject2.transform, false);
                    RectTransform rectTransform = gameObject3.AddComponent<RectTransform>();
                    rectTransform.anchorMin = new Vector2(0f, 0f);
                    rectTransform.anchorMax = new Vector2(1f, 1f);
                    rectTransform.sizeDelta = new Vector2(0f, 0f);
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                    gameObject3.AddComponent<Mask>().showMaskGraphic = false;
                    gameObject3.AddComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                    gameObject3.AddComponent<CVR_Menu_Pointer_Reciever>();
                    GameObject gameObject4 = new GameObject("Scrollbar");
                    gameObject4.transform.localScale = new Vector3(gameObject4.transform.localScale.x, gameObject4.transform.localScale.y, gameObject4.transform.localScale.z + 1f);
                    gameObject4.transform.SetParent(gameObject2.transform, false);
                    Scrollbar scrollbar = gameObject4.AddComponent<Scrollbar>();
                    scrollbar.direction = Scrollbar.Direction.TopToBottom;
                    GameObject gameObject5 = new GameObject("Handle");
                    gameObject5.transform.SetParent(gameObject4.transform, false);
                    Image image = gameObject5.AddComponent<Image>();
                    image.color = Color.white;
                    scrollbar.handleRect = gameObject5.GetComponent<RectTransform>();
                    gameObject5.GetComponent<RectTransform>().sizeDelta = new Vector2(2f, 0f);
                    gameObject5.transform.localScale = new Vector3(gameObject5.transform.localScale.x, gameObject5.transform.localScale.y, gameObject5.transform.localScale.z + 1f);
                    RectTransform component = gameObject4.GetComponent<RectTransform>();
                    component.sizeDelta = new Vector2(2f, 0f);
                    component.anchorMin = new Vector2(1f, 0f);
                    component.anchorMax = new Vector2(1f, 1f);
                    component.pivot = new Vector2(1f, 0.5f);
                    component.anchoredPosition = new Vector2(-15f, 0f);
                    component.offsetMin = new Vector2(component.offsetMin.x, 0f);
                    component.offsetMax = new Vector2(component.offsetMax.x, 0f);
                    scrollRect.verticalScrollbar = scrollbar;
                    scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                    scrollRect.verticalScrollbarSpacing = -3f;
                    GameObject gameObject6 = new GameObject("Content-BDM");
                    cont = gameObject6;
                    gameObject6.transform.SetParent(gameObject3.transform, false);
                    RectTransform rectTransform2 = gameObject6.AddComponent<RectTransform>();
                    rectTransform2.sizeDelta = new Vector2(0f, 0f);
                    rectTransform2.anchorMin = new Vector2(0f, 0f);
                    rectTransform2.anchorMax = new Vector2(1f, 1f);
                    rectTransform2.pivot = new Vector2(0.5f, 1f);
                    gameObject6.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                    VerticalLayoutGroup verticalLayoutGroup = gameObject6.AddComponent<VerticalLayoutGroup>();
                    verticalLayoutGroup.childForceExpandWidth = true;
                    verticalLayoutGroup.childForceExpandHeight = false;
                    verticalLayoutGroup.childControlWidth = true;
                    verticalLayoutGroup.childControlHeight = true;
                    verticalLayoutGroup.childAlignment = TextAnchor.UpperLeft;
                    verticalLayoutGroup.spacing = 2f;
                    gameObject6.AddComponent<CVR_Menu_Pointer_Reciever>();
                    gameObject6.AddComponent<HighlightEffect>();
                    scrollRect.content = rectTransform2;
                    scrollRect.viewport = rectTransform;
                    scrollRect.horizontal = false;
                    PopulateListWithItems(gameObject6);

                    
                }


            }
        }
       static void switchavibyid()
        {
            void doit(string text)
            {
                var aviid = text;
                if (aviid == null)
                {
                    AssetManagement.Instance.LoadLocalAvatar(aviid);
                    SendHudNotif("Infinite", "Switching...");
                }
                
            }
            QuickMenuAPI.OpenKeyboard("", doit);
          
        }
        static void forcefly()
        {
            Fly = true;
        }
        public override void OnInitializeMelon()
        {
           
            propspam = false;
            Fly = false;
            drawclickgui = true;
            drawconsolegui = true;
            InfJump = false;
            RPCHelper.StartRPC();

            Console.Clear();
            MelonLogger.Msg(@"
Made by tocat
Don't skid or else i will force you to step on legos");
            MelonLogger.Msg("Initializing Icons...");

            Assembly l_assembly = Assembly.GetExecutingAssembly();
            string l_assemblyName = l_assembly.GetName().Name;

            
            var resourceStream = l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.InfLogo.png");
            if (resourceStream != null)
            {

                QuickMenuAPI.PrepareIcon("OurMod", "eaclogo", resourceStream);
                QuickMenuAPI.PrepareIcon("OurMod", "remod", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.remod.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "admin", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.admin.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "tools", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.tools.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "teleport", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.teleport.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "play", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.play.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "tocat", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.tocat.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "discord", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.discord.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "log", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.log.png"));
                QuickMenuAPI.PrepareIcon("OurMod", "reload", l_assembly.GetManifestResourceStream("ZuluClientCVR.Resources.RemodCE.reload.png"));

                QuickMenuAPI.UserJoin += OnPlayerJoin;
                QuickMenuAPI.UserLeave += OnPlayerLeave;
                QuickMenuAPI.OnWorldLeave += ondisconnect;

                //animthread = new Thread(animtxt);
               // animthread.Start();
                MelonLogger.Msg("Creating UI (Done with Icons)...");
                ourRoot = new Page("OurMod", "MainPage", true, "eaclogo");
                ourRoot.MenuTitle = "Infinite Client";
                ourRoot.MenuSubtitle = "V0.0.7 ALPHA | Made by tocat.";
                var ourCategory = ourRoot.AddCategory("General");
                /*
                var fakeserialize = ourCategory.AddToggle("Fake Serialize (ClientSided)", "Makes a clone of your avatar.", false);
                fakeserialize.OnValueUpdated += FakeSerialize.ToggleSerialize;
                */
                var clearram = ourCategory.AddButton("Clear RAM", "reload", "Does Garbage Collection and unloads unused resources, saving RAM.");
                clearram.OnPress += ClearRAM;
                var fakemovecat = ourRoot.AddCategory("Movement");
                var wsslider = ourRoot.AddSlider("Walk Speed", "Change your walk speed.", 1f, 0f, 1000f);
                var jpslider = ourRoot.AddSlider("Jump Power", "Change your jump height.", 1f, 0f, 1000f);
                wsslider.OnValueUpdated += ChangeSpeed =>
                {
                    MovementSystem.Instance.baseMovementSpeed = wsslider.SliderValue;
                };
                jpslider.OnValueUpdated += ChangeSpeed =>
                {
                    MovementSystem.Instance.jumpHeight = wsslider.SliderValue;
                };
                var movecat = ourRoot.AddCategory("", false);

                
                var clicktp = movecat.AddToggle("ClickTP", "With this turned on, you teleport to where you are looking by pressing T.", false);
                clicktp.OnValueUpdated += FlyToggle =>
                {
                    ClickTP = !ClickTP;
                };
                /*
                var InfiniteJump = movecat.AddToggle("Infinite Jump", "With this turned on, you will jump without a cooldown or being on the floor.", false);
                InfiniteJump.OnValueUpdated += FlyToggle =>
                {
                    InfJump = !InfJump;
                };
                */

                var visuals = ourRoot.AddCategory("Visuals");
                var funnyToggle = ourCategory.AddToggle("Discord RPC", "Toggles discord RPC.", true);
                funnyToggle.OnValueUpdated += togglevoid;
                var joindiscord = ourCategory.AddButton("Join our Discord", "discord", "Opens a link in your browser to join our discord.");
                joindiscord.OnPress += JoinDiscord;
                FramerateCounter.start();
                var guitoggle = visuals.AddToggle("Desktop ClickGUI", "Toggles the ClickGUI, Powered by Unity's IMGUI System.", true);
                guitoggle.OnValueUpdated += ToggleClickGui;
                var consoletoggle = visuals.AddToggle("Desktop Console Viewer", "Toggles the Console Viewer, Which lets you view the console without tabbing out of the game.", true);
                consoletoggle.OnValueUpdated += ToggleClickGui =>
                {
                    drawconsolegui = !drawconsolegui;
                };
                
                var tracertoggle = visuals.AddToggle("Player Tracers", "Creates a line that follows other players.", false);
                tracertoggle.OnValueUpdated += ESPToggle;
                
                var forceproptoggle = visuals.AddToggle("ESP", "haha funny csgo hack go brrr", false);
                forceproptoggle.OnValueUpdated += PropToggle =>
                {
                    Prop = !Prop;
                };
                var videoforceplaybtn = ourCategory.AddButton("Force Play Video", "play", "Force plays a video on every video player in the instance.");
                videoforceplaybtn.OnPress += SelectVideo;
                var exploits = ourRoot.AddCategory("Exploits");
                exploits.AddButton("Change Avatar By ID", "teleport", "Duh.").OnPress += switchavibyid;
                exploits.AddButton("Force Fly", "admin", "Enables you to fly by modifying game properties.").OnPress += forcefly;


                var fun = ourRoot.AddCategory("Fun");
                var beemoviebtn = fun.AddButton("Bee movie script", "play", "According to all known laws of avia- Prints the entire bee movie script.");
                beemoviebtn.OnPress += beeaction;
                var shrekt = fun.AddButton("Shrek ASCII art", "admin", "Prints shrek into your melonloader console!");
                shrekt.OnPress += Shrekt;
                /*
                var ttsbee = fun.AddButton("Bee movie script in TTS", "log", "According to all known laws of avia- Says the entire bee movie script.");
                ttsbee.OnPress += beeactiontts;
                */
                var creditssubpage = ourCategory.AddPage("Credits", "eaclogo", "Shows the credits.", "OurMod");
                var creditscat = creditssubpage.AddCategory("Credits");
                creditscat.AddButton("tocat (tocat.) - Lead Developer", "tocat", "The lead developer of Infinite Client.");
                creditscat.AddButton("RequiDev", "remod", "The developer of RemodCE, which Infinite Client uses the icons of.");
                var tptoggle = ourCategory.AddToggle("Auto Staff Disconnect", "If enabled, disconnects you when a staff member is detected.", false);
                tptoggle.OnValueUpdated += ChangeStaffDis =>
                {
                    autostaffdis = !autostaffdis;
                };

                var username2 = "";
                try
                {
                    username2 = RPCHelper.getusername();
                }
                catch
                (Exception ex)
                {
                    username2 = "";
                    var yikes = ex;
                    
                }
                //kick????
                creditscat.AddButton($"You.", "admin", "For using Infinite!");
               var Infinitecat = QuickMenuAPI.PlayerSelectPage.AddCategory("Infinite Client");
                var forceclonebtn = Infinitecat.AddButton("Force Clone", "teleport", "Force clone the selected person's avatar.");
                forceclonebtn.OnPress += SpoofUsernamePopup;
                var tpto = Infinitecat.AddButton("Teleport", "teleport", "Teleport to this player.");
                tpto.OnPress += TeleportToPlayer;
                /*
                var kick = Infinitecat.AddButton("Kick Player", "teleport", "Teleport to this player.");
                kick.OnPress += KickSelected;
                */
                var pickupbtn = Infinitecat.AddButton("Spawn LC Wheelchair", "teleport", "laughing handicap :troll:");
                pickupbtn.OnPress += SpawnFunnyOnTarget;
                var spambtn = Infinitecat.AddToggle("Pickup Spam (ClientSided)", "Spam teleports pickups to this player.", propspam);
                spambtn.OnValueUpdated += spambtncall;
                consolepg = ourCategory.AddPage("Music Player", "play", "Opens the Music Player tab.", "OurMod");

                var opscat = consolepg.AddCategory("Options");
                var playpausebtn = opscat.AddButton("Play/Pause", "play", "Plays or Pauses the currently selected audio file.");
                var stopplaybtn = opscat.AddButton("Play/Stop", "play", "Stops or Plays the audio.");
                var reloadbtn = opscat.AddButton("Refresh Music", "log", "Refreshes the music library so you don't have to restart the game each time.");
                muscat = consolepg.AddCategory("Music Selection");
                playpausebtn.OnPress += MusicPlayer.PauseMusic;
                stopplaybtn.OnPress += MusicPlayer.StopMusic;
                reloadbtn.OnPress += MusicPlayer.RefreshMusic;
                
                QuickMenuAPI.OnPlayerSelected += selectplayer;

                MelonLogger.MsgCallbackHandler += print;
                void print(ConsoleColor melonColor, ConsoleColor txtColor, string callingMod, string content)
                {
                    console_sb.AppendLine(callingMod + ": " + content);
                    
                }
                MelonLogger.Msg("Fully initialized. Welcome to Infinite Client.");
                Console.Title = Console.Title + " | Infinite Client V0.0.7 Alpha";
                MelonCoroutines.Start(animtxt());
                
               
            }
            else
            {
                
            }




        }
        static void JoinDiscord()
        {
            Process.Start("https://discord.gg/JR2FbASvjB");
        }
        static void spambtncall(bool shouldspam)
        {
            spam(shouldspam);
        }
        public static void oninfdetect(string id)
        {
            foreach (var player in GameObject.FindObjectsOfType<PlayerNameplate>())
            {
                var plrpos = player.player.transform.localPosition;
                if (plrpos != null)
                {
                    if (player.player != PlayerSetup.Instance._avatar.transform.parent.gameObject)
                    {
                        if (player.player.name == id)
                        {
                            player.rankText.text += " | [Infinite User]";
                            SendHudNotif("Infinite", "Another user has been detected: " + player.usrNameText);
                        }
                    }
                }
            }
        }
        static void tppickupstotarget()
        {
            CVRPickupObject[] AllPickups = Object.FindObjectsOfType<CVRPickupObject>();
            foreach (CVRPickupObject pickup in AllPickups)
            {
                if(pickup.name == "QuickMenu") continue;
                var target = GameObject.Find(QuickMenuAPI.SelectedPlayerID);
                pickup.Grab(PlayerSetup.Instance._avatar.transform, pickup._controllerRay, new Vector3());
                pickup.transform.position = target.transform.position;

            }
        }
        static void KickSelected()
        {
            using (DarkRiftWriter darkRiftWriter = DarkRiftWriter.Create())
            {
                darkRiftWriter.Write(QuickMenuAPI.SelectedPlayerID);
                using (Message message = Message.Create(9040, darkRiftWriter))
                {
                    NetworkManager.Instance.GameNetwork.SendMessage(message, SendMode.Unreliable);
                }
            }
        }
        static IEnumerator spam(bool shouldspam)
        {
            while(shouldspam)
            {
                CVRPickupObject[] AllPickups = Object.FindObjectsOfType<CVRPickupObject>();
                foreach (CVRPickupObject pickup in AllPickups)
                {
                    if (pickup.name == "QuickMenu") continue;
                    var target = GameObject.Find(QuickMenuAPI.SelectedPlayerID);
                    pickup.Grab(PlayerSetup.Instance._avatar.transform, pickup._controllerRay, new Vector3());
                    pickup.transform.position = target.transform.position;
                    
                }
                yield return new WaitForEndOfFrame();
            }
            
        }
        
        static Action<string, string> selectplayer = SelectPlayer;
        static void ToggleClickGui(bool state)
        {
            drawclickgui = state;
        }
        static void Shrekt()
        {
            MelonLogger.Msg(@"                                                         
                                                         
    uWodo                odjjdo                          
    u    u          uuu uuuuuu uuu                       
    A8  WQj      j3FQAALAAAAAALAAAAFA8o                  
          3    ud8    udWWW883dWWW8dW83u                 
           o3dF3d j3L3d  WAFAAQAAAFLALAA3                
             8u    88WLWj 8QQFQFAFL3AQFAFo               
          uQo              33Q8QQQ38 ud QWd              
          AL     dFuuQA3   LFALAWdou8QWoo88       3LAA   
         ojjjoou  jj oooo  oojoju    ojjjju    ju  uojo  
       uAAAAAAAAAAAAAAAFAAAAAAAAWuQjddAAAAFAFAAA  8AAAA  
       u  uuuuuuuu  uuuuuuuuuuuu u   uu uuuuuu           
     LA8    jjdo      8AAAAAAAAAAAWAAAAAAAAA             
     3Wu  Q           uWLLLQ3LWLLLQ8FWLLLLdQ             
    u8d8dj     jj888ju   j8dd8j888dj8j888djd             
             Lo  AAALFAQAAAFLAQ  Aj3ALAAAAWF             
               oo odjjjjdddjojjdddo ujdddduj             
                 jAAuLALAAAAAALAAAAFAoAAAALA             
                  oooou   oooooooooujooooou              
                 jAAAAAFAAAAAAFAAAAAAFAAAAL              
                 uQLWWQ3LLLQWL3LLLQ3FWLLL8               
             uouuoooooouooooooooooooouooo                
             WFQQAAAQLFWAAAQQFWAAALWAWAQ                 
               oojjjoooojjjjojojjjoujoo                  
               u8AAALFAWAAALLAQAAAL3Wu                   
                  jW8838WWW8838WWW                       
                       oojjooju                          ");
           /* QuickMenuAPI.ShowNotice("", @"                                                         
                                                         
    uWodo                odjjdo                          
    u    u          uuu uuuuuu uuu                       
    A8  WQj      j3FQAALAAAAAALAAAAFA8o                  
          3    ud8    udWWW883dWWW8dW83u                 
           o3dF3d j3L3d  WAFAAQAAAFLALAA3                
             8u    88WLWj 8QQFQFAFL3AQFAFo               
          uQo              33Q8QQQ38 ud QWd              
          AL     dFuuQA3   LFALAWdou8QWoo88       3LAA   
         ojjjoou  jj oooo  oojoju    ojjjju    ju  uojo  
       uAAAAAAAAAAAAAAAFAAAAAAAAWuQjddAAAAFAFAAA  8AAAA  
       u  uuuuuuuu  uuuuuuuuuuuu u   uu uuuuuu           
     LA8    jjdo      8AAAAAAAAAAAWAAAAAAAAA             
     3Wu  Q           uWLLLQ3LWLLLQ8FWLLLLdQ             
    u8d8dj     jj888ju   j8dd8j888dj8j888djd             
             Lo  AAALFAQAAAFLAQ  Aj3ALAAAAWF             
               oo odjjjjdddjojjdddo ujdddduj             
                 jAAuLALAAAAAALAAAAFAoAAAALA             
                  oooou   oooooooooujooooou              
                 jAAAAAFAAAAAAFAAAAAAFAAAAL              
                 uQLWWQ3LLLQWL3LLLQ3FWLLL8               
             uouuoooooouooooooooooooouooo                
             WFQQAAAQLFWAAAQQFWAAALWAWAQ                 
               oojjjoooojjjjojojjjoujoo                  
               u8AAALFAWAAALLAQAAAL3Wu                   
                  jW8838WWW8838WWW                       
                       oojjooju                          ");
           */
        }
        IEnumerator animtxt()
        {
            void subvoid()
            {
                AnimateTitle("I N F I N I T E | Made by tocat. | 0.0.8");
            }
            MelonLogger.Msg("Starting thread...");
            Thread animthread = new Thread(new ThreadStart(subvoid));
            MelonLogger.Msg("Thread created!");
            for (;;){
                
                if(animthread.ThreadState == ThreadState.Stopped || animthread.ThreadState == ThreadState.Unstarted)
                {
                    animthread = null;
                    animthread = new Thread(new ThreadStart(subvoid));
                    animthread.Start();
                }
                yield return new WaitForSeconds(0.2f);
            }
           
            yield break;
           
            
        }
        static void Main()
        {
            //Console.Title = "Hello, World!";
           

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }

        static void AnimateTitle(string text)
        {
            for (int i = 0; i <= text.Length; i++)
            {
                Console.Title = text.Substring(0, i);
                Thread.Sleep(100); // Adjust the sleep duration for speed
            }

            Thread.Sleep(1000); // Pause before reversing

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Title = text.Substring(0, i);
                Thread.Sleep(100); // Adjust the sleep duration for speed
            }
        }
        static void TeleportToPlayer()
        {
            if (QuickMenuAPI.SelectedPlayerName != String.Empty) {
                var target = GameObject.Find(QuickMenuAPI.SelectedPlayerID);
                var targetpos = target.transform.position;

                MovementSystem.Instance.TeleportTo(targetpos);
                SendHudNotif("Infinite", "Teleported to target.");
            }
        }
       
        
        static void OnPlayerJoin(CVRPlayerEntity player)
        {
            string StaffNames = @"Marmeladensalat
Luc
WandDschungel
Khodrin
Kyobinoyo
Madvicius
Hordini
Slaynash
Herp Derpinstine
kjoy
Racush
NotAKid
Okami
rakosi2
Ben
N3X15
loliwut
LieutenantMaster
Penny
";

        MelonLogger.Msg("[OnPlayerJoin]: " + player.Username + " has joined.");
            if (StaffNames.Contains(player.Username))
            {
                
                MelonLogger.Msg("[OnStaffJoin]: " + player.Username + " has joined.");
                if (autostaffdis)
                {
                    
                    NetworkManager.Instance.OnDisconnectionRequested(0, true);
                    SendHudNotif("[Infinite]: That was close.", player.Username + " is a staff member. We disconnected you before they could see you.");
                }
                else
                {
                    //QuickMenuAPI.ShowNotice("STAFF JOIN WARNING", player.Username + " is a staff member. Be careful.");
                    SendHudNotif("[Infinite]: Staff Warning", player.Username + " is a staff member. Be careful.");
                }
            }
            
        }
        static void OnPlayerLeave(CVRPlayerEntity player)
        {
            MelonLogger.Msg("[OnPlayerLeave]: " + player.Username + " has left.");
        }

        static void SelectPlayer(string playername, string playerid)
        {
            MelonLogger.Msg($"Selected player name: {playername}");
            MelonLogger.Msg($"Selected player id: {playerid}");
        } 
        int page = 1;

        StringBuilder console_sb = new StringBuilder();
        public static GameObject[] GetDontDestroyOnLoadObjects()
        {
            GameObject temp = null;
            try
            {
                temp = new GameObject();
                GameObject.DontDestroyOnLoad(temp);
                UnityEngine.SceneManagement.Scene dontDestroyOnLoad = temp.scene;
                GameObject.DestroyImmediate(temp);
                temp = null;

                return dontDestroyOnLoad.GetRootGameObjects();
            }
            finally
            {
                if (temp != null)
                    GameObject.DestroyImmediate(temp);
            }
        }
        string isusingInfinite()
        {
            return "TODO: add Infinite detection"; 
        }
        public override void OnGUI()
        {
           
           

            Rect windowRect = new Rect(20, 20, 400, 400);
            Rect consoleRect = new Rect(1000, 20, 800, 400);
            Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            int asciiArtWidth = 15;
            int asciiArtHeight = 73;

            Rect rect2 = new Rect(0, 0, asciiArtWidth, asciiArtHeight);
            GUI.Label(rect, "Infinite Client V0.0.7 ALPHA - Made by tocat. | FPS: " + FramerateCounter.fps.ToInt());
            
            if (SceneManager.GetActiveScene().name != "Login" || SceneManager.GetActiveScene().name != "Intro")
            {
                if (drawclickgui)
                {
                    GUI.Window(0, windowRect, DoMyWindow, "Infinite GUI");
                }
                if(drawconsolegui)
                {
                    GUI.Window(1, consoleRect, console, "Infinite Console");
                }
            
            void console(int id)
                {
                    if (GUILayout.Button("Clear")){
                        console_sb.Clear();
                    }
                    GUILayout.BeginScrollView(new Vector2(), false, true);
                    GUILayout.Label(console_sb.ToString());
                    GUILayout.EndScrollView();
                    
                }
            void DoMyWindow(int id)
                {
                    GUILayout.BeginVertical("box");
                    if (page == 1)
                    {
                        if (GUILayout.Button("General"))
                        {
                            page = 2;
                        }
                    }
                    if (page == 2)
                    {
                        if (GUILayout.Button("Back"))
                        {
                            page = 1;
                        }
                        if (GUILayout.Button("Force Fly: " + Fly))
                        {
                            Fly = !Fly;


                        }
                        if (GUILayout.Button("ESP: " + Prop))
                        {
                            Prop = !Prop;


                        }
                        if (GUILayout.Button("Video Player Force Play"))
                        {
                            SelectVideo();
                        }

                        GUILayout.Label($@"Infinite V0.0.7
Made by tocat
The first ever CVR Client.
Current Position: {PlayerSetup.Instance.PlayerAvatarParent.transform.position}
Players in instance: {getplayercount()}
");
                    }


                    GUILayout.EndVertical();

                    GUI.DragWindow(windowRect);
                }
            }
        }

        
        static void ondisconnect()
        {
            //for some reason you can't control the audio after leaving
            //probably my shit code, so we stop the player to prevent this
            GameObject.Destroy(MusicPlayer.audioSource);
            MelonLogger.Msg("ondisconnect() called");
        }
        
        public override void OnUpdate()
        {
            if (CustomUIInit) { UIHolder.SetActive(CVR_MenuManager.Instance.quickMenu.Enabled); }
            /*
            if (animthread.ThreadState != System.Threading.ThreadState.Running && animthread.IsAlive && animthread.ThreadState != ThreadState.WaitSleepJoin)
            {
                animthread.Abort();
                try
                {
                    animthread.Start();

                }
                catch (Exception e)
                {
                    MelonLogger.Error("[consoleanim]: " + e.Message);
                }
            }
            */
            FramerateCounter.OnUpdate();
            if (Prop)
            {
                foreach (var player in GameObject.FindObjectsOfType<PlayerNameplate>())
                {
                    var plrpos = player.player.transform.localPosition;
                    if (plrpos != null)
                    {
                        RuntimeGizmos.DrawCube(player.player.transform.position, player.player.transform.rotation, player.player.gameObject.transform.Find("[PlayerAvatar]/_CVRAvatar(Clone)").transform.localScale, Color.blue);
                    }
                }
            }
            if (Fly)
            {
                MovementSystem.Instance.canFly = true;
            }
            if (InfJump && Input.GetKey(KeyCode.Space))
            {
                PlayerSetup.Instance._avatar.transform.position.ModifyY(40);
               
            }
            if (ClickTP)
            {
                
                if (Input.GetKeyDown(KeyCode.T))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        MovementSystem.Instance.TeleportTo(hit.point);
                    }
                }
            }
            if (ESP)
            {
                var playerLocalTransform = GameObject.Find("_PLAYERLOCAL").transform;

                // Create lists to store positions, names, and staff information for batch drawing
                List<Vector3> playerPositions = new List<Vector3>();
                List<string> playerInfo = new List<string>();

                foreach (var player in GameObject.FindObjectsOfType<PlayerNameplate>())
                {
                    var plrpos = player.player.transform.localPosition;
                    if (plrpos != null)
                    {
                        playerPositions.Add(plrpos);

                        // Check if staffText.text is not empty, then format the information accordingly
                        string playerName = player.usrNameText.text;
                        if (!string.IsNullOrEmpty(player.staffText.text))
                        {
                            
                        }

                        playerInfo.Add(playerName);
                    }
                }

                // Batch draw lines
                foreach (var pos in playerPositions)
                {
                    RuntimeGizmos.DrawLineFromTo(playerLocalTransform.position, pos, 0.07f, Color.yellow);
                }

                // Batch draw texts
                for (int i = 0; i < playerPositions.Count; i++)
                {
                    RuntimeGizmos.DrawText(playerPositions[i], playerInfo[i], 0.7f, Color.red);
                }
            }


            if (IsQMMusicInit)
            {
                foreach (var player in GameObject.FindObjectsOfType<PlayerNameplate>())
                {
                    var plrpos = player.player.transform.localPosition;
                    if (plrpos != null)
                    {
                        if (player.player != PlayerSetup.Instance._avatar.transform.parent.gameObject)
                        {
                            
                            if (player.usrNameText.text == "InfiniteCrystals")
                            {
                                player.rankText.text = "[Infinite] Owner";
                                //SendHudNotif("Infinite", "Infinite's developer is in your lobby! Go say hi!");
                            }
                            if (player.usrNameText.text == "tedthecat")
                            {
                                player.rankText.text = "[Infinite] Beta Tester";
                            }
                            if (player.usrNameText.text == "Tocat")
                            {
                                player.rankText.text = "[Infinite] Staff";
                            }
                            if (player.usrNameText.text == "samurizey")
                            {
                                player.rankText.text = "[Infinite] EDP445";
                            }
                            if (player.usrNameText.text == "kjoy")
                            {
                                player.rankText.text = "[Infinite] Tocat's pookiebear";
                            }
                            if (player.usrNameText.text == "Racush")
                            {
                                player.rankText.text = "[Infinite] Super secret spy against tocat";
                            }
                            if (player.usrNameText.text == "alphablend_int")
                            {
                                player.rankText.text = "[Infinite] EDP445";
                            }
                        }
                    }
                }
            }
            /*
            if(IsQMMusicInit && CVR_MenuManager.Instance.quickMenu.Enabled && !QMMusicSource.isPlaying)
            {
                QMMusicSource.Play();
               
            }
            else
            {
                if(IsQMMusicInit && !CVR_MenuManager.Instance.quickMenu.Enabled && QMMusicSource.isPlaying)
                {
                    QMMusicSource.Stop();
                }
                
            }
          */

        }
        static void SpoofUsername(string username)
        {
            var avitarget = GameObject.Find(QuickMenuAPI.SelectedPlayerID + "/[PlayerAvatar]/_CVRAvatar(Clone)");
            var aviid = avitarget.GetComponent<CVRAssetInfo>().objectId;
            if (aviid != null)
            {
                AssetManagement.Instance.LoadLocalAvatar(aviid);
            }
            else
            {
                QuickMenuAPI.ShowNotice("Error", "Failed to clone avatar!");
            }
        }
        static void kickselected()
        {
            var plrtokick = QuickMenuAPI.SelectedPlayerID;
            DarkRiftWriter kickwritier = DarkRiftWriter.Create();
            kickwritier.Write(plrtokick);
            Message kickmsg = Message.Create(1, kickwritier);
            CVRPlayerManager.Instance.TryDeletePlayer(kickmsg);
        }
        static void beeaction()
        {
            MelonLogger.Msg(beescript);
            QuickMenuAPI.ShowNotice("As you requested", beescript);
        }

       

        static void beeactiontts()
        {
            MelonLogger.Msg("Should be saying now...");
            //VivoxService.Instance.TextToSpeechCancelAllMessages();
            VivoxService.Instance.TextToSpeechSendMessage(beescript, TextToSpeechMessageType.RemoteTransmissionWithLocalPlayback);
        }

        public override void OnApplicationQuit()
        {
            RPCHelper.StopRPC();
            MelonLogger.Msg("Thank you for choosing Infinite Client. Goodbye!");
        }

        static void ESPToggle(bool toggle)
        {
            ESP = toggle;
        }
        string getplayercount()
        {
            if (CVRPlayerManager.Instance.NetworkPlayers.Count == 0)
            {
                return"Not connected to an instance.";
            }
            else
            {
                return CVRPlayerManager.Instance.NetworkPlayers.Count.ToString();
            }
        }
        void SelectVideo()
        {
            void PlayerForcePlay(string url)
            {
                foreach (var player in GameObject.FindObjectsOfType<CVRVideoPlayer>())
                {
                    MelonLogger.Msg("current_url: " + url);
                    //player.SetVideoTimestamp(0);
                    player.SetUrl(url);
                    
                    //player.SetNetworkSync(true);
                    
                    
                }
            }
            QuickMenuAPI.OpenKeyboard("", PlayerForcePlay);
        }
        void SpoofUsernamePopup()
        {
            SpoofUsername("");
        }


    }
}