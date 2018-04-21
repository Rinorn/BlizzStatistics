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
            base.Seed(context);
        }

    }
}
