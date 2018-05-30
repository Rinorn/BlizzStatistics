using System;
using System.Data.Entity;
using System.Net.Http;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.DataAccess
{
    public class BlizzStatisticsDbInitializer : DropCreateDatabaseIfModelChanges<BlizzStatisticsContext>
    {
        public string[] RealmName = new string[267];
        public int[] RealmId = new int[267];
        public bool DataReady = false;
        public string[] StrengthAgility = {"Strength", "Agility"};
        public string[] Strength = {"Strength"};
        public string[] Agility = {"Agility"};
        public string[] Intellect = {"Intellect"};
        protected override void Seed(BlizzStatisticsContext context)
        {
            
            //Seeds the db with the character classes
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id=1,
                Name = "Warrior",
                ClassDescription = "For as long as war has raged, heroes from every race have aimed to master the art of battle. Warriors combine strength, leadership, and a vast knowledge of arms and armor to wreak havoc in glorious combat. Some protect from the front lines with shields, locking down enemies while allies support the warrior from behind with spell and bow. Others forgo the shield and unleash their rage at the closest threat with a variety of deadly weapons.",
                ClassIcon = "http://localhost:60158/api/images/warrior_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/warrior_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id=2,
                Name = "Paladin",
                ClassDescription = "This is the call of the paladin: to protect the weak, to bring justice to the unjust, and to vanquish evil from the darkest corners of the world. These holy warriors are equipped with plate armor so they can confront the toughest of foes, and the blessing of the Light allows them to heal wounds and, in some cases, even restore life to the dead.",
                ClassIcon = "http://localhost:60158/api/images/paladin_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/paladin_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id=3,
                Name = "Hunter",
                ClassDescription = "From an early age, the call of the wild draws some adventurers from the comfort of their homes into the unforgiving primal world outside. Those who endure become hunters. Masters of their environment, they are able to slip like ghosts through the trees and lay traps in the paths of their enemies.",
                ClassIcon = "http://localhost:60158/api/images/hunter_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/hunter_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 4,
                Name = "Rogue",
                ClassDescription = "For rogues, the only code is the contract, and their honor is purchased in gold. Free from the constraints of a conscience, these mercenaries rely on brutal and efficient tactics. Lethal assassins and masters of stealth, they will approach their marks from behind, piercing a vital organ and vanishing into the shadows before the victim hits the ground.",
                ClassIcon = "http://localhost:60158/api/images/rogue_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/rogue_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 5,
                Name = "Priest",
                ClassDescription = "Priests are devoted to the spiritual, and express their unwavering faith by serving the people. For millennia they have left behind the confines of their temples and the comfort of their shrines so they can support their allies in war-torn lands. In the midst of terrible conflict, no hero questions the value of the priestly orders.",
                ClassIcon = "http://localhost:60158/api/images/priest_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/priest_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 6,
                Name = "Death Knight",
                ClassDescription = "When the Lich King’s control of his death knights was broken, his former champions sought revenge for the horrors committed under his command. After their vengeance was won, the death knights found themselves without a cause and without a home. One by one they trickled into the land of the living in search of a new purpose.",
                ClassIcon = "http://localhost:60158/api/images/dk_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/dk_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 7,
                Name = "Shaman",
                ClassDescription = "Shaman are spiritual guides and practitioners, not of the divine, but of the very elements. Unlike some other mystics, shaman commune with forces that are not strictly benevolent. The elements are chaotic, and left to their own devices, they rage against one another in unending primal fury. It is the call of the shaman to bring balance to this chaos. Acting as moderators among earth, fire, water, and air, shaman summon totems that focus the elements to support the shaman’s allies or punish those who threaten them.",
                ClassIcon = "http://localhost:60158/api/images/shaman_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/shaman_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 8,
                Name = "Mage",
                ClassDescription = "Students gifted with a keen intellect and unwavering discipline may walk the path of the mage. The arcane magic available to magi is both great and dangerous, and thus is revealed only to the most devoted practitioners. To avoid interference with their spellcasting, magi wear only cloth armor, but arcane shields and enchantments give them additional protection. To keep enemies at bay, magi can summon bursts of fire to incinerate distant targets and cause entire areas to erupt, setting groups of foes ablaze.",
                ClassIcon = "http://localhost:60158/api/images/mage_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/mage_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 9,
                Name = "Warlock",
                ClassDescription = "In the face of demonic power, most heroes see death. Warlocks see only opportunity. Dominance is their aim, and they have found a path to it in the dark arts. These voracious spellcasters summon demonic minions to fight beside them. At first, they command only the service of imps, but as a warlock’s knowledge grows, seductive succubi, loyal voidwalkers, and horrific felhunters join the dark sorcerer’s ranks to wreak havoc on anyone who stands in their master’s way.",
                ClassIcon = "http://localhost:60158/api/images/warlock_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/warlock_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 10,
                Name = "Monk",
                ClassDescription = "When the pandaren were subjugated by the mogu centuries ago, it was the monks that brought hope to a seemingly dim future. Restricted from using weapons by their slave masters, these pandaren instead focused on harnessing their chi and learning weaponless combat. When the opportunity for revolution struck, they were well-trained to throw off the yoke of oppression.",
                ClassIcon = "http://localhost:60158/api/images/monk_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/monk_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 11,
                Name = "Druid",
                ClassDescription = "Druids harness the vast powers of nature to preserve balance and protect life. With experience, druids can unleash nature’s raw energy against their enemies, raining celestial fury on them from a great distance, binding them with enchanted vines, or ensnaring them in unrelenting cyclones.",
                ClassIcon = "http://localhost:60158/api/images/druid_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/druid_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                Id = 12,
                Name = "Demon Hunter",
                ClassDescription = "Demon hunters, disciples of Illidan Stormrage, uphold a dark legacy, one that frightens their allies and enemies alike. The Illidari embrace fel and chaotic magics—energies that have long threatened the world of Azeroth—believing them necessary to challenge the Burning Legion. Wielding the powers of demons they’ve slain, they develop demonic features that incite revulsion and dread in fellow elves.",
                ClassIcon = "http://localhost:60158/api/images/dh_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/dh_model.jpg/"
            });

            //seeds the db with character races
            
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 1,
                RaceName = "Human",
                RaceDescription = "Recent discoveries have shown that humans are descended from the barbaric vrykul, half-giant warriors who live in Northrend. Early humans were primarily a scattered and tribal people for several millennia, until the rising strength of the troll empire forced their strategic unification. Thus the nation of Arathor was formed, along with its capital, the city-state of Strom.",
                RaceModel = "http://localhost:60158/api/images/human_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 2,
                RaceName = "Orc",
                RaceDescription = "Unlike the other races of the Horde, orcs are not native to Azeroth. Initially, they lived as shamanic clans on the lush world of Draenor. They abandoned their peaceful culture when Kil’jaeden, a demon lord of the Burning Legion, corrupted the orcs and used them in his vengeful plot against the draenei, who were exiles from Kil’jaeden’s homeworld.",
                RaceModel = "http://localhost:60158/api/images/orc_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 3,
                RaceName = "Dwarf",
                RaceDescription = "The bold and courageous dwarves are an ancient race descended from the earthen—beings of living stone created by the titans when the world was young. Due to a strange malady known as the Curse of Flesh, the dwarves’ earthen progenitors underwent a transformation that turned their rocky hides into soft skin. Ultimately, these creatures of flesh and blood dubbed themselves dwarves and carved out the mighty city of Ironforge in the snowy peaks of Khaz Modan.",
                RaceModel = "http://localhost:60158/api/images/dwarf_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 4,
                RaceName = "Night Elf",
                RaceDescription = "The ancient and reclusive night elves have played a pivotal role in shaping Azeroth’s fate. The night elves of today still remember the War of the Ancients over ten thousand years ago, when they halted the Burning Legion’s first invasion of Azeroth. When the Legion’s remnants rallied together with the vile satyrs centuries later, the night elves again opposed the threat, ultimately vanquishing the forces that set out to wreak havoc on their world. ",
                RaceModel = "http://localhost:60158/api/images/nightelf_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 5,
                RaceName = "Undead",
                RaceDescription = "Death offered no escape for the scores of humans killed during the Lich King’s campaign to scour the living from Lordaeron. Instead, the kingdom’s fallen were risen into undeath as Scourge minions and forced to wage an unholy war against everything… and everyone… that they once held dear.",
                RaceModel = "http://localhost:60158/api/images/undead_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 6,
                RaceName = "Tauren",
                RaceDescription = "The peaceful tauren—known in their own tongue as the shu’halo—have long dwelled in Kalimdor, striving to preserve the balance of nature at the behest of their goddess, the Earth Mother. Until recently, the tauren lived as nomads scattered throughout the Barrens, hunting the great kodo beasts native to the arid region.",
                RaceModel = "http://localhost:60158/api/images/tauren_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 7,
                RaceName = "Gnome",
                RaceDescription = "The clever, spunky, and oftentimes eccentric gnomes present a unique paradox among the civilized races of Azeroth. Brilliant inventors with an irrepressibly cheerful disposition, this race has suffered treachery, displacement, and near-genocide. It is their remarkable optimism in the face of such calamity that symbolizes the truly unshakable spirit of the gnomes.​",
                RaceModel = "http://localhost:60158/api/images/gnome_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 8,
                RaceName = "Troll",
                RaceDescription = "The savage trolls of Azeroth are infamous for their cruelty, dark mysticism, and seething hatred for all other races. Yet one exception among the trolls is the Darkspear tribe and its cunning leader, Vol’jin. Plagued by a history of subservience and exile, this proud tribe was on the brink of extinction when Warchief Thrall and his mighty Horde forces were driven to the trolls’ remote island home in the South Seas during a violent storm.",
                RaceModel = "http://localhost:60158/api/images/troll_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 9,
                RaceName = "Goblin",
                RaceDescription = "Originally the slaves of jungle trolls on the Isle of Kezan, goblins were forced to mine kaja’mite ore out of the volcanic bowels of Mount Kajaro. The trolls used this potent mineral for their voodoo rituals, but it had an unexpected effect on the slaves who were in constant contact with it: kaja’mite generated new cunning and intelligence in the goblin race.",
                RaceModel = "http://localhost:60158/api/images/goblin_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 10,
                RaceName = "Blood elf",
                RaceDescription = "For nearly 7,000 years, high elven society centered on the sacred Sunwell, a magical fount that was created using a vial of pure arcane energy from the first Well of Eternity. Nourished and strengthened by the Sunwell’s potent energies, the high elves’ enchanted kingdom of Quel’Thalas prospered within the verdant forests north of Lordaeron.",
                RaceModel = "http://localhost:60158/api/images/bloodelf_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 11,
                RaceName = "Draenei",
                RaceDescription = "Long before the fallen titan Sargeras unleashed the Legion on Azeroth, he conquered the world of Argus and its inhabitants, the eredar. Believing that this gifted race would be crucial in his quest to undo all of creation, Sargeras contacted the eredar’s leaders – Kil’jaeden, Archimonde, and Velen, offering them knowledge and power in exchange for their loyalty.",
                RaceModel = "http://localhost:60158/api/images/draenei_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 12,
                RaceName = "Worgen",
                RaceDescription = "Behind the formidable Greymane Wall, a terrible curse transformed some of the stalwart citizens of the isolated kingdom of Gilneas into nightmarish lupine beasts known as worgen. Human scholars intensely debated the origins of the curse, until it was revealed that the original worgen were not—as previously believed—nightmares from another dimension, but cursed night elf druids.",
                RaceModel = "http://localhost:60158/api/images/worgen_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 13,
                RaceName = "Pandaren",
                RaceDescription = "Couched in myth and legend, rarely seen and even more rarely understood, the enigmatic pandaren have long been a mystery to the other races of Azeroth. The noble history of the pandaren people stretches back thousands of years, well before the empires of man and before even the sundering of the world.",
                RaceModel = "http://localhost:60158/api/images/pandaren_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/AH_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 14,
                RaceName = "Nightborne",
                RaceDescription = "The nightborne  or shal'dorei in the native tongue are a powerful and mystical race of night elves who live in Suramar. Since the city was first separated from the rest of the world over 10,000 years ago, they have evolved by the Nightwell into an arcane-enhanced version of their former selves. For the majority of their secluded existence, virtually the entire group resided in the ancient city of Suramar, and were led solely until recent times by Grand Magistrix Elisande.",
                RaceModel = "http://localhost:60158/api/images/nightborne_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 15,
                RaceName = "Highmountain Tauren",
                RaceDescription = "The Highmountain tauren are an offshoot of tauren found in the region of Highmountain on the Broken Isles. Divided into four tribes (Highmountain, Rivermane, Skyhorn and Bloodtotem), they are the direct descendants of the tauren led by Huln Highmountain who assisted the Kaldorei Resistance during the War of the Ancients. During the war, Huln received a blessing from Cenarius, so that his people would forever have the demigod's favor, granting them the Horns of Eche'ro.",
                RaceModel = "http://localhost:60158/api/images/hmtauren_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/Horde_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 16,
                RaceName = "Void Elf",
                RaceDescription = "Void elves (or ren'dorei, children of the Void in Thalassian) are a race of Void-infused elves affiliated with the Alliance. Their origins lie with the blood elf magister Umbric who was exiled from Silvermoon along with his followers because of their research into the Void. They were transformed by void ethereals but rescued by Alleria Windrunner, who had gained mastery of the Void herself on Argus. Pledging their loyalty to her and the Alliance, they established themselves as the ren'dorei.",
                RaceModel = "http://localhost:60158/api/images/voidelf_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            context.CharacterRaces.Add(new CharacterRace()
            {
                Id = 17,
                RaceName = "Lightforged Draenei",
                RaceDescription = "The Lightforged draenei are a race of draenei affiliated to the Army of the Light and the Alliance. For untold millennia, the Army of the Light waged war against the Burning Legion throughout the Twisting Nether. The draenei most committed to their long crusade would undergo a ritual to become Lightforged, infusing their bodies with the very essence of the Holy Light. After finally achieving victory on Argus, the Lightforged draenei have undertaken a new mission: protecting Azeroth from rising threats and helping the Alliance push back against Horde aggression.",
                RaceModel = "http://localhost:60158/api/images/lfdraenei_model.jpg/",
                FactionLogo = "http://localhost:60158/api/images/alliance_icon.jpg/"
            });
            //seeds the db with saved character objects
            context.SavedCharacters.Add(new SavedCharacter()
            {
                Id = 1,
                Name = "PestErBest",
                ClassName = "Priest",
                Realm = "StormScale",
                Level = 110,
                Class = 5
                
            });
            context.SavedCharacters.Add(new SavedCharacter()
            {
                Id = 2,
                Name = "SuperSteinar",
                ClassName = "Warrior",
                Realm = "StormScale",
                Level = 110,
                Class = 1
            });
            context.SavedCharacters.Add(new SavedCharacter()
            {
                Id = 3,
                Name = "HelligDykker",
                ClassName = "Paladin",
                Realm = "StormScale",
                Level = 110,
                Class = 2

            });
            /////////////////////Equipment//////////////////////

            //mailhead//
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 3,
                Name = "Headdress of Venerated Spirits",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_mail_raidshamanraid_s_01.jpg",
                Ilvl = 960,
                Armor = 474,
                MainStat =  3795,
                Stamina = 5693,
                Haste = 1167,
                Versatility = 901,
                RestrictedToClass = 7
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 3,
                Name = "Helm of Awakened Soul",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_mail_raidshamanraid_s_01.jpg",
                Ilvl = 970,
                Armor = 489,
                MainStat = 4166,
                Stamina = 6250,
                Haste = 1165,
                Mastery = 981,
                RestrictedToClass = 7
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 3,
                Name = "Nexus Conductor's Headgear",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_mail_raidhunter_s_01.jpg",
                Ilvl = 960,
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1300,
                Haste = 768
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 3,
                Name = "Shadowfused Chain Coif",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_mail_raidhunter_s_01.jpg",
                Ilvl = 960,
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 842,
                Mastery = 1226
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 3,
                Name = "Serpentstalker Helmet",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_mail_raidhunter_s_01.jpg",
                Ilvl = 960,
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1004,
                Versatility = 1063,
                RestrictedToClass = 3
            });
            ////Neck/////
            context.Equipments.Add(new Equipment()
            {
                Slot = 2,
                ArmorType = 0,
                Name = "Chain of the Unmaker",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_necklace_18a.jpg",
                Ilvl = 970,
                Stamina = 3515,
                Crit = 2948,
                Haste = 1538
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 2,
                ArmorType = 0,
                Name = "Collar of Null-Flame",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_necklace_07b.jpg",
                Ilvl = 960,
                Stamina = 3203,
                Versatility = 1809,
                Mastery = 2413
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 2,
                ArmorType = 0,
                Name = "Riveted Choker of Delirium",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_necklace_04b.jpg",
                Ilvl = 960,
                Stamina = 3203,
                Haste = 2533,
                Mastery = 1689
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 2,
                ArmorType = 0,
                Name = "Vulcanacore Pendant",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_necklace_14b.jpg",
                Ilvl = 960,
                Stamina = 3203,
                Crit = 1930,
                Versatility = 2292
            });
            /////Mail Shoulders//////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Serpentstalker Mantle",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_mail_raidhunter_s_01.jpg",
                Armor = 437,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 942,
                Haste = 609,
                RestrictedToClass = 3

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 3,
                Ilvl = 970,
                Name = "Pauldrons of Colossal Burden",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_mail_raidshamanraid_s_01.jpg",
                Armor = 451,
                MainStat =3124,
                Stamina = 4687,
                Crit = 644,
                Mastery = 966
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Pauldrons of the Soulburner",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_mail_raidhunter_s_01.jpg",
                Armor = 437,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 964,
                Mastery = 587

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Pauldrons of Venerated Spirits",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_mail_raidshamanraid_s_01.jpg",
                Armor = 437,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 631,
                Versatility = 919,
                RestrictedToClass = 7

            });
            //////////Cloak///////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 16,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Cloak of the Burning Vanguard",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_cape_raidmagemythic_s_01.jpg",
                Armor = 193,
                MainStat = 2135,
                Stamina = 3203,
                Crit = 623,
                Mastery = 540
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 16,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Drape of the Spirited Hunt",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_cape_plate_raiddeathknight_s_01_long.jpg",
                Armor = 193,
                MainStat = 2135,
                Stamina = 3203,
                Haste = 490,
                Mastery = 673
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 16,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Drape of Venerated Spirits",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_cape_mail_raidshamanraid_s_01.jpg",
                Armor = 193,
                MainStat = 2135,
                Stamina = 3203,
                Versatility = 448,
                Mastery = 714,
                RestrictedToClass = 7
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 16,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Greatcloak of the Dark Pantheon",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidroguemythic_s_01_cape.jpg",
                Armor = 193,
                MainStat = 2135,
                Stamina = 3203,
                Haste = 490,
                Crit = 531
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 16,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Serpentstalker Drape",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_cape_raidhunter_s_01.jpg",
                Armor = 193,
                MainStat = 2135,
                Stamina = 3203,
                Versatility = 515,
                Mastery = 648,
                RestrictedToClass = 3
            });
            //////Mail chest///////
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Fleet Commander's Hauberk",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_mail_raidhunter_s_01.jpg",
                Armor = 583,
                MainStat = 3793,
                Stamina = 5693,
                Crit = 1182,
                Mastery = 886
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Robes of the Forsaken Dreadlord",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_robe_mail_raidshaman_s_01.jpg",
                Armor = 583,
                MainStat = 3793,
                Stamina = 5693,
                Haste = 901,
                Mastery = 1167,
                
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Robes of Venerated Spirits",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_robe_mail_raidshaman_s_01.jpg",
                Armor = 583,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1300,
                Haste = 768,
                RestrictedToClass = 7
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Serpentstalker Tunic",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_mail_raidhunter_s_01.jpg",
                Armor = 583,
                MainStat = 3795,
                Stamina = 5693,
                Versatility = 1241,
                Mastery = 827,
                RestrictedToClass = 3
            });
            ////////////////MailWrist////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Reality-Splitting Wristguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_bracer_mail_raidshamanraid_s_01.jpg",
                Armor = 255,
                MainStat = 2135,
                Stamina = 3203,
                Haste = 748,
                Versatility = 415
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Scalding Shatterguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_bracer_mail_raidhunter_s_01.jpg",
                Armor = 255,
                MainStat = 2135,
                Stamina = 3203,
                Haste = 432,
                Mastery = 731
            });
            //////////////Mail Gloves/////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Gloves of Venerated Spirits",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_mail_raidshamanraid_s_01.jpg",
                Armor = 364,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 587,
                Mastery = 964,
                RestrictedToClass = 7
                
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Heedless Eradication Gauntlets",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_mail_raidshamanraid_s_01.jpg",
                Armor = 364,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 665,
                Mastery = 886

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Praysnare Vicegrips",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_mail_raidhunter_s_01.jpg",
                Armor = 364,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 930,
                Haste = 620

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Serpentstalker Grips",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_mail_raidhunter_s_01.jpg",
                Armor = 364,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 676,
                Haste = 875,
                RestrictedToClass = 3

            });
            ////////////////////mail Waist////////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Depraved Tactician's Waistguard",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_mail_raidshamanraid_s_01.jpg",
                Armor = 328,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 676,
                Mastery = 875
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Sash of the Gilded Rose",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_mail_raidhunter_s_01.jpg",
                Armor = 328,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 897,
                Mastery = 653
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 3,
                Ilvl = 960,
                Name = "World-Ravager Waistguard",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_mail_raidshamanraid_s_01.jpg",
                Armor = 328,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 554,
                Haste = 997
            });
            //////////////mail legs/////////////////
            
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Battalion-Shattering Leggings",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_mail_raidshamanraid_s_01.jpg",
                Armor = 510,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 842,
                Haste = 1226

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Leggings of Venerated Spirits",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_mail_raidshamanraid_s_01.jpg",
                Armor = 510,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1122,
                Mastery = 945,
                RestrictedToClass = 7

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Legguards of Numbing Gloom",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_mail_raidhunter_s_01.jpg",
                Armor = 510,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1300,
                Versatility = 768

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Serpentstalker Legguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_mail_raidhunter_s_01.jpg",
                Armor = 510,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 975,
                Mastery = 1093,
                RestrictedToClass = 3

            });
            ///////////////mail Feet///////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Deft Soulhunter's Sabatons",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_mail_raidhunter_s_01.jpg",
                Armor = 401,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 709,
                Haste = 842
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Greatboots of the Searing Tempest",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_mail_raidshamanraid_s_01.jpg",
                Armor = 401,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 598,
                Mastery = 953
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 3,
                Ilvl = 960,
                Name = "Nathrezim Shade-Walkers",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_mail_raidshamanraid_s_01.jpg",
                Armor = 401,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 897,
                Versatility = 653
            });
            /////////////Ring////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 11,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Band of the Sargerite Smith",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_70_raid_ring4a.jpg",
                Stamina = 3203,
                Crit = 2232,
                Mastery = 1991
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 11,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Loop of the Life-Binder",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_70_raid_ring7d.jpg",
                Stamina = 3203,
                Haste = 1447,
                Mastery = 2775
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 11,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Seal of the Portalmaster",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_70_raid_ring2c.jpg",
                Stamina = 3203,
                Haste = 1568,
                Versatility = 2654
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 11,
                ArmorType = 0,
                Ilvl = 970,
                Name = "Sullied Seal of the Pantheon",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_70_raid_ring3a.jpg",
                Stamina = 3515,
                Versatility = 1922,
                Mastery = 2563
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 11,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Zealous Tormentor's Ring",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_70_quest_ring7a.jpg",
                Stamina = 3203,
                Crit = 1689,
                Haste = 2533
            });
            //////////////Trinkets////////////////////////
            /////Healer Trinkets/////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Carafe of Searing Light",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_offhand_pvealliance_d_01_gold.jpg",
                MainStat = 3608,
                EquipmentEffect = "Use: Sear an enemy with holy light, inflicting x Holy damage over 18 sec. Restores x mana each time damage is dealt.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 940,
                Name = "Eonar's Compassion",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_antorus_green.jpg",
                MainStat = 2994,
                EquipmentEffect = "Equip: Your healing effects have a chance to grow an Emerald Blossom nearby, which heals a random injured ally for x every 2 sec. Lasts 12 sec.\n\nEonar's Verdant Embrace\nWhen empowered by the Pantheon, your next 4 direct healing spells grant the target a shield that prevents x damage for 30 sec.",
                RestrictedToStat = 1

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Garothi Feedback Conduit",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_misc_enggizmos_06.jpg",
                MainStat = 3608,
                EquipmentEffect = "Equip: Your healing effects have a chance to increase your Haste by x for 8 sec, stacking up to 5 times. This is more likely to occur when you heal allies who are at low health.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Highfather's Machination",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/spell_nature_astralrecalgroup.jpg",
                Mastery = 1477,
                EquipmentEffect = "Equip: Your healing effects have a chance to apply a charge of Highfather's Timekeeping for 1 min, max 5 charges. When the ally falls below x% health, Highfather's Timekeeping is consumed to instantly heal them for x health per charge.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Ishkar's Felshield Emitter",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/ability_vehicle_shellshieldgenerator_green.jpg",
                Versatility = 1477,
                EquipmentEffect = "Use: Place a Felshield on an ally, absorbing x damage for 9 sec. When the shield is consumed or expires, it explodes dealing x% of the absorbed damage as Fire split amongst all enemies within 8 yds."
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Tarratus Keystone",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_datacrystal06.jpg",
                MainStat = 3608,
                EquipmentEffect = "Use: Open a portal at an ally's location that releases brilliant light, restoring x health split amongst injured allies within 20 yds.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Vitality Resonator",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_trinket_08d.jpg",
                Versatility = 1477,
                EquipmentEffect = "Use: Redirect the life force of an enemy, increasing your Intellect by up to x for 15 sec. This grants more Intellect when used against targets at high health.",
                RestrictedToStat = 1
            });
            ///////////////Spell dps trinkets/////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Acrid Catalyst Injector",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_trinket_01c.jpg",
                MainStat = 3608,
                EquipmentEffect = "Equip: Your damaging spells that critically strike have a chance to increase your Haste, Mastery, or Critical Strike by x for 45 sec, stacking up to 5 times. When any stack reaches 5, all effects are consumed to grant you x of all three attributes for 12 sec.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 940,
                Name = "Norgannon's Prowess",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_antorus_blue.jpg",
                Mastery = 1370,
                EquipmentEffect = "Equip: Your damaging spells have a chance to increase your Intellect by x for 12 sec.\n\nNorgannon's Command\nWhen empowered by the Pantheon, you gain 6 charges of Norgannon's Command for 15 sec. Your damaging spells expend a charge to inflict an additional x damage to the target, from a random school of magic.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Prototype Personnel Decimator",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/ability_rogue_cannonballbarrage.jpg",
                Haste = 1477,
                EquipmentEffect = "Equip: Your ranged attacks and spells have a chance to launch a Homing Missile if your target is at least x yds away, dealing up to x Fire damage to all enemies within 20 yds. Targets closer to the impact take more damage."

            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Sheath of Asara",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/spell_shadow_ritualofsacrifice.jpg",
                MainStat = 3608,
                EquipmentEffect = "Equip: Your damaging spells have a chance to conjure x Shadow Blades. After 2 sec, the swords begin launching foward, each dealing x Shadow damage to the first enemy in their path and increasing damage taken from your subsequent Shadow Blades by x% for 3 sec, up to x%.",
                RestrictedToStat = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Terminus Signaling Beacon",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_7_0raid_trinket_010d.jpg",
                Mastery = 1477,
                EquipmentEffect = "Use: Call a Legion ship to bombard the target's location for 9 sec, dealing x Fire damage to all targets within 12 yds, including the ship.",
                RestrictedToStat = 1
            });
            ///////////////////Agility trinkets/////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Forgefiend's Fabricator",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_jewelry_orgrimmarraid_trinket_04_green.jpg",
                Mastery = 1477,
                EquipmentEffect = "Equip: Your melee and ranged attacks have a chance to plant Fire Mines at the enemy's feet. Fire Mines detonate after 15 sec, inflicting x Fire damage to all enemies within 12 yds",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 940,
                Name = "Golganneth's Vitality",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_antorus_grey.jpg",
                MainStat = 2994,
                EquipmentEffect = "Equip: Your damaging abilities have a chance to create a Ravaging Storm at your target's location, inflicting x Nature damage split among all enemies within 6 yds over 6 sec.\n\nGolganneth's Thunderous Wrath\nWhen empowered by the Pantheon, your autoattacks cause an explosion of lightning dealing 12 Nature damage to all enemies within 8 yds of the target. Lasts 15 sec.",
                RestrictedToStat = 2
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Gorshalach's Legacy",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_sword_1h_firelandsraid_d_01.jpg",
                Haste = 1477,
                EquipmentEffect = "Equip: Your melee attacks have a chance to grant an Echo of Gorshalach. On reaching 15 applications, you lash out with a devastating combination of attacks, critically striking enemies in a 15 yd cone in front of you for x Fire damage.",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Seeping Scourgewing",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/ability_creature_poison_03.jpg",
                Versatility = 1477,
                EquipmentEffect = "Equip: Your melee attacks have a chance to deal x Shadow damage to the target. If there are no other enemies within x yds of them, this deals an additional x damage.",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Shadow-Singed Fang",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_misc_blacksaberonfang.jpg",
                EquipmentEffect = "Equip: Your melee and ranged abilities have a chance to increase your Strength or Agility by x for 12 sec.\n\n\n Equip: Your autoattacks have a chance to increase your Critical Strike by x for 12 sec.",
                RestrictedToStat = 4
            });
            ///////////////Strength dps trinket///////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 940,
                Name = "Khaz'goroth's Courage",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_antorus_red.jpg",
                MainStat = 2994,
                EquipmentEffect = "Equip: Your damaging attacks have a chance to make your weapon glow hot with the fire of Khaz'goroth's forge, causing your autoattacks to do x additional Fire damage for 12 sec.\n\n\n\nKhaz'goroth's Shaping\n\nWhen empowered by the Pantheon, your Critical Strike, Haste, Mastery, or Versatility is increased by x for 15 sec. Khaz'goroth always empowers your highest stat.",
                RestrictedToStat = 3
            });
            ///////////////Tank Trinkets////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 940,
                Name = "Aggramar's Conviction",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_antorus_orange.jpg",
                MainStat = 2994,
                EquipmentEffect = "Equip: Taking damage has a chance to increase your Versatility by x for 14 sec.\n\nAggramar's Fortitude\nWhen empowered by the Pantheon, your maximum health is increased by x for 15 sec, and you are healed to full health.",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Apocalypse Drive",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_misc_enggizmos_11.jpg",
                Haste = 1477,
                EquipmentEffect = "Use: Reduce the damage of the next 10 melee attacks against you by up to x each. Lasts up to 20 sec.\n\nSuffering melee attacks reduces the cooldown of this ability by 1 sec.",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Diima's Glacial Aegis",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/ability_hunter_glacialtrap.jpg",
                MainStat = 3608,
                EquipmentEffect = "Use: Increase your Armor by x for 12 sec, and inflict x Frost damage to enemies within 12 yds and reduce their movement speed by x for 12 sec",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Eye of F'harg",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_misc_enchantedpearlc.jpg",
                MainStat = 3608,
                Armor = 1131,
                EquipmentEffect = "Equip: Grants x additional Versatility to a nearby tank-specialized ally bearing the Eye of Shatug\n\n\n Use: Transform to Eye of Shatug",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Eye of Shatug",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_misc_enchantedpearlc.jpg",
                Stamina = 5412,
                Versatility = 1477,
                EquipmentEffect = "Equip: Grants x additional Armor to a nearby tank-specialized ally bearing the Eye of F'harg\n\n\n Use: Transform to Eye of F'harg",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Riftworld Codex",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_offhand_pvp330_d_02.jpg",
                Crit = 1477,
                EquipmentEffect = "Equip: Taking damage has a chance to open a portal to another world, either healing you, providing an absorption shield, or empowering you with shadowflame magic",
                RestrictedToStat = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 12,
                ArmorType = 0,
                Ilvl = 960,
                Name = "Smoldering Titanguard",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/ability_warrior_shieldmastery.jpg",
                Mastery = 1477,
                EquipmentEffect = "Use: Channel a Bulwark of Flame that absorbs x damage for 3 sec. When the Bulwark expires you unleash x Waves of Flame, dealing x Fire damage to all enemies in their path.\n\nYou cannot move or use abilities during Bulwark of Flame",
                RestrictedToStat = 4
            });
            //////////////cloth Heads////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Crown of Relentless Annihilation",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_cloth_raidpriest_s_01.jpg",
                Armor = 313,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1300,
                Versatility = 738
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Gilded Seraph's Crown",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_cloth_raidpriest_s_01.jpg",
                Armor = 313,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1300,
                Mastery = 768,
                RestrictedToClass = 5
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Soulhunter's Cowl",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_cloth_raidwarlock_s_01.jpg",
                Armor = 313,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1182,
                Mastery = 886
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Runebound Collar",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_cloth_raidmage_s_01.jpg",
                Armor = 313,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 871,
                Mastery = 1196,
                RestrictedToClass = 8
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Grim Inquisitor's Death Mask",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_cloth_raidwarlock_s_01.jpg",
                Armor = 313,
                MainStat = 3795,
                Stamina = 5693,
                Versatility = 827,
                Mastery = 1241,
                RestrictedToClass = 9
            });

            ///////////////cloth shoulders//////////////////

            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Fallen Avenger's Amice",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_cloth_raidpriest_s_01.jpg",
                Armor = 289,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 609,
                Haste = 1182
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Gilded Seraph's Amice",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_cloth_raidpriest_s_01.jpg",
                Armor = 289,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 620,
                Mastery = 930,
                RestrictedToClass = 5
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Soul-Siphon Mantle",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_cloth_raidwarlock_s_01.jpg",
                Armor = 289,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 631,
                Mastery = 919
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Runebound Mantle",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulders_cloth_raidmage_s_01.jpg",
                Armor = 289,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 997,
                Mastery = 554,
                RestrictedToClass = 8
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Grim Inquisitor's Shoulderguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_cloth_raidwarlock_s_01.jpg",
                Armor = 289,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 953,
                Mastery = 598,
                RestrictedToClass = 9
            });

            ////////////////////Cloth Chests/////////////////////////

            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Gilded Seraph's Robes",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_robe_cloth_raidpriest_s_01.jpg",
                Armor = 385,
                MainStat = 3975,
                Stamina = 5693,
                Crit = 842,
                Versatility = 1226,
                RestrictedToClass = 5
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Magma-Spattered Smock",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_cloth_raidwarlock_s_01.jpg",
                Armor = 385,
                MainStat = 3975,
                Stamina = 5693,
                Versatility = 798,
                Mastery = 1270
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Vestments of Enflamed Blight",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_robe_cloth_raidpriest_s_01.jpg",
                Armor = 385,
                MainStat = 3975,
                Stamina = 5693,
                Crit = 1315,
                Haste = 753
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 1,
                Ilvl = 970,
                Name = "Gambeson of Sargaras' Corruption",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_cloth_raidmage_s_01.jpg",
                Armor = 399,
                MainStat = 4166,
                Stamina = 6250,
                Haste = 1350,
                Mastery = 797
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Runebound Tunic",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_cloth_raidmage_s_01.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1196,
                Versatility = 871,
                RestrictedToClass = 8
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Grim Inquisitor's Robes",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_cloth_raidwarlock_s_01.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 738,
                Haste = 1330,
                RestrictedToClass = 9
            });
            ////////////////////////// Cloth Wrist////////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Blood-Drenched Bindings",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_bracer_cloth_raidwarlock_s_01.jpg",
                Armor = 169,
                MainStat = 2135,
                Stamina = 3203,
                Crit = 731,
                Mastery = 432
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Man'ari Pyromancer Cuffs",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_bracer_cloth_raidmage_s_01.jpg",
                Armor = 169,
                MainStat = 2135,
                Stamina = 3203,
                Versatility = 498,
                Mastery = 665
            });

            //////////////////////Cloth hands/////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Aranasi Shadow-Weaver's Gloves",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_cloth_raidmage_s_01.jpg",
                Armor = 241,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 897,
                Mastery = 653
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Gilded Seraph's Handwraps",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_cloth_raidpriest_s_01.jpg",
                Armor = 241,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 554,
                Mastery = 997,
                RestrictedToClass = 5
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 1,
                Ilvl = 970,
                Name = "Handwraps of Inevitable Doom",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_cloth_raidwarlock_s_01.jpg",
                Armor = 250,
                MainStat = 3124,
                Stamina = 4687,
                Crit = 667,
                Mastery = 943
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Runebound Gloves",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_cloth_raidmage_s_01.jpg",
                Armor = 241,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 953,
                Haste = 598,
                RestrictedToClass = 8
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Grim Inquisitor's Gloves",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_cloth_raidwarlock_s_01.jpg",
                Armor = 241,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 886,
                Versatility = 665,
                RestrictedToClass = 9
            });
            /////////////////////cloth waist////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Cord of Blossoming Petals",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_cloth_raidpriest_s_01.jpg",
                Armor = 217,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 886,
                Versatility = 665
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Cord of Surging Hysteria",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_cloth_raidwarlock_s_01.jpg",
                Armor = 217,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 942,
                Mastery = 609
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Enhanced Worldscorcher Cinch",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_cloth_raidmage_s_01.jpg",
                Armor = 217,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 587,
                Mastery = 964
            });
            /////////////////////////////////// Cloth Legs //////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Fervent Twilight Legwraps",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_cloth_raidpriest_s_01.jpg",
                Armor = 337,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1182,
                Versatility = 886
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Gilded Seraph's Leggings",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_cloth_raidpriest_s_01.jpg",
                Armor = 337,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 857,
                Haste = 1211,
                RestrictedToClass = 5
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Legwraps of the Seasoned Exterminator",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_cloth_raidwarlock_s_01.jpg",
                Armor = 337,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 945,
                Mastery = 1122
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Runebound Leggings",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_cloth_raidmage_s_01.jpg",
                Armor = 337,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1285,
                Versatility = 783,
                RestrictedToClass = 8
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Grim Inquisitor's Leggings",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_cloth_raidwarlock_s_01.jpg",
                Armor = 337,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1211,
                Mastery = 857,
                RestrictedToClass = 9
            });
            ////////////////////Cloth feet////////////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Lady Dacidion's Silk Slippers",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_cloth_raidwarlock_s_01.jpg",
                Armor = 265,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 631,
                Haste = 919
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Sandals of the Reborn Colossus",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_cloth_raidpriest_s_01.jpg",
                Armor = 265,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 598,
                Mastery = 953
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 1,
                Ilvl = 960,
                Name = "Wisperstep Runners",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_cloth_raidmage_s_01.jpg",
                Armor = 265,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 908,
                Mastery = 642
            });
            ///////////////////Leather Head/////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 2,
                Ilvl = 960,
                Name = "General Erodus' Tricorne",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_helm.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Versatility = 916,
                Mastery = 1152
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Headdress of Living Brambles",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_leather_raiddruid_s_01.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 738,
                Haste = 1330
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Cavalier Hat of the Dashing Scoundrel",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_helm.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1093,
                Mastery = 975,
                RestrictedToClass = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Douli of Chi'ji",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_inv_leather_raidmonk_s_01.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1300,
                Versatility = 768,
                RestrictedToClass = 10
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Bearmantle Headdress",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_leather_raiddruid_s_01.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 798,
                Mastery = 1270,
                RestrictedToClass = 11
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Felreaper Hood",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01helm.jpg",
                Armor = 385,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1063,
                Mastery = 1004,
                RestrictedToClass = 12
            });
            ////////////////////////////Leather shoulders///////////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Shoulderpads of the Demonic Blitz",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_shoulder.jpg",
                Armor = 356,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 942,
                Mastery = 609
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Spaulders of the Relentless Tracker",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_leather_raiddruid_s_01.jpg",
                Armor = 356,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 665,
                Mastery = 886
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Shoulderpads of the Dashing Scoundrel",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_shoulder.jpg",
                Armor = 356,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 842,
                Versatility = 709,
                RestrictedToClass = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Meditation Spheres of Chi'Ji",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_inv_leather_raidmonk_s_01.jpg",
                Armor = 356,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 997,
                Mastery = 554,
                RestrictedToClass = 10
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Bearmantle Shoulders",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_leather_raiddruid_s_01.jpg",
                Armor = 356,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 875,
                Mastery = 676,
                RestrictedToClass = 11
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Felreaper Spaulders",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01shoulders.jpg",
                Armor = 356,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 975,
                Versatility = 576,
                RestrictedToClass = 12
            });
            //////////////////////////////////////Leather Chest/////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Harness of Oppressing Dark",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_leather_raiddruid_s_01.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1255,
                Haste = 812
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Vest of the Dashing Scoundrel",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_chest.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Versatility = 768,
                Mastery = 1300,
                RestrictedToClass = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Vest of Unfathomable Anguish",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01chest.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1226,
                Mastery = 842
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Vest of Waning Life",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_inv_leather_raidmonk_s_01.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1165,
                Versatility = 981
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Tunic of Chi'Ji",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_inv_leather_raidmonk_s_01.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 945,
                Mastery = 1122,
                RestrictedToClass = 10
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Bearmantle Harness",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_leather_raiddruid_s_01.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1182,
                Versatility = 886,
                RestrictedToClass = 11
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Felreaper Vest",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01chest.jpg",
                Armor = 474,
                MainStat = 3795,
                Stamina = 5693,
                Versatility = 1285,
                Mastery = 783,
                RestrictedToClass = 12
            });
            /////////////////////////////Leather wrist////////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Bracers of Wanton Morality",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_bracer.jpg",
                Armor = 208,
                MainStat = 2135,
                Stamina = 3203,
                Haste = 731,
                Versatility = 432
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Fiendish Logistican's Wristwraps",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01bracer.jpg",
                Armor = 208,
                MainStat = 2135,
                Stamina = 3203,
                Crit = 623,
                Haste = 540
            });
            /////////////////////////////////////Leather Gloves//////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Gloves of the Dashing Scoundrel",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_glove.jpg",
                Armor = 296,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 576,
                Mastery = 975,
                RestrictedToClass = 4
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Grips of Hungering Shadows",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_glove.jpg",
                Armor = 296,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 642,
                Versatility = 908
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Lurid Grips of the Obscene",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_inv_leather_raidmonk_s_01.jpg",
                Armor = 296,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 731,
                Mastery = 820
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Grips of Chi'Ji",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_inv_leather_raidmonk_s_01.jpg",
                Armor = 296,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 831,
                Versatility = 720,
                RestrictedToClass = 10
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Bearmantle Paws",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_leather_raiddruid_s_01.jpg",
                Armor = 296,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 576,
                Mastery = 976,
                RestrictedToClass = 11
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Felreaper Gloves",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01glove.jpg",
                Armor = 296,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 842,
                Haste = 709,
                RestrictedToClass = 12
            });

            ///////////////////////Leather belt/////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Belt of Fractured Sanity",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_inv_leather_raidmonk_s_01.jpg",
                Armor = 267,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 908,
                Versatility = 642
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 2,
                Ilvl = 970,
                Name = "Death-Enveloping Cincture",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01buckle.jpg",
                Armor = 276,
                MainStat = 3124,
                Stamina = 4687,
                Haste = 920,
                Mastery = 690
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Portal Keeper's Cincture",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_belt.jpg",
                Armor = 267,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 731,
                Mastery = 820
            });

            ///////////////////////Leather Legs/////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Breach-Blocker Legguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_leather_raiddruid_s_01.jpg",
                Armor = 415,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1211,
                Versatility = 857
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Caustic Titanspite Legguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01pants.jpg",
                Armor = 415,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1122,
                Mastery = 945
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Felreaper Leggings",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01pants.jpg",
                Armor = 415,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1167,
                Versatility = 901,
                RestrictedToClass = 12
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Bearmantle Legguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_leather_raiddruid_s_01.jpg",
                Armor = 415,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1211,
                Haste = 857,
                RestrictedToClass = 11
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Leggings of Chi'Ji",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_inv_leather_raidmonk_s_01.jpg",
                Armor = 415,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 798,
                Mastery = 1270,
                RestrictedToClass = 10
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Pants of the Dashing Scoundrel",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raidrogue_s_01_pant.jpg",
                Armor = 415,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1330,
                Versatility = 738,
                RestrictedToClass = 4
            });

            /////////////////////Leather Feet///////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Depraved Machinist's Footpads",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_leather_raiddemonhunter_q_01boots.jpg",
                Armor = 326,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 609,
                Haste = 942
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Life-Bearing Footpads",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_inv_leather_raidmonk_s_01.jpg",
                Armor = 326,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 842,
                Mastery = 709
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 2,
                Ilvl = 960,
                Name = "Vicious Flamepaws",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_leather_raiddruid_s_01.jpg",
                Armor = 326,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 665,
                Mastery = 886
            });
            ////////////Plate Head/////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Helmet of the Hidden Sanctuary",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01helm.jpg",
                Armor = 707,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 975,
                Mastery = 1093
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Juggernaut Helm",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01helm.jpg",
                Armor = 707,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 886,
                Versatility = 1182,
                RestrictedToClass = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Titan-Subjugator's Visage",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_plate_raiddeathknight_s_01.jpg",
                Armor = 707,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1241,
                Versatility = 827
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Light's Vanguard Helm",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_plate_raidpaladin_s_01.jpg",
                Armor = 707,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1270,
                Mastery = 798,
                RestrictedToClass = 2
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 1,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Dreadwake Helm",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_helm_plate_raiddeathknight_s_01.jpg",
                Armor = 707,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 738,
                Mastery = 1330,
                RestrictedToClass = 6
            });

            //////////////////////Plate Shoulders/////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Juggernaut Pauldrons",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01shoulder.jpg",
                Armor = 653,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 631,
                Mastery = 919,
                RestrictedToClass = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Pauldrons of the Eternal Offensive",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_plate_raidpaladin_s_01.jpg",
                Armor = 653,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 554,
                Haste = 997
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Shoulderguards of the Indomitable Purpose",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01shoulder.jpg",
                Armor = 653,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 631,  
                Mastery = 919
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Light's Vanguard Shoulderplates",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_plate_raidpaladin_s_01.jpg",
                Armor = 653,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 665,
                Versatility = 886,
                RestrictedToClass = 2
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 3,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Dreadwake Pauldrons",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_shoulder_plate_raiddeathknight_s_01.jpg",
                Armor = 653,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 908,
                Versatility = 642,
                RestrictedToClass = 6
            });

            /////////////////////////////Plate Chest////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Breastplate of Molten Rebirth",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01chest.jpg",
                Armor = 870,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1270,
                Haste = 798
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Dreadwake Bonecage",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_plate_raiddeathknight_s_01.jpg",
                Armor = 870,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 871,
                Versatility = 1196,
                RestrictedToClass = 6
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Soul-Tempered Chestplate",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_plate_raiddeathknight_s_01.jpg",
                Armor = 870,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1167,
                Mastery = 901
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Light's Vanguard Breastplate",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_chest_plate_raidpaladin_s_01.jpg",
                Armor = 870,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 798,
                Haste = 1270,
                RestrictedToClass = 2
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 5,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Juggernaut Breastplate",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01chest.jpg",
                Armor = 870,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 827,
                Mastery = 1241,
                RestrictedToClass = 1
            });
            /////////////////Plate wrist////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Vambracers of Life's Assurance",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_bracer_plate_raidpaladin_s_01.jpg",
                Armor = 381,
                MainStat = 2135,
                Stamina = 3203,
                Haste = 665,
                Mastery = 498
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 9,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Varimathras' Shattered Manacles",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01bracer.jpg",
                Armor = 381,
                MainStat = 2135,
                Stamina = 3203,
                Crit = 656,
                Haste = 506
            });

            ///////////////////////Plate hands/////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Imonar's Demi-Gauntles",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01gloves.jpg",
                Armor = 544,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 698,
                Versatility = 853
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Juggernaut Gauntles",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01gloves.jpg",
                Armor = 544,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 864,
                Mastery = 687,
                RestrictedToClass = 1
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Molten Bite Handguards",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_plate_raidpaladin_s_01.jpg",
                Armor = 544,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 653,
                Haste = 897
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 4,
                Ilvl = 970,
                Name = "Nascent Deathbringer's Clutches",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_plate_raiddeathknight_s_01.jpg",
                Armor = 556,
                MainStat = 3124,
                Stamina = 4687,
                Crit = 955,
                Mastery = 655
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Light's Vanguard Gauntlets",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_plate_raidpaladin_s_01.jpg",
                Armor = 544,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 676,
                Mastery = 875,
                RestrictedToClass = 2
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 10,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Dreadwake Gauntlets",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_glove_plate_raiddeathknight_s_01.jpg",
                Armor = 544,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 908,
                Mastery = 642,
                RestrictedToClass = 6
            });
            //////////////////////Plate belt////////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Flamelicked Girdle",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_plate_raiddeathknight_s_01.jpg",
                Armor = 490,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 653,
                Versatility = 897
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Grond-Father Girdle",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01buckle.jpg",
                Armor = 490,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 908,
                Mastery = 642
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 6,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Nathrezim Battle Girdle",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_belt_plate_raidpaladin_s_01.jpg",
                Armor = 490,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 665,
                Mastery = 886
            });

            ///////////////////////////////Plate Legs////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 4,
                Ilvl = 970,
                Name = "Cosmos-Culling Legplates",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_plate_raidpaladin_s_01.jpg",
                Armor = 779,
                MainStat = 4166,
                Stamina = 6250,
                Haste = 1227,
                Mastery = 920
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Dreadwake Legplates",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_plate_raiddeathknight_s_01.jpg",
                Armor = 762,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 1152,
                Versatility = 916,
                RestrictedToClass = 6
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Greaves of Mercurial Allegiance",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_plate_raiddeathknight_s_01.jpg",
                Armor = 762,
                MainStat = 3795,
                Stamina = 5693,
                Versatility = 812,
                Mastery = 1255
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Light's Vanguard Legplates",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_pant_plate_raidpaladin_s_01.jpg",
                Armor = 762,
                MainStat = 3795,
                Stamina = 5693,
                Haste = 842,
                Mastery = 1226,
                RestrictedToClass = 2
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 7,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Juggernaut Legplates",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01pants.jpg",
                Armor = 762,
                MainStat = 3795,
                Stamina = 5693,
                Crit = 1093,
                Versatility = 975,
                RestrictedToClass = 1
            });

            /////////////////////////Plate Feet////////////////////
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Burning Coven Sabatons",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_plate_raidwarrior_s_01boots.jpg",
                Armor = 598,
                MainStat = 2847,
                Stamina = 4270,
                Haste = 930,
                Mastery = 620
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Doomwalker Warboots",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_plate_raiddeathknight_s_01.jpg",
                Armor = 598,
                MainStat = 2847,
                Stamina = 4270,
                Crit = 942,
                Haste = 609
            });
            context.Equipments.Add(new Equipment()
            {
                Slot = 8,
                ArmorType = 4,
                Ilvl = 960,
                Name = "Eredar Warcouncil Sabatons",
                Icon = "https://wow.zamimg.com/images/wow/icons/large/inv_boot_plate_raidpaladin_s_01.jpg",
                Armor = 598,
                MainStat = 2847,
                Stamina = 4270,
                Versatility = 576,
                Mastery = 975
            });
            Connection();
            for (int i = 0; i < RealmId.Length; i++)
            {
                context.Realms.Add(new Realm()
                {
                    id = RealmId[i],
                    name = RealmName[i]
                });
            }
                
            
            base.Seed(context);

        }
        public void Connection()
        {
            var ur = new Uri("https://eu.api.battle.net/data/wow/realm/?namespace=dynamic-eu&locale=en_GB&access_token=fb5hv9pjubvebavu85qxstjz");
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(ur).Result;
                if (!response.IsSuccessStatusCode) return;
                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<RealmRootobject>(responseString);
                for (var i = 0; i < data.realms.Length; i++)
                {

                    RealmName[i] = data.realms[i].name;
                    RealmId[i] = data.realms[i].id;

                }
            }
        }


    }
}
