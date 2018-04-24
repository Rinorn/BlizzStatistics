using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace BlizzStatistics.DataAccess
{
    public class BlizzStatisticsDbInitializer : DropCreateDatabaseIfModelChanges<BlizzStatisticsContext>
    {
        protected override void Seed(BlizzStatisticsContext context)
        {
            
            //Seeds the db with the character classes
            context.CharacterClasses.Add(new CharacterClass()
            {
                id=1,
                name = "Warrior",
                classDescription = "For as long as war has raged, heroes from every race have aimed to master the art of battle. Warriors combine strength, leadership, and a vast knowledge of arms and armor to wreak havoc in glorious combat. Some protect from the front lines with shields, locking down enemies while allies support the warrior from behind with spell and bow. Others forgo the shield and unleash their rage at the closest threat with a variety of deadly weapons.",
                ClassIcon = "http://localhost:60158/api/images/warrior_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/warrior_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id=2,
                name = "Paladin",
                classDescription = "This is the call of the paladin: to protect the weak, to bring justice to the unjust, and to vanquish evil from the darkest corners of the world. These holy warriors are equipped with plate armor so they can confront the toughest of foes, and the blessing of the Light allows them to heal wounds and, in some cases, even restore life to the dead.",
                ClassIcon = "http://localhost:60158/api/images/paladin_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/paladin_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id=3,
                name = "Hunter",
                classDescription = "From an early age, the call of the wild draws some adventurers from the comfort of their homes into the unforgiving primal world outside. Those who endure become hunters. Masters of their environment, they are able to slip like ghosts through the trees and lay traps in the paths of their enemies.",
                ClassIcon = "http://localhost:60158/api/images/hunter_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/hunter_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 4,
                name = "Rogue",
                classDescription = "For rogues, the only code is the contract, and their honor is purchased in gold. Free from the constraints of a conscience, these mercenaries rely on brutal and efficient tactics. Lethal assassins and masters of stealth, they will approach their marks from behind, piercing a vital organ and vanishing into the shadows before the victim hits the ground.",
                ClassIcon = "http://localhost:60158/api/images/rogue_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/rogue_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 5,
                name = "Priest",
                classDescription = "Priests are devoted to the spiritual, and express their unwavering faith by serving the people. For millennia they have left behind the confines of their temples and the comfort of their shrines so they can support their allies in war-torn lands. In the midst of terrible conflict, no hero questions the value of the priestly orders.",
                ClassIcon = "http://localhost:60158/api/images/priest_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/priest_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 6,
                name = "Death Knight",
                classDescription = "When the Lich King’s control of his death knights was broken, his former champions sought revenge for the horrors committed under his command. After their vengeance was won, the death knights found themselves without a cause and without a home. One by one they trickled into the land of the living in search of a new purpose.",
                ClassIcon = "http://localhost:60158/api/images/dk_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/dk_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 7,
                name = "Shaman",
                classDescription = "Shaman are spiritual guides and practitioners, not of the divine, but of the very elements. Unlike some other mystics, shaman commune with forces that are not strictly benevolent. The elements are chaotic, and left to their own devices, they rage against one another in unending primal fury. It is the call of the shaman to bring balance to this chaos. Acting as moderators among earth, fire, water, and air, shaman summon totems that focus the elements to support the shaman’s allies or punish those who threaten them.",
                ClassIcon = "http://localhost:60158/api/images/shaman_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/shaman_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 8,
                name = "Mage",
                classDescription = "Students gifted with a keen intellect and unwavering discipline may walk the path of the mage. The arcane magic available to magi is both great and dangerous, and thus is revealed only to the most devoted practitioners. To avoid interference with their spellcasting, magi wear only cloth armor, but arcane shields and enchantments give them additional protection. To keep enemies at bay, magi can summon bursts of fire to incinerate distant targets and cause entire areas to erupt, setting groups of foes ablaze.",
                ClassIcon = "http://localhost:60158/api/images/mage_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/mage_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 9,
                name = "Warlock",
                classDescription = "In the face of demonic power, most heroes see death. Warlocks see only opportunity. Dominance is their aim, and they have found a path to it in the dark arts. These voracious spellcasters summon demonic minions to fight beside them. At first, they command only the service of imps, but as a warlock’s knowledge grows, seductive succubi, loyal voidwalkers, and horrific felhunters join the dark sorcerer’s ranks to wreak havoc on anyone who stands in their master’s way.",
                ClassIcon = "http://localhost:60158/api/images/warlock_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/warlock_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 10,
                name = "Monk",
                classDescription = "When the pandaren were subjugated by the mogu centuries ago, it was the monks that brought hope to a seemingly dim future. Restricted from using weapons by their slave masters, these pandaren instead focused on harnessing their chi and learning weaponless combat. When the opportunity for revolution struck, they were well-trained to throw off the yoke of oppression.",
                ClassIcon = "http://localhost:60158/api/images/monk_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/monk_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 11,
                name = "Druid",
                classDescription = "Druids harness the vast powers of nature to preserve balance and protect life. With experience, druids can unleash nature’s raw energy against their enemies, raining celestial fury on them from a great distance, binding them with enchanted vines, or ensnaring them in unrelenting cyclones.",
                ClassIcon = "http://localhost:60158/api/images/druid_icon.jpg/",
                ClassModel = "http://localhost:60158/api/images/druid_model.jpg/"
            });
            context.CharacterClasses.Add(new CharacterClass()
            {
                id = 12,
                name = "Demon Hunter",
                classDescription = "Demon hunters, disciples of Illidan Stormrage, uphold a dark legacy, one that frightens their allies and enemies alike. The Illidari embrace fel and chaotic magics—energies that have long threatened the world of Azeroth—believing them necessary to challenge the Burning Legion. Wielding the powers of demons they’ve slain, they develop demonic features that incite revulsion and dread in fellow elves.",
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
            context.SavedCharacters.Add(new SavedCharacter()
            {
                id = 1,
                name = "PestErBest",
                ClassName = "Priest",
                realm = "StormScale",
                level = 110
            });
            context.SavedCharacters.Add(new SavedCharacter()
            {
                id = 2,
                name = "SuperSteinar",
                ClassName = "Warrior",
                realm = "StormScale",
                level = 110
            });
            context.SavedCharacters.Add(new SavedCharacter()
            {
                id = 3,
                name = "HelligDykker",
                ClassName = "Paladin",
                realm = "StormScale",
                level = 110
            });
            context.SavedCharacters.Add(new SavedCharacter()
            {
                id = 4,
                name = "RødtKjøtt",
                ClassName = "Monk",
                realm = "StormScale",
                level = 110
            });
            base.Seed(context);
        }

    }
}
