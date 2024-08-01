using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SRTPluginProviderED.Structs.GameStructs
{
    public struct GamePlayer
    {
        public static Dictionary<string, int> bossStatusOffsets = new Dictionary<string, int>(){
            // Limgrave
            {"Alabaster Lord", 0x702D3},
            {"Beastman of Faram Azula", 0x170CC8},
            {"Bell Bearing Hunter (Warmaster's Shack)", 0xA0E25},
            {"Black Knife Assassin (Deathtouched Catacombs)", 0x16AC1A},
            {"Bloodhound Knight (Forlorn Hound Evergaol)", 0xB154E},
            {"Crucible Knight", 0xA0AB4},
            {"Deathbird (Limgrave)", 0xA0E1F},
            {"Demi-Human Chiefs", 0x174184},
            {"Erdtree Burial Watchdog (Stormfront Catacombs)", 0x16848D},
            {"Flying Dragon Agheel", 0xA9001},
            {"Godrick the Grafted", 0x151C33},
            {"Grafted Scion", 0x152098},
            {"Grave Warden Duelist (Murkwater Catacombs)", 0x168D57},
            {"Guardian Golem", 0x1745E9},
            {"Mad Pumpkin Head", 0xB18B9},
            {"Margit the Fell Omen", 0x151C39},
            {"Night's Cavalry (Limgrave)", 0xA936C},
            {"Patches", 0x16FF99},
            {"Soldier of Godrick", 0x15B608},
            {"Stonedigger Troll (Limgrave Tunnels)", 0x1787D4},
            {"Tibia Mariner (Summonwater Village)", 0xBABB2},
            {"Tree Sentinel", 0xA0749},
            {"Ulcerated Tree Spirit (Fringefolk Hero's Grave)", 0x15B602},

            // Weepin Weepin Peninsula
            {"Ancient Hero of Zamor (Weeping Evergaol)", 0x9FD08},
            {"Cemetery Shade (Tombsward Catacombs)", 0x167BC3},
            {"Deathbird (Weeping Peninsula)", 0xB0B0D},
            {"Erdtree Avatar", 0xA85C0},
            {"Edtree Burial Watchdog", 0x168028},
            {"Leonine Misbegotten", 0xA7B7F},
            {"Miranda the Blighted Bloom", 0x170863},
            {"Night's Cavalry (Weeping Peninsula)", 0xB0B13},
            {"Runebear", 0x1703FE},
            {"Scaly Misbegotten", 0x17836F},

            // Liurnia of the Lakes
            {"Adan, Thief of Fire", 0x7F580},
            {"Alecto, Black Knife Ringleader", 0x54D53},
            {"Bell Bearing Hunter (Church of Vows)", 0x77DDF},
            {"Black Knife Assassin (Black Knife Catacombs)", 0x1691C2},
            {"Bloodhound Knight (Lakeside Crystal Cave)", 0x171592},
            {"Bols, Carian Knight", 0x55794},
            {"Cemetery Shade (Black Knife Catacombs)", 0x1691BC},
            {"Cleanrot Knight", 0x17112D},
            {"Crystalian", 0x178C39},
            {"Crystalian Spear & Crystalian Staff", 0x1719F7},
            {"Death Rite Bird (Liurnia North)", 0x6F1BC},
            {"Deathbird (Liurnia South)", 0x77033},
            {"Erdtree Avatar (Liurnia Northeast)", 0x80D6D},
            {"Erdtree Avatar (Liurnia Southwest)", 0x550BE},
            {"Erdtree Burial Watchdog (Cliffbottom Catacombs)", 0x169621},
            {"Glintstone Dragon Adula", 0x5D60B},
            {"Glintstone Dragon Smarag", 0x5E04C},
            {"Magma Wyrm Makar", 0x15DD8F},
            {"Night's Cavalry (Liurnia North)", 0x158146},
            {"Night's Cavalry (Liurnia South)", 0x8850E},
            {"Omenkiller", 0x65EC3},
            {"Onyx Lord (Royal Grave Evergaol)", 0x702D3},
            {"Red Wolf of Radagon", 0x15814C},
            {"Rennala, Queen of the Full Moon", 0x158146},
            {"Royal Knight Loretta", 0x67A1B},
            {"Royal Revenant", 0x5EA8D},
            {"Spiritcaller Snail", 0x1688F2},
            {"Tibia Mariner (East Liurnia)", 0x88879},

            // Caelid
            {"Cemetery Shade (Caelid Catacombs)", 0x16BDAE},
            {"Commander O'Neil (Swamp)", 0xDCB27},
            {"Crucible Knight & Misbegotten Warrior (Redmane Castle)", 0xED5C1},
            {"Death Rite Bird (Caelid)", 0xDC7C2},
            {"Decaying Ekzykes (Caelid)", 0xD3F04},
            {"Elder Dragon Greyoll", 0xE5AB5},
            {"Erdtree Burial Watchdogs (Minor Erdtree Catacombs)", 0x16B949},
            {"Fallingstar Beast (Sellia Crystal Tunnel)", 0x17A232},
            {"Frenzied Duelist", 0x17577D},
            {"Mad Pumpkin Heads", 0xD4945},
            {"Magma Wyrm (Gael Tunnel)", 0x179DCD},
            {"Night's Cavalry (Caelid)", 0xDC7BC},
            {"Nox Swordstress and Nox Priest", 0xDCE92},
            {"Putrid Avatar (Caelid)", 0xCC08D},
            {"Starscourge Radahn", 0x1A1B02},

            // Dragonbarrow
            {"Battlemage Hugues", 0xDCE98},
            {"Beastmen of Faram Azula", 0x172B8B},
            {"Bell Bearing Hunter (Isolated Merchant's Shack)", 0xD4CB0},
            {"Black Blade Kindred (Bestial Sanctum)", 0xEEDAE},
            {"Cleanrot Knights", 0x175318},
            {"Flying Dragon Greyll", 0xF6F90},
            {"Godskin Apostle (Divine Tower of Caelid)", 0x16310E},
            {"Night's Cavalry (Dragonbarrow)", 0xF6F96},
            {"Putrid Avatar (Dragonbarrow)", 0xEE36D},
            {"Putrid Crystalians", 0x172FF0},
            {"Putrid Tree Spirit", 0x16C213},

            // Altus Plateau
            {"Ancient Dragon Lansseax", 0x78EF6},
            {"Ancient Hero of Zamor (Sainted Hero's Grave)", 0x169EEB},
            {"Black Knife Assassin (Sage's Cave)", 0x174EB3},
            {"Black Knife Assassin (Sainted Hero's Grave)", 0x92C89},
            {"Crystalian Spear and Crystalian Ringblade", 0x179968},
            {"Demi-Human Queen Gilika", 0x817AE},
            {"Elemer of the Briar", 0x8AAA7},
            {"Erdtree Burial Watchdog (Wyndham Catacombs)", 0x169A86},
            {"Fallingstar Beast (Altus Plateau)", 0x9AE6B},
            {"Godefroy the Grafted", 0x89CFB},
            {"Godskin Apostle (Dominula, Windmill Village)", 0xA483A},
            {"Necromancer Garris", 0x174EB9},
            {"Night's Cavalry (Altus Plateau)", 0x8A066},
            {"Omenkiller and Miranda the Blighted Bloom", 0x174A4E},
            {"Perfumer Tricia and Misbegotten Warrior", 0x16B07F},
            {"Sanguine Noble", 0x92FF4},
            {"Stonedigger Troll (Old Altus Tunnel)", 0x17909E},
            {"Tibia Mariner (Wyndham Ruins)", 0x81B19},
            {"Tree Sentinels", 0x9B1D6},
            {"Wormface", 0xA483A},

            // Capital Outskirts
            {"Bell Bearing Hunter (Hermit Merchant's Shack)", 0xACA1C},
            {"Crucible Knight & Crucible Knight Ordovis", 0x16A7B5},
            {"Deathbird (Warmaster's Shack)", 0xB52D4},
            {"Draconic Tree Sentinel", 0xBD821},
            {"Fell Twins", 0x163579},
            {"Grave Warden Duelist (Auriza Side Tomb)", 0x16B4E4},
            {"Onyx Lord (Sealed Tunnel)", 0x162CA9},

            // Leyendell, Royal Capital
            {"Esgar, Priest of Blood", 0x15D066},
            {"Godfrey, First Elden Lord (Leyendell)", 0x152DCD},
            {"Mohg, the Omen", 0x15D060},
            {"Morgott, the Omen King", 0x152DC7},

            // Mt. Gelmir
            {"Abductor Virgins", 0x159BAB},
            {"Demi-Human Queen Maggie", 0x795CC},
            {"Demi-Human Queen Margot", 0x172726},
            {"Full-Grown Fallingstar Beast", 0x7107F},
            {"God-Devouring Serpent / Rykard, Lord of Blasphemy", 0x159BA4},
            {"Godskin Noble", 0x159BAA},
            {"Kindred of Rot", 0x171E5C},
            {"Magma Wyrm (Mt. Gelmir)", 0x6845C},
            {"Red Wolf of the Champion", 0x16A350},
            {"Ulcerated Tree Spirit (Mt. Gelmir)", 0x79938},

            // Mountaintops of the Giants
            {"Ancient Hero of Zamor (Giant-Conquring Hero's Grave)", 0x16C678},
            {"Borealis the Freezing Fog", 0x1AA7A2},
            {"Commander Niall", 0xF1D88},
            {"Death Rite Bird (Mountaintops of the Giants)", 0xE94D0},
            {"Erdtree Avatar (Mountaintops of the Giants)", 0xFA2D5},
            {"Fire Giant", 0x1AAC07},
            {"Godskin Apostle and Godskin Noble", 0x175BE2},
            {"Ulcerated Tree Spirit (Giants' Mountaintop Catacombs)", 0x16CADD},
            {"Vyke, Knight of the Roundtable", 0x102B8D},

            // Crumbling Farum Azula
            {"Dragonlord Placidusax", 0x15741A},
            {"Godskin Duo", 0x15741D},
            {"Malekith, the Black Blade", 0x157417},

            // Forbidden Lands
            {"Black Blade Kindred (Forbidden Lands)", 0xDFB01},
            {"Night's Cavalry (Forbidden Lands)", 0xD6EDE},
            {"Stray Mimic Tear", 0x16D3A7},

            // Consecrated Snowfields
            {"Astel, Stars of Darkness", 0x17A697},
            {"Death Rite Bird (Consecrated Snowfield)", 0xD8360},
            {"Great Wyrm Theodorix", 0xE9165},
            {"Misbegotten Crusader", 0x173455},
            {"Night's Cavalry Duo", 0x1ABD9B},
            {"Putrid Avatar", 0xE94D6},
            {"Putrid Grave Warden Duelist", 0x16CF42},

            // Miquella's Haligtree
            {"Loretta, Knight of the Haligtree", 0x158E7B},
            {"Malenia", 0x158E75},

            // Siofra River
            {"Ancestor Spirit", 0x156B4D},
            {"Dragonkin Soldier (Siofra)", 0x1550F2},
            {"Mohg, Lord of Blood", 0x155E1E},

            // Ainsel River
            {"Dragonkin Soldier of Nokstella", 0x154C8A},

            // Nokron Eternal City
            {"Mimic Tear", 0x1550F5},
            {"Regal Ancestor Spirit", 0x156FB2},
            {"Valiant Gargoyles", 0x1550EF},

            // Deeproot Depths
            {"Crucible Knight Siluria", 0x155520},
            {"Fia's Champions", 0x155554},
            {"Lichdragon Fortissax", 0x15555A},

            // Lake of Rot
            {"Astel, Naturalborn of the Void", 0x1559B9},
            {"Dragonkin Soldier", 0x154C90},

            // Leyendell, Ashen Capital
            {"Godfrey, First Elden Lord", 0x15322C},
            {"Sir Gideon Ofnir, the All-Knowing", 0x153232},

            // Elden Throne
            {"Radagon of the Golden Order / Elden Beast", 0x15C331},
        };
    }
}