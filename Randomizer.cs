using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Windows.Forms;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal static class Randomizer
    {
        public static string[] classNames = new string[100];
        public static string[] abilityNames = new string[256];
        public static string[] spellNames = new string[39];
        public static string[] crestNames = new string[87];
        public static string[] combatArtNames = new string[256];
        public static string[] characterNames = new string[1201];
        public static string[] inGameCharacterNames = new string[1201];
        public static string[] effectNames = new string[97];
        public static string[] weaponNames = new string[500];
        public static string[] gambitNames = new string[80];
        public static string[] blowNames = new string[60];
        public static string[] caEffectNames = new string[55];
        public static string[] battalionNames = new string[201];
        public static string[] bgmNames = new string[202];
        public static string[] miscItemNames = new string[223];
        public static string[] dinnerNames = new string[32];
        public static string[] itemNames = new string[256];
        public static string[] giftNames = new string[245];
        public static string[] equipmentNames = new string[50];
        public static string[] scenarioNames = new string[256];
        public static string[][] generalItemNames = new string[5][];
        public static int[] itemTypeIdOffsets = new int[5];
        public static int[][] itemFunctionGroups = new int[23][];
        public static string warnings = "";
        public static string rangeWarnings = "";
        public static bool randBasesRedistRangeWarning = false;
        public static bool randCapsRedistRangeWarning = false;
        public static bool randGrowthsRedistRangeWarning = false;
        public static bool randCapsAelfricWarning = false;
        public static bool chBases = false;
        public static bool chHPBases = false;
        public static bool chBasesRange = false;
        public static bool chCaps = false;
        public static bool chHPCaps = false;
        public static bool chCapsRange = false;
        public static bool chGrowths = false;
        public static bool chHPGrowths = false;
        public static bool chMoveGrowths = false;
        public static bool chGrowthsRange = false;
        public static bool chFaculty = false;
        public static bool chSeminar = false;
        public static bool chPersonalSkills = false;
        public static bool chTSPersonalSkills = false;
        public static bool chEnemyExPersonalSkills = false;
        public static bool chCrests = false;
        public static bool chMinCrest = false;
        public static bool chMaxCrest = false;
        public static bool chClasses = false;
        public static bool chClassInter = false;
        public static bool chClassBeg = false;
        public static bool chClassTS = false;
        public static bool chDLC = false;
        public static bool chAge = false;
        public static bool chGender = false;
        public static bool chBirthday = false;
        public static bool chHeight = false;
        public static bool chTSHeight = false;
        public static bool chChest = false;
        public static bool chTSChest = false;
        public static bool chMagic = false;
        public static bool chEnemyMagic = false;
        public static bool clRemoveGender = false;
        public static bool clWepRankReqs = false;
        public static bool clConstrainWepRankReqs = false;
        public static bool chAdvPegKnight = false;
        public static bool chDancer = false;
        public static bool wepSkipper = false;
        public static bool wepDura = false;
        public static bool wepMight = false;
        public static bool wepCrit = false;
        public static bool wepHit = false;
        public static bool splDura = false;
        public static bool splMight = false;
        public static bool splCrit = false;
        public static bool splHit = false;
        public static bool asGenderRestrict = false;
        public static bool asPlay = false;
        public static bool asAll = false;
        public static bool includeMona = false;
        public static bool includeConstance = false;
        public static bool includeAnna = false;
        public static bool includeDLC = false;
        public static bool includeFEmp = false;
        public static bool chBud = false;
        public static bool chEnemyExBud = false;
        public static bool clBoosts = false;
        public static bool clMoveBoosts = false;
        public static bool clMountBoosts = false;
        public static bool clMountMoveBoosts = false;
        public static bool clEnemyGrowths = false;
        public static bool clEnemyMoveGrowths = false;
        public static bool clPlayerGrowths = false;
        public static bool clPlayerMoveGrowths = false;
        public static bool clPros = false;
        public static bool clBases = false;
        public static bool clCharmBases = false;
        public static bool clRemoveWeapon = false;
        public static bool clWeaponType = false;
        public static bool clMasteryReq = false;
        public static bool clMasteryAb = false;
        public static bool clEnemyExMasteryAb = false;
        public static bool clEnemyEqAb = false;
        public static bool clAb = false;
        public static bool clEnemyExAb = false;
        public static bool wepWeight = false;
        public static bool wepUpRange = false;
        public static bool wepLoRange = false;
        public static bool wepDebuffs = false;
        public static bool wepIncBuffs = false;
        public static bool wepEff = false;
        public static bool wepIncInf = false;
        public static bool wepMagic = false;
        public static bool wepLa1 = false;
        public static bool wepNoFua = false;
        public static bool wepStTw = false;
        public static bool wepIncGauntlets = false;
        public static bool splWeight = false;
        public static bool splUpRange = false;
        public static bool splLoRange = false;
        public static bool splDebuffs = false;
        public static bool splIncBuffs = false;
        public static bool splEff = false;
        public static bool splIncInf = false;
        public static bool splPhy = false;
        public static bool splLa1 = false;
        public static bool splNoFua = false;
        public static bool splStTw = false;
        public static bool gamMight = false;
        public static bool gamHit = false;
        public static bool gamUpRange = false;
        public static bool gamLoRange = false;
        public static bool gamDebuffs = false;
        public static bool gamIncBuffs = false;
        public static bool gamEff = false;
        public static bool gamIncInf = false;
        public static bool gamMagic = false;
        public static int chHPBasesWeight = 0;
        public static int chMinBases = 0;
        public static int chMaxBases = 0;
        public static int chMinHPBases = 0;
        public static int chMaxHPBases = 0;
        public static int chHPCapsWeight = 0;
        public static int chMinCaps = 0;
        public static int chMaxCaps = 0;
        public static int chMinHPCaps = 0;
        public static int chMaxHPCaps = 0;
        public static int chHPGrowthsWeight = 0;
        public static int chMoveGrowthsWeight = 0;
        public static int chMinGrowths = 0;
        public static int chMaxGrowths = 0;
        public static int chMinHPGrowths = 0;
        public static int chMaxHPGrowths = 0;
        public static int chMinMoveGrowths = 0;
        public static int chMaxMoveGrowths = 0;
        public static double wepDuraDev = 0;
        public static double wepMightDev = 0;
        public static double wepHitDev = 0;
        public static double wepCritDev = 0;
        public static double splDuraDev = 0;
        public static double splMightDev = 0;
        public static double splHitDev = 0;
        public static double splCritDev = 0;
        public static int chBudP = 60;
        public static double clBegBoostsPos = 1.0;
        public static double clBegBoostsNeg = 0.0;
        public static double clInterBoostsPos = 5.0;
        public static double clInterBoostsNeg = 1.0;
        public static double clAdvDlcBoostsPos = 10.0;
        public static double clAdvDlcBoostsNeg = 1.0;
        public static double clMasterBoostsPos = 13.0;
        public static double clMasterBoostsNeg = 0.5;
        public static double clUniqueBoostsPos = 15.0;
        public static double clUniqueBoostsNeg = 1.0;
        public static double clBegMountBoostsPos = 0.0;
        public static double clBegMountBoostsNeg = 0.0;
        public static double clInterMountBoostsPos = 4.0;
        public static double clInterMountBoostsNeg = 1.0;
        public static double clAdvDlcMountBoostsPos = 4.0;
        public static double clAdvDlcMountBoostsNeg = 1.0;
        public static double clMasterMountBoostsPos = 4.0;
        public static double clMasterMountBoostsNeg = 1.0;
        public static double clUniqueMountBoostsPos = 4.0;
        public static double clUniqueMountBoostsNeg = 1.0;
        public static int clEnemyBegGrowthsMin = -10;
        public static int clEnemyBegGrowthsMax = 20;
        public static int clEnemyInterGrowthsMin = -30;
        public static int clEnemyInterGrowthsMax = 40;
        public static int clEnemyAdvDlcGrowthsMin = -30;
        public static int clEnemyAdvDlcGrowthsMax = 60;
        public static int clEnemyMasterGrowthsMin = -20;
        public static int clEnemyMasterGrowthsMax = 60;
        public static int clEnemyUniqueGrowthsMin = 0;
        public static int clEnemyUniqueGrowthsMax = 60;
        public static int clPlayerBegGrowthsMin = -5;
        public static int clPlayerBegGrowthsMax = 10;
        public static int clPlayerInterGrowthsMin = -10;
        public static int clPlayerInterGrowthsMax = 30;
        public static int clPlayerAdvDlcGrowthsMin = -10;
        public static int clPlayerAdvDlcGrowthsMax = 40;
        public static int clPlayerMasterGrowthsMin = -10;
        public static int clPlayerMasterGrowthsMax = 40;
        public static int clPlayerUniqueGrowthsMin = -5;
        public static int clPlayerUniqueGrowthsMax = 30;
        public static int clBegNumProsMin = 1;
        public static int clBegNumProsMax = 3;
        public static int clInterNumProsMin = 2;
        public static int clInterNumProsMax = 3;
        public static int clAdvDlcNumProsMin = 1;
        public static int clAdvDlcNumProsMax = 3;
        public static int clMasterNumProsMin = 2;
        public static int clMasterNumProsMax = 3;
        public static int clUniqueNumProsMin = 2;
        public static int clUniqueNumProsMax = 4;
        public static int clBegProsMin = 1;
        public static int clBegProsMax = 1;
        public static int clInterProsMin = 1;
        public static int clInterProsMax = 2;
        public static int clAdvDlcProsMin = 1;
        public static int clAdvDlcProsMax = 3;
        public static int clMasterProsMin = 3;
        public static int clMasterProsMax = 3;
        public static int clUniqueProsMin = 2;
        public static int clUniqueProsMax = 3;
        public static int clBegBasesHpMin = 20;
        public static int clBegBasesHpMax = 20;
        public static int clInterBasesHpMin = 25;
        public static int clInterBasesHpMax = 30;
        public static int clAdvDlcBasesHpMin = 30;
        public static int clAdvDlcBasesHpMax = 35;
        public static int clMasterBasesHpMin = 32;
        public static int clMasterBasesHpMax = 35;
        public static int clUniqueBasesHpMin = 28;
        public static int clUniqueBasesHpMax = 38;
        public static int clBegBasesMin = 2;
        public static int clBegBasesMax = 8;
        public static int clInterBasesMin = 1;
        public static int clInterBasesMax = 12;
        public static int clAdvDlcBasesMin = 7;
        public static int clAdvDlcBasesMax = 19;
        public static int clMasterBasesMin = 8;
        public static int clMasterBasesMax = 20;
        public static int clUniqueBasesMin = 6;
        public static int clUniqueBasesMax = 20;
        public static int clMasteryReqMin = 20;
        public static int clMasteryReqMax = 200;
        public static int clBegEnemyEqAbMin = 0;
        public static int clBegEnemyEqAbMax = 3;
        public static int clInterEnemyEqAbMin = 0;
        public static int clInterEnemyEqAbMax = 5;
        public static int clAdvDlcEnemyEqAbMin = 3;
        public static int clAdvDlcEnemyEqAbMax = 5;
        public static int clMasterEnemyEqAbMin = 5;
        public static int clMasterEnemyEqAbMax = 5;
        public static int clUniqueEnemyEqAbMin = 5;
        public static int clUniqueEnemyEqAbMax = 5;
        public static double clBegAb = 0.0;
        public static double clInterAb = 1.0;
        public static double clAdvDlcAb = 2.5;
        public static double clMasterAb = 3.0;
        public static double clUniqueAb = 2.0;
        public static double wepWeightDev = 0.0;
        public static double wepRangeFreq = 0.0;
        public static double wepDebuffFreq = 0.0;
        public static double wepEffFreq = 0.0;
        public static double wepMagicFreq = 0.0;
        public static double wepLa1Freq = 0.0;
        public static double wepNoFuaFreq = 0.0;
        public static double wepStTwFreq = 0.0;
        public static double splWeightDev = 0.0;
        public static double splRangeFreq = 0.0;
        public static double splDebuffFreq = 0.0;
        public static double splEffFreq = 0.0;
        public static double splPhyFreq = 0.0;
        public static double splLa1Freq = 0.0;
        public static double splNoFuaFreq = 0.0;
        public static double splStTwFreq = 0.0;
        public static double gamMightDev = 0.0;
        public static double gamHitDev = 0.0;
        public static double gamRangeFreq = 0.0;
        public static double gamDebuffFreq = 0.0;
        public static double gamEffFreq = 0.0;
        public static double gamMagicFreq = 0.0;
        public static long charBlockStart = 212;
        public static long charBlockLen = 80;
        public static long charAssetStart = 96356;
        public static long charAssetLen = 18;
        public static long charVoiceStart = 107220;
        public static long charVoiceLen = 8;
        public static long charWepRankStart = 108212;
        public static long charWepRankLen = 34;
        public static long charWepStart = 113628;
        public static long charWepLen = 14;
        public static long charFacultyStart = 122824;
        public static long charFacultyLen = 6;
        public static long charSeminarStart = 123196;
        public static long charSeminarLen = 6;
        public static long charPortraitStart = 124592;
        public static long charPortraitLen = 24;
        public static long charSpellStart = 109808;
        public static long charSpellLen = 20;
        public static long charSkillStart = 110772;
        public static long charSkillLen = 62;
        public static long charGoalStart = 123568;
        public static long charGoalLen = 24;
        public static long charBudStart = 120992;
        public static long charBudLen = 6;
        public static long charArtStart = 114324;
        public static long charArtLen = 30;
        public static long charSupStart = 115740;
        public static long charSupLen = 25;
        public static long charSpeSupStart = 116932;
        public static long charSpeSupLen = 30;
        public static long charLearnStart = 122496;
        public static long charLearnLen = 22;
        public static long charEnemySkillStart = 139056;
        public static long charEnemySkillLen = 4;
        public static short classBlockStart = 148;
        public static short classBlockLen = 118;
        public static short classCertStart = 12012;
        public static short classCertLen = 15;
        public static short classAbStart = 13648;
        public static short classAbLen = 5;
        public static short classTierStart = 13576;
        public static short classTierLen = 1;
        public static short classMonsterStart = 14212;
        public static short classMonsterLen = 80;
        public static short weaponBlockStart = 196;
        public static short weaponBlockLen = 24;
        public static short magicBlockStart = 12260;
        public static short magicBlockLen = 24;
        public static short turretBlockStart = 13236;
        public static short turretBlockLen = 24;
        public static short gambitBlockStart = 13372;
        public static short gambitBlockLen = 24;
        public static short gambitExtraStart = 24492;
        public static short gambitExtraLen = 13;
        public static short blowBlockStart = 15356;
        public static short blowBlockLen = 24;
        public static short artBlockStart = 22988;
        public static short artBlockLen = 18;
        public static short battalionBlockStart = 26288;
        public static short battalionBlockLen = 44;
        public static long academyScheduleStart = 2620;
        public static long scheduleLen = 16;
        public static long churchScheduleStart = 4284;
        public static long lionsScheduleStart = 5948;
        public static long deerScheduleStart = 7612;
        public static long eaglesScheduleStart = 9276;
        public static long reqruitStart = 15636;
        public static long reqruitLen = 14;
        public static long classBaseAniStart = 2784;
        public static long classBaseAniLen = 10;
        public static long classAniSetStart = 4216;
        public static long classAniSetLen = 2;
        public static long charActivityStart = 204;
        public static long charActivityLen = 6;
        public static long mealStart = 568;
        public static long mealLen = 18;
        public static long mealPrefStart = 2432;
        public static long mealPrefLen = 45;
        public static long fishingStart = 10696;
        public static long fishingLen = 60;
        public static long gardenStart = 12680;
        public static long gardenLen = 62;
        public static long cultivationStart = 14944;
        public static long cultivationLen = 4;
        public static long profLvStart = 15032;
        public static long profLvLen = 20;
        public static long groupTaskStart = 108;
        public static long groupTaskLen = 10;
        public static long groupTaskProfsStart = 1316;
        public static long groupTaskProfsLen = 8;
        public static long giftStart = 100;
        public static long giftLen = 12;
        public static long giftPrefsStart = 3104;
        public static long giftPrefsLen = 17;
        public static long weaponShopStart = 172;
        public static long weaponShopLen = 20;
        public static long equipmentShopStart = 4236;
        public static long equipmentShopLen = 16;
        public static long itemShopStart = 5100;
        public static long itemShopLen = 16;
        public static long battalionShopStart = 8364;
        public static long battalionShopLen = 20;
        public static long forgingStart = 12428;
        public static long forgingLen = 12;
        public static long statueStart = 13944;
        public static long statueLen = 32;
        public static long merchantStart = 15288;
        public static long merchantLen = 6;
        public static long annaShopStart = 15952;
        public static long annaShopLen = 8;
        public static long influencerStart = 16416;
        public static long influencerLen = 4;
        public static long paganWeaponStart = 16504;
        public static long paganWeaponLen = 20;
        public static long paganEquipmentStart = 17568;
        public static long paganEquipmentLen = 16;
        public static long paganItemStart = 18112;
        public static long paganItemLen = 16;
        public static long questStart = 92;
        public static long questLen = 52;
        public static long annaQuestStart = 8472;
        public static long annaQuestLen = 10;
        public static long scenarioStart = 84;
        public static long scenarioLen = 46;
        public static long expStart = 132;
        public static long expLen = 3;
        public static long teaTopicStart = 38164;
        public static long teaTopicLen = 43;
        public static long teaResponseStart = 26096;
        public static long teaResponseLen = 14;
        public static long[] BGMLinkLocations = {
            72,
            3950152,
            7900232,
            12029384,
            16158536,
            20569344,
            24980040,
            28514824,
            32049608,
            36165128,
            40280648,
            44568392,
            48856136,
            53143880,
            57431624,
            63561608,
            69691592,
            74960712,
            80229832,
            86818504,
            93407176,
            97172808,
            100938440,
            104704072,
            108469704,
            113009288,
            117548872,
            121363272,
            125177672,
            126962504,
            128747336,
            130869384,
            132991432,
            134646920,
            136302408,
            138799240,
            141296072,
            144030024,
            145195080,
            147139464,
            150732808,
            153409224,
            155826504,
            158063240,
            160255560,
            162237064,
            164183880,
            166560136,
            169080392,
            171322440,
            173755784,
            176180872,
            178506888,
            180685064,
            183208712,
            185565448,
            188120328,
            190167176,
            192786504,
            195310664,
            197542472,
            199893384,
            203483784,
            205984520,
            207575624,
            209569288,
            211170632,
            213671368,
            215090696,
            217084360,
            217718472,
            218417480,
            //218657288, Short
            219659848,
            221068424,
            //221308232, Short
            //223686472, Plays once
            224079048,
            226755464,
            //227920520, Plays once
            //227945608, Plays once
            231102664,
            234227528,
            238358152,
            242049096,
            245527752,
            249006408,
            252485064,
            255963720,
            258602568,
            261752840,
            264170568,
            266576136,
            267640648,
            268705160,
            275166472,
            //277644744, Plays once
            //285719880, Plays once
            //290861640, Plays once
            //293487752, Plays once
            //296644808, Plays once
            //304720456, Plays once
            307346568,
            309833160,
            311728776,
            //312938248, Plays once
            //317058120, Plays once
            //319101576, Plays once
            //321110856, Plays once
            322109000,
            //324187080, Plays once
            //327098696, Plays once
            //329175816, Plays once
            //329652808, Plays once
            331185352,
            332776456,
            334367560,
            //335958664, Plays once
            //337181768, Plays once
            //338327304, Plays once
            //340161416, Plays once
            //343396552, Plays once
            //345626888, Plays once
            //346785096, Plays once
            //348368840, Plays once
            //349580232, Plays once
            //351468488, Plays once
            //351659528, Plays once
            //351741256, Plays once
            //351801480, Plays once
            //351946632, Plays once
            //352008840, Plays once
            //355311816, Plays once
            //355995720, Plays once
            //357987912, Plays once
            //359146120, Plays once
            //360295560, Plays once
            360849672,
            362451976,
            365847176,
            370283784,
            373392520,
            375314440,
            378087432,
            380404168,
            384304008,
            388473224,
            392413512
            //395472008, plays once
            };
        public static long baiSectionOffset = 28317312;
        public static int baiSectionLength = 2286432;
        public static long[] baiOffsets =
        {
            28317312,
            28340448,
            28394240,
            28419776,
            28444448,
            28472736,
            28499040,
            28524864,
            28600544,
            28635744,
            28660576,
            28683456,
            28718752,
            28754880,
            28791872,
            28831584,
            28861088,
            28892384,
            28978272,
            28993760,
            29009248,
            29035648,
            29059072,
            29083264,
            29109728,
            29135360,
            29157472,
            29183904,
            29211936,
            29236608,
            29262944,
            29288832,
            29327840,
            29362176,
            29392672,
            29449184,
            29470784,
            29508352,
            29558976,
            29585856,
            29610560,
            29631232,
            29650656,
            29683584,
            29713792,
            29753408,
            29776128,
            29818080,
            29846208,
            29873216,
            29904032,
            29920800,
            29953216,
            29974816,
            30027296,
            30052928,
            30078016,
            30104352,
            30138816,
            30161440,
            30181792,
            30209184,
            30225568,
            30241312,
            30257344,
            30273728,
            30289792,
            30305856,
            30322240,
            30338304,
            30353376,
            30368160,
            30382944,
            30399328,
            30414112,
            30430176,
            30444960,
            30459744,
            30476128,
            30492352,
            30508416,
            30523200,
            30537760,
            30552320,
            30566880,
            30589184
        };
        public static int baiUnitsLen = 44;
        public static int baiUnitEntries = 100;
        public static int baiSpecialsLen = 4;
        public static int baiItemsLen = 8;
        public static long textSectionOffset = 6115304960;
        public static int textSectionLength = 7578688;
        public static RandomLog rng;
        public static byte[] personData;
        public static byte[] classData;
        public static byte[] itemData;
        public static byte[] calendarData;
        public static byte[] lobbyData;
        public static byte[] actData;
        public static byte[] BGMData;
        public static byte[] msgData;
        public static byte[] scrData;
        public static byte[] gwscrData;
        public static byte[] tuscrData;
        public static byte[] btlscrData;
        public static byte[] activityData;
        public static byte[] groupWorkData;
        public static byte[] presentData;
        public static byte[] shopData;
        public static byte[] questData;
        public static byte[] scenarioData;
        public static byte[] growthdataData;
        public static byte[] baiSectionData;
        public static byte[] textSectionData;
        public static byte[] personDataV;
        public static byte[] classDataV;
        public static byte[] itemDataV;
        public static byte[] calendarDataV;
        public static byte[] lobbyDataV;
        public static byte[] actDataV;
        public static byte[] BGMDataV;
        public static byte[] msgDataV;
        public static byte[] scrDataV;
        public static byte[] gwscrDataV;
        public static byte[] tuscrDataV;
        public static byte[] btlscrDataV;
        public static byte[] activityDataV;
        public static byte[] groupWorkDataV;
        public static byte[] presentDataV;
        public static byte[] shopDataV;
        public static byte[] questDataV;
        public static byte[] scenarioDataV;
        public static byte[] growthdataDataV;
        public static byte[] baiSectionDataV;
        public static byte[] textSectionDataV;
        public static string personFilename;
        public static string classFilename;
        public static string itemFilename;
        public static string calendarFilename;
        public static string lobbyFilename;
        public static string actFilename;
        public static string BGMFilename;
        public static string msgFilename;
        public static string scrFilename;
        public static string gwscrFilename;
        public static string tuscrFilename;
        public static string btlscrFilename;
        public static string activityFilename;
        public static string groupWorkFilename;
        public static string presentFilename;
        public static string shopFilename;
        public static string questFilename;
        public static string scenarioFilename;
        public static string growthdataFilename;
        public static string data1Filename;
        public static bool personLoaded;
        public static bool classLoaded;
        public static bool itemLoaded;
        public static bool calendarLoaded;
        public static bool lobbyLoaded;
        public static bool actLoaded;
        public static bool BGMLoaded;
        public static bool msgLoaded;
        public static bool scrLoaded;
        public static bool gwscrLoaded;
        public static bool tuscrLoaded;
        public static bool btlscrLoaded;
        public static bool activityLoaded;
        public static bool groupWorkLoaded;
        public static bool presentLoaded;
        public static bool shopLoaded;
        public static bool questLoaded;
        public static bool scenarioLoaded;
        public static bool growthdataLoaded;
        public static bool data1Loaded;
        public static string changelog;
        public static int seed;

        public static int[] swordAbilities = { 0, 1, 2, 3, 4, 35, 36, 37, 38, 39, 40, 48, 56, 64, 65, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 89, 90, 91, 92, 93, 94,
            95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 123, 127, 128, 129, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156, 157,
            159, 160, 161, 162, 163, 177, 178, 179, 181, 182, 183, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 227, 228, 230, 231, 232,
            233, 234, 235, 236, 237, 238, 239, 241, 242, 243, 244, 245, 248, 250, 251};
        public static int[] lanceAbilities = { 5, 6, 7, 8, 9, 35, 36, 37, 38, 39, 41, 49, 57, 64, 65, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 89, 90, 91, 92, 93, 94,
            95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 127, 128, 129, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156, 157,
            159, 160, 161, 162, 163, 164, 177, 178, 181, 182, 183, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 227, 228, 230, 231, 232,
            233, 234, 235, 236, 237, 238, 239, 241, 242, 243, 244, 245, 248, 250, 251 };
        public static int[] axeAbilities = { 10, 11, 12, 13, 14, 35, 36, 37, 38, 39, 42, 50, 58, 64, 65, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 89, 90, 91, 92, 93,
            94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 122, 127, 128, 129, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156, 157,
            159, 160, 161, 162, 163, 165, 177, 178, 181, 182, 183, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 227, 228, 230, 231, 232,
            233, 234, 235, 236, 237, 238, 239, 241, 242, 243, 244, 245, 248, 250, 251 };
        public static int[] bowAbilities = { 15, 16, 17, 18, 19, 35, 36, 37, 38, 39, 43, 51, 59, 64, 65, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 89, 90, 91, 92, 93,
            94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 125, 127, 128, 129, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156, 157,
            159, 160, 161, 162, 163, 166, 167, 177, 178, 181, 182, 183, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 227, 228, 229, 230,
            231, 232, 233, 234, 235, 236, 237, 238, 239, 242, 243, 244, 245, 248, 250, 251 };
        public static int[] brawlAbilities = { 20, 21, 22, 23, 24, 35, 36, 37, 38, 39, 44, 52, 60, 64, 65, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 89, 90, 91, 92, 93,
            94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 126, 127, 128, 129, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156, 157,
            159, 160, 161, 162, 163, 171, 177, 178, 181, 182, 183, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 227, 228, 230, 231, 232,
            233, 234, 235, 236, 237, 238, 239, 241, 242, 243, 244, 245, 248, 250, 251 };
        public static int[] blackAbilities = { 25, 26, 27, 28, 29, 35, 36, 37, 38, 39, 45, 53, 61, 64, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 88, 89, 90, 91, 92, 93,
            94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 124, 127, 128, 129, 130, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156,
            157, 159, 160, 161, 162, 163, 168, 172, 177, 178, 180, 181, 182, 183, 184, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222,
            227, 228, 243, 244, 245, 248, 250, 251 };
        public static int[] faithAbilities = { 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 46, 54, 62, 64, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 88, 89, 90, 91, 92, 93,
            94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 124, 127, 128, 129, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155,
            156, 157, 159, 160, 161, 162, 163, 170, 174, 175, 176, 177, 178, 180, 181, 182, 183, 184, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
            220, 221, 224, 227, 228, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 243, 244, 245, 248, 250, 251 };
        public static int[] darkAbilities = { 25, 26, 27, 28, 29, 35, 36, 37, 38, 39, 47, 55, 63, 64, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 88, 89, 90, 91, 92, 93,
            94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 124, 127, 128, 129, 131, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156,
            157, 159, 160, 161, 162, 163, 169, 173, 177, 178, 180, 181, 182, 183, 184, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 223,
            227, 228, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 243, 244, 245, 248, 250, 251 };

        public static int[] badAbilities = { 148, 154, 158, 190, 191, 193, 197, 198, 199, 201, 206, 225, 226, 240, 246, 249, 247, 249 };
        public static int[] badPlayerSkills = { 54, 55, 56, 57, 58, 59, 63, 121, 123, 125, 143, 148, 149, 151, 154, 180, 181, 182, 183, 184, 185, 186, 190, 191, 192, 193, 194, 195, 196, 197,
            198, 199, 201, 202, 204, 205, 206, 207, 208, 222, 223, 224, 225, 226, 236, 240, 246, 249, 247, 248, 249 };

        public static int[] genericAbilities = { 35, 36, 37, 38, 39, 64, 67, 68, 69, 70, 71, 72, 73, 74, 75, 78, 79, 80, 81, 82, 83, 84, 85, 86, 89, 90, 91, 92, 93, 94,
            95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 127, 128, 129, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 155, 156, 157,
            159, 160, 161, 162, 163, 177, 178, 181, 182, 183, 185, 192, 194, 195, 196, 200, 202, 203, 204, 205, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 227, 228, 230, 231, 232, 233,
            234, 235, 236, 237, 238, 239, 243, 244, 245, 248, 250, 251};

        public static int[] swordOnlyAbilities = { 0, 1, 2, 3, 4, 40, 48, 56, 123, 179 };
        public static int[] lanceOnlyAbilities = { 5, 6, 7, 8, 9, 41, 49, 57, 121, 164 };
        public static int[] axeOnlyAbilities = { 10, 11, 12, 13, 14, 42, 50, 58, 122, 165 };
        public static int[] bowOnlyAbilities = { 15, 16, 17, 18, 19, 43, 51, 59, 125, 166, 167, 229 };
        public static int[] brawlOnlyAbilities = { 20, 21, 22, 23, 24, 44, 52, 60, 126, 171 };
        public static int[] blackOnlyAbilities = { 25, 26, 27, 28, 29, 45, 53, 61, 130, 168, 172, 222 };
        public static int[] faithOnlyAbilities = { 30, 31, 32, 33, 34, 46, 54, 62, 132, 139, 170, 174, 175, 176, 224 };
        public static int[] darkOnlyAbilities = { 25, 26, 27, 28, 29, 47, 55, 63, 131, 169, 173, 223 };

        public static int[] obtainableWeapons = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37,
        38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82,
        83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122,
        123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158,
        159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190 };
        public static int[] obtainableEquipment = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 31, 32, 33, 34,
        37, 38, 39, 40, 41, 42};
        public static int[] obtainableItems = { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 51, 52, 53, 54, 126, 127, 128, 129, 130, 131,
        132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 161 };
        public static int[] obtainableMiscItems = { 0, 5, 10, 17, 23, 32, 33, 34, 38, 39, 41, 42, 43, 44, 45, 46, 47, 49, 50, 52, 53, 54, 55, 56, 57, 58, 64, 65, 66, 67, 68, 69, 70, 71, 96,
        97, 98, 99, 100, 101, 102, 104, 106, 107, 108, 109, 110, 111, 112, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 160, 164, 167,
        168, 169, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212 };
        public static int[] obtainableGifts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 197, 198, 199, 200, 201, 202, 203,
        204, 205, 206, 207, 208 };
        public static int[][] obtainableGeneralItems = { obtainableWeapons, obtainableEquipment, obtainableItems, obtainableMiscItems, obtainableGifts };

        public static void setKnown()
        {
            Randomizer.classNames[0] = "Noble";
            Randomizer.classNames[1] = "Commoner";
            Randomizer.classNames[2] = "Myrmidon";
            Randomizer.classNames[3] = "Soldier";
            Randomizer.classNames[4] = "Fighter";
            Randomizer.classNames[5] = "Monk";
            Randomizer.classNames[6] = "Lord";
            Randomizer.classNames[7] = "Mercenary";
            Randomizer.classNames[8] = "Thief";
            Randomizer.classNames[9] = "Armored Knight";
            Randomizer.classNames[10] = "Cavalier";
            Randomizer.classNames[11] = "Brigand";
            Randomizer.classNames[12] = "Archer";
            Randomizer.classNames[13] = "Brawler";
            Randomizer.classNames[14] = "Mage";
            Randomizer.classNames[15] = "Dark Mage";
            Randomizer.classNames[16] = "Priest";
            Randomizer.classNames[17] = "Barbarossa";
            Randomizer.classNames[18] = "Hero";
            Randomizer.classNames[19] = "Swordmaster";
            Randomizer.classNames[20] = "Assassin";
            Randomizer.classNames[21] = "Fortress Knight";
            Randomizer.classNames[22] = "Paladin";
            Randomizer.classNames[23] = "Pegasus Knight (Advanced)";
            Randomizer.classNames[24] = "Wyvern Rider";
            Randomizer.classNames[25] = "Warrior";
            Randomizer.classNames[26] = "Sniper";
            Randomizer.classNames[27] = "Grappler";
            Randomizer.classNames[28] = "Warlock";
            Randomizer.classNames[29] = "Dark Bishop";
            Randomizer.classNames[30] = "Bishop";
            Randomizer.classNames[31] = "Falcon Knight";
            Randomizer.classNames[32] = "Wyvern Lord";
            Randomizer.classNames[33] = "Mortal Savant";
            Randomizer.classNames[34] = "Great Knight";
            Randomizer.classNames[35] = "Bow Knight";
            Randomizer.classNames[36] = "Dark Knight";
            Randomizer.classNames[37] = "Holy Knight";
            Randomizer.classNames[38] = "War Master";
            Randomizer.classNames[39] = "Gremory";
            Randomizer.classNames[40] = "Emperor";
            Randomizer.classNames[41] = "Agastya";
            Randomizer.classNames[42] = "Enlightened One";
            Randomizer.classNames[43] = "Dancer";
            Randomizer.classNames[44] = "Great Lord";
            Randomizer.classNames[45] = "King of Liberation";
            Randomizer.classNames[46] = "Saint";
            Randomizer.classNames[47] = "Flame Emperor";
            Randomizer.classNames[48] = "Flame Emperor ";
            Randomizer.classNames[49] = "Thief ";
            Randomizer.classNames[50] = "Ruffian";
            Randomizer.classNames[51] = "Paladin ";
            Randomizer.classNames[52] = "Fortress Knight ";
            Randomizer.classNames[53] = "Lord ";
            Randomizer.classNames[54] = "Pegasus Knight (Intermediate)";
            Randomizer.classNames[55] = "Archbishop";
            Randomizer.classNames[56] = "Armored Lord";
            Randomizer.classNames[57] = "High Lord";
            Randomizer.classNames[58] = "Wyvern Master";
            Randomizer.classNames[59] = "Death Knight";
            Randomizer.classNames[60] = "Black Beast";
            Randomizer.classNames[61] = "Wandering Beast";
            Randomizer.classNames[62] = "Wild Demonic Beast";
            Randomizer.classNames[63] = "Demonic Beast";
            Randomizer.classNames[64] = "Exp Demonic Beast";
            Randomizer.classNames[65] = "Altered Demonic Beast";
            Randomizer.classNames[66] = "Giant Demonic Beast";
            Randomizer.classNames[67] = "Flying Demonic Beast";
            Randomizer.classNames[68] = "Golem";
            Randomizer.classNames[69] = "Altered Golem";
            Randomizer.classNames[70] = "Titanus";
            Randomizer.classNames[71] = "White Beast";
            Randomizer.classNames[72] = "The Immaculate One";
            Randomizer.classNames[73] = "The Immaculate One ";
            Randomizer.classNames[74] = "The Immaculate One  ";
            Randomizer.classNames[75] = "Lord of the Desert";
            Randomizer.classNames[76] = "Lord of the Lake";
            Randomizer.classNames[77] = "Giant Bird";
            Randomizer.classNames[78] = "Giant Crawler";
            Randomizer.classNames[79] = "Giant Wolf";
            Randomizer.classNames[80] = "Hegemon Husk";
            Randomizer.classNames[81] = "King of Beasts";
            Randomizer.classNames[82] = "King of Fangs";
            Randomizer.classNames[83] = "King of Wings";
            Randomizer.classNames[84] = "Trickster";
            Randomizer.classNames[85] = "War Monk";
            Randomizer.classNames[86] = "Dark Flier";
            Randomizer.classNames[87] = "Mage Knight";
            Randomizer.classNames[91] = "Death Knight";
            Randomizer.abilityNames[0] = "Sword Prowess Lv1";
            Randomizer.abilityNames[1] = "Sword Prowess Lv2";
            Randomizer.abilityNames[2] = "Sword Prowess Lv3";
            Randomizer.abilityNames[3] = "Sword Prowess Lv4";
            Randomizer.abilityNames[4] = "Sword Prowess Lv5";
            Randomizer.abilityNames[5] = "Lance Prowess Lv1";
            Randomizer.abilityNames[6] = "Lance Prowess Lv2";
            Randomizer.abilityNames[7] = "Lance Prowess Lv3";
            Randomizer.abilityNames[8] = "Lance Prowess Lv4";
            Randomizer.abilityNames[9] = "Lance Prowess Lv5";
            Randomizer.abilityNames[10] = "Axe Prowess Lv1";
            Randomizer.abilityNames[11] = "Axe Prowess Lv2";
            Randomizer.abilityNames[12] = "Axe Prowess Lv3";
            Randomizer.abilityNames[13] = "Axe Prowess Lv4";
            Randomizer.abilityNames[14] = "Axe Prowess Lv5";
            Randomizer.abilityNames[15] = "Bow Prowess Lv1";
            Randomizer.abilityNames[16] = "Bow Prowess Lv2";
            Randomizer.abilityNames[17] = "Bow Prowess Lv3";
            Randomizer.abilityNames[18] = "Bow Prowess Lv4";
            Randomizer.abilityNames[19] = "Bow Prowess Lv5";
            Randomizer.abilityNames[20] = "Brawling Prowess Lv1";
            Randomizer.abilityNames[21] = "Brawling Prowess Lv2";
            Randomizer.abilityNames[22] = "Brawling Prowess Lv3";
            Randomizer.abilityNames[23] = "Brawling Prowess Lv4";
            Randomizer.abilityNames[24] = "Brawling Prowess Lv5";
            Randomizer.abilityNames[25] = "Reason Prowess Lv1";
            Randomizer.abilityNames[26] = "Reason Prowess Lv2";
            Randomizer.abilityNames[27] = "Reason Prowess Lv3";
            Randomizer.abilityNames[28] = "Reason Prowess Lv4";
            Randomizer.abilityNames[29] = "Reason Prowess Lv5";
            Randomizer.abilityNames[30] = "Faith Prowess Lv1";
            Randomizer.abilityNames[31] = "Faith Prowess Lv2";
            Randomizer.abilityNames[32] = "Faith Prowess Lv3";
            Randomizer.abilityNames[33] = "Faith Prowess Lv4";
            Randomizer.abilityNames[34] = "Faith Prowess Lv5";
            Randomizer.abilityNames[35] = "Authority Prowess Lv1";
            Randomizer.abilityNames[36] = "Authority Prowess Lv2";
            Randomizer.abilityNames[37] = "Authority Prowess Lv3";
            Randomizer.abilityNames[38] = "Authority Prowess Lv4";
            Randomizer.abilityNames[39] = "Authority Prowess Lv5";
            Randomizer.abilityNames[40] = "Swordfaire";
            Randomizer.abilityNames[41] = "Lancefaire";
            Randomizer.abilityNames[42] = "Axefaire";
            Randomizer.abilityNames[43] = "Bowfaire";
            Randomizer.abilityNames[44] = "Fistfaire";
            Randomizer.abilityNames[45] = "Black Tomefaire";
            Randomizer.abilityNames[46] = "White Tomefaire";
            Randomizer.abilityNames[47] = "Dark Tomefaire";
            Randomizer.abilityNames[48] = "Sword Crit Plus 10";
            Randomizer.abilityNames[49] = "Lance Crit Plus 10";
            Randomizer.abilityNames[50] = "Axe Crit Plus 10";
            Randomizer.abilityNames[51] = "Bow Crit Plus 10";
            Randomizer.abilityNames[52] = "Brawl Crit Plus 10";
            Randomizer.abilityNames[53] = "Black Magic Crit Plus 10";
            Randomizer.abilityNames[54] = "White Magic Crit Plus 10";
            Randomizer.abilityNames[55] = "Dark Magic Crit Plus 10";
            Randomizer.abilityNames[56] = "Sword Avo Plus 20";
            Randomizer.abilityNames[57] = "Lance Avo Plus 20";
            Randomizer.abilityNames[58] = "Axe Avo Plus 20";
            Randomizer.abilityNames[59] = "Bow Avo Plus 20";
            Randomizer.abilityNames[60] = "Brawl Avo Plus 20";
            Randomizer.abilityNames[61] = "Black Magic Avo Plus 20";
            Randomizer.abilityNames[62] = "White Magic Avo Plus 20";
            Randomizer.abilityNames[63] = "Dark Magic Avo Plus 20";
            Randomizer.abilityNames[64] = "HP Plus 5";
            Randomizer.abilityNames[65] = "Strength Plus 2";
            Randomizer.abilityNames[66] = "Magic Plus 2";
            Randomizer.abilityNames[67] = "Dexterity Plus 2";
            Randomizer.abilityNames[68] = "Speed Plus 2";
            Randomizer.abilityNames[69] = "Pomp and Circumstance";
            Randomizer.abilityNames[70] = "Defence Plus 2";
            Randomizer.abilityNames[71] = "Resistance Plus 2";
            Randomizer.abilityNames[72] = "Movement Plus 1";
            Randomizer.abilityNames[73] = "Hit Plus 20";
            Randomizer.abilityNames[74] = "Avo Plus 20";
            Randomizer.abilityNames[75] = "Crit Plus 20";
            Randomizer.abilityNames[76] = "Defiant Str";
            Randomizer.abilityNames[77] = "Defiant Mag";
            Randomizer.abilityNames[78] = "Defiant Spd";
            Randomizer.abilityNames[79] = "Defiant Def";
            Randomizer.abilityNames[80] = "Defiant Res";
            Randomizer.abilityNames[81] = "Defiant Avo";
            Randomizer.abilityNames[82] = "Defiant Crit";
            Randomizer.abilityNames[83] = "Imperial Lineage";
            Randomizer.abilityNames[84] = "Royal Lineage";
            Randomizer.abilityNames[85] = "Leicester Lineage";
            Randomizer.abilityNames[86] = "Mastermind";
            Randomizer.abilityNames[87] = "Death Blow";
            Randomizer.abilityNames[88] = "Fiendish Blow";
            Randomizer.abilityNames[89] = "Darting Blow";
            Randomizer.abilityNames[90] = "Armored Blow";
            Randomizer.abilityNames[91] = "Warding Blow";
            Randomizer.abilityNames[92] = "Officer Duty";
            Randomizer.abilityNames[93] = "Lady Knight";
            Randomizer.abilityNames[94] = "Watchful Eye";
            Randomizer.abilityNames[95] = "Distinguished House";
            Randomizer.abilityNames[96] = "Veteran Knight";
            Randomizer.abilityNames[97] = "Charm";
            Randomizer.abilityNames[98] = "Advocate";
            Randomizer.abilityNames[99] = "Guardian";
            Randomizer.abilityNames[100] = "Lilys Poise";
            Randomizer.abilityNames[101] = "Infirmary Master";
            Randomizer.abilityNames[102] = "Philanderer";
            Randomizer.abilityNames[103] = "Rivalry";
            Randomizer.abilityNames[104] = "Born Fighter";
            Randomizer.abilityNames[105] = "Rally Strength";
            Randomizer.abilityNames[106] = "Rally Magic";
            Randomizer.abilityNames[107] = "Rally Speed";
            Randomizer.abilityNames[108] = "Rally Defense";
            Randomizer.abilityNames[109] = "Rally Resistance";
            Randomizer.abilityNames[110] = "Rally Movement";
            Randomizer.abilityNames[111] = "Rally Dexterity";
            Randomizer.abilityNames[112] = "Rally Luck";
            Randomizer.abilityNames[113] = "Rally Charm";
            Randomizer.abilityNames[114] = "Seal Strength";
            Randomizer.abilityNames[115] = "Seal Magic";
            Randomizer.abilityNames[116] = "Seal Speed";
            Randomizer.abilityNames[117] = "Seal Defense";
            Randomizer.abilityNames[118] = "Seal Resistance";
            Randomizer.abilityNames[119] = "Seal Movement";
            Randomizer.abilityNames[120] = "Heartseeker";
            Randomizer.abilityNames[121] = "Swordbreaker Plus";
            Randomizer.abilityNames[122] = "Lancebreaker Plus";
            Randomizer.abilityNames[123] = "Axebreaker Plus";
            Randomizer.abilityNames[124] = "Bowbreaker";
            Randomizer.abilityNames[125] = "Fistbreaker";
            Randomizer.abilityNames[126] = "Tomebreaker";
            Randomizer.abilityNames[(int)sbyte.MaxValue] = "Model Leader";
            Randomizer.abilityNames[128] = "Defensive Tactics";
            Randomizer.abilityNames[129] = "Offensive Tactics";
            Randomizer.abilityNames[130] = "Fire Ablilty";
            Randomizer.abilityNames[131] = "Miasma Ablilty";
            Randomizer.abilityNames[132] = "Heal Ablilty";
            Randomizer.abilityNames[133] = "Renewal Ablilty";
            Randomizer.abilityNames[134] = "Catnap";
            Randomizer.abilityNames[135] = "Goody Basket";
            Randomizer.abilityNames[136] = "Songstress";
            Randomizer.abilityNames[137] = "Hunters Boon";
            Randomizer.abilityNames[138] = "Poison Strike";
            Randomizer.abilityNames[139] = "Live to Serve";
            Randomizer.abilityNames[140] = "Lifetaker";
            Randomizer.abilityNames[141] = "Survival Instinct";
            Randomizer.abilityNames[142] = "Lethality";
            Randomizer.abilityNames[143] = "Poison";
            Randomizer.abilityNames[144] = "Pavise";
            Randomizer.abilityNames[145] = "Aegis";
            Randomizer.abilityNames[146] = "Miracle";
            Randomizer.abilityNames[147] = "Terrain Resistance";
            Randomizer.abilityNames[148] = "Special Dance";
            Randomizer.abilityNames[149] = "Paragon";
            Randomizer.abilityNames[150] = "Professors Guidance";
            Randomizer.abilityNames[151] = "Discipline";
            Randomizer.abilityNames[152] = "Aptitude";
            Randomizer.abilityNames[153] = "Vantage";
            Randomizer.abilityNames[154] = "Missing Number";
            Randomizer.abilityNames[155] = "Desperation";
            Randomizer.abilityNames[156] = "Quick Riposte";
            Randomizer.abilityNames[157] = "Wrath";
            Randomizer.abilityNames[158] = "Dance";
            Randomizer.abilityNames[159] = "Steal";
            Randomizer.abilityNames[160] = "Locktouch";
            Randomizer.abilityNames[161] = "Stealth";
            Randomizer.abilityNames[162] = "Canto";
            Randomizer.abilityNames[163] = "Pass";
            Randomizer.abilityNames[164] = "Swordbreaker";
            Randomizer.abilityNames[165] = "Lancebreaker";
            Randomizer.abilityNames[166] = "Bowrange Plus 1";
            Randomizer.abilityNames[167] = "Bowrange Plus 2";
            Randomizer.abilityNames[168] = "Black Magic Range Plus 1";
            Randomizer.abilityNames[169] = "Dark Magic Range Plus 1";
            Randomizer.abilityNames[170] = "White Magic Range Plus 1";
            Randomizer.abilityNames[171] = "Unarmed Combat";
            Randomizer.abilityNames[172] = "Black Magic Uses x2";
            Randomizer.abilityNames[173] = "Dark Magic Uses x2";
            Randomizer.abilityNames[174] = "White Magic Uses x2";
            Randomizer.abilityNames[175] = "White Magic Heal Plus 5";
            Randomizer.abilityNames[176] = "White Magic Heal Plus 10";
            Randomizer.abilityNames[177] = "Weight Minus 3";
            Randomizer.abilityNames[178] = "Weight Minus 5";
            Randomizer.abilityNames[179] = "Axebreaker";
            Randomizer.abilityNames[180] = "Unsealable Magic";
            Randomizer.abilityNames[181] = "Immune Status";
            Randomizer.abilityNames[182] = "General";
            Randomizer.abilityNames[183] = "Commander";
            Randomizer.abilityNames[184] = "Infinite Magic";
            Randomizer.abilityNames[185] = "Magic Bind";
            Randomizer.abilityNames[186] = "Infantry Effect Null";
            Randomizer.abilityNames[187] = "Armored Effect Null";
            Randomizer.abilityNames[188] = "Cavalry Effect Null";
            Randomizer.abilityNames[189] = "Flying Effect Null";
            Randomizer.abilityNames[190] = "Dragon Effect Null";
            Randomizer.abilityNames[191] = "Monster Effect Null";
            Randomizer.abilityNames[192] = "Effect Null";
            Randomizer.abilityNames[193] = "Air of Intimidation";
            Randomizer.abilityNames[194] = "Vital Defense";
            Randomizer.abilityNames[195] = "Giant Wings";
            Randomizer.abilityNames[196] = "Anti Magic Armor";
            Randomizer.abilityNames[197] = "Divine Dragon Horn";
            Randomizer.abilityNames[198] = "Path of the Conqueror";
            Randomizer.abilityNames[199] = "Noncombatant";
            Randomizer.abilityNames[200] = "Battalion Desperation";
            Randomizer.abilityNames[201] = "Cursed Power";
            Randomizer.abilityNames[202] = "Anchor";
            Randomizer.abilityNames[203] = "Counterattack";
            Randomizer.abilityNames[204] = "Twin Crests";
            Randomizer.abilityNames[205] = "Ancient Dragon Wrath";
            Randomizer.abilityNames[206] = "Surging Light";
            Randomizer.abilityNames[207] = "Ancient Dragonskin";
            Randomizer.abilityNames[208] = "Keen Intuition";
            Randomizer.abilityNames[209] = "Staunch Shield";
            Randomizer.abilityNames[210] = "Lone Wolf";
            Randomizer.abilityNames[211] = "Fighting Spirit";
            Randomizer.abilityNames[212] = "Confidence";
            Randomizer.abilityNames[213] = "Persecution Complex";
            Randomizer.abilityNames[214] = "Animal Friend";
            Randomizer.abilityNames[215] = "Perseverance";
            Randomizer.abilityNames[216] = "Crest Scholar";
            Randomizer.abilityNames[217] = "Compassion";
            Randomizer.abilityNames[218] = "Lockpick";
            Randomizer.abilityNames[219] = "Battalion Vantage";
            Randomizer.abilityNames[220] = "Battalion Wrath";
            Randomizer.abilityNames[221] = "Battalion Renewal";
            Randomizer.abilityNames[222] = "Black Magic Uses x4";
            Randomizer.abilityNames[223] = "Dark Magic Uses x4";
            Randomizer.abilityNames[224] = "White Magic Uses x4";
            Randomizer.abilityNames[225] = "Mighty King of Legend";
            Randomizer.abilityNames[226] = "Ten Elites";
            Randomizer.abilityNames[227] = "Alert Stance";
            Randomizer.abilityNames[228] = "Alert Stance Plus";
            Randomizer.abilityNames[229] = "Close Counter";
            Randomizer.abilityNames[230] = "Professors Guidance Plus";
            Randomizer.abilityNames[231] = "Imperial Lineage Plus";
            Randomizer.abilityNames[232] = "Royal Lineage Plus";
            Randomizer.abilityNames[233] = "Leicester Lineage Plus";
            Randomizer.abilityNames[234] = "Murderous Intent";
            Randomizer.abilityNames[235] = "Sacred Power";
            Randomizer.abilityNames[236] = "Agarthan Technology";
            Randomizer.abilityNames[237] = "Blade Breaker";
            Randomizer.abilityNames[238] = "Lucky Seven";
            Randomizer.abilityNames[239] = "Transmute";
            Randomizer.abilityNames[241] = "Honorable Spirit";
            Randomizer.abilityNames[242] = "King of Grappling";
            Randomizer.abilityNames[243] = "Circadian Beat";
            Randomizer.abilityNames[244] = "Monstrous Appeal";
            Randomizer.abilityNames[245] = "Business Prosperity";
            Randomizer.abilityNames[246] = "Umbral Leach";
            Randomizer.abilityNames[247] = "Manifest Phantoms";
            Randomizer.abilityNames[248] = "Enhanced Fortitude";
            Randomizer.abilityNames[250] = "Duelist's Blow";
            Randomizer.abilityNames[251] = "Uncanny Blow";
            Randomizer.abilityNames[255] = "None";
            Randomizer.spellNames[0] = "Fire";
            Randomizer.spellNames[1] = "Bolganone";
            Randomizer.spellNames[2] = "Ragnarok";
            Randomizer.spellNames[3] = "Thunder";
            Randomizer.spellNames[4] = "Thoron";
            Randomizer.spellNames[5] = "Bolting";
            Randomizer.spellNames[6] = "Wind";
            Randomizer.spellNames[7] = "Cutting Gale";
            Randomizer.spellNames[8] = "Excalibur";
            Randomizer.spellNames[9] = "Blizzard";
            Randomizer.spellNames[10] = "Fimbulvetr";
            Randomizer.spellNames[11] = "Sagittae";
            Randomizer.spellNames[12] = "Meteor";
            Randomizer.spellNames[13] = "Agneas Arrow";
            Randomizer.spellNames[14] = "Miasma Δ";
            Randomizer.spellNames[15] = "Mire Β";
            Randomizer.spellNames[16] = "Swarm Ζ";
            Randomizer.spellNames[17] = "Banshee Θ";
            Randomizer.spellNames[18] = "Death Γ";
            Randomizer.spellNames[19] = "Luna Λ";
            Randomizer.spellNames[20] = "Dark Spikes Τ";
            Randomizer.spellNames[21] = "Hades Ω";
            Randomizer.spellNames[22] = "Bohr Χ";
            Randomizer.spellNames[23] = "Quake Σ";
            Randomizer.spellNames[24] = "Heal";
            Randomizer.spellNames[25] = "Recover";
            Randomizer.spellNames[26] = "Physic";
            Randomizer.spellNames[27] = "Fortify";
            Randomizer.spellNames[28] = "Nosferatu";
            Randomizer.spellNames[29] = "Seraphim";
            Randomizer.spellNames[30] = "Aura";
            Randomizer.spellNames[31] = "Abraxas";
            Randomizer.spellNames[32] = "Torch";
            Randomizer.spellNames[33] = "Restore";
            Randomizer.spellNames[34] = "Ward";
            Randomizer.spellNames[35] = "Silence";
            Randomizer.spellNames[36] = "Rescue";
            Randomizer.spellNames[37] = "Warp";
            Randomizer.spellNames[38] = "None";
            Randomizer.crestNames[0] = "Crest of Ernest";
            Randomizer.crestNames[1] = "Crest of Macuil";
            Randomizer.crestNames[2] = "Crest of Seiros";
            Randomizer.crestNames[3] = "Crest of Dominic";
            Randomizer.crestNames[4] = "Crest of Fraldarius";
            Randomizer.crestNames[5] = "Crest of Noa";
            Randomizer.crestNames[6] = "Crest of Cethleann";
            Randomizer.crestNames[7] = "Crest of Daphnel";
            Randomizer.crestNames[8] = "Crest of Blaiddyd";
            Randomizer.crestNames[9] = "Crest of Gloucester";
            Randomizer.crestNames[10] = "Crest of Goneril";
            Randomizer.crestNames[11] = "Crest of Cichol";
            Randomizer.crestNames[12] = "Crest of Aubin";
            Randomizer.crestNames[13] = "Crest of Gautier";
            Randomizer.crestNames[14] = "Crest of Indech";
            Randomizer.crestNames[15] = "Crest of the Beast";
            Randomizer.crestNames[16] = "Crest of Charon";
            Randomizer.crestNames[17] = "Crest of Timotheos";
            Randomizer.crestNames[18] = "Crest of Riegan";
            Randomizer.crestNames[19] = "Crest of Chevalier";
            Randomizer.crestNames[20] = "Crest of Lamine";
            Randomizer.crestNames[21] = "Crest of Flames";
            Randomizer.crestNames[22] = "Minor Crest of Ernest";
            Randomizer.crestNames[23] = "Minor Crest of Macuil";
            Randomizer.crestNames[24] = "Minor Crest of Seiros";
            Randomizer.crestNames[25] = "Minor Crest of Dominic";
            Randomizer.crestNames[26] = "Minor Crest of Fraldarius";
            Randomizer.crestNames[27] = "Minor Crest of Noa";
            Randomizer.crestNames[28] = "Minor Crest of Cethleann";
            Randomizer.crestNames[29] = "Minor Crest of Daphnel";
            Randomizer.crestNames[30] = "Minor Crest of Blaiddyd";
            Randomizer.crestNames[31] = "Minor Crest of Gloucester";
            Randomizer.crestNames[32] = "Minor Crest of Goneril";
            Randomizer.crestNames[33] = "Minor Crest of Cichol";
            Randomizer.crestNames[34] = "Minor Crest of the Oban";
            Randomizer.crestNames[35] = "Minor Crest of Gautier";
            Randomizer.crestNames[36] = "Minor Crest of Indech";
            Randomizer.crestNames[37] = "Minor Crest of the Beast";
            Randomizer.crestNames[38] = "Minor Crest of Charon";
            Randomizer.crestNames[39] = "Minor Crest of Timotheos";
            Randomizer.crestNames[40] = "Minor Crest of Riegan";
            Randomizer.crestNames[41] = "Minor Crest of Chevalier";
            Randomizer.crestNames[42] = "Minor Crest of Lamine";
            Randomizer.crestNames[43] = "Minor Crest of Flames";
            Randomizer.crestNames[44] = "Agarthan Crest";
            Randomizer.crestNames[45] = "Crest of the Forge";
            Randomizer.crestNames[46] = "Mystery Crest";
            Randomizer.crestNames[47] = "Minor Mystery Crest";
            Randomizer.crestNames[48] = "Spare 34";
            Randomizer.crestNames[49] = "Spare 35";
            Randomizer.crestNames[50] = "Spare 36";
            Randomizer.crestNames[51] = "Spare 37";
            Randomizer.crestNames[52] = "Spare 38";
            Randomizer.crestNames[53] = "Spare 39";
            Randomizer.crestNames[54] = "Spare 40";
            Randomizer.crestNames[55] = "Spare 41";
            Randomizer.crestNames[56] = "Spare 42";
            Randomizer.crestNames[57] = "Spare 43";
            Randomizer.crestNames[58] = "Spare 44";
            Randomizer.crestNames[59] = "Spare 45";
            Randomizer.crestNames[60] = "Spare 46";
            Randomizer.crestNames[61] = "Spare 47";
            Randomizer.crestNames[62] = "Spare 48";
            Randomizer.crestNames[63] = "Spare 49";
            Randomizer.crestNames[64] = "Spare 50";
            Randomizer.crestNames[65] = "Spare 51";
            Randomizer.crestNames[66] = "Spare 52";
            Randomizer.crestNames[67] = "Spare 53";
            Randomizer.crestNames[68] = "Spare 54";
            Randomizer.crestNames[69] = "Spare 55";
            Randomizer.crestNames[70] = "Spare 56";
            Randomizer.crestNames[71] = "Spare 57";
            Randomizer.crestNames[72] = "Spare 58";
            Randomizer.crestNames[73] = "Spare 59";
            Randomizer.crestNames[74] = "Spare 60";
            Randomizer.crestNames[75] = "Spare 61";
            Randomizer.crestNames[76] = "Spare 62";
            Randomizer.crestNames[77] = "Spare 63";
            Randomizer.crestNames[78] = "Spare 64";
            Randomizer.crestNames[79] = "Spare 65";
            Randomizer.crestNames[80] = "Spare 66";
            Randomizer.crestNames[81] = "Spare 67";
            Randomizer.crestNames[82] = "Spare 68";
            Randomizer.crestNames[83] = "Spare 69";
            Randomizer.crestNames[84] = "Spare 70";
            Randomizer.crestNames[85] = "Spare 71";
            Randomizer.crestNames[86] = "None";
            combatArtNames[0] = "Sunder";
            combatArtNames[1] = "Wrath Strike";
            combatArtNames[2] = "Grounder";
            combatArtNames[3] = "Hexblade";
            combatArtNames[4] = "Windsweep";
            combatArtNames[5] = "Haze Slice";
            combatArtNames[6] = "Subdue";
            combatArtNames[7] = "Bane of Monsters";
            combatArtNames[8] = "Finesse Blade";
            combatArtNames[9] = "Soulblade";
            combatArtNames[10] = "Tempest Lance";
            combatArtNames[11] = "Shatter Slash";
            combatArtNames[12] = "Knightkneeler";
            combatArtNames[13] = "Hit and Run";
            combatArtNames[14] = "Monster Piercer";
            combatArtNames[15] = "Lance Jab";
            combatArtNames[16] = "Vengeance";
            combatArtNames[17] = "Glowing Ember";
            combatArtNames[18] = "Swift Strikes";
            combatArtNames[19] = "Frozen Lance";
            combatArtNames[20] = "Smash";
            combatArtNames[21] = "Spike";
            combatArtNames[22] = "Helm Splitter";
            combatArtNames[23] = "Monster Breaker";
            combatArtNames[24] = "Diamond Axe";
            combatArtNames[25] = "Exhaustive Strike";
            combatArtNames[26] = "Armored Strike";
            combatArtNames[27] = "Wild Abandon";
            combatArtNames[28] = "Focused Strike";
            combatArtNames[29] = "Lightning Axe";
            combatArtNames[30] = "Curved Shot";
            combatArtNames[31] = "Deadeye";
            combatArtNames[32] = "Heavy Draw";
            combatArtNames[33] = "Encloser";
            combatArtNames[34] = "Ward Arrow";
            combatArtNames[35] = "Point-Blank Volley";
            combatArtNames[36] = "Monster Blast";
            combatArtNames[37] = "Waning Shot";
            combatArtNames[38] = "Break Shot";
            combatArtNames[39] = "Schism Shot";
            combatArtNames[40] = "Healing Focus";
            combatArtNames[41] = "Draining Blow";
            combatArtNames[42] = "Mighty Blow";
            combatArtNames[43] = "Bombard";
            combatArtNames[44] = "Rushing Blow";
            combatArtNames[45] = "Fading Blow";
            combatArtNames[46] = "Mystic Blow";
            combatArtNames[47] = "Nimble Combo";
            combatArtNames[48] = "One-Two Punch";
            combatArtNames[49] = "Monster Crusher";
            combatArtNames[50] = "Swap";
            combatArtNames[51] = "Shove";
            combatArtNames[52] = "Reposition";
            combatArtNames[53] = "Draw Back";
            combatArtNames[54] = "Smite";
            combatArtNames[55] = "Foudroyant Strike";
            combatArtNames[56] = "Beast Fang";
            combatArtNames[57] = "Ruptured Heaven";
            combatArtNames[58] = "Ruined Sky";
            combatArtNames[59] = "Atrocity";
            combatArtNames[60] = "Burning Quake";
            combatArtNames[61] = "Apocalyptic Flame";
            combatArtNames[62] = "Dust";
            combatArtNames[63] = "Fallen Star";
            combatArtNames[64] = "Raging Storm";
            combatArtNames[65] = "Heaven's Fall";
            combatArtNames[66] = "Triangle Attack";
            combatArtNames[67] = "Hunter's Volley";
            combatArtNames[68] = "Assassinate";
            combatArtNames[69] = "Fierce Iron Fist";
            combatArtNames[70] = "Astra";
            combatArtNames[71] = "Parselene";
            combatArtNames[72] = "Wind God";
            combatArtNames[73] = "Flickering Flower";
            combatArtNames[74] = "War Master's Strike";
            combatArtNames[75] = "Sublime Heaven";
            combatArtNames[76] = "Sword Dance";
            combatArtNames[77] = "Foul Play";
            combatArtNames[78] = "Eviscerate";
            combatArtNames[79] = "Pneuma Gale";
            combatArtNames[255] = "None";
            characterNames[0] = "Male Byleth";
            characterNames[1] = "Female Byleth";
            characterNames[2] = "Edelgard";
            characterNames[3] = "Dimitri";
            characterNames[4] = "Claude";
            characterNames[5] = "Hubert";
            characterNames[6] = "Ferdinand";
            characterNames[7] = "Linhardt";
            characterNames[8] = "Caspar";
            characterNames[9] = "Bernadetta";
            characterNames[10] = "Dorothea";
            characterNames[11] = "Petra";
            characterNames[12] = "Dedue";
            characterNames[13] = "Felix";
            characterNames[14] = "Ashe";
            characterNames[15] = "Sylvain";
            characterNames[16] = "Mercedes";
            characterNames[17] = "Annette";
            characterNames[18] = "Ingrid";
            characterNames[19] = "Lorenz";
            characterNames[20] = "Raphael";
            characterNames[21] = "Ignatz";
            characterNames[22] = "Lysithea";
            characterNames[23] = "Marianne";
            characterNames[24] = "Hilda";
            characterNames[25] = "Leonie";
            characterNames[26] = "Seteth";
            characterNames[27] = "Flayn";
            characterNames[28] = "Hanneman";
            characterNames[29] = "Manuela";
            characterNames[30] = "Gilbert";
            characterNames[31] = "Alois";
            characterNames[32] = "Catherine";
            characterNames[33] = "Shamir";
            characterNames[34] = "Cyril";
            characterNames[35] = "Jeralt";
            characterNames[36] = "Rhea";
            characterNames[37] = "Sothis";
            characterNames[38] = "Kronya";
            characterNames[39] = "Solon";
            characterNames[40] = "Thales";
            characterNames[41] = "Cornelia";
            characterNames[42] = "Death Knight";
            characterNames[43] = "Kostas";
            characterNames[44] = "Lonato";
            characterNames[45] = "Miklan";
            characterNames[46] = "Randolph";
            characterNames[47] = "Flame Emperor";
            characterNames[49] = "Masked Jeritza";
            characterNames[50] = "Rodrigue";
            characterNames[51] = "Judith";
            characterNames[52] = "Nader";
            characterNames[53] = "Monica";
            characterNames[54] = "Lord Arundel";
            characterNames[55] = "Tomas";
            characterNames[56] = "Nemesis";
            characterNames[58] = "Seiros";
            characterNames[70] = "Dimitri (child)";
            characterNames[71] = "Edelgard (child)";
            characterNames[72] = "Emperor Ionius IX";
            characterNames[73] = "Duke Aegir";
            characterNames[74] = "Fleche";
            characterNames[75] = "Lambert";
            characterNames[80] = "Metodey";
            characterNames[81] = "Ladislava";
            characterNames[82] = "Gwendal";
            characterNames[83] = "Acheron";
            characterNames[84] = "Pallardó";
            characterNames[220] = "Hegemon Edelgard";
            characterNames[646] = "Maiden";
            characterNames[647] = "Gatekeeper";
            characterNames[681] = "Weakened Rhea";
            characterNames[1040] = "Yuri";
            characterNames[1041] = "Balthus";
            characterNames[1042] = "Constance";
            characterNames[1043] = "Hapi";
            characterNames[1044] = "Aelfric";
            characterNames[1045] = "Jeritza";
            characterNames[1046] = "Anna";
            inGameCharacterNames[0] = "Byleth";
            inGameCharacterNames[1] = "Byleth";
            inGameCharacterNames[2] = "Edelgard";
            inGameCharacterNames[3] = "Dimitri";
            inGameCharacterNames[4] = "Claude";
            inGameCharacterNames[5] = "Hubert";
            inGameCharacterNames[6] = "Ferdinand";
            inGameCharacterNames[7] = "Linhardt";
            inGameCharacterNames[8] = "Caspar";
            inGameCharacterNames[9] = "Bernadetta";
            inGameCharacterNames[10] = "Dorothea";
            inGameCharacterNames[11] = "Petra";
            inGameCharacterNames[12] = "Dedue";
            inGameCharacterNames[13] = "Felix";
            inGameCharacterNames[14] = "Ashe";
            inGameCharacterNames[15] = "Sylvain";
            inGameCharacterNames[16] = "Mercedes";
            inGameCharacterNames[17] = "Annette";
            inGameCharacterNames[18] = "Ingrid";
            inGameCharacterNames[19] = "Lorenz";
            inGameCharacterNames[20] = "Raphael";
            inGameCharacterNames[21] = "Ignatz";
            inGameCharacterNames[22] = "Lysithea";
            inGameCharacterNames[23] = "Marianne";
            inGameCharacterNames[24] = "Hilda";
            inGameCharacterNames[25] = "Leonie";
            inGameCharacterNames[26] = "Seteth";
            inGameCharacterNames[27] = "Flayn";
            inGameCharacterNames[28] = "Hanneman";
            inGameCharacterNames[29] = "Manuela";
            inGameCharacterNames[30] = "Gilbert";
            inGameCharacterNames[31] = "Alois";
            inGameCharacterNames[32] = "Catherine";
            inGameCharacterNames[33] = "Shamir";
            inGameCharacterNames[34] = "Cyril";
            inGameCharacterNames[35] = "Jeralt";
            inGameCharacterNames[36] = "Rhea";
            inGameCharacterNames[37] = "Sothis";
            inGameCharacterNames[38] = "Kronya";
            inGameCharacterNames[39] = "Solon";
            inGameCharacterNames[40] = "Thales";
            inGameCharacterNames[41] = "Cornelia";
            inGameCharacterNames[42] = "Death Knight";
            inGameCharacterNames[43] = "Kostas";
            inGameCharacterNames[44] = "Lonato";
            inGameCharacterNames[45] = "Miklan";
            inGameCharacterNames[46] = "Randolph";
            inGameCharacterNames[47] = "Flame Emperor";
            inGameCharacterNames[49] = "Jeritza";
            inGameCharacterNames[50] = "Rodrigue";
            inGameCharacterNames[51] = "Judith";
            inGameCharacterNames[52] = "Nader";
            inGameCharacterNames[53] = "Monica";
            inGameCharacterNames[54] = "Arundel";
            inGameCharacterNames[55] = "Tomas";
            inGameCharacterNames[56] = "Nemesis";
            inGameCharacterNames[58] = "Seiros";
            inGameCharacterNames[70] = "Dimitri";
            inGameCharacterNames[71] = "Edelgard";
            inGameCharacterNames[72] = "Ionius";
            inGameCharacterNames[73] = "Duke Aegir";
            inGameCharacterNames[74] = "Fleche";
            inGameCharacterNames[75] = "Lambert";
            inGameCharacterNames[80] = "Metodey";
            inGameCharacterNames[81] = "Ladislava";
            inGameCharacterNames[82] = "Gwendal";
            inGameCharacterNames[83] = "Acheron";
            inGameCharacterNames[84] = "Pallardó";
            inGameCharacterNames[220] = "Hegemon Edelgard";
            inGameCharacterNames[646] = "Maiden";
            inGameCharacterNames[647] = "Gatekeeper";
            inGameCharacterNames[681] = "Rhea";
            inGameCharacterNames[1040] = "Yuri";
            inGameCharacterNames[1041] = "Balthus";
            inGameCharacterNames[1042] = "Constance";
            inGameCharacterNames[1043] = "Hapi";
            inGameCharacterNames[1044] = "Aelfric";
            inGameCharacterNames[1045] = "Jeritza";
            inGameCharacterNames[1046] = "Anna";
            effectNames[0] = "Ward";
            effectNames[1] = "Silence";
            effectNames[2] = "Mire Β";
            effectNames[3] = "Swarm Ζ";
            effectNames[4] = "Banshee Θ";
            effectNames[5] = "Torch";
            effectNames[6] = "Poison";
            effectNames[7] = "Rattled";
            effectNames[8] = "Confusion";
            effectNames[9] = "Impregnable Wall";
            effectNames[10] = "Sacred Shield";
            effectNames[11] = "Cause and Effect";
            effectNames[12] = "Retribution";
            effectNames[13] = "Stride";
            effectNames[14] = "Blessing";
            effectNames[15] = "Frozen";
            effectNames[16] = "Silenced";
            effectNames[17] = "Seal Strength";
            effectNames[18] = "Seal Defense";
            effectNames[19] = "Seal Resistance";
            effectNames[20] = "Survival Instinct";
            effectNames[21] = "Strength Rally";
            effectNames[22] = "Magic Rally";
            effectNames[23] = "Speed Rally";
            effectNames[24] = "Defense Rally";
            effectNames[25] = "Resistance Rally";
            effectNames[26] = "Movement Rally";
            effectNames[27] = "Calm";
            effectNames[28] = "Optimist";
            effectNames[29] = "Special Dance";
            effectNames[30] = "Seal Strength";
            effectNames[31] = "Seal Magic";
            effectNames[32] = "Seal Speed";
            effectNames[33] = "Seal Defense";
            effectNames[34] = "Seal Resistance";
            effectNames[35] = "Seal Movement";
            effectNames[36] = "Ambush Tool Fortified";
            effectNames[37] = "Seal Strength";
            effectNames[38] = "Seal Magic";
            effectNames[39] = "Seal Speed";
            effectNames[40] = "Seal Defense";
            effectNames[41] = "Seal Resistance";
            effectNames[42] = "Strength Reinforced";
            effectNames[43] = "Strength Reinforced";
            effectNames[44] = "Strength Reinforced";
            effectNames[45] = "Strength Reinforced";
            effectNames[46] = "Strength Reinforced";
            effectNames[47] = "Magic Reinforced";
            effectNames[48] = "Magic Reinforced";
            effectNames[49] = "Magic Reinforced";
            effectNames[50] = "Magic Reinforced";
            effectNames[51] = "Magic Reinforced";
            effectNames[52] = "Dexterity Reinforced";
            effectNames[53] = "Dexterity Reinforced";
            effectNames[54] = "Dexterity Reinforced";
            effectNames[55] = "Dexterity Reinforced";
            effectNames[56] = "Dexterity Reinforced";
            effectNames[57] = "Speed Reinforced";
            effectNames[58] = "Speed Reinforced";
            effectNames[59] = "Speed Reinforced";
            effectNames[60] = "Speed Reinforced";
            effectNames[61] = "Speed Reinforced";
            effectNames[62] = "Defense Reinforced";
            effectNames[63] = "Defense Reinforced";
            effectNames[64] = "Defense Reinforced";
            effectNames[65] = "Defense Reinforced";
            effectNames[66] = "Defense Reinforced";
            effectNames[67] = "Resistance Reinforced";
            effectNames[68] = "Resistance Reinforced";
            effectNames[69] = "Resistance Reinforced";
            effectNames[70] = "Resistance Reinforced";
            effectNames[71] = "Resistance Reinforced";
            effectNames[72] = "Dexterity Rally";
            effectNames[73] = "Luck Rally";
            effectNames[74] = "Charm Rally";
            effectNames[75] = "Fallen Star";
            effectNames[76] = "Alert Stance";
            effectNames[77] = "Alert Stance+";
            effectNames[78] = "Paralysis";
            effectNames[79] = "Hex";
            effectNames[80] = "Lucky Seven";
            effectNames[81] = "Lucky Seven";
            effectNames[82] = "Lucky Seven";
            effectNames[83] = "Lucky Seven";
            effectNames[84] = "Lucky Seven";
            effectNames[85] = "Lucky Seven";
            effectNames[86] = "Lucky Seven";
            effectNames[87] = "Transmute";
            effectNames[88] = "Chalice's Protection";
            effectNames[89] = "Chalice's Preservation";
            effectNames[90] = "Absolute Defense";
            effectNames[91] = "Battleground Café";
            effectNames[92] = "Blood Sacrifice";
            effectNames[93] = "Stirrings of Reason";
            effectNames[96] = "None";
            weaponNames[0] = "Unarmed";
            weaponNames[1] = "Broken Sword";
            weaponNames[2] = "Broken Lance";
            weaponNames[3] = "Broken Axe";
            weaponNames[4] = "Broken Bow";
            weaponNames[5] = "Broken Gauntlet";
            weaponNames[6] = "Iron Sword";
            weaponNames[7] = "Steel Sword";
            weaponNames[8] = "Silver Sword";
            weaponNames[9] = "Brave Sword";
            weaponNames[10] = "Killing Edge";
            weaponNames[11] = "Training Sword";
            weaponNames[12] = "Iron Lance";
            weaponNames[13] = "Steel Lance";
            weaponNames[14] = "Silver Lance";
            weaponNames[15] = "Brave Lance";
            weaponNames[16] = "Killer Lance";
            weaponNames[17] = "Training Lance";
            weaponNames[18] = "Iron Axe";
            weaponNames[19] = "Steel Axe";
            weaponNames[20] = "Silver Axe";
            weaponNames[21] = "Brave Axe";
            weaponNames[22] = "Killer Axe";
            weaponNames[23] = "Training Axe";
            weaponNames[24] = "Iron Bow";
            weaponNames[25] = "Steel Bow";
            weaponNames[26] = "Silver Bow";
            weaponNames[27] = "Brave Bow";
            weaponNames[28] = "Killer Bow";
            weaponNames[29] = "Training Bow";
            weaponNames[30] = "Iron Gauntlets";
            weaponNames[31] = "Steel Gauntlets";
            weaponNames[32] = "Silver Gauntlets";
            weaponNames[33] = "Training Gauntlets";
            weaponNames[34] = "Levin Sword";
            weaponNames[35] = "Bolt Axe";
            weaponNames[36] = "Magic Bow";
            weaponNames[37] = "Javelin";
            weaponNames[38] = "Short Spear";
            weaponNames[39] = "Spear";
            weaponNames[40] = "Hand Axe";
            weaponNames[41] = "Short Axe";
            weaponNames[42] = "Tomahawk";
            weaponNames[43] = "Longbow";
            weaponNames[44] = "Mini Bow";
            weaponNames[45] = "Armorslayer";
            weaponNames[46] = "Rapier";
            weaponNames[47] = "Horseslayer";
            weaponNames[48] = "Hammer";
            weaponNames[49] = "Blessed Lance";
            weaponNames[50] = "Blessed Bow";
            weaponNames[51] = "Devil Sword";
            weaponNames[52] = "Devil Axe";
            weaponNames[53] = "Wo Dao";
            weaponNames[54] = "Crescent Sickle";
            weaponNames[55] = "Sword of Seiros";
            weaponNames[56] = "Sword of Begalta";
            weaponNames[57] = "Sword of Moralta";
            weaponNames[58] = "Cursed Ashiya Sword";
            weaponNames[59] = "Sword of Zoltan";
            weaponNames[60] = "Thunderbrand";
            weaponNames[61] = "Blutgang";
            weaponNames[62] = "Sword of the Creator";
            weaponNames[63] = "Lance of Zoltan";
            weaponNames[64] = "Lance of Ruin";
            weaponNames[65] = "Areadbhar";
            weaponNames[66] = "Lúin";
            weaponNames[67] = "Spear of Assal";
            weaponNames[68] = "Scythe of Sariel";
            weaponNames[69] = "Arrow of Indra";
            weaponNames[70] = "Freikugel";
            weaponNames[71] = "Crusher";
            weaponNames[72] = "Axe of Ukonvasara";
            weaponNames[73] = "Axe of Zoltan";
            weaponNames[74] = "Tathlum Bow";
            weaponNames[75] = "The Inexhaustible";
            weaponNames[76] = "Bow of Zoltan";
            weaponNames[77] = "Failnaught";
            weaponNames[78] = "Dragon Claws";
            weaponNames[79] = "Mace";
            weaponNames[80] = "Athame";
            weaponNames[81] = "Ridill";
            weaponNames[82] = "Aymr";
            weaponNames[83] = "Dark Creator Sword";
            weaponNames[84] = "Venin Edge";
            weaponNames[85] = "Venin Lance";
            weaponNames[86] = "Venin Axe";
            weaponNames[87] = "Venin Bow";
            weaponNames[88] = "Mercurius";
            weaponNames[89] = "Gradivus";
            weaponNames[90] = "Hauteclere";
            weaponNames[91] = "Parthia";
            weaponNames[92] = "Killer Knuckles";
            weaponNames[93] = "Aura Knuckles";
            weaponNames[94] = "Rusted Sword";
            weaponNames[95] = "Rusted Sword";
            weaponNames[96] = "Rusted Sword";
            weaponNames[97] = "Rusted Sword";
            weaponNames[98] = "Rusted Sword";
            weaponNames[99] = "Rusted Lance";
            weaponNames[100] = "Rusted Lance";
            weaponNames[101] = "Rusted Lance";
            weaponNames[102] = "Rusted Lance";
            weaponNames[103] = "Rusted Lance";
            weaponNames[104] = "Rusted Axe";
            weaponNames[105] = "Rusted Axe";
            weaponNames[106] = "Rusted Axe";
            weaponNames[107] = "Rusted Axe";
            weaponNames[108] = "Rusted Axe";
            weaponNames[109] = "Rusted Bow";
            weaponNames[110] = "Rusted Bow";
            weaponNames[111] = "Rusted Bow";
            weaponNames[112] = "Rusted Bow";
            weaponNames[113] = "Rusted Bow";
            weaponNames[114] = "Rusted Gauntlets";
            weaponNames[115] = "Rusted Gauntlets";
            weaponNames[116] = "Rusted Gauntlets";
            weaponNames[117] = "Rusted Gauntlets";
            weaponNames[118] = "Iron Sword+";
            weaponNames[119] = "Steel Sword+";
            weaponNames[120] = "Silver Sword+";
            weaponNames[121] = "Brave Sword+";
            weaponNames[122] = "Killing Edge+";
            weaponNames[123] = "Training Sword+";
            weaponNames[124] = "Iron Lance+";
            weaponNames[125] = "Steel Lance+";
            weaponNames[126] = "Silver Lance+";
            weaponNames[127] = "Brave Lance+";
            weaponNames[128] = "Killer Lance+";
            weaponNames[129] = "Training Lance+";
            weaponNames[130] = "Iron Axe+";
            weaponNames[131] = "Steel Axe+";
            weaponNames[132] = "Silver Axe+";
            weaponNames[133] = "Brave Axe+";
            weaponNames[134] = "Killer Axe+";
            weaponNames[135] = "Training Axe+";
            weaponNames[136] = "Iron Bow+";
            weaponNames[137] = "Steel Bow+";
            weaponNames[138] = "Silver Bow+";
            weaponNames[139] = "Brave Bow+";
            weaponNames[140] = "Killer Bow+";
            weaponNames[141] = "Training Bow+";
            weaponNames[142] = "Iron Gauntlets+";
            weaponNames[143] = "Steel Gauntlets+";
            weaponNames[144] = "Silver Gauntlets+";
            weaponNames[145] = "Training Gauntlets+";
            weaponNames[146] = "Levin Sword+";
            weaponNames[147] = "Bolt Axe+";
            weaponNames[148] = "Magic Bow+";
            weaponNames[149] = "Javelin +";
            weaponNames[150] = "Short Spear+";
            weaponNames[151] = "Spear +";
            weaponNames[152] = "Hand Axe+";
            weaponNames[153] = "Short Axe+";
            weaponNames[154] = "Tomahawk +";
            weaponNames[155] = "Longbow +";
            weaponNames[156] = "Mini Bow+";
            weaponNames[157] = "Armorslayer +";
            weaponNames[158] = "Rapier +";
            weaponNames[159] = "Horseslayer +";
            weaponNames[160] = "Hammer +";
            weaponNames[161] = "Blessed Lance+";
            weaponNames[162] = "Blessed Bow+";
            weaponNames[163] = "Devil Sword+";
            weaponNames[164] = "Devil Axe+";
            weaponNames[165] = "Wo Dao+";
            weaponNames[166] = "Crescent Sickle+";
            weaponNames[167] = "Cursed Ashiya Sword +";
            weaponNames[168] = "Sword of Zoltan +";
            weaponNames[169] = "Lance of Zoltan +";
            weaponNames[170] = "Arrow of Indra +";
            weaponNames[171] = "Axe of Zoltan +";
            weaponNames[172] = "Bow of Zoltan +";
            weaponNames[173] = "Dragon Claws+";
            weaponNames[174] = "Mace +";
            weaponNames[175] = "Venin Edge+";
            weaponNames[176] = "Venin Lance+";
            weaponNames[177] = "Venin Axe+";
            weaponNames[178] = "Venin Bow+";
            weaponNames[179] = "Killer Knuckles+";
            weaponNames[180] = "Aura Knuckles+";
            weaponNames[181] = "Sublime Creator Sword";
            weaponNames[182] = "Dark Thunderbrand";
            weaponNames[183] = "Dark Blutgang";
            weaponNames[184] = "Dark Lance of Ruin";
            weaponNames[185] = "Areadbhar Î“";
            weaponNames[186] = "Lúin Î”";
            weaponNames[187] = "Freikugel Î›";
            weaponNames[188] = "Dark Crusher";
            weaponNames[189] = "Failnaught Î¤";
            weaponNames[190] = "Vajra - Mushti";
            weaponNames[200] = "Crest Stone (Gautier)";
            weaponNames[201] = "Crest Stone (Beast)";
            weaponNames[202] = "Cracked Crest Stone";
            weaponNames[203] = "Crest Stone Shard";
            weaponNames[204] = "Artificial Crest Stone S";
            weaponNames[205] = "Artificial Crest Stone L";
            weaponNames[206] = "Giant Art. Crest Stone";
            weaponNames[207] = "Pointy Art. Crest Stone";
            weaponNames[208] = "Lance of Light";
            weaponNames[209] = "Lance of Light+";
            weaponNames[210] = "Giant Katar";
            weaponNames[211] = "Blest Crest Stone Shard";
            weaponNames[212] = "Crest Stone of Seiros";
            weaponNames[213] = "Crest Stone of Seiros";
            weaponNames[214] = "Real Seiros Crest Stone";
            weaponNames[215] = "Crest Stone of Macuil";
            weaponNames[216] = "Crest Stone of Indech";
            weaponNames[217] = "Dark Stone (Bird)";
            weaponNames[218] = "Dark Stone (Crawler)";
            weaponNames[219] = "Dark Stone (Wolf)";
            weaponNames[220] = "Crest of Flames Power";
            weaponNames[221] = "Twin-Crest Power";
            weaponNames[222] = "Piercing Light Lance";
            weaponNames[223] = "Throwing Light Lance";
            weaponNames[224] = "Sharp Wings";
            weaponNames[225] = "Lost Crest Stone";
            weaponNames[226] = "Lost Crest Stone (Lg)";
            weaponNames[227] = "Crest of Flames Power";
            weaponNames[228] = "Crest of Flames Power";
            weaponNames[229] = "Chalice of Blood";
            weaponNames[230] = "Crest Stone (Chevalier)";
            weaponNames[300] = "Viskam";
            gambitNames[0] = "Onslaught";
            gambitNames[1] = "Assembly";
            gambitNames[2] = "Reversal";
            gambitNames[3] = "Lure";
            gambitNames[4] = "Disturbance";
            gambitNames[5] = "Blaze";
            gambitNames[6] = "Fusillade";
            gambitNames[7] = "Assault Troop";
            gambitNames[8] = "Absorption";
            gambitNames[9] = "Poisoned Arrows";
            gambitNames[10] = "Resonant Flames";
            gambitNames[11] = "Resonant Ice";
            gambitNames[12] = "Resonant Lightning";
            gambitNames[13] = "Resonant White Magic";
            gambitNames[14] = "Flash-Fire Arrows";
            gambitNames[15] = "Group Lance Attack";
            gambitNames[16] = "Linked Horses";
            gambitNames[17] = "Poison Tactic";
            gambitNames[18] = "Bag of Tricks";
            gambitNames[19] = "Recovery Roar";
            gambitNames[20] = "";
            gambitNames[21] = "Impregnable Wall";
            gambitNames[22] = "Sacred Shield";
            gambitNames[23] = "";
            gambitNames[24] = "Retribution";
            gambitNames[25] = "Stride";
            gambitNames[26] = "Blessing";
            gambitNames[27] = "Dance of the Goddess";
            gambitNames[28] = "Ashes and Dust";
            gambitNames[29] = "Raging Flames";
            gambitNames[30] = "Wave Attack";
            gambitNames[31] = "Line of Lances";
            gambitNames[32] = "Group Flames";
            gambitNames[33] = "Group Ice";
            gambitNames[34] = "Group Lightning";
            gambitNames[35] = "Mad Melee";
            gambitNames[36] = "Random Shot";
            gambitNames[37] = "Absolute Defense";
            gambitNames[38] = "Battleground Café";
            gambitNames[39] = "Battleground Clean Up";
            blowNames[0] = "Thorns of Ruin";
            blowNames[1] = "Heavy Strike";
            blowNames[2] = "Poison Breath";
            blowNames[3] = "Flame Breath";
            blowNames[4] = "Brimstone Breath";
            blowNames[5] = "Arm Press";
            blowNames[6] = "Annihilation";
            blowNames[7] = "Light-Lance Barrage";
            blowNames[8] = "Titanomachy";
            blowNames[9] = "Light Breath";
            blowNames[10] = "Aurora Breath";
            blowNames[11] = "Hoarfrost";
            blowNames[12] = "Gale";
            blowNames[13] = "Rapids";
            blowNames[14] = "Sky Fissure";
            blowNames[15] = "Sandstorm";
            blowNames[16] = "Cyclone";
            blowNames[17] = "Wilted Flower";
            blowNames[18] = "Umbral Surge";
            caEffectNames[0] = "None";
            caEffectNames[18] = "Leaves Target With 1 HP";
            caEffectNames[19] = "Increase Damage Based on Missing HP";
            caEffectNames[20] = "Hits Twice";
            caEffectNames[21] = "Hits 3 times";
            caEffectNames[22] = "Astra Effect";
            caEffectNames[23] = "Depletes all Durability for Amount*30% Might";
            caEffectNames[24] = "Prevent Target from Moving for 1 Turn";
            caEffectNames[25] = "Prevent Target from Using Magic for 1 Turn";
            caEffectNames[26] = "Minus 5 Str for 1 Turn on Target";
            caEffectNames[27] = "Minus 5 Def for 1 Turn on Target";
            caEffectNames[28] = "Minus 5 Res for 1 Turn on Target";
            caEffectNames[29] = "Restores 50% of User's HP";
            caEffectNames[30] = "Restores HP Equal to 50% of Damage";
            caEffectNames[31] = "Moves 1 Space in front of Target";
            caEffectNames[32] = "After Combat, User Moves 1 Space back";
            caEffectNames[33] = "Triggers Follow up Attack";
            caEffectNames[34] = "Swap Places with Target";
            caEffectNames[35] = "Pushes Target forward 1 Space";
            caEffectNames[36] = "Move to other Side of Target";
            caEffectNames[37] = "Move User and Target back 1 Space";
            caEffectNames[38] = "Pushes Target forward 2 Spaces";
            caEffectNames[39] = "Triangle Attack Effect";
            caEffectNames[40] = "Can Kill Instantly";
            caEffectNames[41] = "Unknown";
            caEffectNames[42] = "Unknown";
            caEffectNames[43] = "Effective Against all Units";
            caEffectNames[44] = "Unknown";
            caEffectNames[45] = "Might Increases Based on Mag";
            caEffectNames[46] = "Might Increases Based on Dex";
            caEffectNames[47] = "Might Increases Based on Spd";
            caEffectNames[48] = "Might Increases Based on Res";
            caEffectNames[49] = "Might Increases Based on Def";
            caEffectNames[50] = "Avoid all Attacks Next Combat";
            caEffectNames[51] = "Can Move Again after Successful Hit";
            caEffectNames[52] = "Might Increases Based on Cha";
            caEffectNames[53] = "Calculates Damage Based on the Lowerst of Def and Res";
            caEffectNames[54] = "Swap Position with Target";
            battalionNames[0] = "Church of Seiros Soldiers";
            battalionNames[1] = "Seiros Mercenaries";
            battalionNames[2] = "Seiros Holy Monks";
            battalionNames[3] = "Seiros Sacred Monks";
            battalionNames[4] = "Seiros Magic Corps";
            battalionNames[5] = "Seiros Pegasus Co.";
            battalionNames[6] = "Knights of Seiros";
            battalionNames[7] = "Holy Knights of Seiros";
            battalionNames[8] = "Indech Sword Fighters";
            battalionNames[9] = "Macuil Evil Repelling Co.";
            battalionNames[10] = "Empire Infantry";
            battalionNames[11] = "Empire Warriors";
            battalionNames[12] = "Empire Magic Corps";
            battalionNames[13] = "Empire Archers";
            battalionNames[14] = "Empire Cavalry";
            battalionNames[15] = "Empire Knights";
            battalionNames[16] = "Empire Armored Co.";
            battalionNames[17] = "Empire Snipers";
            battalionNames[18] = "Empire Magic Users";
            battalionNames[19] = "Empire Pavise Co.";
            battalionNames[20] = "Empire Pegasus Co.";
            battalionNames[21] = "Empire Wyvern Co.";
            battalionNames[22] = "Empire Heavy Soldiers";
            battalionNames[23] = "Empire Holy Magic Users";
            battalionNames[24] = "Empire Raiders";
            battalionNames[25] = "Imperial Guard";
            battalionNames[26] = "Empire Elite Wyvern Co.";
            battalionNames[27] = "Black Eagle Heavy Axes";
            battalionNames[28] = "Black Eagle Cavalry";
            battalionNames[29] = "Black Eagle Pegasus Co.";
            battalionNames[30] = "Kingdom Infantry";
            battalionNames[31] = "Kingdom Lance Co.";
            battalionNames[32] = "Kingdom Magic Corps";
            battalionNames[33] = "Kingdom Archers";
            battalionNames[34] = "Kingdom Cavalry";
            battalionNames[35] = "Kingdom Knights";
            battalionNames[36] = "Kingdom Armored Co.";
            battalionNames[37] = "Kingdom Snipers";
            battalionNames[38] = "Kingdom Magic Users";
            battalionNames[39] = "Kingdom Brave Lance Co.";
            battalionNames[40] = "Kingdom Pegasus Co.";
            battalionNames[41] = "Kingdom Wyvern Co.";
            battalionNames[42] = "Kingdom Heavy Soldiers";
            battalionNames[43] = "Kingdom Holy Knights";
            battalionNames[44] = "Kingdom Heavy Knights";
            battalionNames[45] = "Royal Guard";
            battalionNames[46] = "Kingdom Priests";
            battalionNames[47] = "Blue Lion Knights";
            battalionNames[48] = "Blue Lion Magic Corps";
            battalionNames[49] = "Blue Lion Dancers";
            battalionNames[50] = "Alliance Infantry";
            battalionNames[51] = "Alliance Duelists";
            battalionNames[52] = "Alliance Magic Corps";
            battalionNames[53] = "Alliance Archers";
            battalionNames[54] = "Alliance Cavalry";
            battalionNames[55] = "Alliance Knights";
            battalionNames[56] = "Alliance Armored Co.";
            battalionNames[57] = "Alliance Snipers";
            battalionNames[58] = "Alliance Magic Users";
            battalionNames[59] = "Alliance Veteran Duelists";
            battalionNames[60] = "Alliance Pegasus Co.";
            battalionNames[61] = "Alliance Wyvern Co.";
            battalionNames[62] = "Alliance Pavise Co.";
            battalionNames[63] = "Alliance Physicians";
            battalionNames[64] = "Alliance Sages";
            battalionNames[65] = "Alliance Master Archers";
            battalionNames[66] = "Alliance Guard";
            battalionNames[67] = "Golden Deer Wyvern Co.";
            battalionNames[68] = "Golden Deer Archers";
            battalionNames[69] = "Golden Deer Cavalry";
            battalionNames[70] = "Supreme Armored Co.";
            battalionNames[71] = "King of Lions Corps";
            battalionNames[72] = "Immortal Corps";
            battalionNames[73] = "Vestra Sorcery Engineers";
            battalionNames[74] = "Aegir Astral Knights";
            battalionNames[75] = "Hevring Prayer Troops";
            battalionNames[76] = "Bergliez War Group";
            battalionNames[77] = "Varley Archers";
            battalionNames[78] = "Opera Co. Volunteers";
            battalionNames[79] = "Brigid Hunters";
            battalionNames[80] = "Duscur Heavy Soldiers";
            battalionNames[81] = "Fraldarius Soldiers";
            battalionNames[82] = "Gaspard Knights";
            battalionNames[83] = "Gautier Knights";
            battalionNames[84] = "Church Soldiers";
            battalionNames[85] = "School of Sorcery Soldiers";
            battalionNames[86] = "Galatea Pegasus Co.";
            battalionNames[87] = "Gloucester Knights";
            battalionNames[88] = "Leicester Mercenaries";
            battalionNames[89] = "Victor Private Military";
            battalionNames[90] = "Ordelia Sorcery Co.";
            battalionNames[91] = "Edmund Troops";
            battalionNames[92] = "Goneril Valkyries";
            battalionNames[93] = "Sauin Militia";
            battalionNames[94] = "Cichol Wyvern Co.";
            battalionNames[95] = "Cethleann Monks";
            battalionNames[96] = "Jeralt's Mercenaries";
            battalionNames[97] = "Reaper Knights";
            battalionNames[98] = "Secret Transport Force";
            battalionNames[99] = "";
            battalionNames[100] = "Remire Militia";
            battalionNames[101] = "Empire Youths";
            battalionNames[102] = "Kingdom Youths";
            battalionNames[103] = "Alliance Youths";
            battalionNames[104] = "";
            battalionNames[105] = "Duscur Infantry";
            battalionNames[106] = "Almyra Mercenaries";
            battalionNames[107] = "Brigid Mercenaries";
            battalionNames[108] = "Morfis Magic Corps";
            battalionNames[109] = "Seiros Brawlers";
            battalionNames[110] = "Empire Brawlers";
            battalionNames[111] = "Kingdom Brawlers";
            battalionNames[112] = "Alliance Brawlers";
            battalionNames[113] = "Seiros Armored Co.";
            battalionNames[114] = "Seiros Archers";
            battalionNames[115] = "Essar Research Group";
            battalionNames[116] = "Holst's Chosen";
            battalionNames[117] = "Dahlman Guard";
            battalionNames[118] = "Dahlman Magic Co.";
            battalionNames[119] = "Dahlman Armored Group";
            battalionNames[120] = "Dahlman PMC";
            battalionNames[121] = "";
            battalionNames[122] = "";
            battalionNames[123] = "";
            battalionNames[124] = "";
            battalionNames[125] = "";
            battalionNames[126] = "";
            battalionNames[127] = "";
            battalionNames[128] = "";
            battalionNames[129] = "";
            battalionNames[130] = "Iron King's Thieves";
            battalionNames[131] = "Gaspard Militia";
            battalionNames[132] = "Gaspard Knights";
            battalionNames[133] = "West Church Corps";
            battalionNames[134] = "West Church Mercenaries";
            battalionNames[135] = "West Church Sages";
            battalionNames[136] = "West Church Pegasus Co.";
            battalionNames[137] = "West Church Knights";
            battalionNames[138] = "Mysterious Infantry";
            battalionNames[139] = "Mysterious Magic Corps";
            battalionNames[140] = "Mysterious Magic Users";
            battalionNames[141] = "Miklan Private Militia";
            battalionNames[142] = "Reaper Infantry";
            battalionNames[143] = "Reaper Knights";
            battalionNames[144] = "Rampaging Villagers";
            battalionNames[145] = "Solon Subordinates";
            battalionNames[146] = "Kronya Subordinates";
            battalionNames[147] = "Pallardó Bodyguards";
            battalionNames[148] = "Rowe Knights";
            battalionNames[149] = "House Rowe Archers";
            battalionNames[150] = "Rowe Armored Co.";
            battalionNames[151] = "Rowe Cavalry";
            battalionNames[152] = "Daphnel Duelists";
            battalionNames[153] = "Almyra Wyvern Co.";
            battalionNames[154] = "Almyra Cavalry";
            battalionNames[155] = "Dark Infantry";
            battalionNames[156] = "Dark Magic Corps";
            battalionNames[157] = "Einherjar";
            battalionNames[158] = "Enhanced Infantry";
            battalionNames[159] = "Enhanced Heavy Co.";
            battalionNames[160] = "Enhanced Cavalry";
            battalionNames[161] = "Enhanced Wyvern Co.";
            battalionNames[162] = "Ancient Infantry";
            battalionNames[163] = "Ancient Armored Co.";
            battalionNames[164] = "Ancient Cavalry";
            battalionNames[165] = "Ancient Wyvern Co.";
            battalionNames[166] = "Phantasmal Infantry";
            battalionNames[167] = "Phantasmal Cavalry";
            battalionNames[168] = "Phantasmal Wyvern Co.";
            battalionNames[169] = "Duscur Infantry";
            battalionNames[170] = "Duscur Cavalry";
            battalionNames[171] = "Dominic Cavalry";
            battalionNames[172] = "Merchant Military";
            battalionNames[173] = "Thieves";
            battalionNames[174] = "Rogues";
            battalionNames[175] = "Bandits";
            battalionNames[176] = "Pirates";
            battalionNames[177] = "Arundel Magic Corps";
            battalionNames[178] = "Mysterious Wyvern Co.";
            battalionNames[179] = "Dark Wyvern Co.";
            battalionNames[180] = "Ancient Sorcerers";
            battalionNames[181] = "Enhanced Sorcerers";
            battalionNames[182] = "Phantasmal Magic Corps";
            battalionNames[183] = "Phantasmal Archers";
            battalionNames[184] = "Gaspard Archers";
            battalionNames[185] = "Thief Marksmen";
            battalionNames[186] = "Cliff Bandit Marksmen";
            battalionNames[187] = "Pirate Marksmen";
            battalionNames[188] = "West Church Archers";
            battalionNames[189] = "Flame Emperor Co.";
            battalionNames[190] = "Mockingbird's Thieves";
            battalionNames[191] = "Leicester Dicers Corps";
            battalionNames[192] = "Nuvelle Fliers Corps";
            battalionNames[193] = "Timotheos Magi Corps";
            battalionNames[194] = "Thief Pegasus Corps";
            battalionNames[195] = "Pirate Pegasus Corps";
            battalionNames[196] = "Bandit Pegasus Corps";
            battalionNames[197] = "Nuvelle Chamberlain Co.";
            battalionNames[198] = "Nuvelle Attendants Co.";
            battalionNames[199] = "Nuvelle Stewards Co.";
            battalionNames[200] = "None";
            bgmNames[0] = "Fódlan Winds";
            bgmNames[1] = "Fódlan Winds";
            bgmNames[2] = "Tearing Through Heaven";
            bgmNames[3] = "Tearing Through Heaven";
            bgmNames[4] = "Roar of Dominion";
            bgmNames[5] = "Roar of Dominion";
            bgmNames[6] = "Chasing Daybreak";
            bgmNames[7] = "Chasing Daybreak";
            bgmNames[8] = "The Long Road";
            bgmNames[9] = "The Long Road";
            bgmNames[10] = "Blue Skies and a Battle";
            bgmNames[11] = "Blue Skies and a Battle";
            bgmNames[12] = "Between Heaven and Earth";
            bgmNames[13] = "Between Heaven and Earth";
            bgmNames[14] = "God-Shattering Star";
            bgmNames[15] = "God-Shattering Star";
            bgmNames[16] = "A Funeral of Flowers";
            bgmNames[17] = "A Funeral of Flowers";
            bgmNames[18] = "The Apex of the World";
            bgmNames[19] = "The Apex of the World";
            bgmNames[20] = "Tempest of Seasons";
            bgmNames[21] = "Tempest of Seasons";
            bgmNames[22] = "";
            bgmNames[23] = "";
            bgmNames[24] = "Shambhala (Area 17 Redux)";
            bgmNames[25] = "Shambhala (Area 17 Redux)";
            bgmNames[26] = "Dwellings of the Ancient Gods";
            bgmNames[27] = "Dwellings of the Ancient Gods";
            bgmNames[28] = "Corridor of the Tempest";
            bgmNames[29] = "Corridor of the Tempest";
            bgmNames[30] = "";
            bgmNames[31] = "";
            bgmNames[32] = "Wrath Strike";
            bgmNames[33] = "Wrath Strike";
            bgmNames[34] = "The Verge of Death";
            bgmNames[35] = "The Verge of Death";
            bgmNames[36] = "";
            bgmNames[37] = "";
            bgmNames[38] = "Paths That Will Never Cross";
            bgmNames[39] = "Paths That Will Never Cross";
            bgmNames[40] = "Indomitable Will";
            bgmNames[41] = "Indomitable Will";
            bgmNames[42] = "";
            bgmNames[43] = "";
            bgmNames[44] = "The Shackled Wolves";
            bgmNames[45] = "The Shackled Wolves";
            bgmNames[46] = "At What Cost?";
            bgmNames[47] = "At What Cost?";
            bgmNames[48] = "Map Battle Boss Reserved";
            bgmNames[49] = "Map Battle Boss Reserved";
            bgmNames[50] = "Map Battle Boss Reserved";
            bgmNames[51] = "Map Battle Boss Reserved";
            bgmNames[52] = "The Spirit Dais";
            bgmNames[53] = "";
            bgmNames[54] = "Guardian of Starlight";
            bgmNames[55] = "Gazing at Sirius";
            bgmNames[56] = "Song of the Nabateans";
            bgmNames[57] = "Those Who Sow Darkness";
            bgmNames[58] = "Respite and Sunlight";
            bgmNames[59] = "A Gentle Breeze";
            bgmNames[60] = "Beneath the Banner";
            bgmNames[61] = "Recollection and Regret";
            bgmNames[62] = "Somewhere to Belong";
            bgmNames[63] = "Calm Winds Over Gentle Waters";
            bgmNames[64] = "Tactics";
            bgmNames[65] = "Anxiety";
            bgmNames[66] = "The Leader's Path";
            bgmNames[67] = "The King of Lions";
            bgmNames[68] = "Golden Deer and Crescent Moon";
            bgmNames[69] = "A Dark Sign";
            bgmNames[70] = "Spiderweb";
            bgmNames[71] = "Mask of Fire";
            bgmNames[72] = "Dark Clouds Gather";
            bgmNames[73] = "Arcana Code";
            bgmNames[74] = "Beyond the Crossroads";
            bgmNames[75] = "A Lonely Figure";
            bgmNames[76] = "A Vow Remembered";
            bgmNames[77] = "A Place to Rest";
            bgmNames[78] = "A Promise";
            bgmNames[79] = "Unfulfilled";
            bgmNames[80] = "";
            bgmNames[81] = "Funny Footsteps";
            bgmNames[82] = "Words to Believe In";
            bgmNames[83] = "Learning Lessons";
            bgmNames[84] = "Seeking New Heights";
            bgmNames[85] = "Hungry March";
            bgmNames[86] = "Battle on the Waterfront";
            bgmNames[87] = "";
            bgmNames[88] = "Hope as a Melody";
            bgmNames[89] = "Teatime Joy";
            bgmNames[90] = "";
            bgmNames[91] = "Farewell";
            bgmNames[92] = "White Heron Waltz";
            bgmNames[93] = "";
            bgmNames[94] = "";
            bgmNames[95] = "Burning Up";
            bgmNames[96] = "Fire Emblem: Three Houses Main Theme";
            bgmNames[97] = "The Crest of Flames";
            bgmNames[98] = "Life at Garreg Mach Monastery";
            bgmNames[99] = "Broken Routine";
            bgmNames[100] = "Scales of the Goddess";
            bgmNames[101] = "Scales of the Goddess";
            bgmNames[102] = "Scales of the Goddess";
            bgmNames[103] = "Scales of the Goddess";
            bgmNames[104] = "As Swift as Wind";
            bgmNames[105] = "As Fierce as Fire";
            bgmNames[106] = "The Land Beloved by the Goddess";
            bgmNames[107] = "Three Crowns";
            bgmNames[108] = "The Dream is Over";
            bgmNames[109] = "The Dream is Over";
            bgmNames[110] = "A Star in the Morning Sky";
            bgmNames[111] = "Still Horizon";
            bgmNames[112] = "The Edge of Dawn";
            bgmNames[113] = "The Color of Sunrise";
            bgmNames[114] = "The Edge of Dawn (Seasons of Warfare) (Short Version)";
            bgmNames[115] = "";
            bgmNames[116] = "";
            bgmNames[117] = "";
            bgmNames[118] = "Garreg Mach Cathedral";
            bgmNames[119] = "People of the Marketplace";
            bgmNames[120] = "A Guide for the Future";
            bgmNames[121] = "Revenge";
            bgmNames[122] = "";
            bgmNames[123] = "";
            bgmNames[124] = "The Archbishop";
            bgmNames[125] = "The Officers Academy";
            bgmNames[126] = "";
            bgmNames[127] = "";
            bgmNames[128] = "";
            bgmNames[129] = "";
            bgmNames[130] = "The Night of the Ball";
            bgmNames[131] = "Fated Death";
            bgmNames[132] = "";
            bgmNames[133] = "Awakening";
            bgmNames[134] = "Descent";
            bgmNames[135] = "Loathing";
            bgmNames[136] = "";
            bgmNames[137] = "";
            bgmNames[138] = "";
            bgmNames[139] = "Rematch";
            bgmNames[140] = "Javelins of Light";
            bgmNames[141] = "";
            bgmNames[142] = "The Curse";
            bgmNames[143] = "Wailing";
            bgmNames[144] = "Citizens of the East";
            bgmNames[145] = "A World for Humanity";
            bgmNames[146] = "Light and Shadow";
            bgmNames[147] = "A New Dawn";
            bgmNames[148] = "School Chime";
            bgmNames[149] = "Level Up";
            bgmNames[150] = "Positive Type 1 (when acquiring regular item)";
            bgmNames[151] = "Positive Type 1 (when acquiring important item)";
            bgmNames[152] = "Negative Type 1 (when losing item, e.g.)";
            bgmNames[153] = "";
            bgmNames[154] = "";
            bgmNames[155] = "";
            bgmNames[156] = "";
            bgmNames[157] = "";
            bgmNames[158] = "";
            bgmNames[159] = "The Time to Act";
            bgmNames[160] = "Eternal Bond";
            bgmNames[161] = "Id (Purpose)";
            bgmNames[162] = "Conquest (Ablaze)";
            bgmNames[163] = "Beneath a New Light (Roy's Courage)";
            bgmNames[164] = "March to Deliverance";
            bgmNames[165] = "With Mila's Divine Protection";
            bgmNames[166] = "Alight (Storm)";
            bgmNames[167] = "A Dark Fall (Fire)";
            bgmNames[168] = "Destiny (Ablaze)";
            bgmNames[169] = "The World Tree";
            bgmNames[170] = "Courage and Tragedy";
            bgmNames[171] = "";
            bgmNames[172] = "Steam Baths Respite";
            bgmNames[173] = "Legend of the Chalice";
            bgmNames[174] = "The Forgotten";
            bgmNames[175] = "Woven by Fate";
            bgmNames[176] = "";
            bgmNames[177] = "";
            bgmNames[178] = "";
            bgmNames[179] = "";
            bgmNames[180] = "";
            bgmNames[181] = "";
            bgmNames[182] = "";
            bgmNames[183] = "";
            bgmNames[184] = "";
            bgmNames[185] = "";
            bgmNames[186] = "";
            bgmNames[187] = "";
            bgmNames[188] = "";
            bgmNames[189] = "";
            bgmNames[190] = "";
            bgmNames[191] = "";
            bgmNames[192] = "";
            bgmNames[193] = "";
            bgmNames[194] = "";
            bgmNames[195] = "";
            bgmNames[196] = "";
            bgmNames[197] = "";
            bgmNames[198] = "";
            bgmNames[199] = "";
            bgmNames[200] = "";
            bgmNames[201] = "";
            miscItemNames[0] = "Insect Larva";
            miscItemNames[1] = "Minnow fillet";
            miscItemNames[2] = "Fresh insect larva";
            miscItemNames[3] = "Fresh minnow fillet";
            miscItemNames[4] = "Bristle worm";
            miscItemNames[5] = "Pond Snail";
            miscItemNames[6] = "Fresh bristle worm";
            miscItemNames[7] = "Premium Pond Snail";
            miscItemNames[8] = "Shrimp";
            miscItemNames[9] = "Fiddler Crab";
            miscItemNames[10] = "Earthworm";
            miscItemNames[11] = "Premium Shrimp";
            miscItemNames[12] = "Premium Fiddler Crab";
            miscItemNames[13] = "Premium Earthworm";
            miscItemNames[14] = "Pupa";
            miscItemNames[15] = "Grub";
            miscItemNames[16] = "Beetle";
            miscItemNames[17] = "Blowfly";
            miscItemNames[18] = "Premium Pupa";
            miscItemNames[19] = "Premium Grub";
            miscItemNames[20] = "Premium Beetle";
            miscItemNames[21] = "Premium Blowfly";
            miscItemNames[22] = "Squid Ball";
            miscItemNames[23] = "Herring Bait";
            miscItemNames[24] = "Bait 24";
            miscItemNames[25] = "Bait 25";
            miscItemNames[26] = "Bait 26";
            miscItemNames[27] = "Bait 27";
            miscItemNames[28] = "Bait 28";
            miscItemNames[29] = "Bait 29";
            miscItemNames[30] = "Tournament Bait";
            miscItemNames[31] = "Flayn's Bait";
            miscItemNames[32] = "Mixed Herb Seeds";
            miscItemNames[33] = "Western Fódlan Seeds";
            miscItemNames[34] = "Root Vegetable Seeds";
            miscItemNames[35] = "Magical Herb Seeds";
            miscItemNames[36] = "Noah-Fruit Seeds";
            miscItemNames[37] = "Albinean-Nut Seeds";
            miscItemNames[38] = "Vegetable Seeds";
            miscItemNames[39] = "Northern Fódlan Seeds";
            miscItemNames[40] = "Verona Seeds";
            miscItemNames[41] = "Morfis-Plum Seeds";
            miscItemNames[42] = "Southern Fódlan Seeds";
            miscItemNames[43] = "Morfis Seeds";
            miscItemNames[44] = "Nordsalat Seeds";
            miscItemNames[45] = "Boa-Fruit Seeds";
            miscItemNames[46] = "Albinean Seeds";
            miscItemNames[47] = "Eastern Fódlan Seeds";
            miscItemNames[48] = "Magdred Kirsch Seeds";
            miscItemNames[49] = "Angelica Seeds";
            miscItemNames[50] = "Mixed Fruit Seeds";
            miscItemNames[51] = "Albinean-Berry Seeds";
            miscItemNames[52] = "Red Flower Seeds";
            miscItemNames[53] = "White Flower Seeds";
            miscItemNames[54] = "Blue Flower Seeds";
            miscItemNames[55] = "Purple Flower Seeds";
            miscItemNames[56] = "Yellow Flower Seeds";
            miscItemNames[57] = "Green Flower Seeds";
            miscItemNames[58] = "Pale-Blue Flower Seeds";
            miscItemNames[59] = "seeds 27";
            miscItemNames[60] = "seeds 28";
            miscItemNames[61] = "seeds 29";
            miscItemNames[62] = "seeds 30";
            miscItemNames[63] = "Dedue's Seeds";
            miscItemNames[64] = "Smithing Stone";
            miscItemNames[65] = "Black-Sand Steel";
            miscItemNames[66] = "Wootz Steel";
            miscItemNames[67] = "Arcane Crystal";
            miscItemNames[68] = "Mythril";
            miscItemNames[69] = "Umbral Steel";
            miscItemNames[70] = "Agarthium";
            miscItemNames[71] = "Venomstone";
            miscItemNames[72] = "Ore 08";
            miscItemNames[73] = "Ore 09";
            miscItemNames[74] = "Ore 10";
            miscItemNames[75] = "Ore 11";
            miscItemNames[76] = "Ore 12";
            miscItemNames[77] = "Ore 13";
            miscItemNames[78] = "Ore 14";
            miscItemNames[79] = "Ore 15";
            miscItemNames[80] = "Ore 16";
            miscItemNames[81] = "Ore 17";
            miscItemNames[82] = "Ore 18";
            miscItemNames[83] = "Ore 19";
            miscItemNames[84] = "Ore 20";
            miscItemNames[85] = "Ore 21";
            miscItemNames[86] = "Ore 22";
            miscItemNames[87] = "Ore 23";
            miscItemNames[88] = "Ore 24";
            miscItemNames[89] = "Ore 25";
            miscItemNames[90] = "Ore 26";
            miscItemNames[91] = "Ore 27";
            miscItemNames[92] = "Ore 28";
            miscItemNames[93] = "Ore 29";
            miscItemNames[94] = "Ore 30";
            miscItemNames[95] = "tutorial ore";
            miscItemNames[96] = "Airmid Goby";
            miscItemNames[97] = "Caledonian Crayfish";
            miscItemNames[98] = "White Trout";
            miscItemNames[99] = "Teutates Loach";
            miscItemNames[100] = "Airmid Pike";
            miscItemNames[101] = "Caledonian Gar";
            miscItemNames[102] = "Queen Loach";
            miscItemNames[103] = "Ancient Gar";
            miscItemNames[104] = "Teutates Pike";
            miscItemNames[105] = "Teutates Shrimp";
            miscItemNames[106] = "Bullhead";
            miscItemNames[107] = "Albinean Herring";
            miscItemNames[108] = "Golden Fish";
            miscItemNames[109] = "Platinum Fish";
            miscItemNames[110] = "Fódlandy";
            miscItemNames[111] = "Goddess Messenger";
            miscItemNames[112] = "Silverfish";
            miscItemNames[113] = "Fish 17";
            miscItemNames[114] = "Fish 18";
            miscItemNames[115] = "Fish 19";
            miscItemNames[116] = "Fish 20";
            miscItemNames[117] = "Fish 21";
            miscItemNames[118] = "Fish 22";
            miscItemNames[119] = "Fish 23";
            miscItemNames[120] = "Fish 24";
            miscItemNames[121] = "Fish 25";
            miscItemNames[122] = "Fish 26";
            miscItemNames[123] = "Fish 27";
            miscItemNames[124] = "Fish 28";
            miscItemNames[125] = "Fish 29";
            miscItemNames[126] = "Fish 30";
            miscItemNames[127] = "Carassius";
            miscItemNames[128] = "Corn";
            miscItemNames[129] = "Apple";
            miscItemNames[130] = "Sugar Cane";
            miscItemNames[131] = "Barley";
            miscItemNames[132] = "Weeds";
            miscItemNames[133] = "Zanado Fruit";
            miscItemNames[134] = "Dried Vegetables";
            miscItemNames[135] = "Ailell Grass";
            miscItemNames[136] = "Zanado Treasure Fruit";
            miscItemNames[137] = "Tomato";
            miscItemNames[138] = "Noa Fruit";
            miscItemNames[139] = "Peach Currant";
            miscItemNames[140] = "Verona";
            miscItemNames[141] = "Morfis Plum";
            miscItemNames[142] = "Nordsalat";
            miscItemNames[143] = "Boa Fruit";
            miscItemNames[144] = "Magdred Kirsch";
            miscItemNames[145] = "Angelica";
            miscItemNames[146] = "Albinean Berries";
            miscItemNames[147] = "Onion";
            miscItemNames[148] = "Carrot";
            miscItemNames[149] = "Turnip";
            miscItemNames[150] = "Chickpeas";
            miscItemNames[151] = "Cabbage";
            miscItemNames[152] = "Crops 24";
            miscItemNames[153] = "Crops 25";
            miscItemNames[154] = "Crops 26";
            miscItemNames[155] = "Crops 27";
            miscItemNames[156] = "Crops 28";
            miscItemNames[157] = "Crops 29";
            miscItemNames[158] = "Crops 30";
            miscItemNames[159] = "Starter Vegetable";
            miscItemNames[160] = "Poultry";
            miscItemNames[161] = "Rabbit";
            miscItemNames[162] = "Fódlan Pheasant";
            miscItemNames[163] = "Gronder Fox";
            miscItemNames[164] = "Wild Game";
            miscItemNames[165] = "Boar";
            miscItemNames[166] = "Grouse";
            miscItemNames[167] = "Duscur Bear";
            miscItemNames[168] = "Oghma Wolverine";
            miscItemNames[169] = "Albinean Moose";
            miscItemNames[170] = "Rabbit";
            miscItemNames[171] = "Gronder Fox";
            miscItemNames[172] = "Fódlan Pheasant";
            miscItemNames[173] = "Meat 13";
            miscItemNames[174] = "Meat 14";
            miscItemNames[175] = "Meat 15";
            miscItemNames[176] = "Meat 16";
            miscItemNames[177] = "Meat 17";
            miscItemNames[178] = "Meat 18";
            miscItemNames[179] = "Meat 19";
            miscItemNames[180] = "Meat 20";
            miscItemNames[181] = "Meat 21";
            miscItemNames[182] = "Meat 22";
            miscItemNames[183] = "Meat 23";
            miscItemNames[184] = "Meat 24";
            miscItemNames[185] = "Meat 25";
            miscItemNames[186] = "Meat 26";
            miscItemNames[187] = "Meat 27";
            miscItemNames[188] = "Meat 28";
            miscItemNames[189] = "Meat 29";
            miscItemNames[190] = "Meat 30";
            miscItemNames[191] = "Starter Meat";
            miscItemNames[192] = "Bergamot";
            miscItemNames[193] = "Sweet-Apple Blend";
            miscItemNames[194] = "Almyran Pine Needles";
            miscItemNames[195] = "Albinean Berry Blend";
            miscItemNames[196] = "Southern Fruit Blend";
            miscItemNames[197] = "Rose Petal Blend";
            miscItemNames[198] = "Mint Leaves";
            miscItemNames[199] = "Crescent-Moon Tea";
            miscItemNames[200] = "Dagda Fruit Blend";
            miscItemNames[201] = "Almond Blend";
            miscItemNames[202] = "Honeyed-Fruit Blend";
            miscItemNames[203] = "Cinnamon Blend";
            miscItemNames[204] = "Seiros Tea";
            miscItemNames[205] = "Four-Spice Blend";
            miscItemNames[206] = "Ginger Tea";
            miscItemNames[207] = "Angelica Tea";
            miscItemNames[208] = "Lavender Blend";
            miscItemNames[209] = "Chamomile";
            miscItemNames[210] = "Hresvelg Blend";
            miscItemNames[211] = "Leicester Cortania";
            miscItemNames[212] = "Tea of the Saints";
            miscItemNames[213] = "Tea Leaves 22";
            miscItemNames[214] = "Tea Leaves 23";
            miscItemNames[215] = "Tea Leaves 24";
            miscItemNames[216] = "Tea Leaves 25";
            miscItemNames[217] = "Tea Leaves 26";
            miscItemNames[218] = "Tea Leaves 27";
            miscItemNames[219] = "Tea Leaves 28";
            miscItemNames[220] = "Tea Leaves 29";
            miscItemNames[221] = "Tea Leaves 30";
            miscItemNames[222] = "Tea Leaves 31";
            dinnerNames[0] = "Beast Meat Teppanyaki";
            dinnerNames[1] = "Grilled Herring";
            dinnerNames[2] = "Saghert and Cream";
            dinnerNames[3] = "Fish and Bean Soup";
            dinnerNames[4] = "Vegetable Pasta Salad";
            dinnerNames[5] = "Small Fish Skewers";
            dinnerNames[6] = "Sautéed Jerky";
            dinnerNames[7] = "Spicy Fish and Turnip Stew";
            dinnerNames[8] = "Onion Gratin Soup";
            dinnerNames[9] = "Sweet and Salty Whitefish Sauté";
            dinnerNames[10] = "Sweet Bun Trio";
            dinnerNames[11] = "Fruit and Herring Tart";
            dinnerNames[12] = "Garreg Mach Meat Pie";
            dinnerNames[13] = "Fisherman's Bounty";
            dinnerNames[14] = "Pheasant Roast with Berry Sauce";
            dinnerNames[15] = "Cheesy Verona Stew";
            dinnerNames[16] = "Fish Sandwich";
            dinnerNames[17] = "Pickled Rabbit Skewers";
            dinnerNames[18] = "Country-Style Red Turnip Plate";
            dinnerNames[19] = "Super-Spicy Fish Dango";
            dinnerNames[20] = "Peach Sorbet";
            dinnerNames[21] = "Pickled Seafood and Vegetables";
            dinnerNames[22] = "Two-Fish Sauté";
            dinnerNames[23] = "Daphnel Stew";
            dinnerNames[24] = "Gronder Meat Skewers";
            dinnerNames[25] = "Sautéed Pheasant and Eggs";
            dinnerNames[26] = "Gautier Cheese Gratin";
            dinnerNames[27] = "Cabbage and Herring Stew";
            dinnerNames[28] = "Vegetable Stir-Fry";
            dinnerNames[29] = "Bourgeois Pike";
            dinnerNames[30] = "Fried Crayfish";
            dinnerNames[31] = "Derdriu-Style Fried Pheasant";
            itemTypeIdOffsets[0] = 10; //Weapons
            itemTypeIdOffsets[1] = 600; //Equipment
            itemTypeIdOffsets[2] = 1000; //Items
            itemTypeIdOffsets[3] = 1400; //Misc Items
            itemTypeIdOffsets[4] = 2000; //Gifts, Lost Items, Quest Items
            itemFunctionGroups[0] = new int[] { 1, 6, 7, 8, 9, 10, 11, 34, 45, 46, 47, 51, 53, 55, 56, 57, 58, 59, 60, 61, 62, 80, 81, 83, 84, 88, 94, 95, 96, 97, 98, 118, 119, 120, 121,
                122, 123, 146, 157, 158, 159, 163, 165, 167, 168, 175, 181, 182, 183 }; //Swords
            itemFunctionGroups[1] = new int[] { 2, 12, 13, 14, 15, 16, 17, 37, 38, 39, 49, 54, 63, 64, 65, 66, 67, 68, 69, 85, 89, 99, 100, 101, 102, 103, 124, 125, 126, 127, 129, 149, 150,
                151, 161, 166, 169, 170, 176, 184, 185, 186 }; //Lances
            itemFunctionGroups[2] = new int[] { 3, 18, 19, 20, 21, 22, 23, 35, 40, 41, 42, 48, 52, 70, 71, 72, 73, 79, 82, 86, 90, 104, 105, 106, 107, 108, 130, 131, 132, 133, 134, 135, 147,
                152, 153, 154, 160, 164, 171, 174, 177, 187, 188 }; //Axes
            itemFunctionGroups[3] = new int[] { 4, 24, 25, 26, 27, 28, 29, 36, 43, 44, 50, 74, 75, 76, 77, 87, 91, 109, 110, 111, 112, 113, 136, 137, 138, 139, 140, 141, 148, 155, 156, 162,
                172, 178, 189 }; //Bows
            itemFunctionGroups[4] = new int[] { 5, 30, 31, 32, 33, 34, 35, 78, 92, 93, 114, 115, 116, 117, 142, 143, 144, 145, 173, 179, 180, 190 }; //Gauntlets
            itemFunctionGroups[5] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 32 }; //Shields
            itemFunctionGroups[6] = new int[] { 12, 13, 14, 15, 16, 17, 18, 37, 38, 39, 40, 42 }; //Rings
            itemFunctionGroups[7] = new int[] { 19, 20, 21, 22, 26, 27, 31, 33 }; //Staffs
            itemFunctionGroups[8] = new int[] { 23, 24, 25, 34, 41 }; //Gems
            itemFunctionGroups[9] = new int[] { 0, 1, 2, 7, 11, 12 }; //Battle Items
            itemFunctionGroups[10] = new int[] { 3, 4, 6, 157, 158, 159 }; //Certification Seals
            itemFunctionGroups[11] = new int[] { 8, 9, 10, 161 }; //Bullions
            itemFunctionGroups[12] = new int[] { 13, 14, 15 }; //Keys
            itemFunctionGroups[13] = new int[] { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 51, 52, 53, 54, 148, 149, 150, 151, 152, 153, 154, 155, 156 }; //Stat Boosters
            itemFunctionGroups[14] = new int[] { 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 145, 146 }; //Crest Signs
            itemFunctionGroups[15] = new int[] { 0, 5, 10, 17, 23 }; //Baits
            itemFunctionGroups[16] = new int[] { 32, 33, 34, 38, 39, 41, 42, 43, 44, 45, 46, 47, 49, 50, 52, 53, 54, 55, 56, 57, 58 }; //Seeds
            itemFunctionGroups[17] = new int[] { 64, 65, 66, 67, 68, 69, 70, 71 }; //Ores
            itemFunctionGroups[18] = new int[] { 96, 97, 98, 99, 100, 101, 102, 104, 106, 107, 108, 109, 110, 111, 112 }; //Fish
            itemFunctionGroups[19] = new int[] { 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151 }; //Crops
            itemFunctionGroups[20] = new int[] { 160, 164, 167, 168, 169 }; //Meats
            itemFunctionGroups[21] = new int[] { 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212 }; //Tea Leaves
            itemFunctionGroups[22] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 197, 198, 199, 200, 201, 202, 203, 204, 205,
                    206, 207, 208}; //Gifts
            itemNames[0] = "Vulnerary";
            itemNames[1] = "Concoction";
            itemNames[2] = "Elixir";
            itemNames[3] = "Intermediate Seal";
            itemNames[4] = "Advanced Seal";
            itemNames[5] = "Combined Seal";
            itemNames[6] = "Master Seal";
            itemNames[7] = "Torch";
            itemNames[8] = "Bullion";
            itemNames[9] = "Large Bullion";
            itemNames[10] = "Extra Large Bullion";
            itemNames[11] = "Antitoxin";
            itemNames[12] = "Pure Water";
            itemNames[13] = "Door Key";
            itemNames[14] = "Chest Key";
            itemNames[15] = "Master Key";
            itemNames[16] = "Seraph Robe";
            itemNames[17] = "Energy Drop";
            itemNames[18] = "Spirit Dust";
            itemNames[19] = "Secret Book";
            itemNames[20] = "Speedwing";
            itemNames[21] = "Goddess Icon";
            itemNames[22] = "Giant Shell";
            itemNames[23] = "Talisman";
            itemNames[24] = "Black Pearl";
            itemNames[25] = "Shoes of the Wind";
            itemNames[26] = "Grilled Duck";
            itemNames[27] = "Fried Boar";
            itemNames[28] = "Magical Herb Salad";
            itemNames[29] = "Dried Plums";
            itemNames[30] = "Pike Casserole";
            itemNames[31] = "Bear & Vegetable Soup";
            itemNames[32] = "Fried Gar";
            itemNames[33] = "Fried Queen Koi";
            itemNames[34] = "Sculpin Gratin";
            itemNames[35] = "Grilled Wolverine & Herbs";
            itemNames[36] = "Grilled Duck +";
            itemNames[37] = "Fried Boar +";
            itemNames[38] = "Magical Herb Salad +";
            itemNames[39] = "Dried Plums +";
            itemNames[40] = "Pike Casserole +";
            itemNames[41] = "Bear & Vegetable Soup +";
            itemNames[42] = "Fried Gar +";
            itemNames[43] = "Fried Queen Koi +";
            itemNames[44] = "Sculpin Gratin +";
            itemNames[45] = "Grilled Wolverine & Herbs +";
            itemNames[46] = "Albinea Juice";
            itemNames[47] = "Grilled Chicken & Herbs";
            itemNames[48] = "Roast Duck";
            itemNames[49] = "Grilled Chicken & Herbs +";
            itemNames[50] = "Roast Duck +";
            itemNames[51] = "Sacred Galewind Shoes";
            itemNames[52] = "Sacred Floral Robe";
            itemNames[53] = "Sacred Snowmelt Drop";
            itemNames[54] = "Sacred Moonstone";
            itemNames[55] = "0";
            itemNames[56] = "0";
            itemNames[57] = "0";
            itemNames[58] = "0";
            itemNames[59] = "0";
            itemNames[60] = "0";
            itemNames[61] = "0";
            itemNames[62] = "0";
            itemNames[63] = "0";
            itemNames[64] = "0";
            itemNames[65] = "0";
            itemNames[66] = "0";
            itemNames[67] = "0";
            itemNames[68] = "0";
            itemNames[69] = "0";
            itemNames[70] = "0";
            itemNames[71] = "0";
            itemNames[72] = "0";
            itemNames[73] = "0";
            itemNames[74] = "0";
            itemNames[75] = "0";
            itemNames[76] = "0";
            itemNames[77] = "0";
            itemNames[78] = "0";
            itemNames[79] = "0";
            itemNames[80] = "0";
            itemNames[81] = "0";
            itemNames[82] = "0";
            itemNames[83] = "0";
            itemNames[84] = "0";
            itemNames[85] = "0";
            itemNames[86] = "0";
            itemNames[87] = "0";
            itemNames[88] = "0";
            itemNames[89] = "Dish 63";
            itemNames[90] = "Dish 64";
            itemNames[91] = "Dish 65";
            itemNames[92] = "Dish 66";
            itemNames[93] = "Dish 67";
            itemNames[94] = "Dish 68";
            itemNames[95] = "Dish 69";
            itemNames[96] = "Dish 70";
            itemNames[97] = "Dish 71";
            itemNames[98] = "Dish 72";
            itemNames[99] = "Dish 73";
            itemNames[100] = "Dish 74";
            itemNames[101] = "Dish 75";
            itemNames[102] = "Dish 76";
            itemNames[103] = "Dish 77";
            itemNames[104] = "Dish 78";
            itemNames[105] = "Dish 79";
            itemNames[106] = "Dish 80";
            itemNames[107] = "Dish 81";
            itemNames[108] = "Dish 82";
            itemNames[109] = "Dish 83";
            itemNames[110] = "Dish 84";
            itemNames[111] = "Dish 85";
            itemNames[112] = "Dish 86";
            itemNames[113] = "Dish 87";
            itemNames[114] = "Dish 88";
            itemNames[115] = "Dish 89";
            itemNames[116] = "Dish 90";
            itemNames[117] = "Dish 91";
            itemNames[118] = "Dish 92";
            itemNames[119] = "Dish 93";
            itemNames[120] = "Dish 94";
            itemNames[121] = "Dish 95";
            itemNames[122] = "Dish 96";
            itemNames[123] = "Dish 97";
            itemNames[124] = "Dish 98";
            itemNames[125] = "Dish 99";
            itemNames[126] = "Thorn Dragon Sign";
            itemNames[127] = "Wind Dragon Sign";
            itemNames[128] = "Sky Dragon Sign";
            itemNames[129] = "Crusher Dragon Sign";
            itemNames[130] = "Shield Dragon Sign";
            itemNames[131] = "Bloom Dragon Sign";
            itemNames[132] = "Light Dragon Sign";
            itemNames[133] = "Flame Dragon Sign";
            itemNames[134] = "Grim Dragon Sign";
            itemNames[135] = "Craft Dragon Sign";
            itemNames[136] = "Kalpa Dragon Sign";
            itemNames[137] = "Earth Dragon Sign";
            itemNames[138] = "Ice Dragon Sign";
            itemNames[139] = "Fissure Dragon Sign";
            itemNames[140] = "Water Dragon Sign";
            itemNames[141] = "Storm Dragon Sign";
            itemNames[142] = "Lightning Dragon Sign";
            itemNames[143] = "Dark Dragon Sign";
            itemNames[144] = "Star Dragon Sign";
            itemNames[145] = "Snow Dragon Sign";
            itemNames[146] = "Aegis Dragon Sign";
            itemNames[147] = "Crest Stone";
            itemNames[148] = "Rocky Burdock";
            itemNames[149] = "Premium Magic Herbs";
            itemNames[150] = "Ailell Pomegranate";
            itemNames[151] = "Speed Carrot";
            itemNames[152] = "Miracle Bean";
            itemNames[153] = "Ambrosia";
            itemNames[154] = "White Verona";
            itemNames[155] = "Golden Apple";
            itemNames[156] = "Fruit of Life";
            itemNames[157] = "Dark Seal";
            itemNames[158] = "Beginner Seal";
            itemNames[159] = "Abyssian Exam Pass";
            itemNames[160] = "Spellbreak Key";
            itemNames[161] = "Trade Secret";
            giftNames[0] = "Floral Adornment";
            giftNames[1] = "Fishing Float";
            giftNames[2] = "Tasty Baked Treat";
            giftNames[3] = "Gemstone Beads";
            giftNames[4] = "Smoked Meat";
            giftNames[5] = "Armored Bear Stuffy";
            giftNames[6] = "Training Weight";
            giftNames[7] = "Book of Sheet Music";
            giftNames[8] = "Hunting Dagger";
            giftNames[9] = "Arithmetic Textbook";
            giftNames[10] = "The History of Fódlan";
            giftNames[11] = "Watering Can";
            giftNames[12] = "Riding Boots";
            giftNames[13] = "Whetstone";
            giftNames[14] = "Tea Leaves";
            giftNames[15] = "Book of Crest Designs";
            giftNames[16] = "Stylish Hair Clip";
            giftNames[17] = "Legends of Chivalry";
            giftNames[18] = "Monarch Studies Book";
            giftNames[19] = "Dapper Handkerchief";
            giftNames[20] = "Owl Feather";
            giftNames[21] = "Blue Cheese";
            giftNames[22] = "Landscape Painting";
            giftNames[23] = "Exotic Spices";
            giftNames[24] = "Goddess Statuette";
            giftNames[25] = "Ceremonial Sword";
            giftNames[26] = "Ancient Coin";
            giftNames[27] = "Board Game";
            giftNames[28] = "Coffee Beans";
            giftNames[29] = "Crestological Mysteries";
            giftNames[30] = "Tome of Comely Saints";
            giftNames[31] = "Fire Amulet";
            giftNames[32] = "Glowing Stone";
            giftNames[33] = "The Path of Dawn";
            giftNames[34] = "Medicinal Eyedrops";
            giftNames[35] = "Two-Toned Whetstone";
            giftNames[36] = "Catherine's Dagger";
            giftNames[37] = "Shamir's Quiver";
            giftNames[38] = "White Glove";
            giftNames[39] = "Dulled Longsword";
            giftNames[40] = "Leather Bow Sheath";
            giftNames[41] = "Hresvelg Treatise";
            giftNames[42] = "Maintenance Oil";
            giftNames[43] = "The Saints Revealed";
            giftNames[44] = "Thunderbrand Replica";
            giftNames[45] = "Needle and Thread";
            giftNames[46] = "Silver Brooch";
            giftNames[47] = "Exotic Feather";
            giftNames[48] = "Gold Earring";
            giftNames[49] = "Black Iron Spur";
            giftNames[50] = "Moon Knight's Tale";
            giftNames[51] = "Unused Lipstick";
            giftNames[52] = "Book of Ghost Stories";
            giftNames[53] = "Unfinished Score";
            giftNames[54] = "Pegasus Horseshoes";
            giftNames[55] = "Artificial Flower";
            giftNames[56] = "Wooden Button";
            giftNames[57] = "Blue Stone";
            giftNames[58] = "Encyclopedia of Sweets";
            giftNames[59] = "Bag of Seeds";
            giftNames[60] = "Handmade Hair Clip";
            giftNames[61] = "Hand Drawn Map";
            giftNames[62] = "Unfinished Fable";
            giftNames[63] = "Antique Clasp";
            giftNames[64] = "Lens Cloth";
            giftNames[65] = "Wellness Herbs";
            giftNames[66] = "Noseless Puppet";
            giftNames[67] = "Introduction to Magic";
            giftNames[68] = "Weathered Cloak";
            giftNames[69] = "Bundle of Dry Hemp";
            giftNames[70] = "Well-Used Hatchet";
            giftNames[71] = "Wooden Flask";
            giftNames[72] = "Elegant Hair Clip";
            giftNames[73] = "Saint Cethleann Shard";
            giftNames[74] = "Saint Cichol Shard";
            giftNames[75] = "Saint Macuil Shard";
            giftNames[76] = "Saint Indech Shard";
            giftNames[77] = "Classic Cookbook";
            giftNames[78] = "Choir Sign Up Sheet";
            giftNames[79] = "Choir Sign Up Sheet";
            giftNames[80] = "Choir Sign Up Sheet";
            giftNames[81] = "Unlock Trade";
            giftNames[82] = "Elegant Tea Set";
            giftNames[83] = "Unlock Report Cards";
            giftNames[84] = "Unlock Report Cards";
            giftNames[85] = "Unlock Report Cards";
            giftNames[86] = "Dissidents Intel";
            giftNames[87] = "Thieves Intel";
            giftNames[88] = "Imperial Army Intel";
            giftNames[89] = "Admiring Love Letter";
            giftNames[90] = "Heartfelt Love Letter";
            giftNames[91] = "Reverent Love Letter";
            giftNames[92] = "Enlightening Herbs";
            giftNames[93] = "Bravery Herbs";
            giftNames[94] = "Fortifying Herbs";
            giftNames[95] = "Calming Herbs";
            giftNames[96] = "Confidence Herbs";
            giftNames[97] = "Hopeful Herbs";
            giftNames[98] = "Missing Student Poster";
            giftNames[99] = "Floral Tribute";
            giftNames[100] = "Tantalizing Cookbook";
            giftNames[101] = "Illustrated Cookbook";
            giftNames[102] = "Black Eagle Note";
            giftNames[103] = "Blue Lion Note";
            giftNames[104] = "Golden Deer Note";
            giftNames[105] = "Sheet Music (Spring)";
            giftNames[106] = "Sheet Music (Summer)";
            giftNames[107] = "Sheet Music (Fall)";
            giftNames[108] = "Sheet Music (Winter)";
            giftNames[109] = "Tiny Fódlan Carp";
            giftNames[110] = "Small Fódlan Carp";
            giftNames[111] = "Regular Fódlan Carp";
            giftNames[112] = "Large Fódlan Carp";
            giftNames[113] = "Huge Fódlan Carp";
            giftNames[114] = "Teutates Herring";
            giftNames[115] = "Iron Welding Material";
            giftNames[116] = "Investigation Note #1";
            giftNames[117] = "Investigation Note #2";
            giftNames[118] = "Investigation Note #3";
            giftNames[119] = "Investigation Note #4";
            giftNames[120] = "Investigation Note #5";
            giftNames[121] = "Investigation Note #6";
            giftNames[122] = "Investigation Note #7";
            giftNames[123] = "Noxious Handkerchief";
            giftNames[124] = "Agricultural Survey";
            giftNames[125] = "Feather Pillow";
            giftNames[126] = "Tattered Overcoat";
            giftNames[127] = "Still-Life Picture";
            giftNames[128] = "Songstress Poster";
            giftNames[129] = "Small Tanned Hide";
            giftNames[130] = "Gardening Shears";
            giftNames[131] = "Sword Belt Fragment";
            giftNames[132] = "Evil-Repelling Amulet";
            giftNames[133] = "Crumpled Love Letter";
            giftNames[134] = "Fruit Preserves";
            giftNames[135] = "School of Sorcery Book";
            giftNames[136] = "Jousting Almanac";
            giftNames[137] = "A Treatise on Etiquette";
            giftNames[138] = "Burlap Sack of Rocks";
            giftNames[139] = "Art Book";
            giftNames[140] = "Princess Doll";
            giftNames[141] = "How to be Tidy";
            giftNames[142] = "Spotless Bandage";
            giftNames[143] = "Crude Arrowheads";
            giftNames[144] = "Old Fishing Rod";
            giftNames[145] = "Old Map of Enbarr";
            giftNames[146] = "Hammer and Chisel";
            giftNames[147] = "Clean Dusting Cloth";
            giftNames[148] = "Carving Hammer";
            giftNames[149] = "Foreign Gold Coin";
            giftNames[150] = "Letter to Rhea";
            giftNames[151] = "Centipede Picture";
            giftNames[152] = "Portrait of Rhea";
            giftNames[153] = "Folding Razor";
            giftNames[154] = "Bag of Tea Leaves";
            giftNames[155] = "Animated Bait";
            giftNames[156] = "Grounding Charm";
            giftNames[157] = "Hedgehog Case";
            giftNames[158] = "Lovely Comb";
            giftNames[159] = "Annotated Dictionary";
            giftNames[160] = "Iron Cooking Pot";
            giftNames[161] = "Toothed Dagger";
            giftNames[162] = "Bundle of Herbs";
            giftNames[163] = "The History of Sreng";
            giftNames[164] = "How to Bake Sweets";
            giftNames[165] = "Wax Diptych";
            giftNames[166] = "Curry Comb";
            giftNames[167] = "Silk Handkerchief";
            giftNames[168] = "Big Spoon";
            giftNames[169] = "Letter to the Goddess";
            giftNames[170] = "New Bottle of Perfume";
            giftNames[171] = "Confessional Letter";
            giftNames[172] = "Used Bottle of Perfume";
            giftNames[173] = "Fur Scarf";
            giftNames[174] = "Snapped Writing Quill";
            giftNames[175] = "Dusty Book of Fables";
            giftNames[176] = "Sketch of a Sigil";
            giftNames[177] = "Light Purple Veil";
            giftNames[178] = "Silver Necklace";
            giftNames[179] = "Mysterious Notebook";
            giftNames[180] = "Badge of Graduation";
            giftNames[181] = "Animal Bone Dice";
            giftNames[182] = "Old Cleaning Cloth";
            giftNames[183] = "Birthing Herbs";
            giftNames[184] = "Brigid Techniques";
            giftNames[185] = "Seiros Scriptures";
            giftNames[186] = "Faded Star Chart";
            giftNames[187] = "Growing a Garden";
            giftNames[188] = "Orange";
            giftNames[189] = "Lavandula grass";
            giftNames[190] = "The Big One";
            giftNames[191] = "Cornerstone Fragment";
            giftNames[192] = "Zoltan's Beast Idol";
            giftNames[193] = "Gladiolus";
            giftNames[194] = "Gladiolus";
            giftNames[195] = "Gladiolus";
            giftNames[196] = "Anna's Secret Thingy";
            giftNames[197] = "Pitcher Plant";
            giftNames[198] = "Sunflower";
            giftNames[199] = "Violet";
            giftNames[200] = "Lavender";
            giftNames[201] = "Daffodil";
            giftNames[202] = "Rose";
            giftNames[203] = "Forget-me-nots";
            giftNames[204] = "Lily";
            giftNames[205] = "Lily of the Valley";
            giftNames[206] = "Baby's Breath";
            giftNames[207] = "Anemone";
            giftNames[208] = "Carnation";
            giftNames[209] = "Tactics Primer";
            giftNames[210] = "Time-worn Quill Pen";
            giftNames[211] = "Black Leather Gloves";
            giftNames[212] = "MildÂ Stomach Poison";
            giftNames[213] = "Eastern Porcelain";
            giftNames[214] = "Training Logbook";
            giftNames[215] = "Board Game Piece";
            giftNames[216] = "Letter From Edelgard";
            giftNames[217] = "Letter From Edelgard";
            giftNames[218] = "Letter From Dimitri";
            giftNames[219] = "Letter From Dimitri";
            giftNames[220] = "Letter From Claude";
            giftNames[221] = "Letter From Claude";
            giftNames[222] = "Letter From Rhea";
            giftNames[223] = "Letter From Flayn";
            giftNames[224] = "Letter From Gilbert";
            giftNames[225] = "Jar of Sweets";
            giftNames[226] = "Black Hair Tie";
            giftNames[227] = "Armor Clasp";
            giftNames[228] = "Secret Ledger";
            giftNames[229] = "Balance Scale";
            giftNames[230] = "Rare Item Index";
            giftNames[231] = "Abyss Information";
            giftNames[232] = "Servant's Supplies";
            giftNames[233] = "List of Rare Books";
            giftNames[234] = "Valerian";
            giftNames[235] = "The Wealth of Anna";
            giftNames[236] = "Makeup Brush";
            giftNames[237] = "Suspicious Dice";
            giftNames[238] = "Well-Worn Hammock";
            giftNames[239] = "Stiff Hand Wrap";
            giftNames[240] = "Nimbus Charm";
            giftNames[241] = "Repellent Powder";
            giftNames[242] = "Shiny Striated Pebble";
            giftNames[243] = "Basket of Berries";
            equipmentNames[0] = "Leather Shield";
            equipmentNames[1] = "Iron Shield";
            equipmentNames[2] = "Steel Shield";
            equipmentNames[3] = "Silver Shield";
            equipmentNames[4] = "Talisman Shield";
            equipmentNames[5] = "Hexlock Shield";
            equipmentNames[6] = "Aegis Shield";
            equipmentNames[7] = "Ochain Shield";
            equipmentNames[8] = "Seiros Shield";
            equipmentNames[9] = "Aurora Shield";
            equipmentNames[10] = "Kadmos Shield";
            equipmentNames[11] = "Lampos Shield";
            equipmentNames[12] = "Accuracy Ring";
            equipmentNames[13] = "Critical Ring";
            equipmentNames[14] = "Evasion Ring";
            equipmentNames[15] = "Speed Ring";
            equipmentNames[16] = "March Ring";
            equipmentNames[17] = "Goddess Ring";
            equipmentNames[18] = "Prayer Ring";
            equipmentNames[19] = "Magic Staff";
            equipmentNames[20] = "Healing Staff";
            equipmentNames[21] = "Caduceus Staff";
            equipmentNames[22] = "Thyrsus";
            equipmentNames[23] = "Rafail Gem";
            equipmentNames[24] = "Experience Gem";
            equipmentNames[25] = "Knowledge Gem";
            equipmentNames[26] = "Circe Staff";
            equipmentNames[27] = "Tomas's Staff";
            equipmentNames[28] = "Armored Soldier Shield";
            equipmentNames[29] = "Armored Knight Shield";
            equipmentNames[30] = "Fortress Soldier Shield";
            equipmentNames[31] = "Asclepius";
            equipmentNames[32] = "Dark Aegis Shield";
            equipmentNames[33] = "Dark Thyrsus";
            equipmentNames[34] = "Dark Rafail Gem";
            equipmentNames[35] = "Flame Shield";
            equipmentNames[36] = "Emperor Shield";
            equipmentNames[37] = "Black Eagle Pendant";
            equipmentNames[38] = "Blue Lion Brooch";
            equipmentNames[39] = "Golden Deer Bracelet";
            equipmentNames[40] = "White Dragon Scarf";
            equipmentNames[41] = "Chalice of Beginnings";
            equipmentNames[42] = "Fetters of Dromi";
            generalItemNames[0] = weaponNames;
            generalItemNames[1] = equipmentNames;
            generalItemNames[2] = itemNames;
            generalItemNames[3] = miscItemNames;
            generalItemNames[4] = giftNames;
            scenarioNames[0] = "A Skirmish at Dawn";
            scenarioNames[1] = "Rivalry of the Houses";
            scenarioNames[2] = "Red Canyon Dominance";
            scenarioNames[3] = "The Magdred Ambush";
            scenarioNames[4] = "Assault at the Rite of Rebirth";
            scenarioNames[5] = "The Gautier Inheritance";
            scenarioNames[6] = "The Underground Chamber";
            scenarioNames[7] = "Battle of the Eagle and Lion";
            scenarioNames[8] = "The Remire Calamity";
            scenarioNames[9] = "Salvation at the Chapel";
            scenarioNames[10] = "The Sealed Forest Snare";
            scenarioNames[11] = "Conflict in the Holy Tomb";
            scenarioNames[12] = "The Battle of Garreg Mach";
            scenarioNames[13] = "Hunting by Daybreak";
            scenarioNames[14] = "Protecting Garreg Mach";
            scenarioNames[15] = "Ambush at Ailell";
            scenarioNames[16] = "The Great Bridge Coup";
            scenarioNames[17] = "To War at Gronder";
            scenarioNames[18] = "To War at Gronder";
            scenarioNames[19] = "Taking Fort Merceus";
            scenarioNames[20] = "Taking Fort Merceus";
            scenarioNames[21] = "Reclaiming the Capital";
            scenarioNames[22] = "The Enbarr Infiltration";
            scenarioNames[23] = "Saving Derdriu";
            scenarioNames[24] = "Confrontation at the Palace";
            scenarioNames[25] = "Taking Fort Merceus";
            scenarioNames[26] = "Stand Strong at Shambhala";
            scenarioNames[27] = "Assault on Enbarr";
            scenarioNames[28] = "The Final Battle";
            scenarioNames[29] = "For the Freedom of Fódlan";
            scenarioNames[30] = "Clash at the Imperial Capital";
            scenarioNames[31] = "The Battle of Garreg Mach";
            scenarioNames[32] = "The Great Bridge Coup";
            scenarioNames[33] = "Capturing Derdriu";
            scenarioNames[34] = "Protecting Garreg Mach";
            scenarioNames[35] = "The Siege of Arianrhod";
            scenarioNames[36] = "Combat at Tailtean Plains";
            scenarioNames[37] = "The Fight for Fhirdiad";
            scenarioNames[38] = "Eternal Guardian";
            scenarioNames[39] = "The Silver Maiden";
            scenarioNames[40] = "Insurmountable";
            scenarioNames[41] = "The Sleeping Sand Legend";
            scenarioNames[42] = "Tales of the Red Canyon";
            scenarioNames[43] = "War for the Weak";
            scenarioNames[44] = "True Chivalry";
            scenarioNames[45] = "Falling Short of Heaven";
            scenarioNames[46] = "The Forgotten";
            scenarioNames[47] = "The Face Beneath";
            scenarioNames[48] = "Weathervanes of Fódlan";
            scenarioNames[49] = "Rumored Nuptials";
            scenarioNames[50] = "Darkness Beneath the Earth";
            scenarioNames[51] = "Retribution";
            scenarioNames[52] = "Legend of the Lake";
            scenarioNames[53] = "Foreign Land and Sky";
            scenarioNames[54] = "Land of the Golden Deer";
            scenarioNames[55] = "Death Toll";
            scenarioNames[56] = "Forgotten Hero";
            scenarioNames[57] = "Dividing the World";
            scenarioNames[58] = "An Ocean View";
            scenarioNames[59] = "Oil and Water";
            scenarioNames[60] = "Sword and Shield of Seiros";
            scenarioNames[61] = "Battle in the Outskirts";
            scenarioNames[62] = "Battle in the Mountains";
            scenarioNames[63] = "Battle in the Empire";
            scenarioNames[64] = "Battle in the Kingdom";
            scenarioNames[65] = "Battle in the Desert";
            scenarioNames[66] = "Battle at Magdred Way";
            scenarioNames[67] = "Battle at the Border";
            scenarioNames[68] = "Battle on the Plateau";
            scenarioNames[69] = "Monsters on the Road";
            scenarioNames[70] = "Monsters in the Mountains";
            scenarioNames[71] = "Monsters in the Desert";
            scenarioNames[72] = "Battle at Gronder Field";
            scenarioNames[73] = "Monsters at Gronder Field";
            scenarioNames[74] = "Battle in the Ruins";
            scenarioNames[75] = "Monsters in the Ruins";
            scenarioNames[76] = "Monsters in the Red Canyon";
            scenarioNames[77] = "Bandits on the Rhodos Coast";
            scenarioNames[78] = "Western Church Suppression";
            scenarioNames[79] = "Battle in Ailell";
            scenarioNames[80] = "Monsters on the Plains";
            scenarioNames[81] = "Battle at Lake Teutates";
            scenarioNames[82] = "Battle in the Forest";
            scenarioNames[83] = "Battle in the Plains";
            scenarioNames[84] = "Battle at the Sealed Forest";
            scenarioNames[85] = "Battle at Conand Tower";
            scenarioNames[86] = "A Skirmish in Abyss";
            scenarioNames[87] = "Ambush in the Arena";
            scenarioNames[88] = "Search for the Chalice";
            scenarioNames[89] = "A Harrowing Escape";
            scenarioNames[90] = "Besieged in the Chapel Ruins";
            scenarioNames[91] = "The Rite of Rising";
            scenarioNames[92] = "A Beast in the Cathedral";
            scenarioNames[93] = "Black Market Scheme";
            scenarioNames[94] = "A Cursed Relic";
            scenarioNames[95] = "";
            scenarioNames[96] = "";
            scenarioNames[97] = "The Secret Merchant";
            scenarioNames[98] = "";
            scenarioNames[99] = "";
            scenarioNames[100] = "Practice Battle";
        }

        public static void randomizeTrue(Settings settings)
        {
            if (Randomizer.personLoaded)
            {
                Randomizer.personData = new byte[Randomizer.personDataV.Length];
                Randomizer.personDataV.CopyTo((Array)Randomizer.personData, 0);
            }
            Randomizer.randomize(settings);
        }

        public static void randomize(Settings settings)
        {
            /*
            if (data1Loaded) // replace all enemies with commanders
            {
                Randomizer.baiSectionData = new byte[Randomizer.baiSectionDataV.Length];
                Randomizer.baiSectionDataV.CopyTo((Array)Randomizer.baiSectionData, 0);

                List<byte[]> commanders = new List<byte[]>();

                for (int scenario = 0; scenario < baiOffsets.Length; scenario++)
                {
                    int baiStart = (int)(baiOffsets[scenario] - baiSectionOffset);
                    int headerLen = 24;

                    byte[] specialEntries = new byte[3];
                    specialEntries[0] = baiSectionData[baiStart + 4];
                    specialEntries[1] = baiSectionData[baiStart + 5];
                    specialEntries[2] = baiSectionData[baiStart + 6];

                    byte[] itemEntries = new byte[3];
                    itemEntries[0] = baiSectionData[baiStart + 7];
                    itemEntries[1] = baiSectionData[baiStart + 8];
                    itemEntries[2] = baiSectionData[baiStart + 9];

                    int[] routeStarts = new int[3];
                    routeStarts[0] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 12);
                    routeStarts[1] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 16);
                    routeStarts[2] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 20);

                    for (int route = 0; route < 3; route++)
                    {
                        int unitTableStart = routeStarts[route];
                        int specialTableStart = unitTableStart + baiUnitsLen * baiUnitEntries;
                        int itemTableStart = specialTableStart + baiSpecialsLen * specialEntries[route];

                        for (int unit = 0; unit < baiUnitEntries; unit++)
                        {
                            int unitStart = unitTableStart + unit * baiUnitsLen;

                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            if (characterShort != 0)
                            {
                                bool ally = baiSectionData[unitStart + 29] == 0;
                                bool enemy = baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3;
                                bool npc = baiSectionData[unitStart + 29] == 2;
                                bool com = baiSectionData[unitStart + 33] == 0 && enemy;
                                if (com)
                                {
                                    byte[] unitData = new byte[baiUnitsLen];
                                    for (int i = 0; i < baiUnitsLen; i++)
                                        unitData[i] = baiSectionData[unitStart + i];
                                    commanders.Add(unitData);
                                }
                            }
                        }
                    }
                }

                for (int scenario = 0; scenario < baiOffsets.Length; scenario++)
                {
                    int baiStart = (int)(baiOffsets[scenario] - baiSectionOffset);
                    int headerLen = 24;

                    byte[] specialEntries = new byte[3];
                    specialEntries[0] = baiSectionData[baiStart + 4];
                    specialEntries[1] = baiSectionData[baiStart + 5];
                    specialEntries[2] = baiSectionData[baiStart + 6];

                    byte[] itemEntries = new byte[3];
                    itemEntries[0] = baiSectionData[baiStart + 7];
                    itemEntries[1] = baiSectionData[baiStart + 8];
                    itemEntries[2] = baiSectionData[baiStart + 9];

                    int[] routeStarts = new int[3];
                    routeStarts[0] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 12);
                    routeStarts[1] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 16);
                    routeStarts[2] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 20);

                    for (int route = 0; route < 3; route++)
                    {
                        int unitTableStart = routeStarts[route];
                        int specialTableStart = unitTableStart + baiUnitsLen * baiUnitEntries;
                        int itemTableStart = specialTableStart + baiSpecialsLen * specialEntries[route];

                        List<byte[]> occupiedPositions = new List<byte[]>();

                        byte[] minAllyPos = { 255, 255 };
                        byte[] maxAllyPos = { 0, 0 };

                        byte[] minEnemyPos = { 255, 255 };
                        byte[] maxEnemyPos = { 0, 0 };

                        int unitTotal = 0;
                        int enemyTotal = 0;
                        for (int unit = 0; unit < baiUnitEntries; unit++)
                        {
                            int unitStart = unitTableStart + unit * baiUnitsLen;

                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            if (characterShort != 0)
                            {
                                bool ally = baiSectionData[unitStart + 29] == 0;
                                bool enemy = baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3;
                                bool npc = baiSectionData[unitStart + 29] == 2;
                                bool com = baiSectionData[unitStart + 33] == 0 && enemy;

                                unitTotal++;

                                occupiedPositions.Add(new byte[] { baiSectionData[unitStart + 25], baiSectionData[unitStart + 26] });

                                if (baiSectionData[unitStart + 29] == 0 || baiSectionData[unitStart + 29] == 2)
                                {
                                    minAllyPos[0] = Math.Min(minAllyPos[0], baiSectionData[unitStart + 25]);
                                    minAllyPos[1] = Math.Min(minAllyPos[1], baiSectionData[unitStart + 26]);
                                    maxAllyPos[0] = Math.Max(maxAllyPos[0], baiSectionData[unitStart + 25]);
                                    maxAllyPos[1] = Math.Max(maxAllyPos[1], baiSectionData[unitStart + 26]);
                                }

                                if (baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3)
                                {
                                    enemyTotal++;
                                    minEnemyPos[0] = Math.Min(minEnemyPos[0], baiSectionData[unitStart + 25]);
                                    minEnemyPos[1] = Math.Min(minEnemyPos[1], baiSectionData[unitStart + 26]);
                                    maxEnemyPos[0] = Math.Max(maxEnemyPos[0], baiSectionData[unitStart + 25]);
                                    maxEnemyPos[1] = Math.Max(maxEnemyPos[1], baiSectionData[unitStart + 26]);
                                }
                            }
                        }
                        for (int special = 0; special < specialEntries[route]; special++)
                        {
                            int specialStart = specialTableStart + special * baiSpecialsLen;
                            occupiedPositions.Add(new byte[] { baiSectionData[specialStart + 0], baiSectionData[specialStart + 1] });
                        }
                        for (int item = 0; item < itemEntries[route]; item++)
                        {
                            int itemStart = itemTableStart + item * baiItemsLen;
                            occupiedPositions.Add(new byte[] { baiSectionData[itemStart + 2], baiSectionData[itemStart + 3] });
                        }

                        List<byte[]> commanderQueue = new List<byte[]>();
                        for (int i = 0; i < commanders.Count; i++)
                            commanderQueue.Add(commanders[i]);
                        commanderQueue.Shuffle();

                        for (int i = 0; i < baiUnitEntries && commanderQueue.Count > 0; i++)
                        {
                            int unitStart = unitTableStart + baiUnitsLen * i;
                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            bool ally = baiSectionData[unitStart + 29] == 0;
                            bool enemy = baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3;
                            bool npc = baiSectionData[unitStart + 29] == 2;
                            bool com = baiSectionData[unitStart + 33] == 0 && enemy;

                            if (characterShort != 0 && (ally || npc))
                                continue;

                            if (characterShort != 0 && enemy)
                            {
                                byte[] newUnitData = commanderQueue[commanderQueue.Count - 1];
                                commanderQueue.RemoveAt(commanderQueue.Count - 1);

                                newUnitData[25] = baiSectionData[unitStart + 25];
                                newUnitData[26] = baiSectionData[unitStart + 26];
                                newUnitData[28] = baiSectionData[unitStart + 28];
                                newUnitData[29] = baiSectionData[unitStart + 29];
                                newUnitData[30] = baiSectionData[unitStart + 30];

                                for (int j = 0; j < baiUnitsLen; j++)
                                    baiSectionData[unitStart + j] = newUnitData[j]; // bosses
                            }
                        }
                    }
                }

                return;
            }
            */

            List<int> zeroClasses = new List<int>();
            List<int> begClasses = new List<int>();
            List<int> interClasses = new List<int>();
            List<int> advClasses = new List<int>();
            List<int> masterClasses = new List<int>();
            List<int> uniClasses = new List<int>();
            List<int> monsterClasses = new List<int>();

            List<int[][]> classCertReqs = new List<int[][]>();

            List<int>[] classWeaponTypes = new List<int>[100];

            List<int> eBattalions = new List<int>();
            List<int> dBattalions = new List<int>();
            List<int> cBattalions = new List<int>();
            List<int> bBattalions = new List<int>();
            List<int> aBattalions = new List<int>();

            int[][] availableArts = { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 40, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 68, 70, 75, 76, 77 },
                    new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 40, 50, 51, 52, 53, 54, 58, 59, 60, 66, 71, 77 },
                    new int[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 40, 50, 51, 52, 53, 54, 61, 62, 64, 66, 73, 74, 77 },
                    new int[] { 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 50, 51, 52, 53, 54, 63, 66, 67, 72, 77 },
                    new int[] { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 66, 69, 77, 78, 79 },
                    new int[] { 40, 50, 51, 52, 53, 54, 66, 77 } };

            // [weaponType][Rank][Weapon]
            int[][][] availableWeapons =
            {
                // Swords
                new int[][]
                {
                    // E
                    new int[] { 6, 11, 46, 118, 123, 158 },
                    // D
                    new int[] { 7, 45, 51, 119, 157, 163 },
                    // C
                    new int[] { 10, 34, 80, 81, 84, 122, 146, 175 },
                    // B
                    new int[] { 8, 9, 53, 58, 120, 121, 165, 167 },
                    // A
                    new int[] { 55, 56, 57, 59, 88, 168 },
                    // Relic
                    new int[] { 60, 61, 62, 83, 181, 182, 183 }
                },
                // Lances
                new int[][]
                {
                    // E
                    new int[] { 12, 17, 124, 129 },
                    // D
                    new int[] { 13, 37, 47, 125, 149, 159 },
                    // C
                    new int[] { 16, 38, 49, 69, 85, 128, 150, 161, 170, 176 },
                    // B
                    new int[] { 14, 15, 39, 54, 126, 127, 151, 166 },
                    // A
                    new int[] { 63, 67, 68, 89, 169 },
                    // Relic
                    new int[] { 64, 65, 66, 184, 185, 186 }
                },
                // Axes
                new int[][]
                {
                    // E
                    new int[] { 18, 23, 79, 130, 135, 174 },
                    // D
                    new int[] { 19, 40, 48, 52, 131, 152, 160, 164 },
                    // C
                    new int[] { 22, 41, 86, 134, 153, 177 },
                    // B
                    new int[] { 20, 21, 35, 42, 132, 133, 147, 154 },
                    // A
                    new int[] { 72, 73, 90, 171 },
                    // Relic
                    new int[] { 70, 71, 82, 187, 188 }
                },
                // Bows
                new int[][]
                {
                    // E
                    new int[] { 24, 29, 136, 141 },
                    // D
                    new int[] { 25, 44, 137, 156 },
                    // C
                    new int[] { 28, 43, 50, 87, 140, 155, 162, 178 },
                    // B
                    new int[] { 26, 27, 36, 138, 139, 148 },
                    // A
                    new int[] { 74, 75, 76, 91, 172 },
                    // Relic
                    new int[] { 77, 189 }
                },
                // Gauntlets
                new int[][]
                {
                    // E
                    new int[] { 30, 33, 142, 145 },
                    // D
                    new int[] { 31, 143 },
                    // C
                    new int[] { },
                    // B
                    new int[] { 32, 92, 144, 179 },
                    // A
                    new int[] { 78, 93, 173, 180 },
                    // Relic
                    new int[] { 190 }
                }
            };

            int[][] proficiencyArchive = new int[1201][];

            TextFormatter msgf = new TextBinFormatter();
            List<string> msgStrings = new List<string>();

            if (msgLoaded && settings.changeMsg)
            {
                Randomizer.msgData = new byte[Randomizer.msgDataV.Length];
                Randomizer.msgDataV.CopyTo((Array)Randomizer.msgData, 0);
                msgf = new TextBinFormatter(msgData);
                msgStrings = msgf.getStrings(true);
            }

            TextFormatter scrf = new TextBinFormatter();
            List<string> scrStrings = new List<string>();

            if (scrLoaded && settings.changeScr)
            {
                Randomizer.scrData = new byte[Randomizer.scrDataV.Length];
                Randomizer.scrDataV.CopyTo((Array)Randomizer.scrData, 0);
                scrf = new TextBinFormatter(scrData);
                scrStrings = scrf.getStrings(true);
            }

            if (actLoaded)
            {
                Randomizer.actData = new byte[Randomizer.actDataV.Length];
                Randomizer.actDataV.CopyTo((Array)Randomizer.actData, 0);

                //[animationSet][weaponType][animations]
                List<List<List<int>>> battleAnimations = new List<List<List<int>>>();
                battleAnimations.Add(new List<List<int>>());
                battleAnimations[0].Add(new List<int>()); // Infantry sword animations:
                battleAnimations[0][0].Add(124);
                battleAnimations[0][0].Add(126);
                battleAnimations[0][0].Add(127);
                battleAnimations[0][0].Add(128);
                battleAnimations[0][0].Add(146);
                battleAnimations[0][0].Add(123);
                battleAnimations[0][0].Add(302);
                battleAnimations[0][0].Add(76);
                battleAnimations[0][0].Add(104);
                battleAnimations[0].Add(new List<int>()); // Infantry lance animations:
                battleAnimations[0][1].Add(77);
                battleAnimations[0][1].Add(105);
                battleAnimations[0].Add(new List<int>()); // Infantry axe animations:
                battleAnimations[0][2].Add(130);
                battleAnimations[0][2].Add(78);
                battleAnimations[0][2].Add(106);
                battleAnimations[0].Add(new List<int>()); // Infantry bow animations:
                battleAnimations[0][3].Add(131);
                battleAnimations[0][3].Add(79);
                battleAnimations[0][3].Add(107);
                battleAnimations[0].Add(new List<int>()); // Infantry brawling animations:
                battleAnimations[0][4].Add(132);
                battleAnimations[0][4].Add(304);
                battleAnimations[0][4].Add(80);
                battleAnimations[0][4].Add(108);
                battleAnimations[0].Add(new List<int>()); // Infantry magic animations:
                battleAnimations[0][5].Add(133);
                battleAnimations[0][5].Add(134);
                battleAnimations[0][5].Add(143);
                battleAnimations[0][5].Add(303);
                battleAnimations[0][5].Add(305);
                battleAnimations[0][5].Add(81);
                battleAnimations[0][5].Add(109);
                battleAnimations.Add(new List<List<int>>());
                battleAnimations[1].Add(new List<int>()); // Armored sword animations:
                battleAnimations[1][0].Add(84);
                battleAnimations[1].Add(new List<int>()); // Armored lance animations:
                battleAnimations[1][1].Add(85);
                battleAnimations[1].Add(new List<int>()); // Armored axe animations:
                battleAnimations[1][2].Add(86);
                battleAnimations[1].Add(new List<int>()); // Armored bow animations:
                battleAnimations[1][3].Add(87);
                battleAnimations[1].Add(new List<int>()); // Armored brawling animations:
                battleAnimations[1][4].Add(88);
                battleAnimations[1].Add(new List<int>()); // Armored magic animations:
                battleAnimations.Add(new List<List<int>>());
                battleAnimations[2].Add(new List<int>()); // Cavalry sword animations:
                battleAnimations[2][0].Add(137);
                battleAnimations[2][0].Add(91);
                battleAnimations[2].Add(new List<int>()); // Cavalry lance animations:
                battleAnimations[2][1].Add(129);
                battleAnimations[2][1].Add(138);
                battleAnimations[2][1].Add(92);
                battleAnimations[2].Add(new List<int>()); // Cavalry axe animations:
                battleAnimations[2][2].Add(139);
                battleAnimations[2][2].Add(93);
                battleAnimations[2].Add(new List<int>()); // Cavalry bow animations:
                battleAnimations[2][3].Add(140);
                battleAnimations[2][3].Add(141);
                battleAnimations[2][3].Add(94);
                battleAnimations[2].Add(new List<int>()); // Cavalry brawling animations:
                battleAnimations[2].Add(new List<int>()); // Cavalry magic animations:
                battleAnimations[2][5].Add(142);
                battleAnimations[2][5].Add(307);
                battleAnimations.Add(new List<List<int>>()); // Armored Cavalry
                battleAnimations.Add(new List<List<int>>());
                battleAnimations[4].Add(new List<int>()); // Pegasus sword animations:
                battleAnimations[4][0].Add(112);
                battleAnimations[4].Add(new List<int>()); // Pegasus lance animations:
                battleAnimations[4][1].Add(113);
                battleAnimations[4].Add(new List<int>()); // Pegasus axe animations:
                battleAnimations[4][2].Add(114);
                battleAnimations[4].Add(new List<int>()); // Pegasus bow animations:
                battleAnimations[4][3].Add(115);
                battleAnimations[4].Add(new List<int>()); // Pegasus brawling animations:
                battleAnimations[4].Add(new List<int>()); // Pegasus magic animations:
                battleAnimations[4][5].Add(306);
                battleAnimations.Add(new List<List<int>>());
                battleAnimations[5].Add(new List<int>()); // Wyvern sword animations:
                battleAnimations[5][0].Add(98);
                battleAnimations[5].Add(new List<int>()); // Wyvern lance animations:
                battleAnimations[5][1].Add(99);
                battleAnimations[5].Add(new List<int>()); // Wyvern axe animations:
                battleAnimations[5][2].Add(100);
                battleAnimations[5].Add(new List<int>()); // Wyvern bow animations:
                battleAnimations[5][3].Add(101);
                battleAnimations[5].Add(new List<int>()); // Wyvern brawling animations:
                battleAnimations[5].Add(new List<int>()); // Wyvern magic animations:

                //[animationSet][weaponType][animations]
                List<List<List<int>>> mountAnimations = new List<List<List<int>>>();
                mountAnimations.Add(new List<List<int>>()); // Infantry
                mountAnimations.Add(new List<List<int>>()); // Armored
                mountAnimations.Add(new List<List<int>>());
                mountAnimations[2].Add(new List<int>()); // Cavalry sword animations:
                mountAnimations[2][0].Add(5940);
                mountAnimations[2][0].Add(543);
                mountAnimations[2].Add(new List<int>()); // Cavalry lance animations:
                mountAnimations[2][1].Add(5169);
                mountAnimations[2][1].Add(6197);
                mountAnimations[2][1].Add(800);
                mountAnimations[2].Add(new List<int>()); // Cavalry axe animations:
                mountAnimations[2][2].Add(6454);
                mountAnimations[2][2].Add(1057);
                mountAnimations[2].Add(new List<int>()); // Cavalry bow animations:
                mountAnimations[2][3].Add(6711);
                mountAnimations[2][3].Add(6968);
                mountAnimations[2][3].Add(1314);
                mountAnimations[2].Add(new List<int>()); // Cavalry brawling animations:
                mountAnimations[2].Add(new List<int>()); // Cavalry magic animations:
                mountAnimations[2][5].Add(7225);
                mountAnimations[2][5].Add(65387);
                mountAnimations.Add(new List<List<int>>()); // Armored Cavalry
                mountAnimations.Add(new List<List<int>>());
                mountAnimations[4].Add(new List<int>()); // Pegasus sword animations:
                mountAnimations[4][0].Add(2342);
                mountAnimations[4].Add(new List<int>()); // Pegasus lance animations:
                mountAnimations[4][1].Add(2599);
                mountAnimations[4].Add(new List<int>()); // Pegasus axe animations:
                mountAnimations[4][2].Add(2856);
                mountAnimations[4].Add(new List<int>()); // Pegasus bow animations:
                mountAnimations[4][3].Add(3113);
                mountAnimations[4].Add(new List<int>()); // Pegasus brawling animations:
                mountAnimations[4].Add(new List<int>()); // Pegasus magic animations:
                mountAnimations[4][5].Add(65386);
                mountAnimations.Add(new List<List<int>>());
                mountAnimations[5].Add(new List<int>()); // Wyvern sword animations:
                mountAnimations[5][0].Add(3884);
                mountAnimations[5].Add(new List<int>()); // Wyvern lance animations:
                mountAnimations[5][1].Add(4141);
                mountAnimations[5].Add(new List<int>()); // Wyvern axe animations:
                mountAnimations[5][2].Add(4398);
                mountAnimations[5].Add(new List<int>()); // Wyvern bow animations:
                mountAnimations[5][3].Add(4655);
                mountAnimations[5].Add(new List<int>()); // Wyvern brawling animations:
                mountAnimations[5].Add(new List<int>()); // Wyvern magic animations:

                for (int index = 0; index < 35 && settings.provideClassAni; index++)
                {
                    long baseAniMod = classBaseAniLen * (long)index;
                    actData[classBaseAniStart + baseAniMod + 4L] = (byte)0;

                    bool preserve = false;
                    ushort animation = 0;
                    byte animationSet = 0;
                    byte attackFlag = 1;
                    byte weaponType = 0;
                    ushort mountAnimation = 65535;
                    switch (index)
                    {
                        case 23:
                            animation = 81;
                            animationSet = 1;
                            weaponType = 5;
                            break;
                        case 24:
                            animation = 80;
                            animationSet = 2;
                            weaponType = 4;
                            mountAnimation = 543;
                            break;
                        case 25:
                            animation = 142;
                            animationSet = 2;
                            weaponType = 5;
                            mountAnimation = 7225;
                            break;
                        case 26:
                            animation = 80;
                            animationSet = 4;
                            weaponType = 4;
                            mountAnimation = 2342;
                            break;
                        case 27:
                            animation = 306;
                            animationSet = 4;
                            weaponType = 5;
                            mountAnimation = 65386;
                            break;
                        case 28:
                            animation = 80;
                            animationSet = 5;
                            weaponType = 4;
                            mountAnimation = 3884;
                            break;
                        case 29:
                            animation = 306;
                            animationSet = 5;
                            weaponType = 5;
                            mountAnimation = 4655;
                            break;
                        default:
                            preserve = true;
                            break;
                    }
                    if (!preserve)
                    {
                        byte[] animationBytes = BitConverter.GetBytes(animation);
                        actData[classBaseAniStart + baseAniMod + 0L] = animationBytes[0];
                        actData[classBaseAniStart + baseAniMod + 1L] = animationBytes[1];
                        actData[classBaseAniStart + baseAniMod + 5L] = animationSet;
                        actData[classBaseAniStart + baseAniMod + 6L] = attackFlag;
                        actData[classBaseAniStart + baseAniMod + 7L] = weaponType;
                        byte[] mountAnimationBytes = BitConverter.GetBytes(mountAnimation);
                        actData[classBaseAniStart + baseAniMod + 8L] = mountAnimationBytes[0];
                        actData[classBaseAniStart + baseAniMod + 9L] = mountAnimationBytes[1];
                    }
                    if (settings.randClassAni)
                    {
                        animationSet = actData[classBaseAniStart + baseAniMod + 5L];
                        attackFlag = actData[classBaseAniStart + baseAniMod + 6L];
                        weaponType = actData[classBaseAniStart + baseAniMod + 7L];
                        if (attackFlag == 1)
                        {
                            List<int> aniPool = new List<int>();
                            List<int> mountAniPool = new List<int>();

                            bool[][] compatibility = new bool[6][];
                            compatibility[0] = new bool[] { true, true, true, false, true, false };
                            compatibility[1] = new bool[] { true, true, true, false, true, false };
                            compatibility[2] = new bool[] { true, true, true, false, true, false };
                            compatibility[3] = new bool[] { true, true, true, true, true, false };
                            compatibility[4] = new bool[] { true, true, true, false, true, false };
                            compatibility[5] = new bool[] { false, false, false, false, false, true };

                            for (int j = 0; j < battleAnimations[animationSet].Count; j++)
                                if (compatibility[weaponType][j])
                                    aniPool.AddRange(battleAnimations[animationSet][j]);

                            if (aniPool.Count > 0)
                            {
                                int selectedAni = rng.Next(0, aniPool.Count);

                                animation = (ushort)aniPool[selectedAni];

                                if (animationSet > 1)
                                {
                                    for (int j = 0; j < mountAnimations[animationSet].Count; j++)
                                        if (compatibility[weaponType][j])
                                            mountAniPool.AddRange(mountAnimations[animationSet][j]);
                                    mountAnimation = (ushort)mountAniPool[selectedAni];
                                }

                                byte[] animationBytes = BitConverter.GetBytes(animation);
                                actData[classBaseAniStart + baseAniMod + 0L] = animationBytes[0];
                                actData[classBaseAniStart + baseAniMod + 1L] = animationBytes[1];
                                byte[] mountAnimationBytes = BitConverter.GetBytes(mountAnimation);
                                actData[classBaseAniStart + baseAniMod + 8L] = mountAnimationBytes[0];
                                actData[classBaseAniStart + baseAniMod + 9L] = mountAnimationBytes[1];
                            }
                        }
                    }
                }
            }

            if (Randomizer.classLoaded)
            {
                Randomizer.classData = new byte[Randomizer.classDataV.Length];
                Randomizer.classDataV.CopyTo((Array)Randomizer.classData, 0);

                changelog += "\n\n\n---CLASS DATA---";

                for (int index = 0; index < 100; ++index)
                {
                    long blockMod = classBlockLen * (long)index;
                    long certMod = classCertLen * (long)index;
                    long abMod = classAbLen * (long)index;
                    long aniSetMod = classAniSetLen * (long)index;

                    int classTier = 0;
                    bool monster = false;
                    if (index < 88 || index == 91)
                        if (classData[classBlockStart + blockMod + 73L] != 255)
                        {
                            monsterClasses.Add(index);
                            monster = true;
                        }
                        else
                            switch (classData[classBlockStart + blockMod + 69L])
                            {
                                case 0:
                                    zeroClasses.Add(index);
                                    classTier = 0;
                                    break;
                                case 1:
                                    begClasses.Add(index);
                                    classTier = 1;
                                    break;
                                case 2:
                                    interClasses.Add(index);
                                    classTier = 2;
                                    break;
                                case 3:
                                case 5:
                                    advClasses.Add(index);
                                    classTier = 3;
                                    break;
                                case 4:
                                    masterClasses.Add(index);
                                    classTier = 4;
                                    break;
                                case 6:
                                    uniClasses.Add(index);
                                    classTier = 6;
                                    break;
                                default:
                                    break;
                            }

                    int[] statBoosts = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] statBoostPosRestrictions = { 0, 1 };
                    int[] statBoostNegRestrictions = { 0, 1 };
                    int numPosStatBoosts = 0;
                    int numNegStatBoosts = 0;
                    int moveBoost = 0;

                    int[] enemyGrowths = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] enemyGrowthsPosRestrictions = { 0, 1 };
                    int[] enemyGrowthsNegRestrictions = { 0, 1 };
                    int numPosEnemyGrowths = 0;
                    int numNegEnemyGrowths = 0;
                    int moveEnemyGrowth = 0;
                    double randMoveEnemyGrowthsP = 0;

                    int[] playerGrowths = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] playerGrowthsPosRestrictions = { 0, 1 };
                    int[] playerGrowthsNegRestrictions = { 0, 1 };
                    int numPosPlayerGrowths = 0;
                    int numNegPlayerGrowths = 0;
                    int movePlayerGrowth = 0;
                    double randMovePlayerGrowthsP = 0;

                    int[] mountBoosts = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] mountBoostPosRestrictions = { 0, 1 };
                    int[] mountBoostNegRestrictions = { 0, 1 };
                    int numPosMountBoosts = 0;
                    int numNegMountBoosts = 0;
                    int moveMountBoost = 0;

                    int masteryReq = 0;

                    int baseHP = 0;
                    int baseStr = 0;
                    int baseMag = 0;
                    int baseDex = 0;
                    int baseSpd = 0;
                    int baseLck = 0;
                    int baseDef = 0;
                    int baseRes = 0;
                    int baseCha = 0;

                    int expYield = 0;

                    int[] movementTypes = { 0, 0 };

                    int numWeaponTypes = 1;

                    int specialUnitTypings = 1;

                    int[] proficiencyRestrictions = { 0, 1 };
                    int extraProficiencies = 0;

                    int numReason = 1;
                    int numFaith = 1;
                    int spellRankMax = 0;

                    int numEquippedAbilities = 0;

                    bool randStatBoosts = false;
                    bool randMountBoosts = false;
                    bool randPlayerGrowths = false;
                    bool randEnemyGrowths = false;
                    bool randBases = false;
                    bool randDefAb = settings.randClassAb && settings.randClassDefAb;
                    bool randMasteryReq = false;
                    bool randExpYield = false;

                    if (monster)
                    {
                        if (settings.randStatBoosts && settings.randMonStatBoosts)
                            randStatBoosts = true;
                        numPosStatBoosts = rng.Next(
                            settings.monStatBoostsPosCountMin,
                            settings.monStatBoostsPosCountMax + 1);
                        numNegStatBoosts = rng.Next(
                            settings.monStatBoostsNegCountMin,
                            settings.monStatBoostsNegCountMax + 1);
                        statBoostPosRestrictions = new int[] {
                            settings.monStatBoostsPosMin,
                            settings.monStatBoostsPosMax + 1 };
                        statBoostNegRestrictions = new int[] {
                            settings.monStatBoostsNegMin,
                            settings.monStatBoostsNegMax + 1 };
                        moveBoost = rng.Next(
                            settings.monMovStatBoostsMin,
                            settings.monMovStatBoostsMax + 1);

                        randMountBoosts = settings.randMountBoosts && settings.randMonMountBoosts;
                        numPosMountBoosts = rng.Next(settings.monMountBoostsPosCountMin, settings.monMountBoostsPosCountMax + 1);
                        numNegMountBoosts = rng.Next(settings.monMountBoostsNegCountMin, settings.monMountBoostsNegCountMax + 1);
                        mountBoostPosRestrictions = new int[] { settings.monMountBoostsPosMin, settings.monMountBoostsPosMax + 1 };
                        mountBoostNegRestrictions = new int[] { settings.monMountBoostsNegMin, settings.monMountBoostsNegMax + 1 };
                        moveMountBoost = rng.Next(settings.monMovMountBoostsMin, settings.monMovMountBoostsMax);

                        randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randMonPlayerGrowthBoosts;
                        randMovePlayerGrowthsP = settings.monMovPlayerGrowthBoostsP;
                        numPosPlayerGrowths = rng.Next(settings.monPlayerGrowthBoostsPosCountMin, settings.monPlayerGrowthBoostsPosCountMax + 1);
                        numNegPlayerGrowths = rng.Next(settings.monPlayerGrowthBoostsNegCountMin, settings.monPlayerGrowthBoostsNegCountMax + 1);
                        playerGrowthsPosRestrictions = new int[] { settings.monPlayerGrowthBoostsPosMin, settings.monPlayerGrowthBoostsPosMax + 1 };
                        playerGrowthsNegRestrictions = new int[] { settings.monPlayerGrowthBoostsNegMin, settings.monPlayerGrowthBoostsNegMax + 1 };
                        movePlayerGrowth = rng.Next(settings.monMovPlayerGrowthBoostsMin, settings.monMovPlayerGrowthBoostsMax + 1);

                        randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randMonEnemyGrowthBoosts;
                        randMoveEnemyGrowthsP = settings.monMovEnemyGrowthBoostsP;
                        numPosEnemyGrowths = rng.Next(settings.monEnemyGrowthBoostsPosCountMin, settings.monEnemyGrowthBoostsPosCountMax + 1);
                        numNegEnemyGrowths = rng.Next(settings.monEnemyGrowthBoostsNegCountMin, settings.monEnemyGrowthBoostsNegCountMax + 1);
                        enemyGrowthsPosRestrictions = new int[] { settings.monEnemyGrowthBoostsPosMin, settings.monEnemyGrowthBoostsPosMax + 1 };
                        enemyGrowthsNegRestrictions = new int[] { settings.monEnemyGrowthBoostsNegMin, settings.monEnemyGrowthBoostsNegMax + 1 };
                        moveEnemyGrowth = rng.Next(settings.monMovEnemyGrowthBoostsMin, settings.monMovEnemyGrowthBoostsMax + 1);

                        randBases = settings.randClassBases && settings.randMonClassBases;
                        baseHP = rng.Next(settings.hpMonClassBasesMin, settings.hpMonClassBasesMax + 1);
                        baseStr = rng.Next(settings.strMonClassBasesMin, settings.strMonClassBasesMax + 1);
                        baseMag = rng.Next(settings.magMonClassBasesMin, settings.magMonClassBasesMax + 1);
                        baseDex = rng.Next(settings.dexMonClassBasesMin, settings.dexMonClassBasesMax + 1);
                        baseSpd = rng.Next(settings.speMonClassBasesMin, settings.speMonClassBasesMax + 1);
                        baseLck = rng.Next(settings.lucMonClassBasesMin, settings.lucMonClassBasesMax + 1);
                        baseDef = rng.Next(settings.defMonClassBasesMin, settings.defMonClassBasesMax + 1);
                        baseRes = rng.Next(settings.resMonClassBasesMin, settings.resMonClassBasesMax + 1);
                        baseCha = rng.Next(settings.chaMonClassBasesMin, settings.chaMonClassBasesMax + 1);

                        if (p(settings.mon2ndWeaponTypeP))
                            numWeaponTypes = 2;

                        randExpYield = settings.randExpYield && settings.randMonExpYield;
                        expYield = rng.Next(settings.monExpYieldMin, settings.monExpYieldMax);

                        randMasteryReq = settings.randMonClassMasteryExpReq && settings.randClassMasteryExpReq;
                        masteryReq = rng.Next(settings.monClassMasteryExpReqMin, settings.monClassMasteryExpReqMax + 1);

                        for (int i = 0; i < movementTypes.Length; i++)
                        {
                            int movementPicker = rng.Next(0, 20);
                            if (movementPicker < 17)
                                movementTypes[i] = 7;
                            else if (movementPicker < 18)
                                movementTypes[i] = 8;
                            else
                                movementTypes[i] = 9;
                        }

                        int unitTypeNumPicker = rng.Next(0, 4);
                        if (unitTypeNumPicker < 2)
                            specialUnitTypings = 2;
                        else if (unitTypeNumPicker < 3)
                            specialUnitTypings = 3;

                        randDefAb = randDefAb && settings.randMonClassDefAb;
                        numEquippedAbilities = rng.Next(settings.monClassDefAbCountMin, settings.monClassDefAbCountMax + 1);
                    }
                    else
                        switch (classTier)
                        {
                            case 0:
                                if (settings.randStatBoosts && settings.randStaStatBoosts)
                                    randStatBoosts = true;
                                numPosStatBoosts = rng.Next(
                                    settings.staStatBoostsPosCountMin,
                                    settings.staStatBoostsPosCountMax + 1);
                                numNegStatBoosts = rng.Next(
                                    settings.staStatBoostsNegCountMin,
                                    settings.staStatBoostsNegCountMax + 1);
                                statBoostPosRestrictions = new int[] {
                            settings.staStatBoostsPosMin,
                            settings.staStatBoostsPosMax + 1 };
                                statBoostNegRestrictions = new int[] {
                            settings.staStatBoostsNegMin,
                            settings.staStatBoostsNegMax + 1 };
                                moveBoost = rng.Next(
                                    settings.staMovStatBoostsMin,
                                    settings.staMovStatBoostsMax + 1);

                                randMountBoosts = settings.randMountBoosts && settings.randStaMountBoosts;
                                numPosMountBoosts = rng.Next(settings.staMountBoostsPosCountMin, settings.staMountBoostsPosCountMax + 1);
                                numNegMountBoosts = rng.Next(settings.staMountBoostsNegCountMin, settings.staMountBoostsNegCountMax + 1);
                                mountBoostPosRestrictions = new int[] { settings.staMountBoostsPosMin, settings.staMountBoostsPosMax + 1 };
                                mountBoostNegRestrictions = new int[] { settings.staMountBoostsNegMin, settings.staMountBoostsNegMax + 1 };
                                moveMountBoost = rng.Next(settings.staMovMountBoostsMin, settings.staMovMountBoostsMax);

                                randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randStaPlayerGrowthBoosts;
                                randMovePlayerGrowthsP = settings.staMovPlayerGrowthBoostsP;
                                numPosPlayerGrowths = rng.Next(settings.staPlayerGrowthBoostsPosCountMin, settings.staPlayerGrowthBoostsPosCountMax + 1);
                                numNegPlayerGrowths = rng.Next(settings.staPlayerGrowthBoostsNegCountMin, settings.staPlayerGrowthBoostsNegCountMax + 1);
                                playerGrowthsPosRestrictions = new int[] { settings.staPlayerGrowthBoostsPosMin, settings.staPlayerGrowthBoostsPosMax + 1 };
                                playerGrowthsNegRestrictions = new int[] { settings.staPlayerGrowthBoostsNegMin, settings.staPlayerGrowthBoostsNegMax + 1 };
                                movePlayerGrowth = rng.Next(settings.staMovPlayerGrowthBoostsMin, settings.staMovPlayerGrowthBoostsMax + 1);

                                randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randStaEnemyGrowthBoosts;
                                randMoveEnemyGrowthsP = settings.staMovEnemyGrowthBoostsP;
                                numPosEnemyGrowths = rng.Next(settings.staEnemyGrowthBoostsPosCountMin, settings.staEnemyGrowthBoostsPosCountMax + 1);
                                numNegEnemyGrowths = rng.Next(settings.staEnemyGrowthBoostsNegCountMin, settings.staEnemyGrowthBoostsNegCountMax + 1);
                                enemyGrowthsPosRestrictions = new int[] { settings.staEnemyGrowthBoostsPosMin, settings.staEnemyGrowthBoostsPosMax + 1 };
                                enemyGrowthsNegRestrictions = new int[] { settings.staEnemyGrowthBoostsNegMin, settings.staEnemyGrowthBoostsNegMax + 1 };
                                moveEnemyGrowth = rng.Next(settings.staMovEnemyGrowthBoostsMin, settings.staMovEnemyGrowthBoostsMax + 1);

                                randBases = settings.randClassBases && settings.randStaClassBases;
                                baseHP = rng.Next(settings.hpStaClassBasesMin, settings.hpStaClassBasesMax + 1);
                                baseStr = rng.Next(settings.strStaClassBasesMin, settings.strStaClassBasesMax + 1);
                                baseMag = rng.Next(settings.magStaClassBasesMin, settings.magStaClassBasesMax + 1);
                                baseDex = rng.Next(settings.dexStaClassBasesMin, settings.dexStaClassBasesMax + 1);
                                baseSpd = rng.Next(settings.speStaClassBasesMin, settings.speStaClassBasesMax + 1);
                                baseLck = rng.Next(settings.lucStaClassBasesMin, settings.lucStaClassBasesMax + 1);
                                baseDef = rng.Next(settings.defStaClassBasesMin, settings.defStaClassBasesMax + 1);
                                baseRes = rng.Next(settings.resStaClassBasesMin, settings.resStaClassBasesMax + 1);
                                baseCha = rng.Next(settings.chaStaClassBasesMin, settings.chaStaClassBasesMax + 1);

                                if (p(settings.sta2ndWeaponTypeP))
                                    numWeaponTypes = 2;

                                randExpYield = settings.randExpYield && settings.randStaExpYield;
                                expYield = rng.Next(settings.staExpYieldMin, settings.staExpYieldMax);

                                randMasteryReq = settings.randStaClassMasteryExpReq && settings.randClassMasteryExpReq;
                                masteryReq = rng.Next(settings.staClassMasteryExpReqMin, settings.staClassMasteryExpReqMax + 1);

                                randDefAb = randDefAb && settings.randStaClassDefAb;
                                numEquippedAbilities = rng.Next(settings.staClassDefAbCountMin, settings.staClassDefAbCountMax + 1);
                                break;
                            case 1:
                                if (settings.randStatBoosts && settings.randBegStatBoosts)
                                    randStatBoosts = true;
                                numPosStatBoosts = rng.Next(
                                    settings.begStatBoostsPosCountMin,
                                    settings.begStatBoostsPosCountMax + 1);
                                numNegStatBoosts = rng.Next(
                                    settings.begStatBoostsNegCountMin,
                                    settings.begStatBoostsNegCountMax + 1);
                                statBoostPosRestrictions = new int[] {
                            settings.begStatBoostsPosMin,
                            settings.begStatBoostsPosMax + 1 };
                                statBoostNegRestrictions = new int[] {
                            settings.begStatBoostsNegMin,
                            settings.begStatBoostsNegMax + 1 };
                                moveBoost = rng.Next(
                                    settings.begMovStatBoostsMin,
                                    settings.begMovStatBoostsMax + 1);

                                randMountBoosts = settings.randMountBoosts && settings.randBegMountBoosts;
                                numPosMountBoosts = rng.Next(settings.begMountBoostsPosCountMin, settings.begMountBoostsPosCountMax + 1);
                                numNegMountBoosts = rng.Next(settings.begMountBoostsNegCountMin, settings.begMountBoostsNegCountMax + 1);
                                mountBoostPosRestrictions = new int[] { settings.begMountBoostsPosMin, settings.begMountBoostsPosMax + 1 };
                                mountBoostNegRestrictions = new int[] { settings.begMountBoostsNegMin, settings.begMountBoostsNegMax + 1 };
                                moveMountBoost = rng.Next(settings.begMovMountBoostsMin, settings.begMovMountBoostsMax);

                                randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randBegPlayerGrowthBoosts;
                                randMovePlayerGrowthsP = settings.begMovPlayerGrowthBoostsP;
                                numPosPlayerGrowths = rng.Next(settings.begPlayerGrowthBoostsPosCountMin, settings.begPlayerGrowthBoostsPosCountMax + 1);
                                numNegPlayerGrowths = rng.Next(settings.begPlayerGrowthBoostsNegCountMin, settings.begPlayerGrowthBoostsNegCountMax + 1);
                                playerGrowthsPosRestrictions = new int[] { settings.begPlayerGrowthBoostsPosMin, settings.begPlayerGrowthBoostsPosMax + 1 };
                                playerGrowthsNegRestrictions = new int[] { settings.begPlayerGrowthBoostsNegMin, settings.begPlayerGrowthBoostsNegMax + 1 };
                                movePlayerGrowth = rng.Next(settings.begMovPlayerGrowthBoostsMin, settings.begMovPlayerGrowthBoostsMax + 1);

                                randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randBegEnemyGrowthBoosts;
                                randMoveEnemyGrowthsP = settings.begMovEnemyGrowthBoostsP;
                                numPosEnemyGrowths = rng.Next(settings.begEnemyGrowthBoostsPosCountMin, settings.begEnemyGrowthBoostsPosCountMax + 1);
                                numNegEnemyGrowths = rng.Next(settings.begEnemyGrowthBoostsNegCountMin, settings.begEnemyGrowthBoostsNegCountMax + 1);
                                enemyGrowthsPosRestrictions = new int[] { settings.begEnemyGrowthBoostsPosMin, settings.begEnemyGrowthBoostsPosMax + 1 };
                                enemyGrowthsNegRestrictions = new int[] { settings.begEnemyGrowthBoostsNegMin, settings.begEnemyGrowthBoostsNegMax + 1 };
                                moveEnemyGrowth = rng.Next(settings.begMovEnemyGrowthBoostsMin, settings.begMovEnemyGrowthBoostsMax + 1);

                                randBases = settings.randClassBases && settings.randBegClassBases;
                                baseHP = rng.Next(settings.hpBegClassBasesMin, settings.hpBegClassBasesMax + 1);
                                baseStr = rng.Next(settings.strBegClassBasesMin, settings.strBegClassBasesMax + 1);
                                baseMag = rng.Next(settings.magBegClassBasesMin, settings.magBegClassBasesMax + 1);
                                baseDex = rng.Next(settings.dexBegClassBasesMin, settings.dexBegClassBasesMax + 1);
                                baseSpd = rng.Next(settings.speBegClassBasesMin, settings.speBegClassBasesMax + 1);
                                baseLck = rng.Next(settings.lucBegClassBasesMin, settings.lucBegClassBasesMax + 1);
                                baseDef = rng.Next(settings.defBegClassBasesMin, settings.defBegClassBasesMax + 1);
                                baseRes = rng.Next(settings.resBegClassBasesMin, settings.resBegClassBasesMax + 1);
                                baseCha = rng.Next(settings.chaBegClassBasesMin, settings.chaBegClassBasesMax + 1);

                                if (p(settings.beg2ndWeaponTypeP))
                                    numWeaponTypes = 2;

                                randMasteryReq = settings.randBegClassMasteryExpReq && settings.randClassMasteryExpReq;
                                masteryReq = rng.Next(settings.begClassMasteryExpReqMin, settings.begClassMasteryExpReqMax + 1);

                                randExpYield = settings.randExpYield && settings.randBegExpYield;
                                expYield = rng.Next(settings.begExpYieldMin, settings.begExpYieldMax);

                                if (settings.baseMovTypes)
                                    for (int i = 0; i < movementTypes.Length; i++)
                                    {
                                        int movementPicker = rng.Next(0, 4);
                                        if (movementPicker < 1)
                                            movementTypes[i] = 4;
                                        else if (movementPicker < 2)
                                            movementTypes[i] = 5;
                                    }
                                else
                                    for (int i = 0; i < movementTypes.Length; i++)
                                        movementTypes[i] = rng.Next(0, 7);

                                proficiencyRestrictions = new int[] { 1, 2 };
                                extraProficiencies = rng.Next(0, 3);

                                randDefAb = randDefAb && settings.randBegClassDefAb;
                                numEquippedAbilities = rng.Next(settings.begClassDefAbCountMin, settings.begClassDefAbCountMax + 1);
                                break;
                            case 2:
                                if (settings.randStatBoosts && settings.randIntStatBoosts)
                                    randStatBoosts = true;
                                numPosStatBoosts = rng.Next(
                                    settings.intStatBoostsPosCountMin,
                                    settings.intStatBoostsPosCountMax + 1);
                                numNegStatBoosts = rng.Next(
                                    settings.intStatBoostsNegCountMin,
                                    settings.intStatBoostsNegCountMax + 1);
                                statBoostPosRestrictions = new int[] {
                            settings.intStatBoostsPosMin,
                            settings.intStatBoostsPosMax + 1 };
                                statBoostNegRestrictions = new int[] {
                            settings.intStatBoostsNegMin,
                            settings.intStatBoostsNegMax + 1 };
                                moveBoost = rng.Next(
                                    settings.intMovStatBoostsMin,
                                    settings.intMovStatBoostsMax + 1);

                                randMountBoosts = settings.randMountBoosts && settings.randIntMountBoosts;
                                numPosMountBoosts = rng.Next(settings.intMountBoostsPosCountMin, settings.intMountBoostsPosCountMax + 1);
                                numNegMountBoosts = rng.Next(settings.intMountBoostsNegCountMin, settings.intMountBoostsNegCountMax + 1);
                                mountBoostPosRestrictions = new int[] { settings.intMountBoostsPosMin, settings.intMountBoostsPosMax + 1 };
                                mountBoostNegRestrictions = new int[] { settings.intMountBoostsNegMin, settings.intMountBoostsNegMax + 1 };
                                moveMountBoost = rng.Next(settings.intMovMountBoostsMin, settings.intMovMountBoostsMax);

                                randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randIntPlayerGrowthBoosts;
                                randMovePlayerGrowthsP = settings.intMovPlayerGrowthBoostsP;
                                numPosPlayerGrowths = rng.Next(settings.intPlayerGrowthBoostsPosCountMin, settings.intPlayerGrowthBoostsPosCountMax + 1);
                                numNegPlayerGrowths = rng.Next(settings.intPlayerGrowthBoostsNegCountMin, settings.intPlayerGrowthBoostsNegCountMax + 1);
                                playerGrowthsPosRestrictions = new int[] { settings.intPlayerGrowthBoostsPosMin, settings.intPlayerGrowthBoostsPosMax + 1 };
                                playerGrowthsNegRestrictions = new int[] { settings.intPlayerGrowthBoostsNegMin, settings.intPlayerGrowthBoostsNegMax + 1 };
                                movePlayerGrowth = rng.Next(settings.intMovPlayerGrowthBoostsMin, settings.intMovPlayerGrowthBoostsMax + 1);

                                randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randIntEnemyGrowthBoosts;
                                randMoveEnemyGrowthsP = settings.intMovEnemyGrowthBoostsP;
                                numPosEnemyGrowths = rng.Next(settings.intEnemyGrowthBoostsPosCountMin, settings.intEnemyGrowthBoostsPosCountMax + 1);
                                numNegEnemyGrowths = rng.Next(settings.intEnemyGrowthBoostsNegCountMin, settings.intEnemyGrowthBoostsNegCountMax + 1);
                                enemyGrowthsPosRestrictions = new int[] { settings.intEnemyGrowthBoostsPosMin, settings.intEnemyGrowthBoostsPosMax + 1 };
                                enemyGrowthsNegRestrictions = new int[] { settings.intEnemyGrowthBoostsNegMin, settings.intEnemyGrowthBoostsNegMax + 1 };
                                moveEnemyGrowth = rng.Next(settings.intMovEnemyGrowthBoostsMin, settings.intMovEnemyGrowthBoostsMax + 1);

                                randBases = settings.randClassBases && settings.randIntClassBases;
                                baseHP = rng.Next(settings.hpIntClassBasesMin, settings.hpIntClassBasesMax + 1);
                                baseStr = rng.Next(settings.strIntClassBasesMin, settings.strIntClassBasesMax + 1);
                                baseMag = rng.Next(settings.magIntClassBasesMin, settings.magIntClassBasesMax + 1);
                                baseDex = rng.Next(settings.dexIntClassBasesMin, settings.dexIntClassBasesMax + 1);
                                baseSpd = rng.Next(settings.speIntClassBasesMin, settings.speIntClassBasesMax + 1);
                                baseLck = rng.Next(settings.lucIntClassBasesMin, settings.lucIntClassBasesMax + 1);
                                baseDef = rng.Next(settings.defIntClassBasesMin, settings.defIntClassBasesMax + 1);
                                baseRes = rng.Next(settings.resIntClassBasesMin, settings.resIntClassBasesMax + 1);
                                baseCha = rng.Next(settings.chaIntClassBasesMin, settings.chaIntClassBasesMax + 1);

                                if (p(settings.int2ndWeaponTypeP))
                                    numWeaponTypes = 2;

                                randMasteryReq = settings.randIntClassMasteryExpReq && settings.randClassMasteryExpReq;
                                masteryReq = rng.Next(settings.intClassMasteryExpReqMin, settings.intClassMasteryExpReqMax + 1);

                                randExpYield = settings.randExpYield && settings.randIntExpYield;
                                expYield = rng.Next(settings.intExpYieldMin, settings.intExpYieldMax);

                                if (settings.baseMovTypes)
                                    for (int i = 0; i < movementTypes.Length; i++)
                                    {
                                        int movementPicker = rng.Next(0, 4);
                                        if (movementPicker < 1)
                                            movementTypes[i] = 4;
                                        else if (movementPicker < 2)
                                            movementTypes[i] = 5;
                                    }
                                else
                                    for (int i = 0; i < movementTypes.Length; i++)
                                        movementTypes[i] = rng.Next(0, 7);

                                proficiencyRestrictions = new int[] { 1, 3 };
                                extraProficiencies = 1;

                                spellRankMax = 4;

                                randDefAb = randDefAb && settings.randIntClassDefAb;
                                numEquippedAbilities = rng.Next(settings.intClassDefAbCountMin, settings.intClassDefAbCountMax + 1);
                                break;
                            case 3:
                                if (settings.randStatBoosts && settings.randAdvStatBoosts)
                                    randStatBoosts = true;
                                numPosStatBoosts = rng.Next(
                                    settings.advStatBoostsPosCountMin,
                                    settings.advStatBoostsPosCountMax + 1);
                                numNegStatBoosts = rng.Next(
                                    settings.advStatBoostsNegCountMin,
                                    settings.advStatBoostsNegCountMax + 1);
                                statBoostPosRestrictions = new int[] {
                            settings.advStatBoostsPosMin,
                            settings.advStatBoostsPosMax + 1 };
                                statBoostNegRestrictions = new int[] {
                            settings.advStatBoostsNegMin,
                            settings.advStatBoostsNegMax + 1 };
                                moveBoost = rng.Next(
                                    settings.advMovStatBoostsMin,
                                    settings.advMovStatBoostsMax + 1);

                                randMountBoosts = settings.randMountBoosts && settings.randAdvMountBoosts;
                                numPosMountBoosts = rng.Next(settings.advMountBoostsPosCountMin, settings.advMountBoostsPosCountMax + 1);
                                numNegMountBoosts = rng.Next(settings.advMountBoostsNegCountMin, settings.advMountBoostsNegCountMax + 1);
                                mountBoostPosRestrictions = new int[] { settings.advMountBoostsPosMin, settings.advMountBoostsPosMax + 1 };
                                mountBoostNegRestrictions = new int[] { settings.advMountBoostsNegMin, settings.advMountBoostsNegMax + 1 };
                                moveMountBoost = rng.Next(settings.advMovMountBoostsMin, settings.advMovMountBoostsMax);

                                randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randAdvPlayerGrowthBoosts;
                                randMovePlayerGrowthsP = settings.advMovPlayerGrowthBoostsP;
                                numPosPlayerGrowths = rng.Next(settings.advPlayerGrowthBoostsPosCountMin, settings.advPlayerGrowthBoostsPosCountMax + 1);
                                numNegPlayerGrowths = rng.Next(settings.advPlayerGrowthBoostsNegCountMin, settings.advPlayerGrowthBoostsNegCountMax + 1);
                                playerGrowthsPosRestrictions = new int[] { settings.advPlayerGrowthBoostsPosMin, settings.advPlayerGrowthBoostsPosMax + 1 };
                                playerGrowthsNegRestrictions = new int[] { settings.advPlayerGrowthBoostsNegMin, settings.advPlayerGrowthBoostsNegMax + 1 };
                                movePlayerGrowth = rng.Next(settings.advMovPlayerGrowthBoostsMin, settings.advMovPlayerGrowthBoostsMax + 1);

                                randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randAdvEnemyGrowthBoosts;
                                randMoveEnemyGrowthsP = settings.advMovEnemyGrowthBoostsP;
                                numPosEnemyGrowths = rng.Next(settings.advEnemyGrowthBoostsPosCountMin, settings.advEnemyGrowthBoostsPosCountMax + 1);
                                numNegEnemyGrowths = rng.Next(settings.advEnemyGrowthBoostsNegCountMin, settings.advEnemyGrowthBoostsNegCountMax + 1);
                                enemyGrowthsPosRestrictions = new int[] { settings.advEnemyGrowthBoostsPosMin, settings.advEnemyGrowthBoostsPosMax + 1 };
                                enemyGrowthsNegRestrictions = new int[] { settings.advEnemyGrowthBoostsNegMin, settings.advEnemyGrowthBoostsNegMax + 1 };
                                moveEnemyGrowth = rng.Next(settings.advMovEnemyGrowthBoostsMin, settings.advMovEnemyGrowthBoostsMax + 1);

                                randBases = settings.randClassBases && settings.randAdvClassBases;
                                baseHP = rng.Next(settings.hpAdvClassBasesMin, settings.hpAdvClassBasesMax + 1);
                                baseStr = rng.Next(settings.strAdvClassBasesMin, settings.strAdvClassBasesMax + 1);
                                baseMag = rng.Next(settings.magAdvClassBasesMin, settings.magAdvClassBasesMax + 1);
                                baseDex = rng.Next(settings.dexAdvClassBasesMin, settings.dexAdvClassBasesMax + 1);
                                baseSpd = rng.Next(settings.speAdvClassBasesMin, settings.speAdvClassBasesMax + 1);
                                baseLck = rng.Next(settings.lucAdvClassBasesMin, settings.lucAdvClassBasesMax + 1);
                                baseDef = rng.Next(settings.defAdvClassBasesMin, settings.defAdvClassBasesMax + 1);
                                baseRes = rng.Next(settings.resAdvClassBasesMin, settings.resAdvClassBasesMax + 1);
                                baseCha = rng.Next(settings.chaAdvClassBasesMin, settings.chaAdvClassBasesMax + 1);

                                if (p(settings.adv2ndWeaponTypeP))
                                    numWeaponTypes = 2;

                                randMasteryReq = settings.randAdvClassMasteryExpReq && settings.randClassMasteryExpReq;
                                masteryReq = rng.Next(settings.advClassMasteryExpReqMin, settings.advClassMasteryExpReqMax + 1);

                                randExpYield = settings.randExpYield && settings.randAdvExpYield;
                                expYield = rng.Next(settings.advExpYieldMin, settings.advExpYieldMax);

                                if (settings.baseMovTypes)
                                    for (int i = 0; i < movementTypes.Length; i++)
                                    {
                                        int movementPicker = rng.Next(0, 4);
                                        if (movementPicker < 1)
                                            movementTypes[i] = 4;
                                        else if (movementPicker < 2)
                                            movementTypes[i] = 5;
                                    }
                                else
                                    for (int i = 0; i < movementTypes.Length; i++)
                                        movementTypes[i] = rng.Next(0, 7);

                                proficiencyRestrictions = new int[] { 1, 4 };
                                extraProficiencies = rng.Next(0, 2);

                                numReason = rng.Next(1, 3);
                                numFaith = rng.Next(1, 3);
                                spellRankMax = 6;

                                randDefAb = randDefAb && settings.randAdvClassDefAb;
                                numEquippedAbilities = rng.Next(settings.advClassDefAbCountMin, settings.advClassDefAbCountMax + 1);
                                break;
                            case 4:
                                if (settings.randStatBoosts && settings.randMasStatBoosts)
                                    randStatBoosts = true;
                                numPosStatBoosts = rng.Next(
                                    settings.masStatBoostsPosCountMin,
                                    settings.masStatBoostsPosCountMax + 1);
                                numNegStatBoosts = rng.Next(
                                    settings.masStatBoostsNegCountMin,
                                    settings.masStatBoostsNegCountMax + 1);
                                statBoostPosRestrictions = new int[] {
                            settings.masStatBoostsPosMin,
                            settings.masStatBoostsPosMax + 1 };
                                statBoostNegRestrictions = new int[] {
                            settings.masStatBoostsNegMin,
                            settings.masStatBoostsNegMax + 1 };
                                moveBoost = rng.Next(
                                    settings.masMovStatBoostsMin,
                                    settings.masMovStatBoostsMax + 1);

                                randMountBoosts = settings.randMountBoosts && settings.randMasMountBoosts;
                                numPosMountBoosts = rng.Next(settings.masMountBoostsPosCountMin, settings.masMountBoostsPosCountMax + 1);
                                numNegMountBoosts = rng.Next(settings.masMountBoostsNegCountMin, settings.masMountBoostsNegCountMax + 1);
                                mountBoostPosRestrictions = new int[] { settings.masMountBoostsPosMin, settings.masMountBoostsPosMax + 1 };
                                mountBoostNegRestrictions = new int[] { settings.masMountBoostsNegMin, settings.masMountBoostsNegMax + 1 };
                                moveMountBoost = rng.Next(settings.masMovMountBoostsMin, settings.masMovMountBoostsMax);

                                randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randMasPlayerGrowthBoosts;
                                randMovePlayerGrowthsP = settings.masMovPlayerGrowthBoostsP;
                                numPosPlayerGrowths = rng.Next(settings.masPlayerGrowthBoostsPosCountMin, settings.masPlayerGrowthBoostsPosCountMax + 1);
                                numNegPlayerGrowths = rng.Next(settings.masPlayerGrowthBoostsNegCountMin, settings.masPlayerGrowthBoostsNegCountMax + 1);
                                playerGrowthsPosRestrictions = new int[] { settings.masPlayerGrowthBoostsPosMin, settings.masPlayerGrowthBoostsPosMax + 1 };
                                playerGrowthsNegRestrictions = new int[] { settings.masPlayerGrowthBoostsNegMin, settings.masPlayerGrowthBoostsNegMax + 1 };
                                movePlayerGrowth = rng.Next(settings.masMovPlayerGrowthBoostsMin, settings.masMovPlayerGrowthBoostsMax + 1);

                                randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randMasEnemyGrowthBoosts;
                                randMoveEnemyGrowthsP = settings.masMovEnemyGrowthBoostsP;
                                numPosEnemyGrowths = rng.Next(settings.masEnemyGrowthBoostsPosCountMin, settings.masEnemyGrowthBoostsPosCountMax + 1);
                                numNegEnemyGrowths = rng.Next(settings.masEnemyGrowthBoostsNegCountMin, settings.masEnemyGrowthBoostsNegCountMax + 1);
                                enemyGrowthsPosRestrictions = new int[] { settings.masEnemyGrowthBoostsPosMin, settings.masEnemyGrowthBoostsPosMax + 1 };
                                enemyGrowthsNegRestrictions = new int[] { settings.masEnemyGrowthBoostsNegMin, settings.masEnemyGrowthBoostsNegMax + 1 };
                                moveEnemyGrowth = rng.Next(settings.masMovEnemyGrowthBoostsMin, settings.masMovEnemyGrowthBoostsMax + 1);

                                randBases = settings.randClassBases && settings.randMasClassBases;
                                baseHP = rng.Next(settings.hpMasClassBasesMin, settings.hpMasClassBasesMax + 1);
                                baseStr = rng.Next(settings.strMasClassBasesMin, settings.strMasClassBasesMax + 1);
                                baseMag = rng.Next(settings.magMasClassBasesMin, settings.magMasClassBasesMax + 1);
                                baseDex = rng.Next(settings.dexMasClassBasesMin, settings.dexMasClassBasesMax + 1);
                                baseSpd = rng.Next(settings.speMasClassBasesMin, settings.speMasClassBasesMax + 1);
                                baseLck = rng.Next(settings.lucMasClassBasesMin, settings.lucMasClassBasesMax + 1);
                                baseDef = rng.Next(settings.defMasClassBasesMin, settings.defMasClassBasesMax + 1);
                                baseRes = rng.Next(settings.resMasClassBasesMin, settings.resMasClassBasesMax + 1);
                                baseCha = rng.Next(settings.chaMasClassBasesMin, settings.chaMasClassBasesMax + 1);

                                if (p(settings.mas2ndWeaponTypeP))
                                    numWeaponTypes = 2;

                                randMasteryReq = settings.randMasClassMasteryExpReq && settings.randClassMasteryExpReq;
                                masteryReq = rng.Next(settings.masClassMasteryExpReqMin, settings.masClassMasteryExpReqMax + 1);

                                randExpYield = settings.randExpYield && settings.randMasExpYield;
                                expYield = rng.Next(settings.masExpYieldMin, settings.masExpYieldMax);

                                if (settings.baseMovTypes)
                                    for (int i = 0; i < movementTypes.Length; i++)
                                    {
                                        int movementPicker = rng.Next(0, 4);
                                        if (movementPicker < 1)
                                            movementTypes[i] = 4;
                                        else if (movementPicker < 2)
                                            movementTypes[i] = 5;
                                    }
                                else
                                    for (int i = 0; i < movementTypes.Length; i++)
                                        movementTypes[i] = rng.Next(0, 7);

                                if (rng.Next(0, 5) == 0)
                                    specialUnitTypings = 2;

                                proficiencyRestrictions = new int[] { 3, 4 };
                                extraProficiencies = rng.Next(0, 2);

                                numReason = rng.Next(1, 3);
                                numFaith = rng.Next(1, 3);
                                spellRankMax = 8;

                                numEquippedAbilities = 5;

                                randDefAb = randDefAb && settings.randMasClassDefAb;
                                numEquippedAbilities = rng.Next(settings.masClassDefAbCountMin, settings.masClassDefAbCountMax + 1);
                                break;
                            case 6:
                                if (settings.randStatBoosts && settings.randUniStatBoosts)
                                    randStatBoosts = true;
                                numPosStatBoosts = rng.Next(
                                    settings.uniStatBoostsPosCountMin,
                                    settings.uniStatBoostsPosCountMax + 1);
                                numNegStatBoosts = rng.Next(
                                    settings.uniStatBoostsNegCountMin,
                                    settings.uniStatBoostsNegCountMax + 1);
                                statBoostPosRestrictions = new int[] {
                            settings.uniStatBoostsPosMin,
                            settings.uniStatBoostsPosMax + 1 };
                                statBoostNegRestrictions = new int[] {
                            settings.uniStatBoostsNegMin,
                            settings.uniStatBoostsNegMax + 1 };
                                moveBoost = rng.Next(
                                    settings.uniMovStatBoostsMin,
                                    settings.uniMovStatBoostsMax + 1);

                                randMountBoosts = settings.randMountBoosts && settings.randUniMountBoosts;
                                numPosMountBoosts = rng.Next(settings.uniMountBoostsPosCountMin, settings.uniMountBoostsPosCountMax + 1);
                                numNegMountBoosts = rng.Next(settings.uniMountBoostsNegCountMin, settings.uniMountBoostsNegCountMax + 1);
                                mountBoostPosRestrictions = new int[] { settings.uniMountBoostsPosMin, settings.uniMountBoostsPosMax + 1 };
                                mountBoostNegRestrictions = new int[] { settings.uniMountBoostsNegMin, settings.uniMountBoostsNegMax + 1 };
                                moveMountBoost = rng.Next(settings.uniMovMountBoostsMin, settings.uniMovMountBoostsMax);

                                randPlayerGrowths = settings.randPlayerGrowthBoosts && settings.randUniPlayerGrowthBoosts;
                                randMovePlayerGrowthsP = settings.uniMovPlayerGrowthBoostsP;
                                numPosPlayerGrowths = rng.Next(settings.uniPlayerGrowthBoostsPosCountMin, settings.uniPlayerGrowthBoostsPosCountMax + 1);
                                numNegPlayerGrowths = rng.Next(settings.uniPlayerGrowthBoostsNegCountMin, settings.uniPlayerGrowthBoostsNegCountMax + 1);
                                playerGrowthsPosRestrictions = new int[] { settings.uniPlayerGrowthBoostsPosMin, settings.uniPlayerGrowthBoostsPosMax + 1 };
                                playerGrowthsNegRestrictions = new int[] { settings.uniPlayerGrowthBoostsNegMin, settings.uniPlayerGrowthBoostsNegMax + 1 };
                                movePlayerGrowth = rng.Next(settings.uniMovPlayerGrowthBoostsMin, settings.uniMovPlayerGrowthBoostsMax + 1);

                                randEnemyGrowths = settings.randEnemyGrowthBoosts && settings.randUniEnemyGrowthBoosts;
                                randMoveEnemyGrowthsP = settings.uniMovEnemyGrowthBoostsP;
                                numPosEnemyGrowths = rng.Next(settings.uniEnemyGrowthBoostsPosCountMin, settings.uniEnemyGrowthBoostsPosCountMax + 1);
                                numNegEnemyGrowths = rng.Next(settings.uniEnemyGrowthBoostsNegCountMin, settings.uniEnemyGrowthBoostsNegCountMax + 1);
                                enemyGrowthsPosRestrictions = new int[] { settings.uniEnemyGrowthBoostsPosMin, settings.uniEnemyGrowthBoostsPosMax + 1 };
                                enemyGrowthsNegRestrictions = new int[] { settings.uniEnemyGrowthBoostsNegMin, settings.uniEnemyGrowthBoostsNegMax + 1 };
                                moveEnemyGrowth = rng.Next(settings.uniMovEnemyGrowthBoostsMin, settings.uniMovEnemyGrowthBoostsMax + 1);

                                randBases = settings.randClassBases && settings.randUniClassBases;
                                baseHP = rng.Next(settings.hpUniClassBasesMin, settings.hpUniClassBasesMax + 1);
                                baseStr = rng.Next(settings.strUniClassBasesMin, settings.strUniClassBasesMax + 1);
                                baseMag = rng.Next(settings.magUniClassBasesMin, settings.magUniClassBasesMax + 1);
                                baseDex = rng.Next(settings.dexUniClassBasesMin, settings.dexUniClassBasesMax + 1);
                                baseSpd = rng.Next(settings.speUniClassBasesMin, settings.speUniClassBasesMax + 1);
                                baseLck = rng.Next(settings.lucUniClassBasesMin, settings.lucUniClassBasesMax + 1);
                                baseDef = rng.Next(settings.defUniClassBasesMin, settings.defUniClassBasesMax + 1);
                                baseRes = rng.Next(settings.resUniClassBasesMin, settings.resUniClassBasesMax + 1);
                                baseCha = rng.Next(settings.chaUniClassBasesMin, settings.chaUniClassBasesMax + 1);

                                if (p(settings.uni2ndWeaponTypeP))
                                    numWeaponTypes = 2;

                                randMasteryReq = settings.randUniClassMasteryExpReq && settings.randClassMasteryExpReq;
                                masteryReq = rng.Next(settings.uniClassMasteryExpReqMin, settings.uniClassMasteryExpReqMax + 1);

                                randExpYield = settings.randExpYield && settings.randUniExpYield;
                                expYield = rng.Next(settings.uniExpYieldMin, settings.uniExpYieldMax);

                                if (settings.baseMovTypes)
                                    for (int i = 0; i < movementTypes.Length; i++)
                                    {
                                        int movementPicker = rng.Next(0, 4);
                                        if (movementPicker < 1)
                                            movementTypes[i] = 4;
                                        else if (movementPicker < 2)
                                            movementTypes[i] = 5;
                                    }
                                else
                                    for (int i = 0; i < movementTypes.Length; i++)
                                        movementTypes[i] = rng.Next(0, 7);

                                proficiencyRestrictions = new int[] { 2, 4 };
                                extraProficiencies = rng.Next(0, 4);

                                numReason = 2;
                                numFaith = 2;
                                spellRankMax = 8;

                                randDefAb = randDefAb && settings.randUniClassDefAb;
                                numEquippedAbilities = rng.Next(settings.uniClassDefAbCountMin, settings.uniClassDefAbCountMax + 1);
                                break;
                        }

                    changelog += "\n\n\t" + (classNames[index] != null ? classNames[index] : "(nameless)");
                    changelog += "\nClass ID:\t\t" + index;

                    if (randStatBoosts)
                    {
                        while (numPosStatBoosts + numNegStatBoosts > 9)
                        {
                            if (rng.Next(0, 2) == 0)
                                numPosStatBoosts--;
                            else
                                numNegStatBoosts--;
                        }
                        for (int i = 0; i < numPosStatBoosts;)
                        {
                            int selector = rng.Next(0, 9);
                            if (statBoosts[selector] == 0)
                            {
                                statBoosts[selector] = rng.Next(statBoostPosRestrictions[0], statBoostPosRestrictions[1]);
                                i++;
                            }
                        }
                        for (int i = 0; i < numNegStatBoosts;)
                        {
                            int selector = rng.Next(0, 9);
                            if (statBoosts[selector] == 0)
                            {
                                statBoosts[selector] = rng.Next(statBoostNegRestrictions[0], statBoostNegRestrictions[1]);
                                i++;
                            }
                        }
                        classData[classBlockStart + blockMod + 16L] = (byte)statBoosts[0]; // Class boosts
                        classData[classBlockStart + blockMod + 39L] = (byte)statBoosts[1];
                        classData[classBlockStart + blockMod + 40L] = (byte)statBoosts[2];
                        classData[classBlockStart + blockMod + 41L] = (byte)statBoosts[3];
                        classData[classBlockStart + blockMod + 42L] = (byte)statBoosts[4];
                        classData[classBlockStart + blockMod + 43L] = (byte)statBoosts[5];
                        classData[classBlockStart + blockMod + 44L] = (byte)statBoosts[6];
                        classData[classBlockStart + blockMod + 45L] = (byte)statBoosts[7];
                        classData[classBlockStart + blockMod + 46L] = (byte)moveBoost;
                        classData[classBlockStart + blockMod + 47L] = (byte)statBoosts[8];

                        changelog += "\nStat Boosts:\t\t" +
                            statBoosts[0] + "HP\t" +
                            statBoosts[1] + "Str\t" +
                            statBoosts[2] + "Mag\t" +
                            statBoosts[3] + "Dex\t" +
                            statBoosts[4] + "Spd\t" +
                            statBoosts[5] + "Lck\t" +
                            statBoosts[6] + "Def\t" +
                            statBoosts[7] + "Res\t" +
                            statBoosts[8] + "Cha\t" +
                            moveBoost + "Mv";
                    }
                    if (settings.randAdjutant)
                        classData[(long)classBlockStart + blockMod + 18L] = (byte)rng.Next(1, 4); // Adjutant type

                    if (randEnemyGrowths)
                    {
                        while (numPosEnemyGrowths + numNegEnemyGrowths > 9)
                        {
                            if (rng.Next(0, 2) == 0)
                                numPosEnemyGrowths--;
                            else
                                numNegEnemyGrowths--;
                        }
                        for (int i = 0; i < numPosEnemyGrowths;)
                        {
                            int selector = rng.Next(0, 9);
                            if (enemyGrowths[selector] == 0)
                            {
                                enemyGrowths[selector] = (int)Math.Round(rng.Next(enemyGrowthsPosRestrictions[0], enemyGrowthsPosRestrictions[1]) / 5.0) * 5;
                                i++;
                            }
                        }
                        for (int i = 0; i < numNegEnemyGrowths;)
                        {
                            int selector = rng.Next(0, 9);
                            if (enemyGrowths[selector] == 0)
                            {
                                enemyGrowths[selector] = (int)Math.Round(rng.Next(enemyGrowthsNegRestrictions[0], enemyGrowthsNegRestrictions[1]) / 5.0) * 5;
                                i++;
                            }
                        }

                        classData[classBlockStart + blockMod + 19L] = (byte)enemyGrowths[0]; // Enemy growths
                        classData[classBlockStart + blockMod + 30L] = (byte)enemyGrowths[1];
                        classData[classBlockStart + blockMod + 31L] = (byte)enemyGrowths[2];
                        classData[classBlockStart + blockMod + 32L] = (byte)enemyGrowths[3];
                        classData[classBlockStart + blockMod + 33L] = (byte)enemyGrowths[4];
                        classData[classBlockStart + blockMod + 34L] = (byte)enemyGrowths[5];
                        classData[classBlockStart + blockMod + 35L] = (byte)enemyGrowths[6];
                        classData[classBlockStart + blockMod + 36L] = (byte)enemyGrowths[7];
                        classData[classBlockStart + blockMod + 38L] = (byte)enemyGrowths[8];

                        changelog += "\nGrowths (Enemies):\t" +
                            enemyGrowths[0] + "HP\t" +
                            enemyGrowths[1] + "Str\t" +
                            enemyGrowths[2] + "Mag\t" +
                            enemyGrowths[3] + "Dex\t" +
                            enemyGrowths[4] + "Spd\t" +
                            enemyGrowths[5] + "Lck\t" +
                            enemyGrowths[6] + "Def\t" +
                            enemyGrowths[7] + "Res\t" +
                            enemyGrowths[8] + "Cha";

                        if (p(randMoveEnemyGrowthsP))
                            classData[classBlockStart + blockMod + 37L] = (byte)moveEnemyGrowth;

                        changelog += "\t" +
                            moveEnemyGrowth + "Mv";
                    }

                    if (randPlayerGrowths)
                    {
                        while (numPosPlayerGrowths + numNegPlayerGrowths > 9)
                        {
                            if (rng.Next(0, 2) == 0)
                                numPosPlayerGrowths--;
                            else
                                numNegPlayerGrowths--;
                        }
                        for (int i = 0; i < numPosPlayerGrowths;)
                        {
                            int selector = rng.Next(0, 9);
                            if (playerGrowths[selector] == 0)
                            {
                                playerGrowths[selector] = (int)Math.Round(rng.Next(playerGrowthsPosRestrictions[0], playerGrowthsPosRestrictions[1]) / 5.0) * 5;
                                i++;
                            }
                        }
                        for (int i = 0; i < numNegPlayerGrowths;)
                        {
                            int selector = rng.Next(0, 9);
                            if (playerGrowths[selector] == 0)
                            {
                                playerGrowths[selector] = (int)Math.Round(rng.Next(playerGrowthsNegRestrictions[0], playerGrowthsNegRestrictions[1]) / 5.0) * 5;
                                i++;
                            }
                        }
                        classData[classBlockStart + blockMod + 20L] = (byte)playerGrowths[0]; // Player growths
                        classData[classBlockStart + blockMod + 21L] = (byte)playerGrowths[1];
                        classData[classBlockStart + blockMod + 22L] = (byte)playerGrowths[2];
                        classData[classBlockStart + blockMod + 23L] = (byte)playerGrowths[3];
                        classData[classBlockStart + blockMod + 24L] = (byte)playerGrowths[4];
                        classData[classBlockStart + blockMod + 25L] = (byte)playerGrowths[5];
                        classData[classBlockStart + blockMod + 26L] = (byte)playerGrowths[6];
                        classData[classBlockStart + blockMod + 27L] = (byte)playerGrowths[7];
                        classData[classBlockStart + blockMod + 29L] = (byte)playerGrowths[8];

                        changelog += "\nGrowths (Player):\t" +
                            playerGrowths[0] + "HP\t" +
                            playerGrowths[1] + "Str\t" +
                            playerGrowths[2] + "Mag\t" +
                            playerGrowths[3] + "Dex\t" +
                            playerGrowths[4] + "Spd\t" +
                            playerGrowths[5] + "Lck\t" +
                            playerGrowths[6] + "Def\t" +
                            playerGrowths[7] + "Res\t" +
                            playerGrowths[8] + "Cha";

                        if (p(randMovePlayerGrowthsP))
                            classData[classBlockStart + blockMod + 28L] = (byte)movePlayerGrowth;

                        changelog += "\t" +
                            classData[classBlockStart + blockMod + 28L] + "Mv";
                    }

                    if (msgLoaded && settings.changeMsg && settings.qolText && numPosPlayerGrowths + numNegPlayerGrowths > 0)
                    {
                        string classDescription = "Growth rate bonuses:";
                        int descriptionWordCount = 2;
                        for (int i = 0; i < 10; i++)
                            if (classData[classBlockStart + blockMod + 20L + i] != 0)
                            {
                                if (descriptionWordCount > 2)
                                    classDescription += ",";
                                if (descriptionWordCount % 4 == 0)
                                    classDescription += "\n";
                                else
                                    classDescription += " ";
                                classDescription += ((sbyte)classData[classBlockStart + blockMod + 20L + i] > 0 ? "+" : "") + (sbyte)classData[classBlockStart + blockMod + 20L + i] + "% " + (i == 0 ? "HP" : getStatName(i - 1));
                                descriptionWordCount++;
                            }
                        classDescription += ".";
                        msgStrings[10460 + index] = classDescription;
                    }

                    if (randMountBoosts)
                    {
                        while (numPosMountBoosts + numNegMountBoosts > 9)
                        {
                            if (rng.Next(0, 2) == 0)
                                numPosMountBoosts--;
                            else
                                numNegMountBoosts--;
                        }
                        for (int i = 0; i < numPosMountBoosts;)
                        {
                            int selector = rng.Next(0, 8);
                            if (mountBoosts[selector] == 0)
                            {
                                mountBoosts[selector] = rng.Next(mountBoostPosRestrictions[0], mountBoostPosRestrictions[1]);
                                i++;
                            }
                        }
                        for (int i = 0; i < numNegMountBoosts;)
                        {
                            int selector = rng.Next(0, 8);
                            if (mountBoosts[selector] == 0)
                            {
                                mountBoosts[selector] = rng.Next(mountBoostNegRestrictions[0], mountBoostNegRestrictions[1]);
                                i++;
                            }
                        }
                        classData[classBlockStart + blockMod + 48L] = (byte)mountBoosts[0]; // Mounting boosts
                        classData[classBlockStart + blockMod + 49L] = (byte)mountBoosts[1];
                        classData[classBlockStart + blockMod + 50L] = (byte)mountBoosts[2];
                        classData[classBlockStart + blockMod + 51L] = (byte)mountBoosts[3];
                        classData[classBlockStart + blockMod + 52L] = (byte)mountBoosts[4];
                        classData[classBlockStart + blockMod + 53L] = (byte)mountBoosts[5];
                        classData[classBlockStart + blockMod + 54L] = (byte)mountBoosts[6];
                        classData[classBlockStart + blockMod + 56L] = (byte)mountBoosts[7];
                        classData[classBlockStart + blockMod + 55L] = (byte)moveMountBoost;
                    }

                    if (settings.specialToAdv)
                    {
                        classData[classBlockStart + blockMod + 69L] = (byte)classTier; // Class tier

                        changelog += "\nClass Tier:\t\t" + classTier;
                    }

                    if (randMasteryReq)
                    {
                        classData[classBlockStart + blockMod + 74L] = (byte)masteryReq; // Mastery Requirement

                        changelog += "\nMastery EXP Req.:\t" + masteryReq;
                    }

                    if (randBases)
                    {
                        classData[classBlockStart + blockMod + 75L] = (byte)baseHP; // Base Stats
                        classData[classBlockStart + blockMod + 85L] = (byte)baseStr;
                        classData[classBlockStart + blockMod + 86L] = (byte)baseMag;
                        classData[classBlockStart + blockMod + 87L] = (byte)baseDex;
                        classData[classBlockStart + blockMod + 88L] = (byte)baseSpd;
                        classData[classBlockStart + blockMod + 89L] = (byte)baseLck;
                        classData[classBlockStart + blockMod + 90L] = (byte)baseDef;
                        classData[classBlockStart + blockMod + 91L] = (byte)baseRes;
                        classData[classBlockStart + blockMod + 93L] = (byte)baseCha;

                        changelog += "\nBase Stats:\t\t" +
                            baseHP + "HP\t" +
                            baseStr + "Str\t" +
                            baseMag + "Mag\t" +
                            baseDex + "Dex\t" +
                            baseSpd + "Spd\t" +
                            baseLck + "Lck\t" +
                            baseDef + "Def\t" +
                            baseRes + "Res\t" +
                            baseCha + "Cha\t";
                    }

                    if (settings.randExpYield)
                    {
                        classData[classBlockStart + blockMod + 76L] = (byte)expYield; // Exp yield
                        changelog += "\nEXP Yield:\t\t" + expYield;
                    }

                    int[] weaponTypes = { 0, 0 };

                    if (settings.removeWeaponRestrictions && settings.randWeaponTypes)
                    {
                        if (numWeaponTypes == 1)
                        {
                            weaponTypes[0] = rng.Next(0, 7);
                            if (weaponTypes[0] == 5 && rng.Next(0, 2) == 0)
                                weaponTypes[0] = 7;
                            weaponTypes[1] = 0;
                        }
                        else if (numWeaponTypes == 2)
                        {
                            while (weaponTypes[0] == weaponTypes[1])
                            {
                                weaponTypes[0] = rng.Next(0, 7);
                                if (weaponTypes[0] == 5 && rng.Next(0, 2) == 0)
                                    weaponTypes[0] = 7;
                                weaponTypes[1] = rng.Next(0, 7);
                                if (weaponTypes[1] == 5 && rng.Next(0, 2) == 0)
                                    weaponTypes[1] = 7;
                            }
                            if (weaponTypes[0] > weaponTypes[1])
                            {
                                int a = weaponTypes[0];
                                weaponTypes[0] = weaponTypes[1];
                                weaponTypes[1] = a;
                            }
                        }
                        classData[classBlockStart + blockMod + 79L] = (byte)weaponTypes[0]; // Weapon types
                        classData[classBlockStart + blockMod + 80L] = (byte)weaponTypes[1];

                        changelog += "\nWeapon type:\t\t" + getWeaponType(weaponTypes[0]);
                        changelog += "\n2nd Weapon type:\t" + (weaponTypes[1] != 0 ? getWeaponType(weaponTypes[1]) : "None");
                    }
                    else
                    {
                        weaponTypes[0] = classData[classBlockStart + blockMod + 79L];
                        weaponTypes[1] = classData[classBlockStart + blockMod + 80L];
                    }

                    classWeaponTypes[index] = new List<int>();
                    classWeaponTypes[index].Add(weaponTypes[0]);
                    if (weaponTypes[1] != 0)
                        classWeaponTypes[index].Add(weaponTypes[1]);

                    int[] typingBits = { 0, 0, 0, 0, 0, 0, 0, 0 };

                    if (settings.randTyping)
                    {
                        if (monster && rng.Next(0, 2) == 0)
                        {
                            typingBits[5] = 1;
                            specialUnitTypings--;
                        }
                        if (rng.Next(0, 2) == 0 || monster)
                            for (int i = 0; i < specialUnitTypings;)
                            {
                                int selector = rng.Next(0, 6);
                                if (typingBits[selector] == 0)
                                {
                                    typingBits[selector] = 1;
                                    i++;
                                }
                            }
                        else if (!monster)
                            typingBits[0] = 1;
                        changelog += "\nClass Typings:\t";
                        int typingByte = 0;
                        for (int i = 0; i < typingBits.Length; i++)
                            if (typingBits[i] == 1)
                            {
                                typingByte += (int)Math.Pow(2, i);
                                changelog += "\t" + getClassTyping(i);
                            }
                        classData[classBlockStart + blockMod + 81L] = (byte)typingByte; // Class typing
                    }
                    else
                        typingBits = toBits(classData[classBlockStart + blockMod + 81L]);

                    bool hasHorse = false;
                    bool hasWyvern = false;
                    bool hasPegasus = false;
                    byte[] aniSets = { 0, 0 };
                    if (typingBits[3] == 1 && typingBits[1] == 1) // Armored flier
                    {
                        if (settings.baseMovTypes)
                        {
                            movementTypes[0] = 6;
                            movementTypes[1] = 1;
                        }

                        aniSets[1] = 1;

                        if (rng.Next(0, 2) == 0)
                            hasWyvern = true;
                        else
                            hasPegasus = true;
                    }
                    else if (typingBits[2] == 1 && typingBits[1] == 1) // Armored cavalry
                    {
                        if (settings.baseMovTypes)
                        {
                            movementTypes[0] = 3;
                            movementTypes[1] = 1;
                        }

                        if (settings.randMounts)
                            aniSets[0] = 2;

                        aniSets[1] = 1;

                        hasHorse = true;
                    }
                    else if (typingBits[1] == 1) // Armored
                    {
                        if (settings.baseMovTypes)
                        {
                            movementTypes[0] = 1;
                            movementTypes[1] = 1;
                        }

                        aniSets[0] = 1;
                        aniSets[1] = 1;
                    }
                    else if (typingBits[3] == 1) // Flier
                    {
                        if (settings.baseMovTypes)
                            movementTypes[0] = 6;

                        if (rng.Next(0, 2) == 0)
                            hasWyvern = true;
                        else
                            hasPegasus = true;
                    }
                    else if (typingBits[2] == 1) // Cavalry
                    {
                        if (settings.baseMovTypes)
                            movementTypes[0] = 2;

                        if (settings.randMounts)
                            aniSets[0] = 2;

                        hasHorse = true;
                    }

                    if (settings.randMovTypes)
                    {
                        classData[classBlockStart + blockMod + 77L] = (byte)movementTypes[0]; // Movement type
                        classData[classBlockStart + blockMod + 78L] = (byte)movementTypes[1]; // Dismounted movement type

                        changelog += "\nMovement Type:\t\t" + getMovementType(movementTypes[0]);
                    }

                    if (typingBits[2] == 1 || typingBits[3] == 1)
                    {
                        if (settings.randMovTypes)
                            changelog += "\nDismounted Movement:\t" + getMovementType(movementTypes[1]);

                        if (randMountBoosts)
                            changelog += "\nMounting Boosts:\t\t" +
                                mountBoosts[0] + "Str\t" +
                                mountBoosts[1] + "Mag\t" +
                                mountBoosts[2] + "Dex\t" +
                                mountBoosts[3] + "Spd\t" +
                                mountBoosts[4] + "Lck\t" +
                                mountBoosts[5] + "Def\t" +
                                mountBoosts[6] + "Res\t" +
                                mountBoosts[7] + "Cha\t" +
                                moveMountBoost + "Mv";
                    }

                    short short0L = 190;
                    short short2L = 15;
                    short short4L = 15;
                    short short6L = 30;
                    short short12L = 120;
                    short short14L = 75;
                    byte byte17L = 255;
                    byte dismountedScale = 100;
                    byte mountScale = 0;
                    if (hasHorse)
                    {
                        short0L = 200;
                        short2L = -100;
                        short4L = -110;
                        short6L = -70;
                        short12L = 160;
                        short14L = 90;

                        byte[] mounts = { 0, 1, 2, 3, 4, 5, 12 };
                        byte17L = mounts[rng.Next(0, mounts.Length)];

                        dismountedScale = 75;
                        mountScale = 100;
                    }
                    else if (hasWyvern)
                    {
                        short0L = 345;
                        short2L = -90;
                        short4L = -100;
                        short6L = -50;
                        short12L = 200;
                        short14L = 120;

                        byte[] mounts = { 6, 7, 10 };
                        byte17L = mounts[rng.Next(0, mounts.Length)];

                        if (settings.randMounts)
                            aniSets[0] = 5;

                        dismountedScale = 50;
                        mountScale = 100;
                    }
                    else if (hasPegasus)
                    {
                        short0L = 245;
                        short2L = -100;
                        short4L = -110;
                        short6L = -70;
                        short12L = 170;
                        short14L = 90;

                        byte[] mounts = { 8, 9, 11 };
                        byte17L = mounts[rng.Next(0, mounts.Length)];

                        if (settings.randMounts)
                            aniSets[0] = 4;

                        dismountedScale = 50;
                        mountScale = 100;
                    }

                    if (!monster)
                    {
                        if (settings.randMounts)
                        {
                            byte[] bytes0L = BitConverter.GetBytes(short0L);
                            byte[] bytes2L = BitConverter.GetBytes(short2L);
                            byte[] bytes4L = BitConverter.GetBytes(short4L);
                            byte[] bytes6L = BitConverter.GetBytes(short6L);
                            byte[] bytes12L = BitConverter.GetBytes(short12L);
                            byte[] bytes14L = BitConverter.GetBytes(short14L);
                            classData[classBlockStart + blockMod + 0L] = bytes0L[0]; // Camera adjustments for mounted units
                            classData[classBlockStart + blockMod + 1L] = bytes0L[1];
                            classData[classBlockStart + blockMod + 2L] = bytes2L[0];
                            classData[classBlockStart + blockMod + 3L] = bytes2L[1];
                            classData[classBlockStart + blockMod + 4L] = bytes4L[0];
                            classData[classBlockStart + blockMod + 5L] = bytes4L[1];
                            classData[classBlockStart + blockMod + 6L] = bytes6L[0];
                            classData[classBlockStart + blockMod + 7L] = bytes6L[1];
                            classData[classBlockStart + blockMod + 12L] = bytes12L[0];
                            classData[classBlockStart + blockMod + 13L] = bytes12L[1];
                            classData[classBlockStart + blockMod + 14L] = bytes14L[0];
                            classData[classBlockStart + blockMod + 15L] = bytes14L[1];
                            classData[classBlockStart + blockMod + 17L] = byte17L; // Mount model
                            classData[classBlockStart + blockMod + 70L] = mountScale; // Mount map scale
                            classData[classBlockStart + blockMod + 71L] = dismountedScale;
                        }
                        if (actLoaded)
                        {
                            bool mounted = hasHorse || hasPegasus || hasWyvern;
                            if ((mounted && settings.randMounts) || (settings.setArmorAni && !mounted))
                            {
                                actData[classAniSetStart + aniSetMod + 0L] = aniSets[0]; // Animation set
                            }
                            if (settings.setArmorAni)
                                actData[classAniSetStart + aniSetMod + 1L] = aniSets[1]; // Dismounted animation set
                        }
                    }

                    if (settings.unitsToScale)
                    {
                        classData[classBlockStart + blockMod + 71L] = (byte)75; // Unit map scale
                    }

                    int[] proficiencies = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    List<int> secondaryWeaponTypes = new List<int>();
                    List<int> typeSkills = new List<int>();
                    if (typingBits[1] == 1)
                    {
                        if (settings.baseClassProf)
                            proficiencies[8] = proficiencyRestrictions[1] - 1;
                        typeSkills.Add(8);
                    }
                    if (typingBits[2] == 1)
                    {
                        if (settings.baseClassProf)
                            proficiencies[9] = proficiencyRestrictions[1] - 1;
                        typeSkills.Add(9);
                    }
                    if (typingBits[3] == 1)
                    {
                        if (settings.baseClassProf)
                            proficiencies[10] = proficiencyRestrictions[1] - 1;
                        typeSkills.Add(10);
                    }

                    if (settings.baseClassProf)
                    {
                        if (weaponTypes[0] == 7)
                            proficiencies[5] = proficiencyRestrictions[1] - 1;
                        else
                            proficiencies[weaponTypes[0]] = proficiencyRestrictions[1] - 1;
                        if (weaponTypes[1] != 0)
                        {
                            if (weaponTypes[1] == 7)
                                proficiencies[5] = proficiencyRestrictions[1] - 1;
                            else
                                proficiencies[weaponTypes[1]] = proficiencyRestrictions[1] - 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < numWeaponTypes; i++)
                            proficiencies[rng.Next(0, 11)] = proficiencyRestrictions[1] - 1;

                        for (int i = 0; i < extraProficiencies;)
                        {
                            int selector = rng.Next(0, 8);
                            if (proficiencies[selector] == 0)
                            {
                                proficiencies[selector] = rng.Next(proficiencyRestrictions[0], proficiencyRestrictions[1]);
                                i++;
                            }
                        }

                        for (int i = 0; i < extraProficiencies; i++)
                            secondaryWeaponTypes.Add(rng.Next(0, 11));
                    }

                    if (settings.baseClassProf)
                        for (int i = 0; i < extraProficiencies;)
                        {
                            int selector = rng.Next(0, 8);
                            if (proficiencies[selector] == 0)
                            {
                                proficiencies[selector] = rng.Next(proficiencyRestrictions[0], proficiencyRestrictions[1]);
                                secondaryWeaponTypes.Add(selector);
                                i++;
                            }
                        }

                    if (settings.randClassProf)
                    {
                        classData[classBlockStart + blockMod + 57L] = (byte)proficiencies[0]; // Class proficiencies
                        classData[classBlockStart + blockMod + 58L] = (byte)proficiencies[1];
                        classData[classBlockStart + blockMod + 59L] = (byte)proficiencies[2];
                        classData[classBlockStart + blockMod + 60L] = (byte)proficiencies[3];
                        classData[classBlockStart + blockMod + 61L] = (byte)proficiencies[4];
                        classData[classBlockStart + blockMod + 62L] = (byte)proficiencies[5];
                        classData[classBlockStart + blockMod + 63L] = (byte)proficiencies[6];
                        classData[classBlockStart + blockMod + 64L] = (byte)proficiencies[7];
                        classData[classBlockStart + blockMod + 65L] = (byte)proficiencies[8];
                        classData[classBlockStart + blockMod + 66L] = (byte)proficiencies[9];
                        classData[classBlockStart + blockMod + 67L] = (byte)proficiencies[10];

                        changelog += "\nProficiencies:\t\t" +
                            proficiencies[0] + "Swo\t" +
                            proficiencies[1] + "Lan\t" +
                            proficiencies[2] + "Axe\t" +
                            proficiencies[3] + "Bow\t" +
                            proficiencies[4] + "Bra\t" +
                            proficiencies[5] + "Rea\t" +
                            proficiencies[6] + "Fai\t" +
                            proficiencies[7] + "Aut\t" +
                            proficiencies[8] + "HeA\t" +
                            proficiencies[9] + "Rid\t" +
                            proficiencies[10] + "Fly";
                    }

                    int classPropertiesByte = classData[classBlockStart + blockMod + 82L];
                    int[] classPropertiesBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int i = 0; i < 8; i++)
                    {
                        int selector = 7 - i;
                        if (classPropertiesByte >= (int)Math.Pow(2, selector))
                        {
                            classPropertiesBits[selector] = 1;
                            classPropertiesByte -= (int)Math.Pow(2, selector);
                        }
                    }
                    classPropertiesBits[0] = 0; // Mounted
                    classPropertiesBits[2] = 0; // Flying
                    if (settings.removeWeaponRestrictions)
                    {
                        classPropertiesBits[1] = 1; // Brawling
                        classPropertiesBits[3] = 1; // Magic
                    }
                    if (typingBits[2] == 1)
                        classPropertiesBits[0] = 1;
                    if (typingBits[3] == 1)
                    {
                        classPropertiesBits[0] = 1;
                        classPropertiesBits[2] = 1;
                    }
                    for (int i = 0; i < classPropertiesBits.Length; i++)
                        if (classPropertiesBits[i] == 1)
                            classPropertiesByte += (int)Math.Pow(2, i);
                    classData[classBlockStart + blockMod + 82L] = (byte)classPropertiesByte; // Class properties

                    if (settings.removeWeaponRestrictions && settings.randWeaponTypes && !monster)
                    {
                        int[] defaultSpells = { 38, 38 };
                        if (weaponTypes.Contains(5))
                        {
                            if (weaponTypes.Contains(6))
                            {
                                defaultSpells[0] = getSpell(5, spellRankMax, false, true);
                                defaultSpells[1] = getSpell(6, spellRankMax, false, true);
                            }
                            else if (weaponTypes.Contains(7))
                            {
                                defaultSpells[0] = getSpell(5, spellRankMax, false, true);
                                defaultSpells[1] = getSpell(7, spellRankMax, false, true);
                            }
                            else
                            {
                                for (int i = 0; i < numReason; i++)
                                {
                                    defaultSpells[i] = getSpell(5, spellRankMax, false, true);
                                }
                            }
                        }
                        else if (weaponTypes.Contains(6))
                        {
                            if (weaponTypes.Contains(7))
                            {
                                defaultSpells[0] = getSpell(7, spellRankMax, false, true);
                                defaultSpells[1] = getSpell(6, spellRankMax, false, true);
                            }
                            else
                            {
                                for (int i = 0; i < numFaith; i++)
                                {
                                    defaultSpells[i] = getSpell(6, spellRankMax, false, true);
                                }
                            }
                        }
                        else if (weaponTypes.Contains(7))
                        {
                            for (int i = 0; i < numReason; i++)
                            {
                                defaultSpells[i] = getSpell(7, spellRankMax, false, true);
                            }
                        }
                        classData[classBlockStart + blockMod + 83L] = (byte)defaultSpells[0]; // Default spells
                        classData[classBlockStart + blockMod + 84L] = (byte)defaultSpells[1];

                        changelog += "\nDefault Spell 1:\t" + spellNames[defaultSpells[0]];
                        changelog += "\nDefault Spell 2:\t" + spellNames[defaultSpells[1]];
                    }

                    List<int> abilityPool = new List<int>();

                    if (settings.baseClassAb)
                    {
                        abilityPool.AddRange(genericAbilities);
                        for (int i = 0; i < numWeaponTypes && !monster; i++)
                        {
                            switch (weaponTypes[i])
                            {
                                case 0:
                                    if (i == 1)
                                        addMissingAbilities(ref abilityPool, swordAbilities);
                                    break;
                                case 1:
                                    addMissingAbilities(ref abilityPool, lanceAbilities);
                                    break;
                                case 2:
                                    addMissingAbilities(ref abilityPool, axeAbilities);
                                    break;
                                case 3:
                                    addMissingAbilities(ref abilityPool, bowAbilities);
                                    break;
                                case 4:
                                    addMissingAbilities(ref abilityPool, brawlAbilities);
                                    break;
                                case 5:
                                    addMissingAbilities(ref abilityPool, blackAbilities);
                                    break;
                                case 6:
                                    addMissingAbilities(ref abilityPool, faithAbilities);
                                    break;
                                case 7:
                                    addMissingAbilities(ref abilityPool, darkAbilities);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 252; i++)
                            abilityPool.Add(i);
                        for (int i = 0; i < badAbilities.Length; i++)
                            abilityPool.Remove(badAbilities[i]);
                    }

                    if (randDefAb)
                    {
                        int[] equippedAbilities = { 255, 255, 255, 255, 255 };
                        for (int i = 0; i < numEquippedAbilities; i++)
                            equippedAbilities[i] = abilityPool[rng.Next(0, abilityPool.Count)];

                        for (int i = 0; i < 5; i++)
                        {
                            classData[classBlockStart + blockMod + 98L + (long)i] = (byte)equippedAbilities[i]; // Default equipped abilities
                            classData[classBlockStart + blockMod + 103L + (long)i] = (byte)equippedAbilities[i];
                            classData[classBlockStart + blockMod + 108L + (long)i] = (byte)equippedAbilities[i];
                            classData[classBlockStart + blockMod + 113L + (long)i] = (byte)equippedAbilities[i];
                        }

                        changelog += "\nDefault Abilities:";
                        for (int i = 0; i < numEquippedAbilities; i++)
                            changelog += "\t" + abilityNames[equippedAbilities[i]];
                        if (numEquippedAbilities == 0)
                            changelog += "\tNone";
                    }

                    List<int> mainCertSkills = new List<int>();
                    List<int> secondaryCertSkills = new List<int>();
                    List<int> typeCertSkills = new List<int>();
                    int[] mainWeaponRankRestrictions = { 0, 0 };
                    int[] otherRankRestrictions = { 0, 0 };
                    int[] typeSkillRankRestrictions = { 0, 0 };
                    bool randCert = false;

                    switch (classTier)
                    {
                        case 0:
                            if (monster)
                            {
                                randCert = settings.randCert && settings.randMonCert;
                                mainWeaponRankRestrictions = new int[] { settings.mainMonCertMin, settings.mainMonCertMax + 1 };
                                typeSkillRankRestrictions = new int[] { settings.typeMonCertMin, settings.typeMonCertMax + 1 };
                                otherRankRestrictions = new int[] { settings.otherMonCertMin, settings.otherMonCertMax + 1 };
                                if (rng.Next(0, 3) == 0 && secondaryWeaponTypes.Count > 0 && otherRankRestrictions[1] > 1)
                                    secondaryCertSkills.Add(secondaryWeaponTypes[rng.Next(0, secondaryWeaponTypes.Count)]);
                            }
                            else
                            {
                                randCert = settings.randCert && settings.randStaCert;
                                mainWeaponRankRestrictions = new int[] { settings.mainStaCertMin, settings.mainStaCertMax + 1 };
                                typeSkillRankRestrictions = new int[] { settings.typeStaCertMin, settings.typeStaCertMax + 1 };
                                otherRankRestrictions = new int[] { settings.otherStaCertMin, settings.otherStaCertMax + 1 };
                                if (rng.Next(0, 3) == 0 && secondaryWeaponTypes.Count > 0 && otherRankRestrictions[1] > 1)
                                    secondaryCertSkills.Add(secondaryWeaponTypes[rng.Next(0, secondaryWeaponTypes.Count)]);
                            }
                            break;
                        case 1:
                            randCert = settings.randCert && settings.randBegCert;
                            mainWeaponRankRestrictions = new int[] { settings.mainBegCertMin, settings.mainBegCertMax + 1 };
                            typeSkillRankRestrictions = new int[] { settings.typeBegCertMin, settings.typeBegCertMax + 1 };
                            otherRankRestrictions = new int[] { settings.otherBegCertMin, settings.otherBegCertMax + 1 };
                            for (int i = 0; i < secondaryWeaponTypes.Count && otherRankRestrictions[1] > 1; i++)
                                secondaryCertSkills.Add(secondaryWeaponTypes[i]);
                            break;
                        case 2:
                            randCert = settings.randCert && settings.randIntCert;
                            mainWeaponRankRestrictions = new int[] { settings.mainIntCertMin, settings.mainIntCertMax + 1 };
                            typeSkillRankRestrictions = new int[] { settings.typeIntCertMin, settings.typeIntCertMax + 1 };
                            otherRankRestrictions = new int[] { settings.otherIntCertMin, settings.otherIntCertMax + 1 };
                            if (rng.Next(0, 3) == 0 && secondaryWeaponTypes.Count > 0 && otherRankRestrictions[1] > 1)
                                secondaryCertSkills.Add(secondaryWeaponTypes[rng.Next(0, secondaryWeaponTypes.Count)]);
                            break;
                        case 3:
                            randCert = settings.randCert && settings.randAdvCert;
                            mainWeaponRankRestrictions = new int[] { settings.mainAdvCertMin, settings.mainAdvCertMax + 1 };
                            typeSkillRankRestrictions = new int[] { settings.typeAdvCertMin, settings.typeAdvCertMax + 1 };
                            otherRankRestrictions = new int[] { settings.otherAdvCertMin, settings.otherAdvCertMax + 1 };
                            if (rng.Next(0, 3) == 0 && secondaryWeaponTypes.Count > 0 && otherRankRestrictions[1] > 1)
                                secondaryCertSkills.Add(secondaryWeaponTypes[rng.Next(0, secondaryWeaponTypes.Count)]);
                            break;
                        case 4:
                            randCert = settings.randCert && settings.randMasCert;
                            mainWeaponRankRestrictions = new int[] { settings.mainMasCertMin, settings.mainMasCertMax + 1 };
                            typeSkillRankRestrictions = new int[] { settings.typeMasCertMin, settings.typeMasCertMax + 1 };
                            otherRankRestrictions = new int[] { settings.otherMasCertMin, settings.otherMasCertMax + 1 };
                            if (secondaryWeaponTypes.Count > 0 && otherRankRestrictions[1] > 1)
                                secondaryCertSkills.Add(secondaryWeaponTypes[rng.Next(0, secondaryWeaponTypes.Count)]);
                            break;
                        case 6:
                            randCert = settings.randCert && settings.randUniCert;
                            mainWeaponRankRestrictions = new int[] { settings.mainUniCertMin, settings.mainUniCertMax + 1 };
                            typeSkillRankRestrictions = new int[] { settings.typeUniCertMin, settings.typeUniCertMax + 1 };
                            otherRankRestrictions = new int[] { settings.otherUniCertMin, settings.otherUniCertMax + 1 };
                            if (rng.Next(0, 3) == 0 && otherRankRestrictions[1] > 1 && secondaryWeaponTypes.Count > 0)
                                secondaryCertSkills.Add(secondaryWeaponTypes[rng.Next(0, secondaryWeaponTypes.Count)]);
                            break;
                    }

                    if (weaponTypes[0] == 7)
                        mainCertSkills.Add(5);
                    else
                        mainCertSkills.Add(weaponTypes[0]);
                    if (weaponTypes[1] != 0)
                    {
                        if (weaponTypes[1] == 7)
                            mainCertSkills.Add(5);
                        else
                            mainCertSkills.Add(weaponTypes[1]);
                    }
                    for (int i = 0; i < typeSkills.Count && typeSkillRankRestrictions[1] > 1; i++)
                        typeCertSkills.Add(typeSkills[i]);

                    if (settings.randCertItem)
                    {
                        int certItem = classData[classCertStart + certMod + 1L];

                        if (settings.allowNonSealCertItems)
                        {
                            certItem = obtainableItems[rng.Next(0, obtainableItems.Length)];
                        }
                        else
                        {
                            if (classTier == 2 || classTier == 3)
                            {
                                certItem = classTier == 2 ? 3 : 4;
                                if (rng.Next(0, 15) == 0)
                                    certItem = 157;
                                else if (classTier == 3 && rng.Next(0, 4) == 0)
                                    certItem = 159;
                            }
                        }

                        classData[classCertStart + certMod + 1L] = (byte)certItem; // Certification item

                        if (certItem != 255)
                            changelog += "\nCertification Item:\t" + itemNames[certItem];
                    }
                    if (settings.removeGenderRestrictions)
                    {
                        classData[classCertStart + certMod + 3L] = (byte)2; // Gender availability
                    }

                    int[] certificationReqs = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    if (randCert)
                    {
                        int skillCount = 0;
                        if (settings.baseCert)
                        {
                            for (int i = 0; i < mainCertSkills.Count && skillCount < 3; i++)
                            {
                                certificationReqs[mainCertSkills[i]] = rng.Next(mainWeaponRankRestrictions[0], mainWeaponRankRestrictions[1]);
                                skillCount++;
                            }
                            for (int i = 0; i < typeCertSkills.Count && skillCount < 3; i++)
                            {
                                certificationReqs[typeCertSkills[i]] = rng.Next(typeSkillRankRestrictions[0], typeSkillRankRestrictions[1]);
                                skillCount++;
                            }
                            for (int i = 0; i < secondaryCertSkills.Count && skillCount < 3; i++)
                            {
                                certificationReqs[secondaryCertSkills[i]] = rng.Next(otherRankRestrictions[0], otherRankRestrictions[1]);
                                skillCount++;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < mainCertSkills.Count && skillCount < 3; i++)
                            {
                                certificationReqs[rng.Next(0, 11)] = rng.Next(mainWeaponRankRestrictions[0], mainWeaponRankRestrictions[1]);
                                skillCount++;
                            }
                            for (int i = 0; i < typeCertSkills.Count && skillCount < 3; i++)
                            {
                                certificationReqs[rng.Next(0, 11)] = rng.Next(typeSkillRankRestrictions[0], typeSkillRankRestrictions[1]);
                                skillCount++;
                            }
                            for (int i = 0; i < secondaryCertSkills.Count && skillCount < 3; i++)
                            {
                                certificationReqs[rng.Next(0, 11)] = rng.Next(otherRankRestrictions[0], otherRankRestrictions[1]);
                                skillCount++;
                            }
                        }
                        classData[classCertStart + certMod + 4L] = (byte)certificationReqs[0]; // Certification requirements
                        classData[classCertStart + certMod + 5L] = (byte)certificationReqs[1];
                        classData[classCertStart + certMod + 6L] = (byte)certificationReqs[2];
                        classData[classCertStart + certMod + 7L] = (byte)certificationReqs[3];
                        classData[classCertStart + certMod + 8L] = (byte)certificationReqs[4];
                        classData[classCertStart + certMod + 9L] = (byte)certificationReqs[5];
                        classData[classCertStart + certMod + 10L] = (byte)certificationReqs[6];
                        classData[classCertStart + certMod + 11L] = (byte)certificationReqs[7];
                        classData[classCertStart + certMod + 12L] = (byte)certificationReqs[8];
                        classData[classCertStart + certMod + 13L] = (byte)certificationReqs[9];
                        classData[classCertStart + certMod + 14L] = (byte)certificationReqs[10];

                        changelog += "\nCertification Req.:";
                        for (int i = 0; i < certificationReqs.Length; i++)
                            if (certificationReqs[i] > 0)
                                changelog += "\t" + getSkillName(i) + " " + getRankName(certificationReqs[i]);
                    }
                    else
                    {
                        certificationReqs[0] = classData[classCertStart + certMod + 4L];
                        certificationReqs[1] = classData[classCertStart + certMod + 5L];
                        certificationReqs[2] = classData[classCertStart + certMod + 6L];
                        certificationReqs[3] = classData[classCertStart + certMod + 7L];
                        certificationReqs[4] = classData[classCertStart + certMod + 8L];
                        certificationReqs[5] = classData[classCertStart + certMod + 9L];
                        certificationReqs[6] = classData[classCertStart + certMod + 10L];
                        certificationReqs[7] = classData[classCertStart + certMod + 11L];
                        certificationReqs[8] = classData[classCertStart + certMod + 12L];
                        certificationReqs[9] = classData[classCertStart + certMod + 13L];
                        certificationReqs[10] = classData[classCertStart + certMod + 14L];
                    }
                    classCertReqs.Add(new int[][] { new int[] { classTier }, certificationReqs, new int[] { classData[classCertStart + certMod + 2L] } });

                    if (settings.randClassMasteryAb && settings.randClassAb)
                    {
                        int masteryAbility = abilityPool[rng.Next(0, abilityPool.Count)];
                        classData[classAbStart + abMod + 0L] = (byte)masteryAbility; // Mastery Ability

                        changelog += "\nMastery Ability:\t" + abilityNames[classData[classAbStart + abMod + 0L]];
                    }

                    if (settings.randClassMasteryCa)
                    {
                        int masteryArt = 255;
                        int selectedWeaponType = 10;

                        if (settings.baseClassMasteryCa)
                        {
                            if (weaponTypes[0] < 5)
                                selectedWeaponType = weaponTypes[0];
                            if (numWeaponTypes == 2 && (rng.Next(0, 2) == 0 || selectedWeaponType == 10))
                                selectedWeaponType = weaponTypes[1];
                        }
                        else
                            selectedWeaponType = rng.Next(0, 5);
                        if (selectedWeaponType < 5)
                            if (rng.Next(0, 3) == 0)
                                masteryArt = availableArts[selectedWeaponType][rng.Next(0, availableArts[selectedWeaponType].Length)];

                        classData[classAbStart + abMod + 1L] = (byte)masteryArt; // Mastery Combat Art

                        changelog += "\nMastery Combat Art:\t" + combatArtNames[classData[classAbStart + abMod + 1L]];
                    }

                    bool randClassAb = settings.randClassAb && settings.randClassClassAb;
                    int numClassAbs = 0;
                    if (monster)
                    {
                        randClassAb = randClassAb && settings.randMonClassClassAb;
                        numClassAbs = rng.Next(settings.monClassClassAbCountMin, settings.monClassClassAbCountMin + 1);
                    }
                    else
                        switch (classTier)
                        {
                            case 0:
                                randClassAb = randClassAb && settings.randStaClassClassAb;
                                numClassAbs = rng.Next(settings.staClassClassAbCountMin, settings.staClassClassAbCountMax + 1);
                                break;
                            case 1:
                                randClassAb = randClassAb && settings.randBegClassClassAb;
                                numClassAbs = rng.Next(settings.begClassClassAbCountMin, settings.begClassClassAbCountMax + 1);
                                break;
                            case 2:
                                randClassAb = randClassAb && settings.randIntClassClassAb;
                                numClassAbs = rng.Next(settings.intClassClassAbCountMin, settings.intClassClassAbCountMax + 1);
                                break;
                            case 3:
                                randClassAb = randClassAb && settings.randAdvClassClassAb;
                                numClassAbs = rng.Next(settings.advClassClassAbCountMin, settings.advClassClassAbCountMax + 1);
                                break;
                            case 4:
                                randClassAb = randClassAb && settings.randMasClassClassAb;
                                numClassAbs = rng.Next(settings.masClassClassAbCountMin, settings.masClassClassAbCountMax + 1);
                                break;
                            case 6:
                                randClassAb = randClassAb && settings.randUniClassClassAb;
                                numClassAbs = rng.Next(settings.uniClassClassAbCountMin, settings.uniClassClassAbCountMax + 1);
                                break;
                        }

                    if (randClassAb)
                    {
                        int[] classAbilities = { 255, 255, 255 };
                        for (int i = 0; i < numClassAbs; i++)
                        {
                            if (!settings.baseClassAb || rng.Next(0, 3) != 0)
                                classAbilities[i] = abilityPool[rng.Next(0, abilityPool.Count)];
                            else
                            {
                                switch (weaponTypes[rng.Next(0, numWeaponTypes)])
                                {
                                    case 0:
                                        classAbilities[i] = swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)];
                                        break;
                                    case 1:
                                        classAbilities[i] = lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)];
                                        break;
                                    case 2:
                                        classAbilities[i] = axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)];
                                        break;
                                    case 3:
                                        classAbilities[i] = bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)];
                                        break;
                                    case 4:
                                        classAbilities[i] = brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)];
                                        break;
                                    case 5:
                                        classAbilities[i] = blackOnlyAbilities[rng.Next(0, blackOnlyAbilities.Length)];
                                        break;
                                    case 6:
                                        classAbilities[i] = faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)];
                                        break;
                                    case 7:
                                        classAbilities[i] = darkOnlyAbilities[rng.Next(0, darkOnlyAbilities.Length)];
                                        break;
                                }
                            }
                        }
                        if (index == 43)
                            classAbilities[0] = 158;
                        classData[classAbStart + abMod + 2L] = (byte)classAbilities[0]; // Class Abilities
                        classData[classAbStart + abMod + 3L] = (byte)classAbilities[1];
                        classData[classAbStart + abMod + 4L] = (byte)classAbilities[2];

                        changelog += "\nClass Abilities:";
                        if (numClassAbs == 0)
                            changelog += "\tNone";
                        for (int i = 0; i < numClassAbs; i++)
                            changelog += "\t" + abilityNames[classAbilities[i]];
                    }
                }
                if (settings.randTierLv)
                    changelog += "\n\n\n---CLASS TIERS---";

                for (int index = 0; index < 7; index++)
                {
                    long tierMod = classTierLen * (long)index;
                    switch (index)
                    {
                        case 1:
                            if (settings.randTierLv && settings.randBegTierLv)
                            {
                                classData[classTierStart + tierMod + 0L] = (byte)rng.Next(settings.begTierLvMin, settings.begTierLvMax + 1);
                                changelog += "\n\nBeginner Tier Level Requirement:\t" + classData[classTierStart + tierMod + 0L];
                                if (msgLoaded && settings.changeMsg)
                                {
                                    msgStrings[2767] = "A beginner certification, which serves as the\nfoundation for other classes. These exams can\nbe taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + ".";
                                    msgStrings[3486] = "This exam can be taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + " or higher.";
                                }
                            }
                            break;
                        case 2:
                            if (settings.randTierLv && settings.randIntTierLv)
                            {
                                classData[classTierStart + tierMod + 0L] = (byte)rng.Next(settings.intTierLvMin, settings.intTierLvMax + 1);
                                changelog += "\nIntermediate Tier Level Requirement:\t" + classData[classTierStart + tierMod + 0L];
                                if (msgLoaded && settings.changeMsg)
                                {
                                    msgStrings[2768] = "An intermediate certification. These exams can\nbe taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + ".";
                                    msgStrings[3487] = "This exam can be taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + " or higher.";
                                }
                            }
                            break;
                        case 3:
                            if (settings.randTierLv && settings.randAdvTierLv)
                            {
                                classData[classTierStart + tierMod + 0L] = (byte)rng.Next(settings.advTierLvMin, settings.advTierLvMax + 1);
                                changelog += "\nAdvanced Tier Level Requirement:\t" + classData[classTierStart + tierMod + 0L];
                                if (msgLoaded && settings.changeMsg)
                                {
                                    msgStrings[2769] = "An advanced certification. These exams can be\ntaken at Level " +
                                        classData[classTierStart + tierMod + 0L] + ".";
                                    msgStrings[3488] = "This exam can be taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + " or higher.";
                                    msgStrings[22419] = "A special certification. These exams can be\ntaken at Level " +
                                        classData[classTierStart + tierMod + 0L] + ".";
                                }
                            }
                            break;
                        case 4:
                            if (settings.randTierLv && settings.randMasTierLv)
                            {
                                classData[classTierStart + tierMod + 0L] = (byte)rng.Next(settings.masTierLvMin, settings.masTierLvMax + 1);
                                changelog += "\nMaster Tier Level Requirement:\t\t" + classData[classTierStart + tierMod + 0L];
                                if (msgLoaded && settings.changeMsg)
                                {
                                    msgStrings[2770] = "A mastery certification which requires deep\nknowledge in multiple skills. These exams can\nbe taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + ".";
                                    msgStrings[3489] = "This exam can be taken at Level " +
                                        classData[classTierStart + tierMod + 0L] + " or higher.";
                                    msgStrings[3490] = "This exam can be taken at Lv. " +
                                        classData[classTierStart + tierMod + 0L] + " or higher.";
                                }
                            }
                            break;
                    }
                }

                for (int index = 0; index < 30; index++)
                {
                    long monsterMod = classMonsterLen * (long)index;

                    if (settings.randBarrierBreakItem)
                    {
                        if (settings.allowNonMineralBarrierBreakItem)
                        {
                            classData[classMonsterStart + monsterMod + 6L] = (byte)obtainableMiscItems[rng.Next(0, obtainableMiscItems.Length)];
                            classData[classMonsterStart + monsterMod + 8L] = (byte)obtainableMiscItems[rng.Next(0, obtainableMiscItems.Length)];
                        }
                        else
                        {
                            classData[classMonsterStart + monsterMod + 6L] = (byte)rng.Next(64, 72); // Barrier break items
                            classData[classMonsterStart + monsterMod + 8L] = (byte)rng.Next(64, 72);
                        }
                    }

                    if (settings.randLatentAb)
                    {
                        int numLatentAbilities = classData[classMonsterStart + monsterMod + 52L] - 1;
                        int[] latentAbilities = { 255, 255, 255, 255 };
                        for (int i = 0; i < numLatentAbilities; i++)
                            latentAbilities[i] = genericAbilities[rng.Next(0, genericAbilities.Length)];
                        classData[classMonsterStart + monsterMod + 64L] = (byte)latentAbilities[0]; // Latent abilities
                        classData[classMonsterStart + monsterMod + 65L] = (byte)latentAbilities[1];
                        classData[classMonsterStart + monsterMod + 66L] = (byte)latentAbilities[2];
                        classData[classMonsterStart + monsterMod + 67L] = (byte)latentAbilities[3];
                    }

                    if (settings.randBarrierAb)
                    {
                        classData[classMonsterStart + monsterMod + 68L] = (byte)genericAbilities[rng.Next(0, genericAbilities.Length)]; // Barrier abilities
                        classData[classMonsterStart + monsterMod + 69L] = (byte)genericAbilities[rng.Next(0, genericAbilities.Length)];
                    }
                }
            }

            if (Randomizer.itemLoaded)
            {
                Randomizer.itemData = new byte[Randomizer.itemDataV.Length];
                Randomizer.itemDataV.CopyTo((Array)Randomizer.itemData, 0);
                if (settings.randWeapons)
                {
                    changelog += "\n\n\n---WEAPONS---";
                    for (int index = 0; index < 500; ++index)
                    {
                        long weaponMod = weaponBlockLen * (long)index;

                        if (settings.randAtkRange && p(settings.randAtkRangeP) && itemData[weaponBlockStart + weaponMod + 7L] < 100)
                        {
                            int rangeUpBound = itemData[weaponBlockStart + weaponMod + 7L];
                            int rangeLoBound = itemData[weaponBlockStart + weaponMod + 10L];
                            int newRangeUpBound = advancedRng(
                                rangeUpBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            int newRangeLoBound = advancedRng(
                                rangeLoBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            if (newRangeLoBound < 1)
                                newRangeLoBound = 1;
                            if (newRangeUpBound > 99)
                                newRangeUpBound = 99;
                            if (newRangeUpBound < 1)
                                newRangeUpBound = 1;
                            if (newRangeLoBound > 99)
                                newRangeLoBound = 99;
                            if (newRangeUpBound < newRangeLoBound)
                            {
                                int switcher = newRangeLoBound;
                                newRangeLoBound = newRangeUpBound;
                                newRangeUpBound = switcher;
                            }
                            if (rangeUpBound < 100)
                            {
                                itemData[weaponBlockStart + weaponMod + 7L] = (byte)newRangeUpBound; // Weapon range
                                itemData[weaponBlockStart + weaponMod + 10L] = (byte)newRangeLoBound;
                            }
                        }

                        if (settings.randAtkStatusEffects)
                        {
                            if (p(settings.atkStatusEffectsP))
                                itemData[weaponBlockStart + weaponMod + 12L] = (byte)rng.Next(0, 94); // Weapon effect
                            else
                                itemData[weaponBlockStart + weaponMod + 12L] = (byte)96;
                        }

                        if (settings.randAtkEffectiveness)
                        {
                            int[] effectivenessBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                            int effectivenessByte = 0;
                            for (int i = 0; i < 6; i++)
                                if (p(settings.atkEffectivenessP / 6))
                                    effectivenessBits[i] = 1;
                            if (itemData[weaponBlockStart + weaponMod + 5L] == 3 && settings.atkEffectivenessPreserveBows)
                                effectivenessBits[3] = 1;
                            effectivenessByte = toByte(effectivenessBits);
                            itemData[weaponBlockStart + weaponMod + 14L] = (byte)effectivenessByte; // Weapon effectiveness
                        }

                        if (settings.randAtkDurability && p(settings.randAtkDurabilityP) && itemData[weaponBlockStart + weaponMod + 11L] < 100)
                            itemData[weaponBlockStart + weaponMod + 11L] = (byte)normalize(advancedRng(itemData[weaponBlockStart + weaponMod + 11L], settings.atkDurabilityBinomial,
                                settings.atkDurabilityLinear, settings.atkDurabilityLinearDev, settings.atkDurabilityProportional, settings.atkDurabilityProportionalDev,
                                settings.atkDurabilityExponential, settings.atkDurabilityExponentialDev, 5), 1, 99); // Weapon durability
                        if (settings.randAtkMight && p(settings.randAtkMightP))
                            itemData[weaponBlockStart + weaponMod + 16L] = (byte)normalize(advancedRng(itemData[weaponBlockStart + weaponMod + 16L], settings.atkMightBinomial,
                                settings.atkMightLinear, settings.atkMightLinearDev, settings.atkMightProportional, settings.atkMightProportionalDev,
                                settings.atkMightExponential, settings.atkMightExponentialDev, 1), 0, 255); // Weapon might
                        if (settings.randAtkHit && p(settings.randAtkHitP))
                            itemData[weaponBlockStart + weaponMod + 17L] = (byte)normalize(advancedRng(itemData[weaponBlockStart + weaponMod + 17L], settings.atkHitBinomial,
                                settings.atkHitLinear, settings.atkHitLinearDev, settings.atkHitProportional, settings.atkHitProportionalDev,
                                settings.atkHitExponential, settings.atkHitExponentialDev, 5), 0, 255); // Weapon hit
                        if (settings.randAtkCrit)
                            itemData[weaponBlockStart + weaponMod + 18L] = (byte)randCrit(settings.atkCritP, settings.atkCritMax); // Weapon crit
                        if (settings.randAtkWeight && p(settings.randAtkWeightP))
                            itemData[weaponBlockStart + weaponMod + 19L] = (byte)normalize(advancedRng(itemData[weaponBlockStart + weaponMod + 19L], settings.atkWeightBinomial,
                                settings.atkWeightLinear, settings.atkWeightLinearDev, settings.atkWeightProportional, settings.atkWeightProportionalDev,
                                settings.atkWeightExponential, settings.atkWeightExponentialDev, 1), 0, 255); // Weapon weight

                        int[] properties = toBits(itemData[weaponBlockStart + weaponMod + 22L]);

                        if (settings.randAtkPhysicalMagicSwitch)
                        {
                            if (p(settings.randAtkPhysicalMagicSwitchP))
                                properties[0] = 1;
                            else
                                properties[0] = 0;
                        }
                        if (settings.randAtkIgnoreDefRes)
                        {
                            if (p(settings.randAtkIgnoreDefResP))
                                properties[1] = 1;
                            else
                                properties[1] = 0;
                        }
                        if (settings.randAtkLeaveAt1)
                        {
                            if (p(settings.randAtkLeaveAt1P))
                                properties[2] = 1;
                            else
                                properties[2] = 0;
                        }
                        if (settings.randAtkDoubleAttack)
                        {
                            if (p(settings.atkDoubleAttackP) || (itemData[weaponBlockStart + weaponMod + 5L] == 4 && index < 200 && settings.atkDoubleAttackPreserveGauntlets))
                                properties[5] = 1;
                            else
                                properties[5] = 0;
                        }
                        itemData[weaponBlockStart + weaponMod + 22L] = toByte(properties); // Weapon properties

                        if (weaponNames[index] != null)
                        {
                            changelog += "\n\n\t" + weaponNames[index] +
                                "\nWeapon ID:\t\t" + index;
                            changelog += "\nRange:\t\t\t" + itemData[weaponBlockStart + weaponMod + 10L] + "-" + (itemData[weaponBlockStart + weaponMod + 7L] == 150 ? 2 : itemData[weaponBlockStart + weaponMod + 7L]);
                            changelog += "\nStatus Effect:\t\t" + effectNames[itemData[weaponBlockStart + weaponMod + 12L]];
                            changelog += "\nEffectiveness:\t";
                            int[] effectiveness = toBits(itemData[weaponBlockStart + weaponMod + 14L]);
                            for (int i = 0; i < effectiveness.Length; i++)
                                if (effectiveness[i] == 1)
                                    changelog += "\t" + getClassTyping(i);
                            if (itemData[weaponBlockStart + weaponMod + 14L] == 0)
                                changelog += "\tNone";
                            changelog += "\nDurability:\t\t" + itemData[weaponBlockStart + weaponMod + 11L];
                            changelog += "\nMight:\t\t\t" + itemData[weaponBlockStart + weaponMod + 16L];
                            changelog += "\nHit:\t\t\t" + itemData[weaponBlockStart + weaponMod + 17L];
                            changelog += "\nCrit:\t\t\t" + itemData[weaponBlockStart + weaponMod + 18L];
                            changelog += "\nWeight:\t\t\t" + itemData[weaponBlockStart + weaponMod + 19L];
                            changelog += "\nDamage Type:\t\t" + (properties[0] == 1 ? "Magic" : "Physical");
                            changelog += "\nSpecial Properties:";
                            if (properties[1] == 1)
                                changelog += "\tIgnores Def/Res";
                            if (properties[2] == 1)
                                changelog += "\tLeaves target at 1 HP";
                            if (properties[5] == 1)
                                changelog += "\tDouble Attack";
                            if (properties[1] == 0 && properties[2] == 0 && properties[5] == 0)
                                changelog += "\tNone";

                            if (msgLoaded && settings.changeMsg && index < 300)
                            {
                                string newDescription = "";
                                if (itemData[weaponBlockStart + weaponMod + 12L] != 96)
                                    newDescription += "Inflicts " + effectNames[itemData[weaponBlockStart + weaponMod + 12L]] + ".\n";
                                if (properties[0] == 1)
                                    newDescription += "Deals magic damage.\n";
                                if (properties[1] == 1)
                                    newDescription += "Ignores Def/Res.\n";
                                if (properties[2] == 1)
                                    newDescription += "Leaves target at 1 HP.\n";
                                if (properties[5] == 1)
                                    newDescription += "Attacks twice when initiating combat.\n";
                                if (newDescription.Length == 0)
                                    newDescription = "No special attributes.\n";
                                msgStrings[11162 + index] = newDescription.Trim(new char[] { '\n' });
                            }
                        }
                    }
                }

                if (settings.randSpells)
                {
                    changelog += "\n\n\n---SPELLS---";
                    for (int index = 0; index < 38; ++index)
                    {
                        long magicMod = magicBlockLen * (long)index;

                        if (settings.randAtkRange && p(settings.randAtkRangeP) && itemData[magicBlockStart + magicMod + 7L] < 100)
                        {
                            int rangeUpBound = itemData[magicBlockStart + magicMod + 7L];
                            int rangeLoBound = itemData[magicBlockStart + magicMod + 10L];
                            int newRangeUpBound = advancedRng(
                                rangeUpBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            int newRangeLoBound = advancedRng(
                                rangeLoBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            if (newRangeLoBound < 1)
                                newRangeLoBound = 1;
                            if (newRangeUpBound > 99)
                                newRangeUpBound = 99;
                            if (newRangeUpBound < 1)
                                newRangeUpBound = 1;
                            if (newRangeLoBound > 99)
                                newRangeLoBound = 99;
                            if (newRangeUpBound < newRangeLoBound)
                            {
                                int switcher = newRangeLoBound;
                                newRangeLoBound = newRangeUpBound;
                                newRangeUpBound = switcher;
                            }
                            if (rangeUpBound < 100)
                            {
                                itemData[magicBlockStart + magicMod + 7L] = (byte)newRangeUpBound; // Magic range
                                itemData[magicBlockStart + magicMod + 10L] = (byte)newRangeLoBound;
                            }
                        }

                        if (settings.randAtkStatusEffects)
                        {
                            if (p(settings.atkStatusEffectsP) || itemData[magicBlockStart + magicMod + 16L] == 0)
                                itemData[magicBlockStart + magicMod + 12L] = (byte)rng.Next(0, 94); // Magic effect
                            else
                                itemData[magicBlockStart + magicMod + 12L] = (byte)96;
                        }

                        if (settings.randAtkEffectiveness)
                        {
                            int[] effectivenessBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                            int effectivenessByte = 0;
                            for (int i = 0; i < 6; i++)
                                if (p(settings.atkEffectivenessP / 6))
                                    effectivenessBits[i] = 1;
                            effectivenessByte = toByte(effectivenessBits);
                            itemData[magicBlockStart + magicMod + 14L] = (byte)effectivenessByte; // Magic effectiveness
                        }

                        if (settings.randAtkDurability && p(settings.randAtkDurabilityP) && itemData[magicBlockStart + magicMod + 11L] < 100)
                            itemData[magicBlockStart + magicMod + 11L] = (byte)normalize(advancedRng(itemData[magicBlockStart + magicMod + 11L], settings.atkDurabilityBinomial,
                                settings.atkDurabilityLinear, settings.atkDurabilityLinearDev, settings.atkDurabilityProportional, settings.atkDurabilityProportionalDev,
                                settings.atkDurabilityExponential, settings.atkDurabilityExponentialDev, 1), 1, 99); // Magic uses
                        if (settings.randAtkMight && p(settings.randAtkMightP))
                            itemData[magicBlockStart + magicMod + 16L] = (byte)normalize(advancedRng(itemData[magicBlockStart + magicMod + 16L], settings.atkMightBinomial,
                                settings.atkMightLinear, settings.atkMightLinearDev, settings.atkMightProportional, settings.atkMightProportionalDev,
                                settings.atkMightExponential, settings.atkMightExponentialDev, 1), 0, 255); // Magic might
                        if (settings.randAtkHit && p(settings.randAtkHitP))
                            itemData[magicBlockStart + magicMod + 17L] = (byte)normalize(advancedRng(itemData[magicBlockStart + magicMod + 17L], settings.atkHitBinomial,
                                settings.atkHitLinear, settings.atkHitLinearDev, settings.atkHitProportional, settings.atkHitProportionalDev,
                                settings.atkHitExponential, settings.atkHitExponentialDev, 5), 0, 255); // Magic hit
                        if (settings.randAtkCrit)
                            itemData[magicBlockStart + magicMod + 18L] = (byte)randCrit(settings.atkCritP, settings.atkCritMax); // Magic crit
                        if (settings.randAtkWeight && p(settings.randAtkWeightP))
                            itemData[magicBlockStart + magicMod + 19L] = (byte)normalize(advancedRng(itemData[magicBlockStart + magicMod + 19L], settings.atkWeightBinomial,
                                settings.atkWeightLinear, settings.atkWeightLinearDev, settings.atkWeightProportional, settings.atkWeightProportionalDev,
                                settings.atkWeightExponential, settings.atkWeightExponentialDev, 1), 0, 255); // Magic weight

                        int[] properties = toBits(itemData[magicBlockStart + magicMod + 22L]);

                        if (settings.randAtkPhysicalMagicSwitch)
                        {
                            if (p(settings.randAtkPhysicalMagicSwitchP))
                                properties[0] = 0;
                            else
                                properties[0] = 1;
                        }
                        if (settings.randAtkIgnoreDefRes)
                        {
                            if (p(settings.randAtkIgnoreDefResP))
                                properties[1] = 1;
                            else
                                properties[1] = 0;
                        }
                        if (settings.randAtkLeaveAt1)
                        {
                            if (p(settings.randAtkLeaveAt1P))
                                properties[2] = 1;
                            else
                                properties[2] = 0;
                        }
                        if (settings.randAtkDoubleAttack)
                        {
                            if (p(settings.atkDoubleAttackP))
                                properties[5] = 1;
                            else
                                properties[5] = 0;
                        }
                        itemData[magicBlockStart + magicMod + 22L] = toByte(properties); // Magic properties

                        if (spellNames[index] != null)
                        {
                            changelog += "\n\n\t" + spellNames[index] +
                                "\nMagic ID:\t\t" + index;
                            changelog += "\nRange:\t\t\t" + itemData[magicBlockStart + magicMod + 10L] + "-" + itemData[magicBlockStart + magicMod + 7L];
                            changelog += "\nStatus Effect:\t\t" + effectNames[itemData[magicBlockStart + magicMod + 12L]];
                            changelog += "\nEffectiveness:\t";
                            int[] effectiveness = toBits(itemData[magicBlockStart + magicMod + 14L]);
                            for (int i = 0; i < effectiveness.Length; i++)
                                if (effectiveness[i] == 1)
                                    changelog += "\t" + getClassTyping(i);
                            if (itemData[magicBlockStart + magicMod + 14L] == 0)
                                changelog += "\tNone";
                            changelog += "\nUses:\t\t\t" + itemData[magicBlockStart + magicMod + 11L];
                            changelog += "\nMight:\t\t\t" + itemData[magicBlockStart + magicMod + 16L];
                            changelog += "\nHit:\t\t\t" + itemData[magicBlockStart + magicMod + 17L];
                            changelog += "\nCrit:\t\t\t" + itemData[magicBlockStart + magicMod + 18L];
                            changelog += "\nWeight:\t\t\t" + itemData[magicBlockStart + magicMod + 19L];
                            changelog += "\nDamage Type:\t\t" + (properties[0] == 1 ? "Magic" : "Physical");
                            changelog += "\nSpecial Properties:";
                            if (properties[1] == 1)
                                changelog += "\tIgnores Def/Res";
                            if (properties[2] == 1)
                                changelog += "\tLeaves target at 1 HP";
                            if (properties[5] == 1)
                                changelog += "\tDouble Attack";
                            if (properties[1] == 0 && properties[2] == 0 && properties[5] == 0)
                                changelog += "\tNone";

                            if (msgLoaded && settings.changeMsg)
                            {
                                string newDescription = "";
                                if (itemData[magicBlockStart + magicMod + 12L] != 96)
                                    newDescription += "Inflicts " + effectNames[itemData[magicBlockStart + magicMod + 12L]] + ".\n";
                                if (properties[0] == 0)
                                    newDescription += "Deals physical damage.\n";
                                if (properties[1] == 1)
                                    newDescription += "Ignores Def/Res.\n";
                                if (properties[2] == 1)
                                    newDescription += "Leaves target at 1 HP.\n";
                                if (properties[5] == 1)
                                    newDescription += "Attacks twice when initiating combat.\n";
                                if (newDescription.Length == 0)
                                    newDescription = "No special attributes.\n";
                                msgStrings[15042 + index] = newDescription.Trim(new char[] { '\n' });
                            }
                        }
                    }
                }

                if (settings.randTurrets)
                {
                    changelog += "\n\n\n---TURRETS---";
                    for (int index = 0; index < 3; ++index)
                    {
                        long turretMod = turretBlockLen * (long)index;

                        if (settings.randAtkRange && p(settings.randAtkRangeP) && itemData[turretBlockStart + turretMod + 7L] < 100)
                        {
                            int rangeUpBound = itemData[turretBlockStart + turretMod + 7L];
                            int rangeLoBound = itemData[turretBlockStart + turretMod + 10L];
                            int newRangeUpBound = advancedRng(
                                rangeUpBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            int newRangeLoBound = advancedRng(
                                rangeLoBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            if (newRangeLoBound < 1)
                                newRangeLoBound = 1;
                            if (newRangeUpBound > 99)
                                newRangeUpBound = 99;
                            if (newRangeUpBound < 1)
                                newRangeUpBound = 1;
                            if (newRangeLoBound > 99)
                                newRangeLoBound = 99;
                            if (newRangeUpBound < newRangeLoBound)
                            {
                                int switcher = newRangeLoBound;
                                newRangeLoBound = newRangeUpBound;
                                newRangeUpBound = switcher;
                            }
                            if (rangeUpBound < 100)
                            {
                                itemData[turretBlockStart + turretMod + 7L] = (byte)newRangeUpBound; // Turret range
                                itemData[turretBlockStart + turretMod + 10L] = (byte)newRangeLoBound;
                            }
                        }

                        if (settings.randAtkStatusEffects)
                        {
                            if (p(settings.atkStatusEffectsP))
                                itemData[turretBlockStart + turretMod + 12L] = (byte)rng.Next(0, 94); // Turret effect
                            else
                                itemData[turretBlockStart + turretMod + 12L] = (byte)96;
                        }

                        if (settings.randAtkEffectiveness)
                        {
                            int[] effectivenessBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                            int effectivenessByte = 0;
                            for (int i = 0; i < 6; i++)
                                if (p(settings.atkEffectivenessP / 6))
                                    effectivenessBits[i] = 1;
                            if (itemData[turretBlockStart + turretMod + 5L] == 3 && settings.atkEffectivenessPreserveBows)
                                effectivenessBits[3] = 1;
                            effectivenessByte = toByte(effectivenessBits);
                            itemData[turretBlockStart + turretMod + 14L] = (byte)effectivenessByte; // Turret effectiveness
                        }

                        if (settings.randAtkMight && p(settings.randAtkMightP))
                            itemData[turretBlockStart + turretMod + 16L] = (byte)normalize(advancedRng(itemData[turretBlockStart + turretMod + 16L], settings.atkMightBinomial,
                                settings.atkMightLinear, settings.atkMightLinearDev, settings.atkMightProportional, settings.atkMightProportionalDev,
                                settings.atkMightExponential, settings.atkMightExponentialDev, 1), 0, 255); // Turret might
                        if (settings.randAtkHit && p(settings.randAtkHitP))
                            itemData[turretBlockStart + turretMod + 17L] = (byte)normalize(advancedRng(itemData[turretBlockStart + turretMod + 17L], settings.atkHitBinomial,
                                settings.atkHitLinear, settings.atkHitLinearDev, settings.atkHitProportional, settings.atkHitProportionalDev,
                                settings.atkHitExponential, settings.atkHitExponentialDev, 5), 0, 255); // Turret hit
                        if (settings.randAtkCrit)
                            itemData[turretBlockStart + turretMod + 18L] = (byte)randCrit(settings.atkCritP, settings.atkCritMax); // Turret crit
                        if (settings.randAtkWeight && p(settings.randAtkWeightP))
                            itemData[turretBlockStart + turretMod + 19L] = (byte)normalize(advancedRng(itemData[turretBlockStart + turretMod + 19L], settings.atkWeightBinomial,
                                settings.atkWeightLinear, settings.atkWeightLinearDev, settings.atkWeightProportional, settings.atkWeightProportionalDev,
                                settings.atkWeightExponential, settings.atkWeightExponentialDev, 1), 0, 255); // Turret weight

                        int[] properties = toBits(itemData[turretBlockStart + turretMod + 22L]);

                        if (settings.randAtkPhysicalMagicSwitch)
                        {
                            if (p(settings.randAtkPhysicalMagicSwitchP))
                                properties[0] = 1 - properties[0];
                        }
                        if (settings.randAtkIgnoreDefRes)
                        {
                            if (p(settings.randAtkIgnoreDefResP))
                                properties[1] = 1;
                            else
                                properties[1] = 0;
                        }
                        if (settings.randAtkLeaveAt1)
                        {
                            if (p(settings.randAtkLeaveAt1P))
                                properties[2] = 1;
                            else
                                properties[2] = 0;
                        }
                        if (settings.randAtkDoubleAttack)
                        {
                            if (p(settings.atkDoubleAttackP))
                                properties[5] = 1;
                            else
                                properties[5] = 0;
                        }
                        itemData[turretBlockStart + turretMod + 22L] = toByte(properties); // Turret properties

                        changelog += "\n\n\t" + getTurretName(index) +
                            "\nTurret ID:\t\t" + index;
                        changelog += "\nRange:\t\t\t" + itemData[turretBlockStart + turretMod + 10L] + "-" + itemData[turretBlockStart + turretMod + 7L];
                        changelog += "\nStatus Effect:\t\t" + effectNames[itemData[turretBlockStart + turretMod + 12L]];
                        changelog += "\nEffectiveness:\t";
                        int[] effectiveness = toBits(itemData[turretBlockStart + turretMod + 14L]);
                        for (int i = 0; i < effectiveness.Length; i++)
                            if (effectiveness[i] == 1)
                                changelog += "\t" + getClassTyping(i);
                        if (itemData[turretBlockStart + turretMod + 14L] == 0)
                            changelog += "\tNone";
                        changelog += "\nMight:\t\t\t" + itemData[turretBlockStart + turretMod + 16L];
                        changelog += "\nHit:\t\t\t" + itemData[turretBlockStart + turretMod + 17L];
                        changelog += "\nCrit:\t\t\t" + itemData[turretBlockStart + turretMod + 18L];
                        changelog += "\nWeight:\t\t\t" + itemData[turretBlockStart + turretMod + 19L];
                        changelog += "\nDamage Type:\t\t" + (properties[0] == 1 ? "Magic" : "Physical");
                        changelog += "\nSpecial Properties:";
                        if (properties[1] == 1)
                            changelog += "\tIgnores Def/Res";
                        if (properties[2] == 1)
                            changelog += "\tLeaves target at 1 HP";
                        if (properties[5] == 1)
                            changelog += "\tDouble Attack";
                        if (properties[1] == 0 && properties[2] == 0 && properties[5] == 0)
                            changelog += "\tNone";
                    }
                }

                if (settings.randGambits)
                {
                    changelog += "\n\n\n---GAMBITS---";
                    for (int index = 0; index < 80; index++)
                    {
                        int gambitMod = (int)gambitBlockLen * index;
                        int extraMod = (int)gambitExtraLen * index;

                        if (settings.randAtkRange && p(settings.randAtkRangeP) && itemData[gambitBlockStart + gambitMod + 7L] < 100)
                        {
                            int rangeUpBound = itemData[gambitBlockStart + gambitMod + 7L];
                            int rangeLoBound = itemData[gambitBlockStart + gambitMod + 10L];
                            int newRangeUpBound = advancedRng(
                                rangeUpBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            int newRangeLoBound = advancedRng(
                                rangeLoBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            if (newRangeLoBound < 1)
                                newRangeLoBound = 1;
                            if (newRangeUpBound > 99)
                                newRangeUpBound = 99;
                            if (newRangeUpBound < 1)
                                newRangeUpBound = 1;
                            if (newRangeLoBound > 99)
                                newRangeLoBound = 99;
                            if (newRangeUpBound < newRangeLoBound)
                            {
                                int switcher = newRangeLoBound;
                                newRangeLoBound = newRangeUpBound;
                                newRangeUpBound = switcher;
                            }
                            if (rangeUpBound < 100)
                            {
                                itemData[gambitBlockStart + gambitMod + 7L] = (byte)newRangeUpBound; // Gambit range
                                itemData[gambitBlockStart + gambitMod + 10L] = (byte)newRangeLoBound;
                            }
                        }
                        
                        if(settings.randAtkRange && p(settings.randAtkRangeP))
                        {
                            int[] gambitAoe = { 1, 2, 3, 5, 6, 7, 8, 12, 13 };
                            itemData[gambitExtraStart + extraMod + 10L] = (byte)gambitAoe[rng.Next(0, gambitAoe.Length)];
                            if (p(10))
                            {
                                itemData[gambitExtraStart + extraMod + 10L] = 0;
                                if (p(10))
                                    itemData[gambitExtraStart + extraMod + 10L] = 14;
                            }
                        }

                        if (settings.randAtkStatusEffects)
                        {
                            if (p(settings.atkStatusEffectsP) || itemData[gambitBlockStart + gambitMod + 16L] == 0)
                                itemData[gambitBlockStart + gambitMod + 12L] = (byte)rng.Next(0, 94); // Gambit effect
                            else
                                itemData[gambitBlockStart + gambitMod + 12L] = (byte)96;
                        }
                        if (settings.randAtkStatusEffects)
                        {
                            if (p(settings.atkStatusEffectsP))
                                itemData[gambitExtraStart + extraMod + 8L] = (byte)rng.Next(1, 5); // Gambit movement effect
                            else
                                itemData[gambitExtraStart + extraMod + 8L] = (byte)0;
                        }

                        if (settings.randAtkEffectiveness)
                        {
                            int[] effectivenessBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                            int effectivenessByte = 0;
                            for (int i = 0; i < 6; i++)
                                if (p(settings.atkEffectivenessP / 6))
                                    effectivenessBits[i] = 1;
                            if (itemData[gambitBlockStart + gambitMod + 5L] == 3 && settings.atkEffectivenessPreserveBows)
                                effectivenessBits[3] = 1;
                            effectivenessByte = toByte(effectivenessBits);
                            itemData[gambitBlockStart + gambitMod + 14L] = (byte)effectivenessByte; // Gambit effectiveness
                        }

                        if (settings.randAtkDurability && p(settings.randAtkDurabilityP))
                            itemData[gambitExtraStart + extraMod + 7L] = (byte)normalize(advancedRng(itemData[gambitExtraStart + extraMod + 7L], settings.atkDurabilityBinomial,
                                settings.atkDurabilityLinear, settings.atkDurabilityLinearDev, settings.atkDurabilityProportional, settings.atkDurabilityProportionalDev,
                                settings.atkDurabilityExponential, settings.atkDurabilityExponentialDev, 1), 1, 99); // Gambit uses
                        if (settings.randAtkMight && p(settings.randAtkMightP))
                            itemData[gambitBlockStart + gambitMod + 16L] = (byte)normalize(advancedRng(itemData[gambitBlockStart + gambitMod + 16L], settings.atkMightBinomial,
                                settings.atkMightLinear, settings.atkMightLinearDev, settings.atkMightProportional, settings.atkMightProportionalDev,
                                settings.atkMightExponential, settings.atkMightExponentialDev, 1), 0, 255); // Gambit might
                        if (settings.randAtkHit && p(settings.randAtkHitP))
                            itemData[gambitBlockStart + gambitMod + 17L] = (byte)normalize(advancedRng(itemData[gambitBlockStart + gambitMod + 17L], settings.atkHitBinomial,
                                settings.atkHitLinear, settings.atkHitLinearDev, settings.atkHitProportional, settings.atkHitProportionalDev,
                                settings.atkHitExponential, settings.atkHitExponentialDev, 5), 0, 255); // Gambit hit

                        int[] properties = toBits(itemData[gambitBlockStart + gambitMod + 22L]);

                        if (settings.randAtkPhysicalMagicSwitch)
                        {
                            if (p(settings.randAtkPhysicalMagicSwitchP))
                                properties[0] = 1 - properties[0];
                        }
                        if (settings.randAtkIgnoreDefRes)
                        {
                            if (p(settings.randAtkIgnoreDefResP))
                                properties[1] = 1;
                            else
                                properties[1] = 0;
                        }
                        if (settings.randAtkLeaveAt1)
                        {
                            if (p(settings.randAtkLeaveAt1P))
                                properties[2] = 1;
                            else
                                properties[2] = 0;
                        }
                        if (settings.randAtkDoubleAttack)
                        {
                            if (p(settings.atkDoubleAttackP))
                                properties[5] = 1;
                            else
                                properties[5] = 0;
                        }
                        itemData[gambitBlockStart + gambitMod + 22L] = toByte(properties); // Gambit properties

                        if (gambitNames[index] != null)
                        {
                            changelog += "\n\n\t" + gambitNames[index] +
                                "\nGambit ID:\t\t" + index;
                            changelog += "\nRange:\t\t\t" + itemData[gambitBlockStart + gambitMod + 10L] + "-" + itemData[gambitBlockStart + gambitMod + 7L];
                            changelog += "\nArea of Effect:\t\t" + getGambitAoeName(itemData[gambitExtraStart + extraMod + 10L]);
                            changelog += "\nStatus Effect:\t\t" + effectNames[itemData[gambitBlockStart + gambitMod + 12L]];
                            changelog += "\nExtra Effect:\t\t" + getGambitExtraEffectName(itemData[gambitExtraStart + extraMod + 8L]);
                            changelog += "\nEffectiveness:\t";
                            int[] effectiveness = toBits(itemData[gambitBlockStart + gambitMod + 14L]);
                            for (int i = 0; i < effectiveness.Length; i++)
                                if (effectiveness[i] == 1)
                                    changelog += "\t" + getClassTyping(i);
                            if (itemData[gambitBlockStart + gambitMod + 14L] == 0)
                                changelog += "\tNone";
                            changelog += "\nUses:\t\t\t" + itemData[gambitExtraStart + extraMod + 7L];
                            changelog += "\nMight:\t\t\t" + itemData[gambitBlockStart + gambitMod + 16L];
                            changelog += "\nHit:\t\t\t" + itemData[gambitBlockStart + gambitMod + 17L];
                            changelog += "\nDamage Type:\t\t" + (properties[0] == 1 ? "Magic" : "Physical");
                            changelog += "\nSpecial Properties:";
                            if (properties[1] == 1)
                                changelog += "\tIgnores Def/Res";
                            if (properties[2] == 1)
                                changelog += "\tLeaves target at 1 HP";
                            if (properties[5] == 1)
                                changelog += "\tDouble Attack";
                            if (properties[1] == 0 && properties[2] == 0 && properties[5] == 0)
                                changelog += "\tNone";

                            if (msgLoaded && settings.changeMsg)
                            {
                                string newDescription = "";
                                if (itemData[gambitBlockStart + gambitMod + 12L] != 96)
                                    newDescription += "Inflicts " + effectNames[itemData[gambitBlockStart + gambitMod + 12L]] + ".\n";
                                if (itemData[gambitExtraStart + extraMod + 8L] != 0)
                                    newDescription += "Uses " + getGambitExtraEffectName(itemData[gambitExtraStart + extraMod + 8L]) + " on target.\n";
                                if (properties[0] == 1)
                                    newDescription += "Deals magic damage.\n";
                                if (properties[1] == 1)
                                    newDescription += "Ignores Def/Res.\n";
                                if (properties[2] == 1)
                                    newDescription += "Leaves target at 1 HP.\n";
                                if (properties[5] == 1)
                                    newDescription += "Attacks twice when initiating combat.\n";
                                if (newDescription.Length == 0)
                                    newDescription = "No special attributes.\n";
                                newDescription = newDescription.Trim(new char[] { '\n' });
                                if (itemData[gambitBlockStart + gambitMod + 7L] > 1)
                                    newDescription += " Range: " + itemData[gambitBlockStart + gambitMod + 10L] + "-" + itemData[gambitBlockStart + gambitMod + 7L] + ".";
                                msgStrings[13820 + index] = newDescription;
                            }
                        }
                    }
                }

                if (settings.randMonsterAoe)
                {
                    changelog += "\n\n\n---STAGGERING BLOWS---";
                    for (int index = 0; index < 60; ++index)
                    {
                        long blowMod = blowBlockLen * (long)index;

                        if (settings.randAtkRange && p(settings.randAtkRangeP) && itemData[blowBlockStart + blowMod + 7L] < 100)
                        {
                            int rangeUpBound = itemData[blowBlockStart + blowMod + 7L];
                            int rangeLoBound = itemData[blowBlockStart + blowMod + 10L];
                            int newRangeUpBound = advancedRng(
                                rangeUpBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            int newRangeLoBound = advancedRng(
                                rangeLoBound, settings.atkRangeBinomial,
                                settings.atkRangeLinear, settings.atkRangeLinearDev,
                                settings.atkRangeProportional, settings.atkRangeProportionalDev,
                                settings.atkRangeExponential, settings.atkRangeExponentialDev, 1);
                            if (newRangeLoBound < 1)
                                newRangeLoBound = 1;
                            if (newRangeUpBound > 99)
                                newRangeUpBound = 99;
                            if (newRangeUpBound < 1)
                                newRangeUpBound = 1;
                            if (newRangeLoBound > 99)
                                newRangeLoBound = 99;
                            if (newRangeUpBound < newRangeLoBound)
                            {
                                int switcher = newRangeLoBound;
                                newRangeLoBound = newRangeUpBound;
                                newRangeUpBound = switcher;
                            }
                            if (rangeUpBound < 100)
                            {
                                itemData[blowBlockStart + blowMod + 7L] = (byte)newRangeUpBound; // Staggering blow range
                                itemData[blowBlockStart + blowMod + 10L] = (byte)newRangeLoBound;
                            }
                        }

                        if (settings.randAtkStatusEffects)
                        {
                            if (p(settings.atkStatusEffectsP))
                                itemData[blowBlockStart + blowMod + 12L] = (byte)rng.Next(0, 94); // Staggering blow effect
                            else
                                itemData[blowBlockStart + blowMod + 12L] = (byte)96;
                        }

                        if (settings.randAtkEffectiveness)
                        {
                            int[] effectivenessBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                            int effectivenessByte = 0;
                            for (int i = 0; i < 6; i++)
                                if (p(settings.atkEffectivenessP / 6))
                                    effectivenessBits[i] = 1;
                            if (itemData[blowBlockStart + blowMod + 5L] == 3 && settings.atkEffectivenessPreserveBows)
                                effectivenessBits[3] = 1;
                            effectivenessByte = toByte(effectivenessBits);
                            itemData[blowBlockStart + blowMod + 14L] = (byte)effectivenessByte; // Staggering blow effectiveness
                        }

                        if (settings.randAtkMight && p(settings.randAtkMightP))
                            itemData[blowBlockStart + blowMod + 16L] = (byte)normalize(advancedRng(itemData[blowBlockStart + blowMod + 16L], settings.atkMightBinomial,
                                settings.atkMightLinear, settings.atkMightLinearDev, settings.atkMightProportional, settings.atkMightProportionalDev,
                                settings.atkMightExponential, settings.atkMightExponentialDev, 1), 0, 255); // Staggering blow might
                        if (settings.randAtkHit && p(settings.randAtkHitP))
                            itemData[blowBlockStart + blowMod + 17L] = (byte)normalize(advancedRng(itemData[blowBlockStart + blowMod + 17L], settings.atkHitBinomial,
                                settings.atkHitLinear, settings.atkHitLinearDev, settings.atkHitProportional, settings.atkHitProportionalDev,
                                settings.atkHitExponential, settings.atkHitExponentialDev, 5), 0, 255); // Staggering blow hit

                        int[] properties = toBits(itemData[blowBlockStart + blowMod + 22L]);

                        if (settings.randAtkPhysicalMagicSwitch)
                        {
                            if (p(settings.randAtkPhysicalMagicSwitchP))
                                properties[0] = 1 - properties[0];
                        }
                        if (settings.randAtkIgnoreDefRes)
                        {
                            if (p(settings.randAtkIgnoreDefResP))
                                properties[1] = 1;
                            else
                                properties[1] = 0;
                        }
                        if (settings.randAtkLeaveAt1)
                        {
                            if (p(settings.randAtkLeaveAt1P))
                                properties[2] = 1;
                            else
                                properties[2] = 0;
                        }
                        if (settings.randAtkDoubleAttack)
                        {
                            if (p(settings.atkDoubleAttackP))
                                properties[5] = 1;
                            else
                                properties[5] = 0;
                        }
                        itemData[blowBlockStart + blowMod + 22L] = toByte(properties); // Staggering blow properties

                        if (blowNames[index] != null)
                        {
                            changelog += "\n\n\t" + blowNames[index] +
                                "\nStaggering Blow ID:\t" + index;
                            changelog += "\nRange:\t\t\t" + itemData[blowBlockStart + blowMod + 10L] + "-" + itemData[blowBlockStart + blowMod + 7L];
                            changelog += "\nStatus Effect:\t\t" + effectNames[itemData[blowBlockStart + blowMod + 12L]];
                            changelog += "\nEffectiveness:\t";
                            int[] effectiveness = toBits(itemData[blowBlockStart + blowMod + 14L]);
                            for (int i = 0; i < effectiveness.Length; i++)
                                if (effectiveness[i] == 1)
                                    changelog += "\t" + getClassTyping(i);
                            if (itemData[blowBlockStart + blowMod + 14L] == 0)
                                changelog += "\tNone";
                            changelog += "\nMight:\t\t\t" + itemData[blowBlockStart + blowMod + 16L];
                            changelog += "\nHit:\t\t\t" + itemData[blowBlockStart + blowMod + 17L];
                            changelog += "\nDamage Type:\t\t" + (properties[0] == 1 ? "Magic" : "Physical");
                            changelog += "\nSpecial Properties:";
                            if (properties[1] == 1)
                                changelog += "\tIgnores Def/Res";
                            if (properties[2] == 1)
                                changelog += "\tLeaves target at 1 HP";
                            if (properties[5] == 1)
                                changelog += "\tDouble Attack";
                            if (properties[1] == 0 && properties[2] == 0 && properties[5] == 0)
                                changelog += "\tNone";
                        }

                        if (msgLoaded && settings.changeMsg)
                        {
                            string newDescription = "";
                            if (itemData[blowBlockStart + blowMod + 12L] != 96)
                                newDescription += "Inflicts " + effectNames[itemData[blowBlockStart + blowMod + 12L]] + ".\n";
                            if (properties[0] == 1)
                                newDescription += "Deals magic damage.\n";
                            if (properties[1] == 1)
                                newDescription += "Ignores Def/Res.\n";
                            if (properties[2] == 1)
                                newDescription += "Leaves target at 1 HP.\n";
                            if (properties[5] == 1)
                                newDescription += "Attacks twice when initiating combat.\n";
                            if (newDescription.Length == 0)
                                newDescription = "No special attributes.\n";
                            msgStrings[15642 + index] = newDescription.Trim(new char[] { '\n' });
                        }
                    }
                }

                if (settings.randCa)
                {
                    changelog += "\n\n\n---COMBAT ARTS---";
                    for (int index = 0; index < 80; index++)
                    {
                        long artMod = artBlockLen * (long)index;

                        itemData[artBlockStart + artMod + 0L] = (byte)255; // Weapon requirement for combat arts
                        itemData[artBlockStart + artMod + 1L] = (byte)255;

                        itemData[artBlockStart + artMod + 8L] = (byte)255; // Class requirement

                        if (itemData[artBlockStart + artMod + 13L] != 63)
                        {
                            if (settings.randCaAvoid)
                            {
                                int avoidBonus = 0;
                                if (p(settings.randCaAvoidP))
                                    avoidBonus = roundTo(rng.Next(5, settings.randCaAvoidMax + 1), 5);
                                itemData[artBlockStart + artMod + 2L] = (byte)avoidBonus; // Avoid bonus
                                itemData[artBlockStart + artMod + 6L] = (byte)avoidBonus;
                            }

                            if (settings.randCaMight && p(settings.randCaMightP))
                                itemData[artBlockStart + artMod + 3L] = (byte)normalize(advancedRng(itemData[artBlockStart + artMod + 3L], settings.caMightBinomial,
                                    settings.caMightLinear, settings.caMightLinearDev, settings.caMightProportional, settings.caMightProportionalDev,
                                    settings.caMightExponential, settings.caMightExponentialDev, 1), 0, 255); // Might bonus

                            if (settings.randCaCrit)
                                itemData[artBlockStart + artMod + 4L] = (byte)randCrit(settings.randCaCritP, settings.randCaCritMax); // Crit bonus

                            if (settings.randCaHit && p(settings.randCaHitP))
                                itemData[artBlockStart + artMod + 5L] = (byte)roundTo(rng.Next(settings.caHitMin, settings.caHitMax + 1), 5); // Hit bonus

                            if (settings.randCaEffects)
                            {
                                if (p(settings.randCaEffectsP))
                                    itemData[artBlockStart + artMod + 7L] = (byte)rng.Next(18, 55); // Combat art effect
                                else
                                    itemData[artBlockStart + artMod + 7L] = (byte)0;
                            }

                            if (settings.randCaDurabilityCost && p(settings.randCaDurabilityCostP))
                                itemData[artBlockStart + artMod + 10L] = (byte)normalize(advancedRng(itemData[artBlockStart + artMod + 10L], settings.caDurabilityCostBinomial,
                                    settings.caDurabilityCostLinear, settings.caDurabilityCostLinearDev, settings.caDurabilityCostProportional, settings.caDurabilityCostProportionalDev,
                                    settings.caDurabilityCostExponential, settings.caDurabilityCostExponentialDev, 1), 0, 255); // Durability cost

                            if (settings.randAtkRange && p(settings.randAtkRangeP) && itemData[artBlockStart + artMod + 7L] < 100)
                            {
                                int rangeUpBound = itemData[artBlockStart + artMod + 11L];
                                int rangeLoBound = itemData[artBlockStart + artMod + 12L];
                                int newRangeUpBound = advancedRng(
                                    rangeUpBound, settings.caRangeBinomial,
                                    settings.caRangeLinear, settings.caRangeLinearDev,
                                    settings.caRangeProportional, settings.caRangeProportionalDev,
                                    settings.caRangeExponential, settings.caRangeExponentialDev, 1);
                                int newRangeLoBound = advancedRng(
                                    rangeLoBound, settings.caRangeBinomial,
                                    settings.caRangeLinear, settings.caRangeLinearDev,
                                    settings.caRangeProportional, settings.caRangeProportionalDev,
                                    settings.caRangeExponential, settings.caRangeExponentialDev, 1);
                                if (newRangeLoBound < 1)
                                    newRangeLoBound = 1;
                                if (newRangeUpBound > 99)
                                    newRangeUpBound = 99;
                                if (newRangeUpBound < 1)
                                    newRangeUpBound = 1;
                                if (newRangeLoBound > 99)
                                    newRangeLoBound = 99;
                                if (newRangeUpBound < newRangeLoBound)
                                {
                                    int switcher = newRangeLoBound;
                                    newRangeLoBound = newRangeUpBound;
                                    newRangeUpBound = switcher;
                                }
                                if (rangeUpBound < 100)
                                {
                                    itemData[artBlockStart + artMod + 11L] = (byte)newRangeUpBound; // Combat art range
                                    itemData[artBlockStart + artMod + 12L] = (byte)newRangeLoBound;
                                }
                            }

                            if (settings.randCaEffectiveness)
                            {
                                int[] effectivenessBits = { 0, 0, 0, 0, 0, 0, 0, 0 };
                                int effectivenessByte = 0;
                                for (int i = 0; i < 6; i++)
                                    if (p(settings.randCaEffectivenessP / 6))
                                        effectivenessBits[i] = 1;
                                effectivenessByte = toByte(effectivenessBits);
                                itemData[artBlockStart + artMod + 14L] = (byte)0;
                                itemData[artBlockStart + artMod + 15L] = (byte)effectivenessByte; // Combat art effectiveness
                            }

                            if (combatArtNames[index] != null)
                            {
                                changelog += "\n\n\t" + combatArtNames[index] +
                                    "\nCombat Art ID:\t\t" + index;
                                changelog += "\nAvoid Bonus:\t\t" + itemData[artBlockStart + artMod + 2L];
                                changelog += "\nMight Bonus:\t\t" + itemData[artBlockStart + artMod + 3L];
                                changelog += "\nCrit Bonus:\t\t" + itemData[artBlockStart + artMod + 4L];
                                changelog += "\nHit Bonus:\t\t" + (sbyte)itemData[artBlockStart + artMod + 5L];
                                changelog += "\nSpecial Effect:\t\t" + caEffectNames[itemData[artBlockStart + artMod + 7L]];
                                changelog += "\nDurability Cost:\t" + itemData[artBlockStart + artMod + 10L];
                                changelog += "\nEffectiveness:\t";
                                int[] effectiveness = toBits(itemData[artBlockStart + artMod + 14L]);
                                for (int i = 0; i < effectiveness.Length; i++)
                                    if (effectiveness[i] == 1)
                                        changelog += "\t" + getClassTyping(i);
                                if (itemData[artBlockStart + artMod + 14L] == 0)
                                    changelog += "\tNone";

                                if (msgLoaded && settings.changeMsg)
                                {
                                    string newDescription = "";
                                    if (itemData[artBlockStart + artMod + 7L] != 0)
                                        newDescription = caEffectNames[itemData[artBlockStart + artMod + 7L]] + ".";
                                    if (newDescription.Length == 0)
                                        newDescription = "No special attributes.";
                                    msgStrings[13220 + index] = newDescription;
                                }
                            }
                        }
                    }
                }

                if (settings.randBattalions)
                {
                    changelog += "\n\n\n---BATTALIONS---";
                    for (int index = 0; index < 200; index++)
                    {
                        long battalionMod = battalionBlockLen * (long)index;
                        if (settings.randBattalionEndurance)
                            itemData[battalionBlockStart + battalionMod + 6L] = (byte)normalize(advancedRng(itemData[battalionBlockStart + battalionMod + 6L], settings.battalionEnduranceBinomial,
                                settings.battalionEnduranceLinear, settings.battalionEnduranceLinearDev, settings.battalionEnduranceProportional, settings.battalionEnduranceProportionalDev,
                                settings.battalionEnduranceExponential, settings.battalionEnduranceExponentialDev, 5), 1, 255); // Battalion endurance

                        if (settings.randBattalionBoostBases)
                        {
                            int magic = itemData[battalionBlockStart + battalionMod + 8L];
                            if (magic > 128)
                                magic -= 256;
                            magic = (int)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * magic);
                            if (magic < 0)
                                magic += 256;
                            itemData[battalionBlockStart + battalionMod + 8L] = (byte)magic; // Base magic

                            int phys = itemData[battalionBlockStart + battalionMod + 10L];
                            if (phys > 128)
                                phys -= 256;
                            phys = (int)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * phys);
                            if (phys < 0)
                                phys += 256;
                            itemData[battalionBlockStart + battalionMod + 10L] = (byte)phys; // Base phys

                            int hit = itemData[battalionBlockStart + battalionMod + 11L];
                            if (hit > 128)
                                hit -= 256;
                            hit = (int)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * hit / 5) * 5;
                            if (hit < 0)
                                hit += 256;
                            itemData[battalionBlockStart + battalionMod + 11L] = (byte)hit; // Base hit

                            itemData[battalionBlockStart + battalionMod + 12L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 12L]); // Base crit

                            int avoidBase = itemData[battalionBlockStart + battalionMod + 13L];
                            if (avoidBase > 128)
                                avoidBase -= 256;
                            avoidBase = (int)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * avoidBase);
                            if (avoidBase < 0)
                                avoidBase += 256;
                            itemData[battalionBlockStart + battalionMod + 13L] = (byte)avoidBase; // Base avoid
                            itemData[battalionBlockStart + battalionMod + 14L] = (byte)avoidBase;

                            itemData[battalionBlockStart + battalionMod + 15L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 15L]); // Base prt

                            int rsl = itemData[battalionBlockStart + battalionMod + 16L];
                            if (rsl > 128)
                                rsl -= 256;
                            rsl = (int)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * rsl);
                            if (rsl < 0)
                                rsl += 256;
                            itemData[battalionBlockStart + battalionMod + 16L] = (byte)rsl; // Base rsl
                        }

                        if (settings.randBattalionBoostGrowths)
                        {
                            itemData[battalionBlockStart + battalionMod + 9L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 9L]); // Magic growth

                            itemData[battalionBlockStart + battalionMod + 19L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 19L]); // Phys growth
                            itemData[battalionBlockStart + battalionMod + 20L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 20L]); // Hit growth
                            itemData[battalionBlockStart + battalionMod + 21L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 21L]); // Crit growth

                            int avoid = itemData[battalionBlockStart + battalionMod + 22L];
                            if (avoid > 128)
                                avoid -= 256;
                            avoid = (int)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * avoid);
                            if (avoid < 0)
                                avoid += 256;
                            itemData[battalionBlockStart + battalionMod + 22L] = (byte)avoid; // Avoid growth
                            itemData[battalionBlockStart + battalionMod + 23L] = (byte)avoid;

                            itemData[battalionBlockStart + battalionMod + 24L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 24L]); // Prt growth
                            itemData[battalionBlockStart + battalionMod + 25L] = (byte)Math.Round(Math.Pow(2, 2 * rng.NextDouble() - 1) * itemData[battalionBlockStart + battalionMod + 25L]); // Rsl growth
                        }

                        if (settings.randBattalionStatBoosts)
                        {
                            int statAmount = itemData[battalionBlockStart + battalionMod + 36L];
                            int[] statBoosts = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            for (int stat = 0; stat < statBoosts.Length && settings.battalionStatBoostsIncludeAll; stat++)
                                if (rng.Next(0, 9) == 0)
                                    statBoosts[stat] = exponentialRng(statAmount, 2);

                            if (!settings.battalionStatBoostsIncludeAll)
                                statBoosts[8] = exponentialRng(statAmount, 2);

                            statBoosts[7] = (int)Math.Round(statBoosts[7] / 10.0);

                            itemData[battalionBlockStart + battalionMod + 28L] = (byte)statBoosts[0]; // Stat boosts
                            itemData[battalionBlockStart + battalionMod + 29L] = (byte)statBoosts[1];
                            itemData[battalionBlockStart + battalionMod + 30L] = (byte)statBoosts[2];
                            itemData[battalionBlockStart + battalionMod + 31L] = (byte)statBoosts[3];
                            itemData[battalionBlockStart + battalionMod + 32L] = (byte)statBoosts[4];
                            itemData[battalionBlockStart + battalionMod + 33L] = (byte)statBoosts[5];
                            itemData[battalionBlockStart + battalionMod + 34L] = (byte)statBoosts[6];
                            itemData[battalionBlockStart + battalionMod + 35L] = (byte)statBoosts[7];

                            itemData[battalionBlockStart + battalionMod + 36L] = (byte)statBoosts[8];
                        }

                        if (settings.randBattalionGambit)
                        {
                            int gambit = rng.Next(0, 40);
                            while (gambitNames[gambit] == "" || gambitNames[gambit] == "Bag of Tricks")
                                gambit = rng.Next(0, 40);
                            itemData[battalionBlockStart + battalionMod + 39L] = (byte)gambit;
                        }

                        switch (itemData[battalionBlockStart + battalionMod + 38L])
                        {
                            case 0:
                                eBattalions.Add(index);
                                break;
                            case 1:
                                dBattalions.Add(index);
                                break;
                            case 2:
                                cBattalions.Add(index);
                                break;
                            case 3:
                                bBattalions.Add(index);
                                break;
                            case 4:
                                aBattalions.Add(index);
                                break;
                        }

                        if (battalionNames[index] == "")
                            continue;

                        changelog += "\n\n\t" + battalionNames[index] +
                            "\nBattalion ID:\t" + index;
                        changelog += "\nEndurance:\t" + itemData[battalionBlockStart + battalionMod + 6L];
                        changelog += "\nBonus Bases:\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 10L] + "Phys\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 8L] + "Mag\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 11L] + "Hit\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 12L] + "Crit\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 13L] + "Avoid\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 15L] + "Prt\t" +
                            (sbyte)itemData[battalionBlockStart + battalionMod + 16L] + "Rsl";
                        changelog += "\nBonus Growths:\t" +
                            itemData[battalionBlockStart + battalionMod + 19L] + "Phys\t" +
                            itemData[battalionBlockStart + battalionMod + 9L] + "Mag\t" +
                            itemData[battalionBlockStart + battalionMod + 20L] + "Hit\t" +
                            itemData[battalionBlockStart + battalionMod + 21L] + "Crit\t" +
                            itemData[battalionBlockStart + battalionMod + 22L] + "Avoid\t" +
                            itemData[battalionBlockStart + battalionMod + 24L] + "Prt\t" +
                            itemData[battalionBlockStart + battalionMod + 25L] + "Rsl";
                        changelog += "\nStat Boosts:\t" +
                            itemData[battalionBlockStart + battalionMod + 28L] + "Str\t" +
                            itemData[battalionBlockStart + battalionMod + 29L] + "Mag\t" +
                            itemData[battalionBlockStart + battalionMod + 30L] + "Dex\t" +
                            itemData[battalionBlockStart + battalionMod + 31L] + "Spd\t" +
                            itemData[battalionBlockStart + battalionMod + 32L] + "Lck\t" +
                            itemData[battalionBlockStart + battalionMod + 33L] + "Def\t" +
                            itemData[battalionBlockStart + battalionMod + 34L] + "Res\t" +
                            itemData[battalionBlockStart + battalionMod + 36L] + "Cha\t" +
                            itemData[battalionBlockStart + battalionMod + 35L] + "Mv";
                        changelog += "\nGambit:\t\t" + gambitNames[itemData[battalionBlockStart + battalionMod + 39L]];

                        if (msgLoaded && settings.changeMsg)
                        {
                            string newDescription = "";
                            if (itemData[battalionBlockStart + battalionMod + 28L] != 0)
                                newDescription += ", Str +" + itemData[battalionBlockStart + battalionMod + 28L];
                            if (itemData[battalionBlockStart + battalionMod + 29L] != 0)
                                newDescription += ", Mag +" + itemData[battalionBlockStart + battalionMod + 29L];
                            if (itemData[battalionBlockStart + battalionMod + 30L] != 0)
                                newDescription += ", Dex +" + itemData[battalionBlockStart + battalionMod + 30L];
                            if (itemData[battalionBlockStart + battalionMod + 31L] != 0)
                                newDescription += ", Spd +" + itemData[battalionBlockStart + battalionMod + 31L];
                            if (itemData[battalionBlockStart + battalionMod + 32L] != 0)
                                newDescription += ", Lck +" + itemData[battalionBlockStart + battalionMod + 32L];
                            if (itemData[battalionBlockStart + battalionMod + 33L] != 0)
                                newDescription += ", Def +" + itemData[battalionBlockStart + battalionMod + 33L];
                            if (itemData[battalionBlockStart + battalionMod + 34L] != 0)
                                newDescription += ", Res +" + itemData[battalionBlockStart + battalionMod + 34L];
                            if (itemData[battalionBlockStart + battalionMod + 35L] != 0)
                                newDescription += ", Mv +" + itemData[battalionBlockStart + battalionMod + 35L];
                            if (newDescription.Length == 0)
                                newDescription = ", No other extra stats";
                            msgStrings[16203 + index] = newDescription.Trim(new char[] { ',', ' ' }) + ".";
                        }
                    }
                }
            }

            int[] newAssetIDs = new int[1050];
            for (int i = 0; i < newAssetIDs.Length; i++)
                newAssetIDs[i] = i;

            if (Randomizer.personLoaded)
            {
                if (settings.shuffleAssets)
                {
                    changelog += "\n\n\n---MODEL SWAPS---\n";

                    fixGenders();
                    newAssetIDs = shuffleAssets(settings.shuffleAssetsGender, settings.shuffleAssetsAge, settings);
                    for (int i = 0; i < characterNames.Length; i++)
                        if (characterNames[i] != null)
                            changelog += "\n" + characterNames[i] + " >>> " + characterNames[newAssetIDs[i]];
                }

                string[] charlog = new string[1201];
                for (int index = 0; index < 1201; ++index)
                {
                    long charMod = Randomizer.charBlockLen * (long)index;

                    charlog[index] = "";

                    if (settings.randModelData)
                    {
                        float num0L = (float)(doubleRng(settings.modelSize1Min, settings.modelSize1Max)); // Model Size 1
                        byte[] bytes0L = BitConverter.GetBytes(num0L);
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 0L] = bytes0L[0];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 1L] = bytes0L[1];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 2L] = bytes0L[2];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 3L] = bytes0L[3];

                        float num4L = (float)(doubleRng(settings.modelPreTsChestSizeMin, settings.modelPreTsChestSizeMax)); // PreTS Chest Size
                        byte[] bytes4L = BitConverter.GetBytes(num4L);
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 4L] = bytes4L[0];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 5L] = bytes4L[1];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 6L] = bytes4L[2];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 7L] = bytes4L[3];

                        float num8L = (float)(doubleRng(settings.modelSize2Min, settings.modelSize2Max)); // Model Size 2
                        byte[] bytes8L = BitConverter.GetBytes(num8L);
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 8L] = bytes8L[0];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 9L] = bytes8L[1];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 10L] = bytes8L[2];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 11L] = bytes8L[3];

                        float num12L = (float)(doubleRng(settings.modelPostTsChestSizeMin, settings.modelPostTsChestSizeMax)); // PostTS Chest Size
                        if (num12L < num4L)
                            num12L = num4L;
                        byte[] bytes12L = BitConverter.GetBytes(num12L);
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 12L] = bytes12L[0];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 13L] = bytes12L[1];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 14L] = bytes12L[2];
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 15L] = bytes12L[3];
                    }

                    //if (Randomizer.personData[Randomizer.charBlockStart + mod + 17L] < 255)
                    //{
                    //    short num16L = 255;
                    //    int[] badNum16L = { 85, 86, 87, 91, 92, 93, 97, 98, 99, 100, 101, 102 };
                    //    for (int i = 0; i < 1;)
                    //    {
                    //        num16L = (short)rng.Next(70, 104); // NPC head model?
                    //        if (!badNum16L.Contains(num16L))
                    //        {
                    //            byte[] bytes = BitConverter.GetBytes(num16L);
                    //            Randomizer.personData[Randomizer.charBlockStart + mod + 16L] = bytes[0];
                    //            Randomizer.personData[Randomizer.charBlockStart + mod + 17L] = bytes[1];
                    //            i++;
                    //        }
                    //    }
                    //}

                    //short num20L = 0;
                    //int[] badNum20L = { 12, 13, 14, 17, 18, 19, 20, 21, 22, 23, 24, 26, 27 };
                    //for (int i = 0; i < 1;)
                    //{
                    //    num20L = (short)rng.Next(11, 29); // No idea
                    //    if (!badNum20L.Contains(num20L))
                    //    {
                    //        byte[] bytes = BitConverter.GetBytes(num20L);
                    //        Randomizer.personData[Randomizer.charBlockStart + charMod + 20L] = bytes[0];
                    //        Randomizer.personData[Randomizer.charBlockStart + charMod + 21L] = bytes[1];
                    //        i++;
                    //    }
                    //}

                    bool monster = false;
                    int classTier = 0;

                    getUnitTier(index, ref classTier, ref monster);

                    if (classLoaded && !monster && settings.randCharStartClasses)
                    {
                        switch (classTier)
                        {
                            case 0:
                                Randomizer.personData[Randomizer.charBlockStart + charMod + 26L] = (byte)zeroClasses[rng.Next(0, zeroClasses.Count)];
                                break;
                            case 1:
                                Randomizer.personData[Randomizer.charBlockStart + charMod + 26L] = (byte)begClasses[rng.Next(0, begClasses.Count)];
                                break;
                            case 2:
                                Randomizer.personData[Randomizer.charBlockStart + charMod + 26L] = (byte)interClasses[rng.Next(0, interClasses.Count)];
                                break;
                            case 3:
                                Randomizer.personData[Randomizer.charBlockStart + charMod + 26L] = (byte)advClasses[rng.Next(0, advClasses.Count)];
                                break;
                            case 4:
                                Randomizer.personData[Randomizer.charBlockStart + charMod + 26L] = (byte)masterClasses[rng.Next(0, masterClasses.Count)];
                                break;
                            case 6:
                                Randomizer.personData[Randomizer.charBlockStart + charMod + 26L] = (byte)uniClasses[rng.Next(0, uniClasses.Count)];
                                break;
                            default:
                                break;
                        }
                    }

                    if (settings.randAge)
                    {
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 27L] = (byte)rng.Next(settings.ageMin, settings.ageMax + 1); // Age
                    }

                    if (Randomizer.personData[Randomizer.charBlockStart + charMod + 30L] < 50 && settings.randBirthday)
                    {
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 28L] = (byte)rng.Next(1, 13); // Birthday month
                        int days = 30;
                        switch (Randomizer.personData[Randomizer.charBlockStart + charMod + 28L])
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                                days = 31;
                                break;
                            case 2:
                                days = 29;
                                break;
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                days = 30;
                                break;
                            default:
                                break;
                        }
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 30L] = (byte)rng.Next(1, days + 1); // Birthday date

                        charlog[index] += "\nBirthday:\t\tDay " +
                            personData[Randomizer.charBlockStart + charMod + 30L] +
                            " of Month " + personData[Randomizer.charBlockStart + charMod + 28L];
                    }

                    if (settings.shuffleAssets)
                    {
                        charlog[index] += "\nGender:\t\t\t" + getGenderName(personData[Randomizer.charBlockStart + charMod + 38L]);
                    }

                    // Randomizer.personData[Randomizer.charBlockStart + mod + 31L] = (byte)rng.Next(0, 5); // NPC skin tone?
                    // Randomizer.personData[Randomizer.charBlockStart + charMod + 33L] = (byte)rng.Next(0, 3); // No idea
                    // Randomizer.personData[Randomizer.charBlockStart + charMod + 35L] = (byte)rng.Next(0, 3); // No idea
                    // Randomizer.personData[Randomizer.charBlockStart + charMod + 37L] = (byte)rng.Next(0, 256); // No idea

                    if (!monster && settings.randStartInventories)
                    {
                        if (itemLoaded && settings.randBattalions)
                        {
                            switch (classTier)
                            {
                                case 0:
                                    personData[charBlockStart + charMod + 40L] = (byte)200;
                                    break;
                                case 1:
                                    personData[charBlockStart + charMod + 40L] = (byte)eBattalions[rng.Next(0, eBattalions.Count)];
                                    break;
                                case 2:
                                    personData[charBlockStart + charMod + 40L] = (byte)dBattalions[rng.Next(0, dBattalions.Count)];
                                    break;
                                case 3:
                                    personData[charBlockStart + charMod + 40L] = (byte)cBattalions[rng.Next(0, cBattalions.Count)];
                                    break;
                                case 4:
                                    personData[charBlockStart + charMod + 40L] = (byte)bBattalions[rng.Next(0, bBattalions.Count)];
                                    break;
                                case 6:
                                    personData[charBlockStart + charMod + 40L] = (byte)aBattalions[rng.Next(0, aBattalions.Count)];
                                    break;
                            }
                        }
                        else
                            personData[charBlockStart + charMod + 40L] = (byte)rng.Next(0, 200);
                    }

                    if (!monster)
                    {
                        if (settings.randCharBases)
                        {
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 43L] = (byte)rng.Next(settings.hpCharBasesMin, settings.hpCharBasesMax + 1); // HP base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 51L] = (byte)rng.Next(settings.strCharBasesMin, settings.strCharBasesMax + 1); // Str base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 52L] = (byte)rng.Next(settings.magCharBasesMin, settings.magCharBasesMax + 1); // Mag base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 53L] = (byte)rng.Next(settings.dexCharBasesMin, settings.dexCharBasesMax + 1); // Dex base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 54L] = (byte)rng.Next(settings.speCharBasesMin, settings.speCharBasesMax + 1); // Spd base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 55L] = (byte)rng.Next(settings.lucCharBasesMin, settings.lucCharBasesMax + 1); // Lck base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 56L] = (byte)rng.Next(settings.defCharBasesMin, settings.defCharBasesMax + 1); // Def base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 57L] = (byte)rng.Next(settings.resCharBasesMin, settings.resCharBasesMax + 1); // Res base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 59L] = (byte)rng.Next(settings.chaCharBasesMin, settings.chaCharBasesMax + 1); // Cha base
                        }

                        if (settings.randCharGrowths)
                        {
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 41L] = (byte)roundTo(rng.Next(settings.hpCharGrowthsMin, settings.hpCharGrowthsMax), 5); // HP growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 60L] = (byte)roundTo(rng.Next(settings.strCharGrowthsMin, settings.strCharGrowthsMax), 5); // Str growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 61L] = (byte)roundTo(rng.Next(settings.magCharGrowthsMin, settings.magCharGrowthsMax), 5); // Mag growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 62L] = (byte)roundTo(rng.Next(settings.dexCharGrowthsMin, settings.dexCharGrowthsMax), 5); // Dex growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 63L] = (byte)roundTo(rng.Next(settings.speCharGrowthsMin, settings.speCharGrowthsMax), 5); // Spd growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 64L] = (byte)roundTo(rng.Next(settings.lucCharGrowthsMin, settings.lucCharGrowthsMax), 5); // Lck growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 65L] = (byte)roundTo(rng.Next(settings.defCharGrowthsMin, settings.defCharGrowthsMax), 5); // Def growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 66L] = (byte)roundTo(rng.Next(settings.resCharGrowthsMin, settings.resCharGrowthsMax), 5); // Res growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 68L] = (byte)roundTo(rng.Next(settings.chaCharGrowthsMin, settings.chaCharGrowthsMax), 5); // Cha growth
                        }
                    }
                    if (index < 5)
                    {
                        if (settings.ensureGoodBases && settings.randCharBases)
                        {
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 43L] = (byte)goodRng(settings.hpCharBasesMin, settings.hpCharBasesMax); // HP base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 51L] = (byte)goodRng(settings.strCharBasesMin, settings.strCharBasesMax); // Str base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 52L] = (byte)goodRng(settings.magCharBasesMin, settings.magCharBasesMax); // Mag base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 53L] = (byte)goodRng(settings.dexCharBasesMin, settings.dexCharBasesMax); // Dex base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 54L] = (byte)goodRng(settings.speCharBasesMin, settings.speCharBasesMax); // Spd base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 55L] = (byte)goodRng(settings.lucCharBasesMin, settings.lucCharBasesMax); // Lck base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 56L] = (byte)goodRng(settings.defCharBasesMin, settings.defCharBasesMax); // Def base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 57L] = (byte)goodRng(settings.resCharBasesMin, settings.resCharBasesMax); // Res base
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 59L] = (byte)goodRng(settings.chaCharBasesMin, settings.chaCharBasesMax); // Cha base
                        }

                        if (settings.ensureGoodGrowths && settings.randCharGrowths)
                        {
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 41L] = (byte)roundTo(goodRng(settings.hpCharGrowthsMin, settings.hpCharGrowthsMax), 5); // HP growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 60L] = (byte)roundTo(goodRng(settings.strCharGrowthsMin, settings.strCharGrowthsMax), 5); // Str growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 61L] = (byte)roundTo(goodRng(settings.magCharGrowthsMin, settings.magCharGrowthsMax), 5); // Mag growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 62L] = (byte)roundTo(goodRng(settings.dexCharGrowthsMin, settings.dexCharGrowthsMax), 5); // Dex growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 63L] = (byte)roundTo(goodRng(settings.speCharGrowthsMin, settings.speCharGrowthsMax), 5); // Spd growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 64L] = (byte)roundTo(goodRng(settings.lucCharGrowthsMin, settings.lucCharGrowthsMax), 5); // Lck growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 65L] = (byte)roundTo(goodRng(settings.defCharGrowthsMin, settings.defCharGrowthsMax), 5); // Def growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 66L] = (byte)roundTo(goodRng(settings.resCharGrowthsMin, settings.resCharGrowthsMax), 5); // Res growth
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 68L] = (byte)roundTo(goodRng(settings.chaCharGrowthsMin, settings.chaCharGrowthsMax), 5); // Cha growth
                        }
                    }

                    if (settings.randAniSet && !settings.aniSetIncludeCane)
                        if (Randomizer.personData[Randomizer.charBlockStart + charMod + 42L] != 6)
                            Randomizer.personData[Randomizer.charBlockStart + charMod + 42L] = (byte)rng.Next(0, 6); // Non-combat animation set

                    if (settings.randAniSet && settings.aniSetIncludeCane)
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 42L] = (byte)rng.Next(0, 7);

                    if (settings.randCrests)
                    {
                        int crest1 = 86;
                        int crest2 = 86;
                        if (p(settings.crest1P))
                        {
                            crest1 = rng.Next(0, 44);
                            if (p(settings.crest2P))
                                crest2 = rng.Next(0, 44);
                        }
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 44L] = (byte)crest1; // Crest
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 45L] = (byte)crest2; // Crest 2

                        charlog[index] += "\nCrests:\t\t";
                        if (crest1 == 86)
                        {
                            charlog[index] += "\tNone";
                        }
                        else
                        {
                            charlog[index] += "\t" + crestNames[crest1];
                            if (crest2 != 86)
                                charlog[index] += "\t" + crestNames[crest2];
                        }
                    }

                    //if (rng.Next(0, 100) == 0)
                    //    Randomizer.personData[Randomizer.charBlockStart + charMod + 46L] = (byte)rng.Next(0, 256); // Extra unit typing?

                    if (settings.randHeight)
                    {
                        byte preTsHeight = (byte)Randomizer.rng.Next(settings.heightMin, settings.heightMax + 1);
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 47L] = preTsHeight; // Heights

                        byte postTsHeight = (byte)normalize(rng.Next(settings.heightMin, preTsHeight + 31), preTsHeight, settings.heightMax);
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 48L] = postTsHeight;
                    }

                    //Randomizer.personData[Randomizer.charBlockStart + charMod + 49L] = (byte)rng.Next(0, 256); // No idea
                    //Randomizer.personData[Randomizer.charBlockStart + charMod + 50L] = (byte)rng.Next(0, 256); // No idea

                    if (settings.randCharBases && p(settings.randMovCharBasesP) && settings.randMovCharBases)
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 58L] = (byte)rng.Next(settings.movCharBasesMin, settings.movCharBasesMax + 1); // Mov base
                    if (settings.randCharGrowths && p(settings.randMovCharGrowthsP) && settings.randMovCharGrowths)
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 67L] = (byte)rng.Next(settings.movCharGrowthsMin, settings.movCharGrowthsMax + 1); // Mov growth

                    charlog[index] += "\nStat Growths:\t\t" +
                        personData[Randomizer.charBlockStart + charMod + 41L] + "HP\t" +
                        personData[Randomizer.charBlockStart + charMod + 60L] + "Str\t" +
                        personData[Randomizer.charBlockStart + charMod + 61L] + "Mag\t" +
                        personData[Randomizer.charBlockStart + charMod + 62L] + "Dex\t" +
                        personData[Randomizer.charBlockStart + charMod + 63L] + "Spd\t" +
                        personData[Randomizer.charBlockStart + charMod + 64L] + "Lck\t" +
                        personData[Randomizer.charBlockStart + charMod + 65L] + "Def\t" +
                        personData[Randomizer.charBlockStart + charMod + 66L] + "Res\t" +
                        personData[Randomizer.charBlockStart + charMod + 68L] + "Cha\t" +
                        personData[Randomizer.charBlockStart + charMod + 67L] + "Mv\t";

                    charlog[index] += "\nStat Bases:\t\t" +
                        personData[Randomizer.charBlockStart + charMod + 43L] + "HP\t" +
                        personData[Randomizer.charBlockStart + charMod + 51L] + "Str\t" +
                        personData[Randomizer.charBlockStart + charMod + 52L] + "Mag\t" +
                        personData[Randomizer.charBlockStart + charMod + 53L] + "Dex\t" +
                        personData[Randomizer.charBlockStart + charMod + 54L] + "Spd\t" +
                        personData[Randomizer.charBlockStart + charMod + 55L] + "Lck\t" +
                        personData[Randomizer.charBlockStart + charMod + 56L] + "Def\t" +
                        personData[Randomizer.charBlockStart + charMod + 57L] + "Res\t" +
                        personData[Randomizer.charBlockStart + charMod + 59L] + "Cha\t" +
                        personData[Randomizer.charBlockStart + charMod + 58L] + "Mv\t";

                    if (msgLoaded && settings.changeMsg && settings.qolText)
                    {
                        int msgIndex = index;
                        if (msgIndex >= 1045)
                            msgIndex = msgIndex - 1045 + 44;
                        if (msgIndex >= 1040)
                            msgIndex = msgIndex - 1040 + 40;
                        if (msgIndex < 46)
                        {
                            msgStrings[19829 + msgIndex] = "Great\nAverage\nBad\n";
                            msgStrings[19921 + msgIndex] = "Great\nAverage\nBad\n";
                            msgStrings[20013 + msgIndex] = "Great\nAverage\nBad\n";
                            msgStrings[20105 + msgIndex] = "Great\nAverage\nBad\n";

                            List<string>[] statRatings = new List<string>[3];
                            for (int i = 0; i < statRatings.Length; i++)
                                statRatings[i] = new List<string>();
                            int targetStatTotal = personData[Randomizer.charBlockStart + charMod + 41L];
                            int targetMin = settings.hpCharGrowthsMin;
                            int targetMax = settings.hpCharGrowthsMax;
                            string statName = "HP";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 60L];
                            targetMin = settings.strCharGrowthsMin;
                            targetMax = settings.strCharGrowthsMax;
                            statName = "Str";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 61L];
                            targetMin = settings.magCharGrowthsMin;
                            targetMax = settings.magCharGrowthsMax;
                            statName = "Mag";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 62L];
                            targetMin = settings.dexCharGrowthsMin;
                            targetMax = settings.dexCharGrowthsMax;
                            statName = "Dex";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 63L];
                            targetMin = settings.speCharGrowthsMin;
                            targetMax = settings.speCharGrowthsMax;
                            statName = "Spd";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 64L];
                            targetMin = settings.lucCharGrowthsMin;
                            targetMax = settings.lucCharGrowthsMax;
                            statName = "Lck";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 65L];
                            targetMin = settings.defCharGrowthsMin;
                            targetMax = settings.defCharGrowthsMax;
                            statName = "Def";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 66L];
                            targetMin = settings.resCharGrowthsMin;
                            targetMax = settings.resCharGrowthsMax;
                            statName = "Res";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            targetStatTotal = personData[Randomizer.charBlockStart + charMod + 68L];
                            targetMin = settings.chaCharGrowthsMin;
                            targetMax = settings.chaCharGrowthsMax;
                            statName = "Cha";
                            if (targetStatTotal < targetMin + (targetMax - targetMin) / 3.0)
                                statRatings[2].Add(targetStatTotal + " " + statName);
                            else if (targetStatTotal > targetMax - (targetMax - targetMin) / 3.0)
                                statRatings[0].Add(targetStatTotal + " " + statName);
                            else
                                statRatings[1].Add(targetStatTotal + " " + statName);
                            if (settings.randMovCharGrowths)
                            {
                                targetStatTotal = personData[Randomizer.charBlockStart + charMod + 67L];
                                targetMin = settings.movCharGrowthsMin;
                                targetMax = settings.movCharGrowthsMax;
                                statName = "Mv";
                                if (targetStatTotal < (targetMin + (targetMax - targetMin) / 3.0) * settings.randMovCharGrowthsP / 100)
                                    statRatings[2].Add(targetStatTotal + " " + statName);
                                else if (targetStatTotal > (targetMax - (targetMax - targetMin) / 3.0) * settings.randMovCharGrowthsP / 100)
                                    statRatings[0].Add(targetStatTotal + " " + statName);
                                else
                                    statRatings[1].Add(targetStatTotal + " " + statName);
                            }
                            string statValues = "";
                            for (int i = 0; i < statRatings.Length; i++)
                            {
                                int wordCount = 0;
                                for (int j = 0; j < statRatings[i].Count; j++)
                                {
                                    if (wordCount > 0)
                                        statValues += ", ";
                                    statValues += statRatings[i][j];
                                    wordCount++;
                                }
                                statValues += "\n";
                            }
                            statValues += "Total: " + (
                                personData[Randomizer.charBlockStart + charMod + 41L] +
                                personData[Randomizer.charBlockStart + charMod + 60L] +
                                personData[Randomizer.charBlockStart + charMod + 61L] +
                                personData[Randomizer.charBlockStart + charMod + 62L] +
                                personData[Randomizer.charBlockStart + charMod + 63L] +
                                personData[Randomizer.charBlockStart + charMod + 64L] +
                                personData[Randomizer.charBlockStart + charMod + 65L] +
                                personData[Randomizer.charBlockStart + charMod + 66L] +
                                personData[Randomizer.charBlockStart + charMod + 67L] +
                                personData[Randomizer.charBlockStart + charMod + 68L]);

                            msgStrings[19875 + msgIndex] = statValues;
                            msgStrings[19967 + msgIndex] = statValues;
                            msgStrings[20059 + msgIndex] = statValues;
                            msgStrings[20151 + msgIndex] = statValues;
                        }
                    }

                    if (settings.removeCharCaps)
                    {
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 34L] = (byte)199; // HP cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 69L] = (byte)199; // Str cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 70L] = (byte)199; // Mag cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 71L] = (byte)199; // Dex cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 72L] = (byte)199; // Spd cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 73L] = (byte)199; // Lck cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 74L] = (byte)199; // Def cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 75L] = (byte)199; // Res cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 76L] = (byte)199; // Mov cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 77L] = (byte)199; // Cha cap
                    }
                    if (settings.randCharCaps)
                    {
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 34L] = (byte)rng.Next(settings.hpCharCapsMin, settings.hpCharCapsMax + 1); // HP cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 69L] = (byte)rng.Next(settings.strCharCapsMin, settings.strCharCapsMax + 1); // Str cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 70L] = (byte)rng.Next(settings.magCharCapsMin, settings.magCharCapsMax + 1); // Mag cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 71L] = (byte)rng.Next(settings.dexCharCapsMin, settings.dexCharCapsMax + 1); // Dex cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 72L] = (byte)rng.Next(settings.speCharCapsMin, settings.speCharCapsMax + 1); // Spd cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 73L] = (byte)rng.Next(settings.lucCharCapsMin, settings.lucCharCapsMax + 1); // Lck cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 74L] = (byte)rng.Next(settings.defCharCapsMin, settings.defCharCapsMax + 1); // Def cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 75L] = (byte)rng.Next(settings.resCharCapsMin, settings.resCharCapsMax + 1); // Res cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 76L] = (byte)199; // Mov cap
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 77L] = (byte)rng.Next(settings.chaCharCapsMin, settings.chaCharCapsMax + 1); // Cha cap
                    }

                    charlog[index] += "\nStat Caps:\t\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 34L] + "HP\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 69L] + "Str\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 70L] + "Mag\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 71L] + "Dex\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 72L] + "Spd\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 73L] + "Lck\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 74L] + "Def\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 75L] + "Res\t" +
                        Randomizer.personData[Randomizer.charBlockStart + charMod + 77L] + "Cha";
                }

                if (settings.randGenericAb || settings.randGenericCa)
                {
                    changelog += "\n\n\n---Generic Learnsets---";

                    List<int> allAbilities = new List<int>();
                    for (int i = 0; i < 252; i++)
                        allAbilities.Add(i);
                    for (int i = 0; i < badAbilities.Length; i++)
                        allAbilities.Remove(badAbilities[i]);

                    for (int rank = 0; rank < 12; rank++)
                    {
                        long learnMod = Randomizer.charLearnLen * (long)rank;

                        switch (rank)
                        {
                            case 1:
                                if (settings.randGenericAb && !settings.preserveProwessAb)
                                {
                                    changelog += "\n";
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 16L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 18L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 16L]] + " learned at " + getSkillName(5) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 18L]] + " learned at " + getSkillName(7) + " " + getRankName(rank);
                                }
                                break;
                            case 2:
                                if (settings.randGenericCa)
                                {
                                    changelog += "\n";
                                    for (int i = 0; i < 5; i++)
                                    {
                                        int randomWeaponD = rng.Next(0, 5);
                                        personData[charLearnStart + learnMod + 0L + (long)i] = settings.baseGenericCa ? (byte)availableArts[i][rng.Next(0, availableArts[i].Length)] : (byte)availableArts[randomWeaponD][rng.Next(0, availableArts[randomWeaponD].Length)];
                                        changelog += "\n" +
                                            combatArtNames[personData[charLearnStart + learnMod + 0L + (long)i]] +
                                            " learned at " + getSkillName(i) + " " + getRankName(rank);
                                    }
                                }
                                break;
                            case 3:
                                if (settings.randGenericAb && !settings.preserveProwessAb)
                                {
                                    changelog += "\n";
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 16L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 18L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 16L]] + " learned at " + getSkillName(5) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 18L]] + " learned at " + getSkillName(7) + " " + getRankName(rank);
                                }
                                break;
                            case 4:
                                changelog += "\n";
                                if (settings.randGenericCa)
                                {
                                    int swordCaC = 0;
                                    int lanceCaC = 1;
                                    int axeCaC = 2;
                                    int gauntletCaC = 4;
                                    if (!settings.baseGenericCa)
                                    {
                                        swordCaC = rng.Next(0, 5);
                                        lanceCaC = rng.Next(0, 5);
                                        axeCaC = rng.Next(0, 5);
                                        gauntletCaC = rng.Next(0, 5);
                                    }
                                    personData[charLearnStart + learnMod + 0L] = (byte)availableArts[swordCaC][rng.Next(0, availableArts[swordCaC].Length)]; // Generic learnsets
                                    personData[charLearnStart + learnMod + 1L] = (byte)availableArts[lanceCaC][rng.Next(0, availableArts[lanceCaC].Length)];
                                    personData[charLearnStart + learnMod + 2L] = (byte)availableArts[axeCaC][rng.Next(0, availableArts[axeCaC].Length)];
                                    personData[charLearnStart + learnMod + 4L] = (byte)availableArts[gauntletCaC][rng.Next(0, availableArts[gauntletCaC].Length)];

                                    changelog += "\n" +
                                        combatArtNames[personData[charLearnStart + learnMod + 0L]] +
                                        " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        combatArtNames[personData[charLearnStart + learnMod + 1L]] +
                                        " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        combatArtNames[personData[charLearnStart + learnMod + 2L]] +
                                        " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        combatArtNames[personData[charLearnStart + learnMod + 4L]] +
                                        " learned at " + getSkillName(4) + " " + getRankName(rank);
                                }

                                if (settings.baseGenericAb)
                                {
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" +
                                        abilityNames[personData[charLearnStart + learnMod + 14L]] +
                                        " learned at " + getSkillName(3) + " " + getRankName(rank);

                                    for (int i = 0; i < 2; i++)
                                    {
                                        int tempAbility = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 19L + (long)i] = (byte)tempAbility;

                                        changelog += "\n" +
                                            abilityNames[personData[charLearnStart + learnMod + 19L + (long)i]] +
                                            " learned at " + getSkillName(8 + i) + " " + getRankName(rank);
                                    }
                                }
                                break;
                            case 5:
                                if (settings.randGenericAb && !settings.preserveProwessAb)
                                {
                                    changelog += "\n";
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 16L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 18L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 16L]] + " learned at " + getSkillName(5) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 18L]] + " learned at " + getSkillName(7) + " " + getRankName(rank);
                                }
                                break;
                            case 6:
                                changelog += "\n";
                                if (settings.randGenericCa)
                                {
                                    int gauntletCaB = 4;
                                    int genericCaB = 5;
                                    if (!settings.baseGenericCa)
                                    {
                                        gauntletCaB = rng.Next(0, 5);
                                        genericCaB = rng.Next(0, 5);
                                    }
                                    personData[charLearnStart + learnMod + 4L] = (byte)availableArts[gauntletCaB][rng.Next(0, availableArts[gauntletCaB].Length)];
                                    personData[charLearnStart + learnMod + 8L] = (byte)availableArts[genericCaB][rng.Next(0, availableArts[genericCaB].Length)];

                                    changelog += "\n" +
                                        combatArtNames[personData[charLearnStart + learnMod + 4L]] +
                                        " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        combatArtNames[personData[charLearnStart + learnMod + 8L]] +
                                        " learned at " + getSkillName(8) + " " + getRankName(rank);
                                }

                                if (settings.randGenericAb)
                                {
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    personData[charLearnStart + learnMod + 18L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 21L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" +
                                        abilityNames[personData[charLearnStart + learnMod + 11L]] +
                                        " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        abilityNames[personData[charLearnStart + learnMod + 12L]] +
                                        " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        abilityNames[personData[charLearnStart + learnMod + 13L]] +
                                        " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        abilityNames[personData[charLearnStart + learnMod + 18L]] +
                                        " learned at " + getSkillName(7) + " " + getRankName(rank);
                                    changelog += "\n" +
                                        abilityNames[personData[charLearnStart + learnMod + 21L]] +
                                        " learned at " + getSkillName(10) + " " + getRankName(rank);
                                }
                                break;
                            case 7:
                                if (settings.randGenericAb && !settings.preserveProwessAb)
                                {
                                    changelog += "\n";
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 16L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 18L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 16L]] + " learned at " + getSkillName(5) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 18L]] + " learned at " + getSkillName(7) + " " + getRankName(rank);
                                }
                                break;
                            case 9:
                                if (settings.randGenericAb)
                                {
                                    changelog += "\n";
                                    if (!settings.preserveProwessAb)
                                    {
                                        personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 16L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                        personData[charLearnStart + learnMod + 18L] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 16L]] + " learned at " + getSkillName(5) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);
                                        changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 18L]] + " learned at " + getSkillName(7) + " " + getRankName(rank);
                                    }
                                    for (int i = 0; i < 3; i++)
                                    {
                                        personData[charLearnStart + learnMod + 19L + (long)i] = settings.baseGenericAb ? (byte)genericAbilities[rng.Next(0, genericAbilities.Length)] : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                        changelog += "\n" +
                                            abilityNames[personData[charLearnStart + learnMod + 19L + (long)i]] +
                                            " learned at " + getSkillName(8 + i) + " " + getRankName(rank);
                                    }
                                }
                                break;
                            case 10:
                                if (settings.randGenericAb)
                                {
                                    changelog += "\n";
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);
                                }
                                break;
                            case 11:
                                if (settings.randGenericAb)
                                {
                                    changelog += "\n";
                                    personData[charLearnStart + learnMod + 11L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)swordAbilities[rng.Next(0, swordAbilities.Length)] : (byte)swordOnlyAbilities[rng.Next(0, swordOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 12L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)lanceAbilities[rng.Next(0, lanceAbilities.Length)] : (byte)lanceOnlyAbilities[rng.Next(0, lanceOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 13L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)axeAbilities[rng.Next(0, axeAbilities.Length)] : (byte)axeOnlyAbilities[rng.Next(0, axeOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 14L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)bowAbilities[rng.Next(0, bowAbilities.Length)] : (byte)bowOnlyAbilities[rng.Next(0, bowOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 15L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)brawlAbilities[rng.Next(0, brawlAbilities.Length)] : (byte)brawlOnlyAbilities[rng.Next(0, brawlOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];
                                    personData[charLearnStart + learnMod + 17L] = settings.baseGenericAb ? (rng.Next(0, 2) == 0 ? (byte)faithAbilities[rng.Next(0, faithAbilities.Length)] : (byte)faithOnlyAbilities[rng.Next(0, faithOnlyAbilities.Length)]) : (byte)allAbilities[rng.Next(0, allAbilities.Count)];

                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 11L]] + " learned at " + getSkillName(0) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 12L]] + " learned at " + getSkillName(1) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 13L]] + " learned at " + getSkillName(2) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 14L]] + " learned at " + getSkillName(3) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 15L]] + " learned at " + getSkillName(4) + " " + getRankName(rank);
                                    changelog += "\n" + abilityNames[personData[charLearnStart + learnMod + 17L]] + " learned at " + getSkillName(6) + " " + getRankName(rank);

                                    for (int i = 0; i < 4; i++)
                                    {
                                        personData[charLearnStart + learnMod + 18L + (long)i] = (byte)genericAbilities[rng.Next(genericAbilities.Length)];

                                        changelog += "\n" +
                                            abilityNames[personData[charLearnStart + learnMod + 18L + (long)i]] +
                                            " learned at " + getSkillName(7 + i) + " " + getRankName(rank);
                                    }
                                }
                                break;
                            default:
                                break;

                        }
                    }
                }

                changelog += "\n\n\n---CHARACTER DATA---";

                for (int index = 0; index < 45; ++index)
                {
                    long rankMod = Randomizer.charWepRankLen * (long)index;
                    long spellMod = Randomizer.charSpellLen * (long)index;
                    long skillMod = Randomizer.charSkillLen * (long)index;
                    long wepMod = Randomizer.charWepLen * (long)index;
                    long artMod = Randomizer.charArtLen * (long)index;
                    long supMod = Randomizer.charSupLen * (long)index;
                    long speSupMod = Randomizer.charSpeSupLen * (long)index;

                    int charIndex = index;
                    if (charIndex > 37)
                        charIndex = charIndex - 38 + 1040;
                    long charMod = Randomizer.charBlockLen * (long)charIndex;

                    int facultyIndex = index - 2;
                    if (index >= 38)
                        facultyIndex--;
                    long facultyMod = Randomizer.charFacultyLen * (long)facultyIndex;

                    int seminarIndex = index;
                    if (index >= 38)
                        seminarIndex -= 3;
                    long seminarMod = Randomizer.charSeminarLen * (long)seminarIndex;

                    int goalIndex = index - 2;
                    if (index >= 38)
                        goalIndex -= 3;
                    long goalMod = Randomizer.charGoalLen * (long)goalIndex;

                    changelog += "\n\n\t" + characterNames[newAssetIDs[charIndex]];
                    changelog += "\nCharacter ID:\t\t" + charIndex;
                    changelog += charlog[charIndex];

                    int classTier = 0;
                    bool monster = false;
                    getUnitTier(charIndex, ref classTier, ref monster);

                    // personData[charWepRankStart + rankMod + 0L] = (byte)rng.Next(0, 5); // No idea

                    //int[] badNum1L = { 1, 2, 3, 4, 5, 7, 11, 16, 18, 19, 20 };
                    //bool done1L = false;
                    //int num1L = 255;
                    //while (!done1L)
                    //{
                    //    num1L = rng.Next(0, 22);
                    //    if (!badNum1L.Contains(num1L))
                    //    {
                    //        personData[charWepRankStart + rankMod + 1L] = (byte)num1L; // No idea
                    //        done1L = true;
                    //    }
                    //}

                    //int[] badNum2L = { 10, 11, 12, 13, 14, 15, 16, 18, 19, 20, 21, 22, 23 };
                    //bool done2L = false;
                    //int num2L = 255;
                    //while (!done2L)
                    //{
                    //    num2L = rng.Next(0, 26);
                    //    if (!badNum2L.Contains(num2L))
                    //    {
                    //        personData[charWepRankStart + rankMod + 2L] = (byte)num2L; // No idea
                    //        done2L = true;
                    //    }
                    //}

                    // personData[charWepRankStart + rankMod + 8L] = (byte)rng.Next(0, 256); // No idea (pre-obtained class mastery in here)

                    int[] proficiencies = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                    if (settings.randCharProfs)
                    {
                        int posProficiencyNum = rng.Next(settings.strengthCountMin, settings.strengthCountMax + 1);
                        int negProficiencyNum = rng.Next(settings.weaknessCountMin, settings.weaknessCountMax + 1);
                        if (index < 2)
                            negProficiencyNum = settings.weaknessCountMin;
                        proficiencies[rng.Next(0, 7)]++;
                        posProficiencyNum--;
                        int a = 0;
                        for (int i = 0; i < posProficiencyNum;)
                        {
                            a = rng.Next(0, 11);
                            if (proficiencies[a] == 2)
                            {
                                proficiencies[a]++;
                                i++;
                            }
                        }
                        for (int i = 0; i < negProficiencyNum;)
                        {
                            a = rng.Next(0, 11);
                            if (proficiencies[a] == 2)
                            {
                                proficiencies[a]--;
                                i++;
                            }
                        }
                        personData[charWepRankStart + rankMod + 20L] = (byte)proficiencies[0]; // Sword Proficiency
                        personData[charWepRankStart + rankMod + 21L] = (byte)proficiencies[1]; // Lance Proficiency
                        personData[charWepRankStart + rankMod + 22L] = (byte)proficiencies[2]; // Axe Proficiency
                        personData[charWepRankStart + rankMod + 23L] = (byte)proficiencies[3]; // Bow Proficiency
                        personData[charWepRankStart + rankMod + 24L] = (byte)proficiencies[4]; // Brawl Proficiency
                        personData[charWepRankStart + rankMod + 25L] = (byte)proficiencies[5]; // Reason Proficiency
                        personData[charWepRankStart + rankMod + 26L] = (byte)proficiencies[6]; // Faith Proficiency
                        personData[charWepRankStart + rankMod + 27L] = (byte)proficiencies[7]; // Authority Proficiency
                        personData[charWepRankStart + rankMod + 28L] = (byte)proficiencies[8]; // Hvy Armor Proficiency
                        personData[charWepRankStart + rankMod + 29L] = (byte)proficiencies[9]; // Riding Proficiency
                        personData[charWepRankStart + rankMod + 30L] = (byte)proficiencies[10]; // Flying Proficiency

                        changelog += "\nProficiencies:\t";
                        for (int i = 0; i < proficiencies.Length; i++)
                        {
                            switch (proficiencies[i])
                            {
                                case 1:
                                    changelog += "\t-" + getSkillName(i);
                                    break;
                                case 3:
                                    changelog += "\t+" + getSkillName(i);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        proficiencies[0] = personData[charWepRankStart + rankMod + 20L];
                        proficiencies[1] = personData[charWepRankStart + rankMod + 21L];
                        proficiencies[2] = personData[charWepRankStart + rankMod + 22L];
                        proficiencies[3] = personData[charWepRankStart + rankMod + 23L];
                        proficiencies[4] = personData[charWepRankStart + rankMod + 24L];
                        proficiencies[5] = personData[charWepRankStart + rankMod + 25L];
                        proficiencies[6] = personData[charWepRankStart + rankMod + 26L];
                        proficiencies[7] = personData[charWepRankStart + rankMod + 27L];
                        proficiencies[8] = personData[charWepRankStart + rankMod + 28L];
                        proficiencies[9] = personData[charWepRankStart + rankMod + 29L];
                        proficiencies[10] = personData[charWepRankStart + rankMod + 30L];
                    }

                    proficiencyArchive[charIndex] = new int[11];
                    proficiencies.CopyTo(proficiencyArchive[charIndex], 0);

                    int startClass = 255;
                    int[] preCerts = { 255, 255, 255, 255 };
                    int[] postTSCerts = { 255, 255, 255 };
                    if (classLoaded)
                    {
                        switch (classTier)
                        {
                            case 0:
                                if (settings.randCharStartClasses)
                                    startClass = zeroClasses[rng.Next(0, zeroClasses.Count)];
                                if (settings.randCharPreCertClasses)
                                {
                                    postTSCerts[0] = settings.charOptimalClasses ? getBestFittingClass(1, proficiencies, classCertReqs) : begClasses[rng.Next(0, begClasses.Count)];
                                    postTSCerts[1] = settings.charOptimalClasses ? getBestFittingClass(2, proficiencies, classCertReqs) : interClasses[rng.Next(0, interClasses.Count)];
                                    postTSCerts[2] = settings.charOptimalClasses ? getBestFittingClass(3, proficiencies, classCertReqs) : advClasses[rng.Next(0, advClasses.Count)];
                                }
                                break;
                            case 1:
                                if (settings.randCharStartClasses)
                                    startClass = settings.charOptimalClasses ? getBestFittingClass(1, proficiencies, classCertReqs) : begClasses[rng.Next(0, begClasses.Count)];
                                if (settings.randCharPreCertClasses)
                                {
                                    preCerts[0] = zeroClasses[rng.Next(0, zeroClasses.Count)];
                                    postTSCerts[0] = settings.charOptimalClasses ? getBestFittingClass(1, proficiencies, classCertReqs) : begClasses[rng.Next(0, begClasses.Count)];
                                }
                                break;
                            case 2:
                                if (settings.randCharStartClasses)
                                    startClass = settings.charOptimalClasses ? getBestFittingClass(2, proficiencies, classCertReqs) : interClasses[rng.Next(0, interClasses.Count)];
                                if (settings.randCharPreCertClasses)
                                {
                                    preCerts[0] = zeroClasses[rng.Next(0, zeroClasses.Count)];
                                    preCerts[1] = settings.charOptimalClasses ? getBestFittingClass(1, proficiencies, classCertReqs) : begClasses[rng.Next(0, begClasses.Count)];
                                    postTSCerts[0] = settings.charOptimalClasses ? getBestFittingClass(2, proficiencies, classCertReqs) : interClasses[rng.Next(0, interClasses.Count)];
                                }
                                break;
                            case 3:
                                if (settings.randCharStartClasses)
                                    startClass = settings.charOptimalClasses ? getBestFittingClass(3, proficiencies, classCertReqs) : advClasses[rng.Next(0, advClasses.Count)];
                                if (settings.randCharPreCertClasses)
                                {
                                    preCerts[0] = zeroClasses[rng.Next(0, zeroClasses.Count)];
                                    preCerts[1] = settings.charOptimalClasses ? getBestFittingClass(1, proficiencies, classCertReqs) : begClasses[rng.Next(0, begClasses.Count)];
                                    preCerts[2] = settings.charOptimalClasses ? getBestFittingClass(2, proficiencies, classCertReqs) : interClasses[rng.Next(0, interClasses.Count)];
                                    postTSCerts[0] = settings.charOptimalClasses ? getBestFittingClass(3, proficiencies, classCertReqs) : advClasses[rng.Next(0, advClasses.Count)];
                                }
                                break;
                            case 4:
                                // There's, like, none that this would apply to, so I'm, like, not even gonna bother with this, and if you, like, think you can make me, you'd be, like, wrong.
                                break;
                            case 6:
                                if (settings.randCharPreCertClasses)
                                {
                                    preCerts[0] = zeroClasses[rng.Next(0, zeroClasses.Count)];
                                    preCerts[1] = settings.charOptimalClasses ? getBestFittingClass(1, proficiencies, classCertReqs) : begClasses[rng.Next(0, begClasses.Count)];
                                    preCerts[2] = settings.charOptimalClasses ? getBestFittingClass(2, proficiencies, classCertReqs) : interClasses[rng.Next(0, interClasses.Count)];
                                }
                                if (settings.randCharStartClasses)
                                    startClass = personData[charBlockStart + charMod + 26L];
                                break;
                            default:
                                break;
                        }

                        if (settings.randCharStartClasses)
                        {
                            personData[charBlockStart + charMod + 26L] = (byte)startClass; // Starting classes
                            personData[charWepRankStart + rankMod + 3L] = (byte)startClass; // Pre TS class
                        }
                        if (settings.randCharPreCertClasses)
                        {
                            personData[charWepRankStart + rankMod + 4L] = (byte)preCerts[0]; // Pre-certified classes
                            personData[charWepRankStart + rankMod + 5L] = (byte)preCerts[1];
                            personData[charWepRankStart + rankMod + 6L] = (byte)preCerts[2];
                            personData[charWepRankStart + rankMod + 7L] = (byte)preCerts[3];
                            personData[charWepRankStart + rankMod + 31L] = (byte)postTSCerts[0]; // Post TS classes
                            personData[charWepRankStart + rankMod + 32L] = (byte)postTSCerts[1];
                            personData[charWepRankStart + rankMod + 33L] = (byte)postTSCerts[2];
                        }
                    }

                    if (!settings.randCharStartClasses)
                        startClass = personData[charBlockStart + charMod + 26L];
                    if (!settings.randCharPreCertClasses)
                    {
                        preCerts[0] = personData[charWepRankStart + rankMod + 4L];
                        preCerts[1] = personData[charWepRankStart + rankMod + 5L];
                        preCerts[2] = personData[charWepRankStart + rankMod + 6L];
                        preCerts[3] = personData[charWepRankStart + rankMod + 7L];
                        postTSCerts[0] = personData[charWepRankStart + rankMod + 31L];
                        postTSCerts[1] = personData[charWepRankStart + rankMod + 32L];
                        postTSCerts[2] = personData[charWepRankStart + rankMod + 33L];
                    }

                    if (settings.randStartRanks)
                    {
                        int[] startingRanks = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        switch (classTier)
                        {
                            case 0:
                                for (int skill = 0; skill < startingRanks.Length; skill++)
                                {
                                    if (settings.baseStartRanks)
                                    {
                                        if (proficiencies[skill] == 3)
                                        {
                                            startingRanks[skill] = rng.Next(0, 4);
                                            if (skill == 5 || skill == 6)
                                                startingRanks[skill] = rng.Next(2, 4);
                                        }
                                    }
                                    else
                                        startingRanks[skill] = rng.Next(0, 4);
                                }
                                break;
                            case 1:
                                for (int skill = 0; skill < startingRanks.Length; skill++)
                                {
                                    if (settings.baseStartRanks)
                                    {
                                        if (proficiencies[skill] == 3)
                                        {
                                            startingRanks[skill] = rng.Next(0, 4);
                                            if (skill == 5 || skill == 6)
                                                startingRanks[skill] = rng.Next(2, 4);
                                        }
                                    }
                                    else
                                        startingRanks[skill] = rng.Next(0, 4);
                                }
                                break;
                            case 2:
                                for (int skill = 0; skill < startingRanks.Length; skill++)
                                {
                                    if (settings.baseStartRanks)
                                    {
                                        if (proficiencies[skill] == 3)
                                        {
                                            startingRanks[skill] = rng.Next(1, 5);
                                            if (skill == 5 || skill == 6)
                                                startingRanks[skill] = rng.Next(2, 5);
                                        }
                                        else if (proficiencies[skill] <= 2 && rng.Next(0, 10) == 0)
                                            startingRanks[skill] = 2;
                                        if (classLoaded)
                                            if (classCertReqs[startClass][1][skill] > startingRanks[skill])
                                                startingRanks[skill] = classCertReqs[startClass][1][skill];
                                    }
                                    else
                                        startingRanks[skill] = rng.Next(0, 5);
                                }
                                break;
                            case 3:
                                for (int skill = 0; skill < startingRanks.Length; skill++)
                                {
                                    if (settings.baseStartRanks)
                                    {
                                        if (proficiencies[skill] == 3)
                                            startingRanks[skill] = rng.Next(2, 7);
                                        else if (proficiencies[skill] <= 2 && rng.Next(0, 10) == 0)
                                            startingRanks[skill] = rng.Next(2, 5);
                                        if (classLoaded)
                                        {
                                            if (preCerts[2] != 255 && classCertReqs[preCerts[2]][1][skill] > startingRanks[skill])
                                                startingRanks[skill] = classCertReqs[preCerts[2]][1][skill];
                                            if (classCertReqs[startClass][1][skill] > startingRanks[skill])
                                                startingRanks[skill] = classCertReqs[startClass][1][skill];
                                        }
                                    }
                                    else
                                        startingRanks[skill] = rng.Next(0, 7);
                                }
                                break;
                            case 4:
                                // Bruh
                                break;
                            case 6:
                                for (int skill = 0; skill < startingRanks.Length; skill++)
                                {
                                    if (settings.baseStartRanks)
                                    {
                                        if (proficiencies[skill] == 3)
                                            startingRanks[skill] = rng.Next(3, 9);
                                        else if (proficiencies[skill] <= 2 && rng.Next(0, 10) == 0)
                                            startingRanks[skill] = 4;
                                        if (classLoaded)
                                            if (preCerts[2] != 255 && classCertReqs[preCerts[2]][1][skill] > startingRanks[skill])
                                                startingRanks[skill] = classCertReqs[preCerts[2]][1][skill];
                                    }
                                    else
                                        startingRanks[skill] = rng.Next(0, 9);
                                }
                                break;
                        }
                        personData[charWepRankStart + rankMod + 9L] = (byte)startingRanks[0]; // Starting ranks
                        personData[charWepRankStart + rankMod + 10L] = (byte)startingRanks[1];
                        personData[charWepRankStart + rankMod + 11L] = (byte)startingRanks[2];
                        personData[charWepRankStart + rankMod + 12L] = (byte)startingRanks[3];
                        personData[charWepRankStart + rankMod + 13L] = (byte)startingRanks[4];
                        personData[charWepRankStart + rankMod + 14L] = (byte)startingRanks[5];
                        personData[charWepRankStart + rankMod + 15L] = (byte)startingRanks[6];
                        personData[charWepRankStart + rankMod + 16L] = (byte)startingRanks[7];
                        personData[charWepRankStart + rankMod + 17L] = (byte)startingRanks[8];
                        personData[charWepRankStart + rankMod + 18L] = (byte)startingRanks[9];
                        personData[charWepRankStart + rankMod + 19L] = (byte)startingRanks[10];

                        changelog += "\nStarting Ranks:\t\t" +
                            "Swo " + getRankName(startingRanks[0]) + "\t" +
                            "Lan " + getRankName(startingRanks[1]) + "\t" +
                            "Axe " + getRankName(startingRanks[2]) + "\t" +
                            "Bow " + getRankName(startingRanks[3]) + "\t" +
                            "Bra " + getRankName(startingRanks[4]) + "\t" +
                            "Rea " + getRankName(startingRanks[5]) + "\t" +
                            "Fai " + getRankName(startingRanks[6]) + "\t" +
                            "Aut " + getRankName(startingRanks[7]) + "\t" +
                            "HeA " + getRankName(startingRanks[8]) + "\t" +
                            "Rid " + getRankName(startingRanks[9]) + "\t" +
                            "Fly " + getRankName(startingRanks[10]);
                    }

                    int[] startingInventory = { 0, 0 };
                    List<int> wepStrengths = new List<int>();
                    for (int i = 0; i < 5; i++)
                        if (proficiencies[i] == 3)
                            wepStrengths.Add(i);

                    if (settings.randStartInventories)
                    {
                        if (settings.baseStartInventories)
                        {
                            if (wepStrengths.Count > 0)
                            {
                                int localRank = 0;
                                switch (classTier)
                                {
                                    case 0:
                                        localRank = 0;
                                        break;
                                    case 1:
                                        localRank = 1;
                                        break;
                                    case 2:
                                        localRank = 2;
                                        break;
                                    case 3:
                                        localRank = 3;
                                        break;
                                    case 4:
                                        localRank = 4;
                                        break;
                                    case 6:
                                        localRank = 5;
                                        break;
                                }
                                int weaponType = wepStrengths[rng.Next(0, wepStrengths.Count)];
                                List<int> weaponPool = new List<int>();
                                for (int i = 0; i <= localRank; i++)
                                    weaponPool.AddRange(availableWeapons[weaponType][i]);
                                startingInventory[0] = weaponPool[rng.Next(0, weaponPool.Count)] + itemTypeIdOffsets[0];
                            }
                        }
                        else
                            startingInventory[0] = rng.Next(1, 191) + itemTypeIdOffsets[0];
                        if (settings.randStartInventoryItem && p(settings.startInventoryItemP))
                            startingInventory[1] =  obtainableItems[rng.Next(0, obtainableItems.Length)] + itemTypeIdOffsets[2];
                        if (index == 32)
                            startingInventory[0] = 60 + itemTypeIdOffsets[0];
                        byte[] invBytes2L = BitConverter.GetBytes((ushort)startingInventory[0]);
                        byte[] invBytes4L = BitConverter.GetBytes((ushort)startingInventory[1]);
                        personData[charWepStart + wepMod + 2L] = invBytes2L[0]; // Starting inventory
                        personData[charWepStart + wepMod + 3L] = invBytes2L[1];
                        personData[charWepStart + wepMod + 4L] = invBytes4L[0];
                        personData[charWepStart + wepMod + 5L] = invBytes4L[1];
                    }

                    if (settings.randCharCa)
                    {
                        changelog += "\nCombat Art Learnset:";

                        int numSkillArt = 0;
                        if (wepStrengths.Count > 0 || !settings.limitCharCa)
                        {
                            numSkillArt = rng.Next(settings.charCaCountMin, settings.charCaCountMax + 1);
                            int[] skillArts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            int[] skillArtSkills = { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };
                            int[] skillArtRanks = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            for (int i = 0; i < numSkillArt; i++)
                            {
                                skillArtSkills[i] = settings.limitCharCa ? wepStrengths[rng.Next(0, wepStrengths.Count)] : rng.Next(0, 5);
                                int randomWeapon = rng.Next(0, 5);
                                skillArts[i] = settings.baseCharCa ? availableArts[skillArtSkills[i]][rng.Next(0, availableArts[skillArtSkills[i]].Length)] : availableArts[randomWeapon][rng.Next(0, availableArts[randomWeapon].Length)];
                                skillArtRanks[i] = rng.Next(1, 12);
                                changelog += "\t" + combatArtNames[skillArts[i]] + " at " + getSkillName(skillArtSkills[i]) + " " + getRankName(skillArtRanks[i]);
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                personData[charArtStart + artMod + 0L + (long)i] = (byte)skillArts[i]; // Combat arts learned
                                personData[charArtStart + artMod + 10L + (long)i] = (byte)skillArtSkills[i]; // Skill for combat arts
                                personData[charArtStart + artMod + 20L + (long)i] = (byte)skillArtRanks[i]; // Rank for combat arts
                            }
                        }
                        if (numSkillArt == 0)
                            changelog += "\tNone";
                    }

                    if (settings.randSupportBonuses)
                    {
                        int[] supMysteryStatBonus1 = { rng.Next(2, 6), 0, 0, 0, 0 };
                        int[] supMysteryStatBonus2 = { rng.Next(2, 6), 0, 0, 0, 0 };
                        int[] supHitBonus = { rng.Next(2, 6), 0, 0, 0, 0 };
                        int[] supAvoidBonus = { rng.Next(2, 6), 0, 0, 0, 0 };
                        int[] supMightBonus = { rng.Next(0, 3), 0, 0, 0, 0 };
                        for (int i = 1; i < 5; i++)
                        {
                            supMysteryStatBonus1[i] = supMysteryStatBonus1[i - 1] + rng.Next(2, 6);
                            supMysteryStatBonus2[i] = supMysteryStatBonus2[i - 1] + rng.Next(2, 6);
                            supHitBonus[i] = supHitBonus[i - 1] + rng.Next(2, 6);
                            supAvoidBonus[i] = supAvoidBonus[i - 1] + rng.Next(2, 6);
                            supMightBonus[i] = supMightBonus[i - 1] + rng.Next(0, 3);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            //personData[charSupStart + supMod + 5L + (long)i] = (byte)supMysteryStatBonus2[i];
                            personData[charSupStart + supMod + 10L + (long)i] = (byte)supHitBonus[i]; // Regular linked attack bonuses
                            personData[charSupStart + supMod + 15L + (long)i] = (byte)supAvoidBonus[i];
                            if (settings.supportBonusesIncludeMore)
                            {
                                personData[charSupStart + supMod + 20L + (long)i] = (byte)supMightBonus[i];
                                personData[charSupStart + supMod + 0L + (long)i] = (byte)supMysteryStatBonus1[i];
                            }
                        }
                    }

                    if (index <= 23 && settings.randSpecialSupportBonuses)
                    {
                        int[] speSupMysteryStatBonus1 = { rng.Next(3, 6), 0, 0, 0, 0 };
                        int[] speSupMysteryStatBonus2 = { rng.Next(3, 6), 0, 0, 0, 0 };
                        int[] speSupHitBonus = { rng.Next(3, 6), 0, 0, 0, 0 };
                        int[] speSupAvoidBonus = { rng.Next(3, 6), 0, 0, 0, 0 };
                        int[] speSupMightBonus = { rng.Next(1, 3), 0, 0, 0, 0 };
                        for (int i = 1; i < 5; i++)
                        {
                            speSupMysteryStatBonus1[i] = speSupMysteryStatBonus1[i - 1] + rng.Next(3, 6);
                            speSupMysteryStatBonus2[i] = speSupMysteryStatBonus2[i - 1] + rng.Next(3, 6);
                            speSupHitBonus[i] = speSupHitBonus[i - 1] + rng.Next(3, 6);
                            speSupAvoidBonus[i] = speSupAvoidBonus[i - 1] + rng.Next(3, 6);
                            speSupMightBonus[i] = speSupMightBonus[i - 1] + rng.Next(1, 3);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            if (settings.supportBonusesIncludeMore)
                                personData[charSpeSupStart + speSupMod + 4L + (long)i] = (byte)speSupMysteryStatBonus1[i]; // Special linked attack bonuses
                            //personData[charSpeSupStart + speSupMod + 9L + (long)i] = (byte)supMysteryStatBonus2[i];
                            personData[charSpeSupStart + speSupMod + 14L + (long)i] = (byte)speSupHitBonus[i];
                            personData[charSpeSupStart + speSupMod + 19L + (long)i] = (byte)speSupAvoidBonus[i];
                            personData[charSpeSupStart + speSupMod + 24L + (long)i] = (byte)speSupMightBonus[i];
                        }
                    }

                    int[] budCharacter = { 2999, 2999, 2999, 2999, 2999 };
                    int[] lessonReq = { 0, 0, 0, 0, 0 };
                    int[] budSkill = { 255, 255, 255, 255, 255 };
                    int[] budArt = { 255, 255, 255, 255, 255 };
                    int[] budAbility = { 255, 255, 255, 255, 255 };
                    List<int> strengths = new List<int>();
                    for (int i = 0; i < proficiencies.Length; i++)
                        if (proficiencies[i] == 3)
                            strengths.Add(i);
                    bool hasBlackSpells = false;
                    bool hasDarkSpells = false;
                    int budRolls = settings.multipleBuddingTalents ? 5 : 1;
                    List<int> allAbilities = new List<int>();
                    for (int i = 0; i < 252; i++)
                        allAbilities.Add(i);
                    for (int i = 0; i < badAbilities.Length; i++)
                        allAbilities.Remove(badAbilities[i]);

                    for (int i = 0; i < budRolls && settings.randBuddingTalents && strengths.Count < 11; i++)
                    {
                        if (settings.multipleBuddingTalents ? p(12) : p(60))
                        {
                            budCharacter[i] = charIndex;
                            if (settings.randBuddingTalentLessonCount)
                                lessonReq[i] = rng.Next(settings.buddingTalentLessonCountMin, settings.buddingTalentLessonCountMax + 1);
                            else
                                lessonReq[i] = 12;
                            if (index <= 1)
                                lessonReq[i] /= 2;
                            bool skillChosen = false;
                            while (!skillChosen)
                            {
                                budSkill[i] = rng.Next(0, 11);
                                if (!strengths.Contains(budSkill[i]))
                                    skillChosen = true;
                            }
                            int randomWeapon = rng.Next(0, 5);
                            if (rng.Next(0, 3) <= 1 && budSkill[i] < 5)
                                budArt[i] = settings.baseBuddingTalents ? availableArts[budSkill[i]][rng.Next(0, availableArts[budSkill[i]].Length)] : availableArts[randomWeapon][rng.Next(0, availableArts[randomWeapon].Length)];
                            if (budSkill[i] < 11)
                                strengths.Add(budSkill[i]);
                        }
                    }
                    if (settings.randSpellLists)
                    {
                        if (strengths.Contains(5) && settings.baseSpellLists)
                        {
                            if (rng.Next(0, 4) == 0)
                            {
                                hasDarkSpells = true;
                                if (rng.Next(0, 4) == 0)
                                    hasBlackSpells = true;
                            }
                            else
                                hasBlackSpells = true;
                        }
                        else
                        {
                            hasBlackSpells = true;
                            if (rng.Next(0, 20) == 0)
                                hasDarkSpells = true;
                        }
                    }
                    for (int i = 0; i < budRolls && settings.randBuddingTalents; i++)
                    {
                        switch (budSkill[i])
                        {
                            case 0:
                                if (rng.Next(0, 2) == 0 || budArt[i] == 255)
                                    budAbility[i] = swordAbilities[rng.Next(swordAbilities.Length)];
                                break;
                            case 1:
                                if (rng.Next(0, 2) == 0 || budArt[i] == 255)
                                    budAbility[i] = lanceAbilities[rng.Next(lanceAbilities.Length)];
                                break;
                            case 2:
                                if (rng.Next(0, 2) == 0 || budArt[i] == 255)
                                    budAbility[i] = axeAbilities[rng.Next(axeAbilities.Length)];
                                break;
                            case 3:
                                if (rng.Next(0, 2) == 0 || budArt[i] == 255)
                                    budAbility[i] = bowAbilities[rng.Next(bowAbilities.Length)];
                                break;
                            case 4:
                                if (rng.Next(0, 2) == 0 || budArt[i] == 255)
                                    budAbility[i] = brawlAbilities[rng.Next(brawlAbilities.Length)];
                                break;
                            case 5:
                                if (!hasBlackSpells && !hasDarkSpells)
                                    budAbility[i] = genericAbilities[rng.Next(genericAbilities.Length)];
                                else if (!hasDarkSpells)
                                    budAbility[i] = blackAbilities[rng.Next(blackAbilities.Length)];
                                else if (!hasBlackSpells)
                                    budAbility[i] = darkAbilities[rng.Next(darkAbilities.Length)];
                                else if (rng.Next(0, 2) == 0)
                                    budAbility[i] = blackAbilities[rng.Next(blackAbilities.Length)];
                                else
                                    budAbility[i] = darkAbilities[rng.Next(darkAbilities.Length)];
                                break;
                            case 6:
                                budAbility[i] = faithAbilities[rng.Next(faithAbilities.Length)];
                                break;
                            case 255:
                                break;
                            default:
                                budAbility[i] = genericAbilities[rng.Next(genericAbilities.Length)];
                                break;
                        }
                        if (budAbility[i] < 255 && !settings.baseBuddingTalents)
                            budAbility[i] = allAbilities[rng.Next(0, allAbilities.Count)];
                        if (budSkill[i] < 11)
                        {
                            byte[] budBytes0L = BitConverter.GetBytes((short)budCharacter[i]);
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 0L] = budBytes0L[0]; // Budding talents
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 1L] = budBytes0L[1];
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 2L] = (byte)lessonReq[i];
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 3L] = (byte)budSkill[i];
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 4L] = (byte)budArt[i];
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 5L] = (byte)budAbility[i];

                            changelog += "\nBudding Talent in " + getSkillName(budSkill[i]) + ":\t" +
                            lessonReq[i] + " Lessons >>> " +
                            (budArt[i] != 255 ? combatArtNames[budArt[i]] + " " : "") +
                            (budAbility[i] != 255 ? abilityNames[budAbility[i]] : "");
                        }
                        else
                        {
                            byte[] budBytes0L = BitConverter.GetBytes((ushort)2999);
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 0L] = budBytes0L[0];
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 1L] = budBytes0L[1];
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 2L] = (byte)0;
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 3L] = (byte)255;
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 4L] = (byte)255;
                            personData[charBudStart + (long)((index + 45 * i) * charBudLen) + 5L] = (byte)255;
                        }
                    }

                    if (settings.randSpellLists)
                    {
                        changelog += "\nReason Spells:\t";

                        int numReasonSpells = 5;
                        if (!settings.baseSpellLists)
                            numReasonSpells = rng.Next(settings.unknownSpellListReasonCountMin, settings.unknownSpellListReasonCountMax + 1);
                        else if (!strengths.Contains(5))
                            numReasonSpells = rng.Next(settings.regularSpellListReasonCountMin, settings.regularSpellListReasonCountMax + 1);
                        else
                            numReasonSpells = rng.Next(settings.proficientSpellListReasonCountMin, settings.proficientSpellListReasonCountMax + 1);
                        int numFaithSpells = 5;
                        if (!settings.baseSpellLists)
                            numFaithSpells = rng.Next(settings.unknownSpellListFaithCountMin, settings.unknownSpellListFaithCountMax + 1);
                        else if (!strengths.Contains(6))
                            numFaithSpells = rng.Next(settings.regularSpellListFaithCountMin, settings.regularSpellListFaithCountMax + 1);
                        else
                            numFaithSpells = rng.Next(settings.proficientSpellListFaithCountMin, settings.proficientSpellListFaithCountMax + 1);
                        int[] reasonSpellList = { 255, 255, 255, 255, 255 };
                        int[] faithSpellList = { 255, 255, 255, 255, 255 };
                        int[] reasonSpellRanks = { 0, 0, 0, 0, 0 };
                        int[] faithSpellRanks = { 0, 0, 0, 0, 0 };
                        for (int i = 0; i < numReasonSpells;)
                        {
                            int newSpell = 255;
                            if (i == 0 && settings.spellAtD)
                                reasonSpellRanks[i] = 2;
                            else
                                reasonSpellRanks[i] = rng.Next(2, 10);
                            if (!hasBlackSpells)
                                newSpell = getSpell(7, reasonSpellRanks[i], true, false);
                            else if (!hasDarkSpells)
                                newSpell = getSpell(5, reasonSpellRanks[i], true, false);
                            else if (rng.Next(0, 2) == 0)
                                newSpell = getSpell(5, reasonSpellRanks[i], true, false);
                            else
                                newSpell = getSpell(7, reasonSpellRanks[i], true, false);
                            if (!reasonSpellList.Contains(newSpell))
                            {
                                reasonSpellList[i] = newSpell;

                                changelog += "\t" + spellNames[reasonSpellList[i]] +
                                    " at Reason " + getRankName(reasonSpellRanks[i]);
                                i++;
                            }
                        }

                        changelog += "\nFaith Spells:\t";

                        for (int i = 0; i < numFaithSpells;)
                        {
                            int newSpell = 255;
                            if (i == 0 && settings.spellAtD)
                                faithSpellRanks[i] = 2;
                            else
                                faithSpellRanks[i] = rng.Next(2, 10);
                            newSpell = getSpell(6, faithSpellRanks[i], true, false);
                            if (!faithSpellList.Contains(newSpell))
                            {
                                faithSpellList[i] = newSpell;

                                changelog += "\t" + spellNames[faithSpellList[i]] +
                                    " at Faith " + getRankName(faithSpellRanks[i]);
                                i++;
                            }
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            personData[charSpellStart + spellMod + 0L + (long)i] = (byte)faithSpellRanks[i]; // Spell lists
                            personData[charSpellStart + spellMod + 5L + (long)i] = (byte)reasonSpellList[i];
                            personData[charSpellStart + spellMod + 10L + (long)i] = (byte)faithSpellList[i];
                            personData[charSpellStart + spellMod + 15L + (long)i] = (byte)reasonSpellRanks[i];
                        }
                    }

                    if (settings.randCharAb)
                    {
                        changelog += "\nAbility Learnset:";

                        int numSkillAbilities = rng.Next(settings.charAbCountMin, settings.charAbCountMax + 1);
                        if (settings.preserveGenericCharAb)
                            numSkillAbilities = Math.Min(20, numSkillAbilities + 3);
                        int[] skillAbilitySkills =
                            { 255, 255, 255, 255, 255,
                        255, 255, 255, 255, 255,
                        255, 255, 255, 255, 255,
                        255, 255, 255, 255, 255 };
                        int[] skillAbilities =
                            { 255, 255, 255, 255, 255,
                        255, 255, 255, 255, 255,
                        255, 255, 255, 255, 255,
                        255, 255, 255, 255, 255 };
                        int[] skillAbilityRanks =
                            { 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0 };
                        for (int i = 0; i < numSkillAbilities; i++)
                        {
                            skillAbilityRanks[i] = rng.Next(1, 12);
                            for (int c = 0; c < 1;)
                            {
                                skillAbilitySkills[i] = rng.Next(0, 11);
                                if (strengths.Contains(skillAbilitySkills[i]) || !settings.limitCharAb)
                                    c++;
                            }
                            if (settings.preserveGenericCharAb && i == 0)
                            {
                                skillAbilitySkills[i] = 7;
                                skillAbilityRanks[i] = 4;
                            }
                            else if (settings.preserveGenericCharAb && i == 1)
                            {
                                skillAbilitySkills[i] = 5;
                                skillAbilityRanks[i] = 10;
                            }
                            else if (settings.preserveGenericCharAb && i == 2)
                            {
                                skillAbilitySkills[i] = 5;
                                skillAbilityRanks[i] = 11;
                            }
                            switch (skillAbilitySkills[i])
                            {
                                case 0:
                                    skillAbilities[i] = swordAbilities[rng.Next(swordAbilities.Length)];
                                    break;
                                case 1:
                                    skillAbilities[i] = lanceAbilities[rng.Next(lanceAbilities.Length)];
                                    break;
                                case 2:
                                    skillAbilities[i] = axeAbilities[rng.Next(axeAbilities.Length)];
                                    break;
                                case 3:
                                    skillAbilities[i] = bowAbilities[rng.Next(bowAbilities.Length)];
                                    break;
                                case 4:
                                    skillAbilities[i] = brawlAbilities[rng.Next(brawlAbilities.Length)];
                                    break;
                                case 5:
                                    if (!hasBlackSpells)
                                        skillAbilities[i] = darkAbilities[rng.Next(darkAbilities.Length)];
                                    else if (!hasDarkSpells)
                                        skillAbilities[i] = blackAbilities[rng.Next(blackAbilities.Length)];
                                    else if (rng.Next(0, 2) == 0)
                                        skillAbilities[i] = blackAbilities[rng.Next(blackAbilities.Length)];
                                    else
                                        skillAbilities[i] = darkAbilities[rng.Next(darkAbilities.Length)];
                                    break;
                                case 6:
                                    skillAbilities[i] = faithAbilities[rng.Next(faithAbilities.Length)];
                                    break;
                                default:
                                    skillAbilities[i] = genericAbilities[rng.Next(genericAbilities.Length)];
                                    break;
                            }
                            if (!settings.baseCharAb)
                                skillAbilities[i] = allAbilities[rng.Next(0, allAbilities.Count)];

                            changelog += "\t" + abilityNames[skillAbilities[i]] + " at " + getSkillName(skillAbilitySkills[i]) + " " + getRankName(skillAbilityRanks[i]);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            personData[charSkillStart + skillMod + 0L + (long)i] = (byte)skillAbilitySkills[i]; // Skill abilities
                            personData[charSkillStart + skillMod + 22L + (long)i] = (byte)skillAbilities[i];
                            personData[charSkillStart + skillMod + 42L + (long)i] = (byte)skillAbilityRanks[i];
                        }
                    }

                    List<int> abilityPool = new List<int>();
                    addMissingAbilities(ref abilityPool, genericAbilities);
                    for (int i = 0; i < strengths.Count; i++)
                        if (strengths.Contains(i))
                            switch (i)
                            {
                                case 0:
                                    addMissingAbilities(ref abilityPool, swordAbilities);
                                    break;
                                case 1:
                                    addMissingAbilities(ref abilityPool, lanceAbilities);
                                    break;
                                case 2:
                                    addMissingAbilities(ref abilityPool, axeAbilities);
                                    break;
                                case 3:
                                    addMissingAbilities(ref abilityPool, bowAbilities);
                                    break;
                                case 4:
                                    addMissingAbilities(ref abilityPool, brawlAbilities);
                                    break;
                                case 5:
                                    if (!hasBlackSpells)
                                        addMissingAbilities(ref abilityPool, darkAbilities);
                                    else if (!hasDarkSpells)
                                        addMissingAbilities(ref abilityPool, blackAbilities);
                                    else if (rng.Next(0, 2) == 0)
                                        addMissingAbilities(ref abilityPool, blackAbilities);
                                    else
                                        addMissingAbilities(ref abilityPool, darkAbilities);
                                    break;
                                case 6:
                                    addMissingAbilities(ref abilityPool, faithAbilities);
                                    break;
                                default:
                                    break;
                            }

                    if (settings.randPersonalAb)
                    {
                        int[] personalAbilities = { 255, 255 };
                        int numPersonalAbilities = p(settings.newPersonalAbPostTsP) ? 2 : 1;
                        for (int i = 0; i < numPersonalAbilities; i++)
                        {
                            personalAbilities[i] = settings.basePersonalAb ? abilityPool[rng.Next(0, abilityPool.Count)] : allAbilities[rng.Next(0, allAbilities.Count)];
                        }
                        personData[charSkillStart + skillMod + 20L] = (byte)personalAbilities[0]; // Personal ability
                        personData[charSkillStart + skillMod + 21L] = (byte)personalAbilities[1];

                        changelog += "\nPersonal Ability:\t" + abilityNames[personalAbilities[0]];
                        if (personalAbilities[1] != 255)
                            changelog += "\nPost TS Personal Ability:\t" + abilityNames[personalAbilities[1]];
                    }

                    if (index > 1 && index != 37 && settings.randFacultyTraining)
                    {
                        changelog += "\nFaculty Skills:\t";
                        int[] facultySkills = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        for (int i = 0; i < facultySkills.Length; i++)
                        {
                            if (settings.baseFacultyTraining)
                            {
                                if (proficiencies[i] == 3)
                                {
                                    facultySkills[i] = 1;
                                    changelog += "\t" + getSkillName(i);
                                }
                            }
                            else if (p(30))
                            {
                                facultySkills[i] = 1;
                                changelog += "\t" + getSkillName(i);
                            }
                        }
                        int facultyInt = 0;
                        for (int i = 0; i < facultySkills.Length; i++)
                            if (facultySkills[i] == 1)
                                facultyInt += (int)Math.Pow(2, i);
                        byte[] facultyBytes0L = BitConverter.GetBytes((short)facultyInt);
                        personData[charFacultyStart + facultyMod + 0L] = facultyBytes0L[0]; // Faculty training skills
                        personData[charFacultyStart + facultyMod + 1L] = facultyBytes0L[1];
                        if (index == 43)
                        {
                            personData[charFacultyStart + (long)(facultyIndex + 2) * charFacultyLen + 0L] = facultyBytes0L[0];
                            personData[charFacultyStart + (long)(facultyIndex + 2) * charFacultyLen + 1L] = facultyBytes0L[1];
                        }
                    }

                    if ((index < 35 || index > 37) && settings.randSeminars)
                    {
                        changelog += "\nSeminar Skills:\t";
                        List<int> proficientSkills = new List<int>();
                        for (int i = 0; i < proficiencies.Length; i++)
                            if (proficiencies[i] == 3)
                                proficientSkills.Add(i);
                        int[] seminarSkills = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        for (int i = 0; i < 2; i++)
                        {
                            int skill = settings.baseSeminars ? proficientSkills[rng.Next(0, proficientSkills.Count)] : rng.Next(0, 11);
                            seminarSkills[skill] = 1;
                            changelog += "\t" + getSkillName(skill);
                            proficientSkills.Remove(skill);
                        }
                        int seminarInt = 0;
                        for (int i = 0; i < seminarSkills.Length; i++)
                            if (seminarSkills[i] == 1)
                                seminarInt += (int)Math.Pow(2, i);
                        byte[] seminarBytes0L = BitConverter.GetBytes((short)seminarInt);
                        personData[charSeminarStart + seminarMod + 0L] = seminarBytes0L[0]; // Seminar skills
                        personData[charSeminarStart + seminarMod + 1L] = seminarBytes0L[1];
                    }

                    if (((index > 1 && index < 35) || index > 37) && settings.randGoals)
                    {
                        changelog += "\nDefault Skill Goal:";
                        List<int> possibleGoals = new List<int>();
                        possibleGoals.AddRange(strengths);
                        int[] goals = new int[2];
                        for (int i = 0; i < goals.Length; i++)
                        {
                            int skill = settings.baseGoals ? possibleGoals[rng.Next(0, possibleGoals.Count)] : rng.Next(0, 11);
                            goals[i] = skill;
                            changelog += "\t" + getSkillName(skill);
                            possibleGoals.Remove(skill);
                        }

                        personData[charGoalStart + goalMod + 0L] = (byte)toGoalID(goals); // Character goals
                    }
                }

                for (int index = 0; index < 100 && settings.randPersonalAb; index++)
                {
                    long enemySkillMod = charEnemySkillLen * (long)index;

                    personData[charEnemySkillStart + enemySkillMod + 2L] = (byte)genericAbilities[rng.Next(0, genericAbilities.Length)];
                }
            }
            if (calendarLoaded)
            {
                Randomizer.calendarData = new byte[Randomizer.calendarDataV.Length];
                Randomizer.calendarDataV.CopyTo((Array)Randomizer.calendarData, 0);

                if (settings.randCalendar)
                {
                    long[] scheduleStarts = new long[] {
                    academyScheduleStart,
                    churchScheduleStart,
                    lionsScheduleStart,
                    deerScheduleStart,
                    eaglesScheduleStart };

                    for (int set = 0; set < 5; set++)
                    {
                        long start = scheduleStarts[set];

                        List<int[]> newData = new List<int[]>();

                        for (int index = 0; index < 100; index++)
                        {
                            long mod = scheduleLen * (long)index;

                            if (calendarData[start + mod + 6L] == (byte)1)
                            {
                                Month m = new Month(settings);
                                m.monthIndex = calendarData[start + mod + 2L];
                                m.startDate = calendarData[start + mod + 3L];
                                m.startWeekday = calendarData[start + mod + 4L];

                                int tempIndex = index + 1;
                                while (calendarData[start + tempIndex * scheduleLen + 6L] != (byte)3)
                                {
                                    if (m.firstSunday == 0)
                                        m.firstSunday = calendarData[start + tempIndex * scheduleLen + 3L];

                                    if (m.tournaments[0] == 255)
                                    {
                                        m.tournaments[0] = calendarData[start + tempIndex * scheduleLen + 12L];
                                        m.tournaments[1] = calendarData[start + tempIndex * scheduleLen + 13L];
                                        m.tournaments[2] = calendarData[start + tempIndex * scheduleLen + 14L];
                                        m.tournaments[3] = calendarData[start + tempIndex * scheduleLen + 15L];
                                    }

                                    tempIndex++;
                                }

                                m.missionDate = calendarData[start + tempIndex * scheduleLen + 3L];
                                m.missionWeekday = calendarData[start + tempIndex * scheduleLen + 4L];
                                m.setSundays();
                                newData.AddRange(m.generateData(m.sundayDates.Count));
                            }
                        }

                        for (int index = 0; index < 100; index++)
                        {
                            long mod = scheduleLen * (long)index;

                            int[] emptyDate = {
                            255, 0, 0, 1,
                            0, 255, 0, 255,
                            255, 0, 255, 255,
                            255, 255, 255, 255 };

                            for (int i = 0; i < scheduleLen; i++)
                            {
                                if (index < newData.Count)
                                {
                                    if (settings.randRareMonsterSighting)
                                        calendarData[start + mod + 0L] = (byte)newData[index][0];
                                    if (settings.randRestrictFreeday)
                                        calendarData[start + mod + 1L] = (byte)newData[index][1];
                                    calendarData[start + mod + 2L] = (byte)newData[index][2];
                                    calendarData[start + mod + 3L] = (byte)newData[index][3];
                                    calendarData[start + mod + 4L] = (byte)newData[index][4];
                                    if (settings.randCafeteriaEvent)
                                        calendarData[start + mod + 5L] = (byte)newData[index][5];
                                    calendarData[start + mod + 6L] = (byte)newData[index][6];
                                    if (settings.randChoirEvent)
                                        calendarData[start + mod + 7L] = (byte)newData[index][7];
                                    calendarData[start + mod + 8L] = (byte)newData[index][8];
                                    calendarData[start + mod + 9L] = (byte)newData[index][9];
                                    if (settings.randGardenEvent)
                                        calendarData[start + mod + 10L] = (byte)newData[index][10];
                                    if (settings.randFishingEvent)
                                        calendarData[start + mod + 11L] = (byte)newData[index][11];
                                    calendarData[start + mod + 12L] = (byte)newData[index][12];
                                    calendarData[start + mod + 13L] = (byte)newData[index][13];
                                    calendarData[start + mod + 14L] = (byte)newData[index][14];
                                    calendarData[start + mod + 15L] = (byte)newData[index][15];
                                }
                                else
                                    calendarData[start + mod + (long)i] = (byte)emptyDate[i];
                            }

                        }
                    }
                }
            }
            if (lobbyLoaded)
            {
                Randomizer.lobbyData = new byte[Randomizer.lobbyDataV.Length];
                Randomizer.lobbyDataV.CopyTo((Array)Randomizer.lobbyData, 0);

                for (int index = 0; index < 101; index++)
                {
                    long mod = (long)index * reqruitLen;

                    short charIndex = lobbyData[reqruitStart + mod + 0L];
                    charIndex += (short)(lobbyData[reqruitStart + mod + 1L] * 256);

                    int classTier = 0;
                    bool monster = false;
                    getUnitTier(charIndex, ref classTier, ref monster);

                    if ((charIndex < 35 || (charIndex > 1039 && charIndex < 1044) || charIndex == 1045 || charIndex == 1046) && classLoaded && personLoaded)
                    {
                        switch (classTier)
                        {
                            case 0:
                                if (settings.randCharPreCertClasses)
                                {
                                    lobbyData[reqruitStart + mod + 6L] = settings.charOptimalClasses ? (byte)getBestFittingClass(1, proficiencyArchive[charIndex], classCertReqs) : (byte)begClasses[rng.Next(0, begClasses.Count)];
                                    lobbyData[reqruitStart + mod + 8L] = settings.charOptimalClasses ? (byte)getBestFittingClass(2, proficiencyArchive[charIndex], classCertReqs) : (byte)interClasses[rng.Next(0, interClasses.Count)];
                                }
                                break;

                            case 1:
                                if (settings.randCharStartClasses)
                                    lobbyData[reqruitStart + mod + 6L] = settings.charOptimalClasses ? (byte)getBestFittingClass(1, proficiencyArchive[charIndex], classCertReqs) : (byte)begClasses[rng.Next(0, begClasses.Count)];
                                if (settings.randCharPreCertClasses)
                                    lobbyData[reqruitStart + mod + 8L] = settings.charOptimalClasses ? (byte)getBestFittingClass(2, proficiencyArchive[charIndex], classCertReqs) : (byte)interClasses[rng.Next(0, interClasses.Count)];
                                break;

                            case 2:
                                if (settings.randCharStartClasses)
                                {
                                    lobbyData[reqruitStart + mod + 6L] = settings.charOptimalClasses ? (byte)getBestFittingClass(2, proficiencyArchive[charIndex], classCertReqs) : (byte)interClasses[rng.Next(0, interClasses.Count)];
                                    lobbyData[reqruitStart + mod + 8L] = settings.charOptimalClasses ? (byte)getBestFittingClass(2, proficiencyArchive[charIndex], classCertReqs) : (byte)interClasses[rng.Next(0, interClasses.Count)];
                                }
                                break;

                            case 3:
                                if (settings.randCharStartClasses)
                                {
                                    lobbyData[reqruitStart + mod + 6L] = settings.charOptimalClasses ? (byte)getBestFittingClass(3, proficiencyArchive[charIndex], classCertReqs) : (byte)advClasses[rng.Next(0, advClasses.Count)];
                                    lobbyData[reqruitStart + mod + 8L] = settings.charOptimalClasses ? (byte)getBestFittingClass(3, proficiencyArchive[charIndex], classCertReqs) : (byte)advClasses[rng.Next(0, advClasses.Count)];
                                }
                                break;

                            case 4:
                                if (settings.randCharStartClasses)
                                {
                                    lobbyData[reqruitStart + mod + 6L] = settings.charOptimalClasses ? (byte)getBestFittingClass(4, proficiencyArchive[charIndex], classCertReqs) : (byte)masterClasses[rng.Next(0, masterClasses.Count)];
                                    lobbyData[reqruitStart + mod + 8L] = settings.charOptimalClasses ? (byte)getBestFittingClass(4, proficiencyArchive[charIndex], classCertReqs) : (byte)masterClasses[rng.Next(0, masterClasses.Count)];
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }

                if (settings.randRecruitmentRequirements)
                {
                    changelog += "\n\n\n---RECRUITMENT REQUIREMENTS---";

                    for (int index = 0; index < 101; index++)
                    {
                        long mod = (long)index * reqruitLen;

                        short charIndex = lobbyData[reqruitStart + mod + 0L];
                        charIndex += (short)(lobbyData[reqruitStart + mod + 1L] * 256);

                        if (charIndex > 25)
                            continue;

                        int statTypeReq = lobbyData[reqruitStart + mod + 9L];
                        if (statTypeReq < 9)
                        {

                            changelog += "\n\n\t" + characterNames[newAssetIDs[charIndex]];

                            statTypeReq = rng.Next(0, 8);
                            if (statTypeReq == 7)
                                statTypeReq = 8;

                            int statAmountReq = rng.Next(settings.recruitmentRequirementStatsMin, settings.recruitmentRequirementStatsMax + 1);

                            lobbyData[reqruitStart + mod + 9L] = (byte)statTypeReq; // Stat type recruitment requirement
                            lobbyData[reqruitStart + mod + 13L] = (byte)statAmountReq; // Stat amount recruitment requirement

                            changelog += "\nStat Requirement:\t" + statAmountReq + getStatName(statTypeReq);
                        }

                        int skillTypeReq = lobbyData[reqruitStart + mod + 10L];
                        if (skillTypeReq < 11)
                        {
                            lobbyData[reqruitStart + mod + 10L] = (byte)rng.Next(0, 11); // Skill type recruitment requirement
                            lobbyData[reqruitStart + mod + 11L] = (byte)rng.Next(settings.recruitmentRequirementRanksMin, settings.recruitmentRequirementRanksMax + 1); // Skill rank recruitment requirement

                            changelog += "\nSkill Requirement:\t" + getSkillName(lobbyData[reqruitStart + mod + 10L]) + " " + getRankName(lobbyData[reqruitStart + mod + 11L]);
                        }
                    }
                }
            }
            if (activityLoaded)
            {
                Randomizer.activityData = new byte[Randomizer.activityDataV.Length];
                Randomizer.activityDataV.CopyTo((Array)Randomizer.activityData, 0);

                for (int index = 0; index < 50; index++)
                {
                    long mod = (long)index * charActivityLen;

                    if (settings.randChoirProfs)
                    {
                        int selector = rng.Next(0, 100);
                        if (selector < 15)
                            activityData[charActivityStart + mod + 2L] = 255; // choir skill
                        else if (selector < 35)
                            activityData[charActivityStart + mod + 2L] = 1;
                        else
                            activityData[charActivityStart + mod + 2L] = 0;
                    }

                    if (settings.randCookingProfs)
                    {
                        int selector = rng.Next(0, 100);
                        if (selector < 15)
                            activityData[charActivityStart + mod + 3L] = 255; // cooking skill
                        else if (selector < 35)
                            activityData[charActivityStart + mod + 3L] = 1;
                        else
                            activityData[charActivityStart + mod + 3L] = 0;
                    }
                }

                for (int index = 0; index < 100 && settings.randMeal; index++)
                {
                    long mod = (long)index * mealLen;

                    ushort[] ingredientTypes = { 0, 0, 0 };
                    int[] ingredientDist = { 0, 0, 0 };
                    int ingredientCount = rng.Next(2, 4);
                    if (p(5))
                        ingredientCount = 1;

                    for (int i = 0; i < ingredientCount; i++)
                    {
                        byte[] ingredientBytes = { activityData[mealStart + mod + 0L + 2 * i], activityData[mealStart + mod + 1L + 2 * i] };
                        ushort ingredientShort = BitConverter.ToUInt16(ingredientBytes, 0);

                        if (ingredientShort == 0)
                        {
                            int[] standardIngredients = { 96, 133, 160 };
                            ingredientShort = (ushort)standardIngredients[rng.Next(0, standardIngredients.Length)];
                        }

                        ingredientTypes[i] = (ushort)randLocalItem(settings, ingredientShort, 3);
                        ingredientDist[i] = (ingredientCount == 1 ? 3 : 1);
                    }

                    if (activityData[mealStart + mod + 8L] != 255)
                    {
                        byte[] short0L = BitConverter.GetBytes(ingredientTypes[0]);
                        activityData[mealStart + mod + 0L] = short0L[0]; // meal ingredients
                        activityData[mealStart + mod + 1L] = short0L[1];
                        byte[] short2L = BitConverter.GetBytes(ingredientTypes[1]);
                        activityData[mealStart + mod + 2L] = short2L[0];
                        activityData[mealStart + mod + 3L] = short2L[1];
                        byte[] short4L = BitConverter.GetBytes(ingredientTypes[2]);
                        activityData[mealStart + mod + 4L] = short4L[0];
                        activityData[mealStart + mod + 5L] = short4L[1];

                        activityData[mealStart + mod + 10L] = (byte)rng.Next(0, 6); // meal category

                        activityData[mealStart + mod + 14L] = (byte)ingredientDist[0]; // meal ingredient count
                        activityData[mealStart + mod + 15L] = (byte)ingredientDist[1];
                        activityData[mealStart + mod + 16L] = (byte)ingredientDist[2];
                    }
                }

                for (int index = 0; index < 100 && settings.randMealPrefs; index++)
                {
                    long mod = (long)index * mealPrefLen;

                    List<int> mealPrefs = new List<int>();
                    int dislikes = rng.Next(3, 19);
                    int likes = rng.Next(2, 23);
                    for (int i = 0; i < dislikes; i++)
                        mealPrefs.Add(255);
                    for (int i = 0; i < likes; i++)
                        mealPrefs.Add(1);
                    while (mealPrefs.Count < 45)
                        mealPrefs.Add(0);
                    mealPrefs.Shuffle();
                    for (int i = 0; i < mealPrefLen; i++)
                        activityData[mealPrefStart + mod + i] = (byte)mealPrefs[i]; // meal preferences
                }

                if (settings.randFishingItems)
                    changelog += "\n\n\n---FISHING ITEMS---";

                for (int index = 0; index < 32 && settings.randFishingItems; index++)
                {
                    long mod = (long)index * fishingLen;

                    if (obtainableMiscItems.Contains(index))
                        changelog += "\n\n\t" + miscItemNames[index];

                    for (int i = 0; i < 18 && index < 30; i++)
                    {

                        byte[] itemBytes = new byte[] { activityData[fishingStart + mod + (2 * i)], activityData[fishingStart + mod + (2 * i) + 1] };
                        ushort itemShort = BitConverter.ToUInt16(itemBytes, 0);
                        if (itemShort > 0)
                        {
                            itemShort = (ushort)randGeneralItem(settings, itemShort);
                            itemBytes = BitConverter.GetBytes(itemShort);
                            activityData[fishingStart + mod + (2 * i)] = itemBytes[0]; // fishing items
                            activityData[fishingStart + mod + (2 * i) + 1] = itemBytes[1];

                            if (i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15)
                                changelog += "\n" + getFishRarityName(i / 3) + ":";
                            changelog += "\t" + getGeneralItemName(itemShort);
                        }
                    }
                }

                if (settings.randGardeningItems)
                    changelog += "\n\n\n---GARDENING ITEMS---";

                for (int index = 0; index < 32 && settings.randGardeningItems; index++)
                {
                    long mod = (long)index * gardenLen;

                    if (obtainableMiscItems.Contains(index + 32))
                        changelog += "\n\n\t" + miscItemNames[index + 32];

                    for (int i = 0; i < 31; i++)
                    {
                        byte[] itemBytes = new byte[] { activityData[gardenStart + mod + (2 * i)], activityData[gardenStart + mod + (2 * i) + 1] };
                        ushort itemShort = BitConverter.ToUInt16(itemBytes, 0);
                        if (itemShort > 0)
                        {
                            itemShort = (ushort)randGeneralItem(settings, itemShort);
                            itemBytes = BitConverter.GetBytes(itemShort);
                            activityData[gardenStart + mod + (2 * i)] = itemBytes[0]; // gardening items
                            activityData[gardenStart + mod + (2 * i) + 1] = itemBytes[1];

                            if (i == 0 || i == 1 || i == 6 || i == 11 || i == 16 || i == 21 || i == 26)
                                changelog += "\n" + getGeneralItemName(itemShort);
                            else
                                changelog += "\t" + getGeneralItemName(itemShort);
                        }
                    }
                }

                if (settings.randCultivationCosts)
                {
                    ushort[] costs = new ushort[6];
                    costs[0] = (ushort)rng.Next(0, 8);
                    for (int index = 1; index < 6; index++)
                        costs[index] = (ushort)(costs[index - 1] + rng.Next(0, 8));
                    for (int index = 0; index < 6; index++)
                    {
                        long mod = (long)index * cultivationLen;

                        byte[] costBytes = BitConverter.GetBytes((ushort)(costs[index] * 100));
                        activityData[cultivationStart + mod + 0L] = costBytes[0]; // cultivation costs
                        activityData[cultivationStart + mod + 1L] = costBytes[1];
                    }
                }

                ushort[] lectureExp = new ushort[10];
                lectureExp[0] = 100;
                for (int i = 1; i < 10; i++)
                    lectureExp[i] = (ushort)(lectureExp[i - 1] + rng.Next(0, 6) * 50);

                ushort[] expReqs = new ushort[10];
                expReqs[0] = 0;
                for (int i = 1; i < 10; i++)
                    expReqs[i] = (ushort)normalize(roundTo((int)Math.Round(expReqs[i - 1] + (20 + rng.NextDouble() * 160) * (Math.Pow(i, 2) + 4 * i)), 100), 0, 65000);

                ushort[] funds = new ushort[10];
                funds[0] = 1000;
                for (int i = 1; i < 10; i++)
                    funds[i] = (ushort)(funds[i - 1] + rng.Next(0, 2) * 1000);

                byte[] lectures = new byte[10];
                lectures[0] = 3;
                for (int i = 1; i < 10; i++)
                    lectures[i] = (byte)(lectures[i - 1] + rng.Next(0, 2));

                byte[] battles = new byte[10];
                battles[0] = 1;
                for (int i = 1; i < 10; i++)
                    battles[i] = (byte)(battles[i - 1] + (p(25) ? 1 : 0));

                byte[] adjutants = new byte[10];
                adjutants[0] = 0;
                for (int i = 1; i < 10; i++)
                    adjutants[i] = (byte)(adjutants[i - 1] + (p(33) ? 1 : 0));

                byte[] activities = new byte[10];
                activities[0] = 1;
                for (int i = 1; i < 10; i++)
                    activities[i] = (byte)(activities[i - 1] + rng.Next(0, 3));

                bool randProfLvFlag =
                    settings.randLectureExp ||
                    settings.randProfLvExpReq ||
                    settings.randFunds ||
                    settings.randLecturePointCount ||
                    settings.randBattlePointCount ||
                    settings.randAdjutantCount ||
                    settings.randActivityPointCount;

                if (randProfLvFlag)
                    changelog += "\n\n\n---PROFESSOR LEVELS---";

                for (int index = 0; index < 10; index++)
                {
                    long mod = (long)index * profLvLen;

                    if (randProfLvFlag)
                        changelog += "\n\n\tRank " + getRankName(index);

                    if (settings.randLectureExp)
                    {
                        byte[] lectureExpBytes = BitConverter.GetBytes(lectureExp[index]);
                        activityData[profLvStart + mod + 0L] = lectureExpBytes[0]; // lecture exp
                        activityData[profLvStart + mod + 1L] = lectureExpBytes[1];

                        changelog += "\nLecture Exp:\t\t" + lectureExp[index];
                    }

                    if (settings.randProfLvExpReq)
                    {
                        byte[] expReqBytes = BitConverter.GetBytes(expReqs[index]);
                        activityData[profLvStart + mod + 2L] = expReqBytes[0]; // professor level exp requirements
                        activityData[profLvStart + mod + 3L] = expReqBytes[1];

                        changelog += "\nExp Requirement:\t" + expReqs[index];
                    }

                    if (settings.randFunds)
                    {
                        byte[] fundBytes = BitConverter.GetBytes(funds[index]);
                        activityData[profLvStart + mod + 4L] = fundBytes[0]; // monthly gold funds
                        activityData[profLvStart + mod + 5L] = fundBytes[1];

                        changelog += "\nMonthly Funds:\t\t" + funds[index];
                    }

                    if (settings.randLecturePointCount)
                    {
                        activityData[profLvStart + mod + 6L] = lectures[index]; // lecture points

                        changelog += "\nLecture Points:\t\t" + lectures[index];
                    }

                    if (settings.randBattlePointCount)
                    {
                        activityData[profLvStart + mod + 7L] = battles[index]; // battle points

                        changelog += "\nBattle Points:\t\t" + battles[index];
                    }

                    if (settings.randAdjutantCount)
                    {
                        activityData[profLvStart + mod + 9L] = adjutants[index]; // adjutant count

                        changelog += "\nAdjutants:\t\t" + adjutants[index];
                    }

                    if (settings.randActivityPointCount)
                    {
                        activityData[profLvStart + mod + 10L] = activities[index]; // activity count

                        changelog += "\nActivity Points:\t" + activities[index];
                    }

                    if (settings.unlockMasterClasses)
                        activityData[profLvStart + mod + 11L] = 1; // unlock master classes
                }
            }
            if (groupWorkLoaded)
            {
                Randomizer.groupWorkData = new byte[Randomizer.groupWorkDataV.Length];
                Randomizer.groupWorkDataV.CopyTo((Array)Randomizer.groupWorkData, 0);

                for (int index = 0; index < 8; index++)
                {
                    long mod = (long)index * groupTaskLen;

                    if (groupWorkData[groupTaskStart + mod + 4L] != 255)
                    {
                        if (settings.randGroupTaskGold)
                        {
                            ushort goodGold = (ushort)(rng.Next(5, 16) * 50);
                            ushort perfectGold = (ushort)(goodGold + rng.Next(5, 16) * 50);
                            byte[] goodGoldBytes = BitConverter.GetBytes(goodGold);
                            byte[] perfectGoldBytes = BitConverter.GetBytes(perfectGold);
                            groupWorkData[groupTaskStart + mod + 0L] = goodGoldBytes[0]; // group task gold rewards
                            groupWorkData[groupTaskStart + mod + 1L] = goodGoldBytes[1];
                            groupWorkData[groupTaskStart + mod + 2L] = perfectGoldBytes[0];
                            groupWorkData[groupTaskStart + mod + 3L] = perfectGoldBytes[1];
                        }

                        if (settings.randGroupTaskSkills)
                            groupWorkData[groupTaskStart + mod + 4L] = (byte)rng.Next(0, 11); // group task trained skill

                        if (settings.randGroupTaskItems)
                        {
                            groupWorkData[groupTaskStart + mod + 5L] = (byte)randLocalItem(settings, groupWorkData[groupTaskStart + mod + 5L], 3); // group task item rewards
                            groupWorkData[groupTaskStart + mod + 6L] = (byte)randLocalItem(settings, groupWorkData[groupTaskStart + mod + 6L], 3);
                            groupWorkData[groupTaskStart + mod + 7L] = (byte)rng.Next(1, 6); // group task item reward total
                            groupWorkData[groupTaskStart + mod + 8L] = (byte)(groupWorkData[groupTaskStart + mod + 7L] + rng.Next(0, 5));
                        }
                    }
                }

                for (int index = 0; index < 45 && settings.randGroupTaskProfs; index++)
                {
                    long mod = (long)index * groupTaskProfsLen;

                    int selector = rng.Next(0, 100);
                    if (selector < 10)
                        groupWorkData[groupTaskProfsStart + mod + 0L] = 255; // group task proficiencies
                    else if (selector < 25)
                        groupWorkData[groupTaskProfsStart + mod + 0L] = 1;
                    else
                        groupWorkData[groupTaskProfsStart + mod + 0L] = 0;

                    selector = rng.Next(0, 100);
                    if (selector < 10)
                        groupWorkData[groupTaskProfsStart + mod + 3L] = 255;
                    else if (selector < 25)
                        groupWorkData[groupTaskProfsStart + mod + 3L] = 1;
                    else
                        groupWorkData[groupTaskProfsStart + mod + 3L] = 0;

                    selector = rng.Next(0, 100);
                    if (selector < 10)
                        groupWorkData[groupTaskProfsStart + mod + 4L] = 255;
                    else if (selector < 25)
                        groupWorkData[groupTaskProfsStart + mod + 4L] = 1;
                    else
                        groupWorkData[groupTaskProfsStart + mod + 4L] = 0;

                    selector = rng.Next(0, 100);
                    if (selector < 10)
                        groupWorkData[groupTaskProfsStart + mod + 6L] = 255;
                    else if (selector < 25)
                        groupWorkData[groupTaskProfsStart + mod + 6L] = 1;
                    else
                        groupWorkData[groupTaskProfsStart + mod + 6L] = 0;
                }
            }
            if (presentLoaded)
            {
                Randomizer.presentData = new byte[Randomizer.presentDataV.Length];
                Randomizer.presentDataV.CopyTo((Array)Randomizer.presentData, 0);

                List<int>[] dislikingCharactersPerGift = new List<int>[244];
                for (int i = 0; i < dislikingCharactersPerGift.Length; i++)
                    dislikingCharactersPerGift[i] = new List<int>();

                List<int>[] likingCharactersPerGift = new List<int>[244];
                for (int i = 0; i < likingCharactersPerGift.Length; i++)
                    likingCharactersPerGift[i] = new List<int>();

                if (settings.randGiftPrefs)
                {
                    changelog += "\n\n\n---GIFT PREFERENCES---\nPer character:";

                    for (int index = 0; index < 45; index++)
                    {
                        if (index == 0 || index == 1 || index == 35 || index == 37 || index == 42)
                            continue;

                        long mod = (long)index * giftPrefsLen;

                        int charIndex = index;
                        if (charIndex > 37)
                            charIndex = charIndex - 38 + 1040;

                        int msgIndex = index;
                        if (msgIndex > 37)
                            msgIndex += 2;
                        if (msgIndex > 44)
                            msgIndex--;

                        int dislikeCount = rng.Next(2, 4);
                        int likeCount = rng.Next(3, 7);
                        byte[] dislikes = { 255, 255, 255 };
                        byte[] likes = { 255, 255, 255, 255, 255, 255 };

                        List<int> selectedGifts = new List<int>();
                        selectedGifts.Add(20);

                        for (int i = 0; i < dislikeCount; i++)
                        {
                            do
                            {
                                dislikes[i] = (byte)randLocalItem(settings, 0, 4);
                            }
                            while (selectedGifts.Contains(dislikes[i]));
                            selectedGifts.Add(dislikes[i]);
                            dislikingCharactersPerGift[dislikes[i]].Add(charIndex);
                        }

                        for (int i = 0; i < likeCount; i++)
                        {
                            do
                            {
                                likes[i] = (byte)randLocalItem(settings, 0, 4);
                            }
                            while (selectedGifts.Contains(likes[i]));
                            selectedGifts.Add(likes[i]);
                            if (i > 0)
                                likingCharactersPerGift[likes[i]].Add(charIndex);
                        }

                        presentData[giftPrefsStart + mod + 0L] = likes[0]; // liked gifts
                        presentData[giftPrefsStart + mod + 7L] = likes[1];
                        presentData[giftPrefsStart + mod + 8L] = likes[2];
                        presentData[giftPrefsStart + mod + 9L] = likes[3];
                        presentData[giftPrefsStart + mod + 10L] = likes[4];
                        presentData[giftPrefsStart + mod + 11L] = likes[5];

                        presentData[giftPrefsStart + mod + 4L] = dislikes[0]; // disliked gifts
                        presentData[giftPrefsStart + mod + 5L] = dislikes[1];
                        presentData[giftPrefsStart + mod + 6L] = dislikes[2];

                        changelog += "\n\n\t" + characterNames[newAssetIDs[charIndex]];
                        changelog += "\nLiked Gifts:";
                        for (int i = 1; i < likeCount && likes[i] != 255; i++)
                            changelog += "\t" + giftNames[likes[i]];
                        changelog += "\nDisliked Gifts:";
                        for (int i = 0; i < dislikeCount && dislikes[i] != 255; i++)
                            changelog += "\t" + giftNames[dislikes[i]];

                        if (msgLoaded && settings.changeMsg && settings.qolText)
                        {
                            string likesText = "";
                            int wordCount = 0;
                            for (int i = 1; i < likes.Length && likes[i] != 255; i++)
                            {
                                if (wordCount > 0)
                                {
                                    likesText += ",";
                                    if (wordCount % 3 == 0)
                                        likesText += "\n";
                                    else
                                        likesText += " ";
                                }
                                likesText += giftNames[likes[i]];
                                wordCount++;
                            }

                            string dislikesText = "";
                            wordCount = 0;
                            for (int i = 0; i < dislikes.Length && dislikes[i] != 255; i++)
                            {
                                if (wordCount > 0)
                                {
                                    dislikesText += ",";
                                    if (wordCount % 3 == 0)
                                        dislikesText += "\n";
                                    else
                                        dislikesText += " ";
                                }
                                dislikesText += giftNames[dislikes[i]];
                                wordCount++;
                            }

                            msgStrings[20473 + msgIndex] = likesText;
                            msgStrings[20519 + msgIndex] = dislikesText;
                        }
                    }

                    changelog += "\n\n\n---GIFT PREFERENCES---\nPer gift:";
                    for (int i = 0; i < likingCharactersPerGift.Length; i++)
                        if (obtainableGifts.Contains(i) && i != 20)
                        {
                            changelog += "\n\n\t" + giftNames[i];
                            changelog += "\nLiked by:";
                            for (int j = 0; j < likingCharactersPerGift[i].Count; j++)
                                changelog += "\t" + characterNames[newAssetIDs[likingCharactersPerGift[i][j]]];
                            changelog += "\nDisliked by:";
                            for (int j = 0; j < dislikingCharactersPerGift[i].Count; j++)
                                changelog += "\t" + characterNames[newAssetIDs[dislikingCharactersPerGift[i][j]]];
                            if (msgLoaded && settings.changeMsg && settings.qolText)
                            {
                                string giftDescription = "Loved by:";
                                int descriptionWordCount = 1;
                                for (int j = 0; j < likingCharactersPerGift[i].Count; j++)
                                {
                                    if (descriptionWordCount > 1)
                                        giftDescription += ",";
                                    giftDescription += " " + inGameCharacterNames[likingCharactersPerGift[i][j]];
                                    descriptionWordCount++;
                                }
                                if (descriptionWordCount == 1)
                                    giftDescription += " None";
                                giftDescription += ".\nNot so loved by:";
                                descriptionWordCount = 1;
                                for (int j = 0; j < dislikingCharactersPerGift[i].Count; j++)
                                {
                                    if (descriptionWordCount > 1)
                                        giftDescription += ",";
                                    giftDescription += " " + inGameCharacterNames[dislikingCharactersPerGift[i][j]];
                                    descriptionWordCount++;
                                }
                                if (descriptionWordCount == 1)
                                    giftDescription += " None";
                                giftDescription += ".";
                                msgStrings[17303 + i] = giftDescription;
                            }
                        }
                }

                if (shopLoaded && settings.randMerchants && settings.randShopPrices)
                    for (int index = 0; index < 245; index++)
                    {
                        long mod = (long)index * giftLen;
                        ushort priceShort = (ushort)(rng.Next(1, 21) * 100);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);
                        presentData[giftStart + mod + 0L] = priceBytes[0]; // gift prices
                        presentData[giftStart + mod + 1L] = priceBytes[1];
                    }
            }
            if (shopLoaded)
            {
                Randomizer.shopData = new byte[Randomizer.shopDataV.Length];
                Randomizer.shopDataV.CopyTo((Array)Randomizer.shopData, 0);

                for (int index = 0; index < 200; index++)
                {
                    long mod = (long)index * weaponShopLen;

                    if (index >= 182 && index <= 189)
                    {
                        shopData[weaponShopStart + mod + 0L] = (byte)76;
                        shopData[weaponShopStart + mod + 1L] = (byte)29;

                        shopData[weaponShopStart + mod + 4L] = (byte)78;
                        shopData[weaponShopStart + mod + 5L] = (byte)7;
                    }

                    ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[weaponShopStart + mod + 0L], shopData[weaponShopStart + mod + 1L] }, 0);
                    if (priceShort == 0)
                        continue;
                    else if (priceShort > 1 && settings.randWeaponShops && settings.randShopPrices)
                    {
                        priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 10);
                        ushort sellShort = (ushort)roundTo(priceShort / 4, 10);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);
                        byte[] sellBytes = BitConverter.GetBytes(sellShort);

                        shopData[weaponShopStart + mod + 0L] = priceBytes[0]; // weapon shop prices
                        shopData[weaponShopStart + mod + 1L] = priceBytes[1];

                        shopData[weaponShopStart + mod + 4L] = sellBytes[0]; // weapon shop selling prices
                        shopData[weaponShopStart + mod + 5L] = sellBytes[1];
                    }

                    if (priceShort != 0 && settings.randWeaponShops && settings.randShopStocks)
                    {
                        shopData[weaponShopStart + mod + 10L] = 0;

                        int availability = 0;

                        int selector = rng.Next(0, 100);
                        if (selector < 15)
                            availability = 1;
                        else if (selector < 20)
                            availability = 2;

                        shopData[weaponShopStart + mod + 12L] = (byte)availability; // weapon availability

                        byte[] stock = { 0, 0, 0 };

                        if (availability == 2)
                        {
                            stock[2] = (byte)1;
                            if (p(30))
                            {
                                stock[1] = (byte)1;
                                if (p(30))
                                    stock[0] = (byte)1;
                            }
                        }
                        else if (availability == 1)
                        {
                            stock[2] = (byte)255;
                            if (p(10))
                                stock[2] = (byte)rng.Next(3, 11);
                            switch (stock[2])
                            {
                                case 255:
                                    stock[1] = (byte)255;
                                    if (p(30))
                                        stock[1] = (byte)rng.Next(3, 11);
                                    break;
                                default:
                                    stock[1] = (byte)0;
                                    if (p(10))
                                        stock[1] = (byte)rng.Next(3, stock[2] + 1);
                                    break;
                            }
                            switch (stock[1])
                            {
                                case 0:
                                    break;
                                case 255:
                                    stock[0] = (byte)255;
                                    if (p(30))
                                        stock[0] = (byte)rng.Next(3, 11);
                                    break;
                                default:
                                    stock[0] = (byte)0;
                                    if (p(10))
                                        stock[0] = (byte)rng.Next(3, stock[1] + 1);
                                    break;
                            }

                            shopData[weaponShopStart + mod + 16L] = stock[0]; // weapon stock
                            shopData[weaponShopStart + mod + 17L] = stock[1];
                            shopData[weaponShopStart + mod + 18L] = stock[2];
                        }
                    }

                    if (settings.randRepairItems && index > 5)
                    {
                        byte miscItem = shopData[weaponShopStart + mod + 13L];
                        if (miscItem == 255)
                            miscItem = 64;
                        shopData[weaponShopStart + mod + 13L] = (byte)randLocalItem(settings, miscItem, 3); // repairing item
                        shopData[weaponShopStart + mod + 14L] = (byte)rng.Next(1, 6); // repairing item count
                    }
                }

                for (int index = 0; index < 50; index++)
                {
                    long mod = (long)index * equipmentShopLen;

                    if (!obtainableEquipment.Contains(index))
                        continue;

                    if (settings.randItemShops && settings.randShopPrices)
                    {
                        ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[equipmentShopStart + mod + 0L], shopData[equipmentShopStart + mod + 1L] }, 0);
                        priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 500);
                        ushort sellShort = (ushort)roundTo(priceShort / 4, 10);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);
                        byte[] sellBytes = BitConverter.GetBytes(sellShort);

                        shopData[equipmentShopStart + mod + 0L] = priceBytes[0]; // equipment shop prices
                        shopData[equipmentShopStart + mod + 1L] = priceBytes[1];

                        shopData[equipmentShopStart + mod + 4L] = sellBytes[0]; // equipment shop selling prices
                        shopData[equipmentShopStart + mod + 5L] = sellBytes[1];
                    }

                    if (settings.randItemShops && settings.randShopStocks)
                    {
                        shopData[equipmentShopStart + mod + 10L] = 0;

                        int availability = 0;

                        int selector = rng.Next(0, 100);
                        if (selector < 5)
                            availability = 1;
                        else if (selector < 10)
                            availability = 2;

                        shopData[equipmentShopStart + mod + 12L] = (byte)availability; // equipment availability

                        byte[] stock = { 0, 0, 0 };

                        if (availability == 2)
                        {
                            stock[2] = (byte)1;
                            if (p(30))
                            {
                                stock[1] = (byte)1;
                                if (p(30))
                                    stock[0] = (byte)1;
                            }
                        }
                        else if (availability == 1)
                        {
                            stock[2] = (byte)255;
                            if (p(10))
                                stock[2] = (byte)rng.Next(3, 11);
                            switch (stock[2])
                            {
                                case 255:
                                    stock[1] = (byte)255;
                                    if (p(30))
                                        stock[1] = (byte)rng.Next(3, 11);
                                    break;
                                default:
                                    stock[1] = (byte)0;
                                    if (p(10))
                                        stock[1] = (byte)rng.Next(3, stock[2] + 1);
                                    break;
                            }
                            switch (stock[1])
                            {
                                case 0:
                                    break;
                                case 255:
                                    stock[0] = (byte)255;
                                    if (p(30))
                                        stock[0] = (byte)rng.Next(3, 11);
                                    break;
                                default:
                                    stock[0] = (byte)0;
                                    if (p(10))
                                        stock[0] = (byte)rng.Next(3, stock[1] + 1);
                                    break;
                            }

                            shopData[equipmentShopStart + mod + 13L] = stock[0]; // equipment stock
                            shopData[equipmentShopStart + mod + 14L] = stock[1];
                            shopData[equipmentShopStart + mod + 15L] = stock[2];
                        }
                    }
                }

                for (int index = 0; index < 200; index++)
                {
                    long mod = (long)index * itemShopLen;

                    int itemId = shopData[itemShopStart + mod + 8L];
                    if (!obtainableItems.Contains(itemId))
                        continue;

                    if (settings.randItemShops && settings.randShopPrices)
                    {
                        switch (itemId)
                        {
                            case 5:
                            case 159:
                                shopData[itemShopStart + mod + 0L] = (byte)232;
                                shopData[itemShopStart + mod + 1L] = (byte)3;

                                shopData[itemShopStart + mod + 4L] = (byte)200;
                                shopData[itemShopStart + mod + 5L] = (byte)0;
                                break;
                            case 148:
                            case 149:
                            case 150:
                            case 151:
                            case 152:
                            case 153:
                            case 154:
                            case 155:
                            case 156:
                            case 157:
                                shopData[itemShopStart + mod + 0L] = (byte)196;
                                shopData[itemShopStart + mod + 1L] = (byte)9;

                                shopData[itemShopStart + mod + 4L] = (byte)244;
                                shopData[itemShopStart + mod + 5L] = (byte)1;
                                break;
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                                shopData[itemShopStart + mod + 0L] = (byte)136;
                                shopData[itemShopStart + mod + 1L] = (byte)19;

                                shopData[itemShopStart + mod + 4L] = (byte)232;
                                shopData[itemShopStart + mod + 5L] = (byte)3;
                                break;
                            case 25:
                            case 52:
                            case 53:
                            case 54:
                                shopData[itemShopStart + mod + 0L] = (byte)16;
                                shopData[itemShopStart + mod + 1L] = (byte)39;

                                shopData[itemShopStart + mod + 4L] = (byte)208;
                                shopData[itemShopStart + mod + 5L] = (byte)7;
                                break;
                            case 51:
                                shopData[itemShopStart + mod + 0L] = (byte)32;
                                shopData[itemShopStart + mod + 1L] = (byte)78;

                                shopData[itemShopStart + mod + 4L] = (byte)160;
                                shopData[itemShopStart + mod + 5L] = (byte)15;
                                break;
                        }

                        ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[itemShopStart + mod + 0L], shopData[itemShopStart + mod + 1L] }, 0);
                        priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                        ushort sellShort = (ushort)roundTo(priceShort / 5, 100);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);
                        byte[] sellBytes = BitConverter.GetBytes(sellShort);

                        shopData[itemShopStart + mod + 0L] = priceBytes[0]; // item shop prices
                        shopData[itemShopStart + mod + 1L] = priceBytes[1];

                        shopData[itemShopStart + mod + 4L] = sellBytes[0]; // item shop selling prices
                        shopData[itemShopStart + mod + 5L] = sellBytes[1];
                    }

                    if (settings.randItemShops && settings.randShopStocks)
                    {
                        shopData[itemShopStart + mod + 10L] = 0;

                        int availability = 0;

                        int selector = rng.Next(0, 100);
                        if (selector < 15 || index == 13)
                            availability = 1;
                        else if (selector < 20)
                            availability = 2;

                        shopData[itemShopStart + mod + 12L] = (byte)availability; // item availability

                        byte[] stock = { 0, 0, 0 };

                        if (availability == 2)
                        {
                            stock[2] = (byte)1;
                            if (p(30))
                            {
                                stock[1] = (byte)1;
                                if (p(30))
                                    stock[0] = (byte)1;
                            }
                        }
                        else if (availability == 1)
                        {
                            stock[2] = (byte)255;
                            if (p(10))
                                stock[2] = (byte)rng.Next(3, 11);
                            switch (stock[2])
                            {
                                case 255:
                                    stock[1] = (byte)255;
                                    if (p(30))
                                        stock[1] = (byte)rng.Next(3, 11);
                                    break;
                                default:
                                    stock[1] = (byte)0;
                                    if (p(10))
                                        stock[1] = (byte)rng.Next(3, stock[2] + 1);
                                    break;
                            }
                            switch (stock[1])
                            {
                                case 0:
                                    break;
                                case 255:
                                    stock[0] = (byte)255;
                                    if (p(30))
                                        stock[0] = (byte)rng.Next(3, 11);
                                    break;
                                default:
                                    stock[0] = (byte)0;
                                    if (p(10))
                                        stock[0] = (byte)rng.Next(3, stock[1] + 1);
                                    break;
                            }

                            if (index == 13)
                                stock = new byte[] { 255, 255, 255 };

                            shopData[itemShopStart + mod + 13L] = stock[0]; // item stock
                            shopData[itemShopStart + mod + 14L] = stock[1];
                            shopData[itemShopStart + mod + 15L] = stock[2];
                        }
                    }
                }

                for (int index = 0; index < 200; index++)
                {
                    long mod = (long)index * battalionShopLen;

                    if (battalionNames[index] == "")
                        continue;

                    if (settings.randBattalionShops && settings.randShopPrices)
                    {
                        ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[battalionShopStart + mod + 0L], shopData[battalionShopStart + mod + 1L] }, 0);
                        if (priceShort == 0)
                            priceShort = 2500;
                        priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                        ushort sellShort = (ushort)roundTo(priceShort / 5, 10);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);
                        byte[] sellBytes = BitConverter.GetBytes(sellShort);

                        shopData[battalionShopStart + mod + 0L] = priceBytes[0]; // battalion shop prices
                        shopData[battalionShopStart + mod + 1L] = priceBytes[1];

                        shopData[battalionShopStart + mod + 4L] = sellBytes[0]; // battalion shop selling prices
                        shopData[battalionShopStart + mod + 5L] = sellBytes[1];
                    }

                    if (settings.randBattalionShops && settings.randShopStocks)
                    {
                        shopData[battalionShopStart + mod + 15L] = (byte)rng.Next(1, 16); // battalion route availability

                        byte[] stock = { 0, 0, 0 };

                        if (p(50))
                        {
                            stock[2] = 1;
                            if (p(50))
                            {
                                stock[1] = 1;
                                if (p(50))
                                    stock[0] = 1;
                            }
                        }

                        shopData[battalionShopStart + mod + 16L] = stock[0]; // battalion stock
                        shopData[battalionShopStart + mod + 17L] = stock[1];
                        shopData[battalionShopStart + mod + 18L] = stock[2];
                    }
                }

                for (int index = 0; index < 121; index++)
                {
                    long mod = (long)index * forgingLen;

                    if (settings.randForgeCosts)
                    {
                        ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[forgingStart + mod + 0L], shopData[forgingStart + mod + 1L] }, 0);

                        priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);

                        shopData[forgingStart + mod + 0L] = priceBytes[0]; // forging prices
                        shopData[forgingStart + mod + 1L] = priceBytes[1];
                    }

                    if (settings.randForgeItems)
                    {
                        shopData[forgingStart + mod + 6L] = (byte)randLocalItem(settings, shopData[forgingStart + mod + 6L], 3); // forging material
                        shopData[forgingStart + mod + 11L] = (byte)rng.Next(2, 11); // forging material count
                    }

                    if (settings.randForgeWeapons)
                    {
                        int baseWeapon = rng.Next(1, 191);
                        int forgedWeapon = rng.Next(1, 191);
                        if (settings.preserveForgeWeaponTypes)
                        {
                            int weaponType = findItemFunction(baseWeapon, 0);
                            forgedWeapon = itemFunctionGroups[weaponType][rng.Next(0, itemFunctionGroups[weaponType].Length)];
                        }

                        shopData[forgingStart + mod + 4L] = (byte)baseWeapon; // forgeable weapons
                        shopData[forgingStart + mod + 8L] = (byte)forgedWeapon; // forging results
                    }

                    if (settings.randForgeProfLvReq)
                    {
                        shopData[forgingStart + mod + 10L] = (byte)rng.Next(1, 10); // forging professor level requirements
                    }
                }

                if (settings.randSaintStatueCosts || settings.randSaintStatuePerks)
                {
                    changelog += "\n\n\n---SAINT STATUES---";

                    for (int statue = 0; statue < 4; statue++)
                    {
                        ushort[] costs = new ushort[10];
                        for (int i = 1; i < costs.Length; i++)
                            costs[i] = (ushort)(costs[i - 1] + rng.Next(i, 3 * i + 3) * 100);

                        byte[] divinePulses = new byte[10];
                        for (int i = 1; i < divinePulses.Length; i++)
                            divinePulses[i] = (byte)(p(10) ? divinePulses[i - 1] + 1 : divinePulses[i - 1]);

                        byte[] masteryExp = new byte[10];
                        for (int i = 1; i < masteryExp.Length; i++)
                            masteryExp[i] = (byte)(p(3) ? masteryExp[i - 1] + 1 : masteryExp[i - 1]);

                        byte[] exp = new byte[10];
                        for (int i = 1; i < exp.Length; i++)
                            exp[i] = (byte)(p(20) ? exp[i - 1] + 5 : exp[i - 1]);

                        byte[][] caps = new byte[9][];
                        for (int j = 0; j < caps.Length; j++)
                        {
                            caps[j] = new byte[10];
                            for (int i = 1; i < caps[j].Length; i++)
                                caps[j][i] = (byte)(p(3) ? caps[j][i - 1] + 5 : caps[j][i - 1]);
                        }

                        byte[][] skills = new byte[11][];
                        for (int i = 0; i < skills.Length; i++)
                        {
                            skills[i] = new byte[10];
                            for (int j = 1; j < skills[i].Length; j++)
                                skills[i][j] = (byte)(p(5) ? skills[i][j - 1] + 1 : skills[i][j - 1]);
                        }

                        changelog += "\n\n\t" + getStatueName(statue);

                        for (int index = 1; index < 10; index++)
                        {
                            long mod = (long)(10 * statue + index) * statueLen;

                            changelog += "\nLevel " + index + ":";

                            if (settings.randSaintStatueCosts)
                            {
                                byte[] costBytes = BitConverter.GetBytes(costs[index]);
                                shopData[statueStart + mod + 0L] = costBytes[0]; // saint statue renown costs
                                shopData[statueStart + mod + 1L] = costBytes[1];

                                changelog += "\t" + costs[index] + " Renown";
                            }

                            if (settings.randSaintStatuePerks)
                            {
                                shopData[statueStart + mod + 2L] = divinePulses[index]; // extra divine pulse charges
                                shopData[statueStart + mod + 5L] = masteryExp[index]; // extra class mastery exp gain
                                shopData[statueStart + mod + 7L] = exp[index]; // extra exp gain
                                shopData[statueStart + mod + 8L] = masteryExp[index];
                                shopData[statueStart + mod + 10L] = masteryExp[index];
                                shopData[statueStart + mod + 11L] = masteryExp[index];
                                for (int i = 0; i < caps.Length; i++)
                                    shopData[statueStart + mod + 12L + i] = caps[i][index]; // stat cap increases
                                for (int i = 0; i < skills.Length; i++)
                                    shopData[statueStart + mod + 21L + i] = skills[i][index]; // extra skill exp gain

                                if (divinePulses[index] != divinePulses[index - 1])
                                    changelog += "\t+1 Divine Pulse Charge";
                                if (masteryExp[index] != masteryExp[index - 1])
                                    changelog += "\t+1 Class Mastery Exp Gain";
                                if (exp[index] != exp[index - 1])
                                    changelog += "\t+5% Exp Gain";
                                for (int i = 0; i < caps.Length; i++)
                                    if (caps[i][index] != caps[i][index - 1])
                                        changelog += "\t+5 " + getStatName(i) + " Cap";
                                for (int i = 0; i < skills.Length; i++)
                                    if (skills[i][index] != skills[i][index - 1])
                                        changelog += "\t+1 " + getSkillName(i) + " Gain";

                                if (msgLoaded && settings.changeMsg)
                                {
                                    string newTitle = "";
                                    string newDescription = "";
                                    if (divinePulses[index] != divinePulses[index - 1])
                                    {
                                        newTitle += ", +1 Divine Pulse Charge";
                                        newDescription += "\nIncreases available charges for Divine Pulse by 1.";
                                    }
                                    if (masteryExp[index] != masteryExp[index - 1])
                                    {
                                        newTitle += ", +1 Class Mastery Exp Gain";
                                        newDescription += "\nIncreases Exp earned in units' assigned classes by 1.";
                                    }
                                    if (exp[index] != exp[index - 1])
                                    {
                                        newTitle += ", +5% Exp Gain";
                                        newDescription += "\nIncreases experience earned by 5%.";
                                    }
                                    for (int i = 0; i < caps.Length; i++)
                                        if (caps[i][index] != caps[i][index - 1])
                                        {
                                            newTitle += ", +5 " + getStatName(i) + " Cap";
                                            newDescription += "\nIncreases maximum " + getStatName(i) + " by 5.";
                                        }
                                    for (int i = 0; i < skills.Length; i++)
                                        if (skills[i][index] != skills[i][index - 1])
                                        {
                                            newTitle += ", +1 " + getSkillName(i) + " Gain";
                                            newDescription += "\nIncreases Exp earned in the " + getSkillName(i) + " skill by 1.";
                                        }
                                    if (newTitle.Length == 0)
                                        newTitle = ", Nothing";
                                    if (newDescription.Length == 0)
                                        newDescription = "\nYou get nothing.";
                                    msgStrings[16678 + 10 * statue + index] = newTitle.Trim(new char[] { ',', ' ' });
                                    msgStrings[16718 + 10 * statue + index] = newDescription.Trim(new char[] { '\n' });
                                }
                            }
                        }
                    }
                }

                for (int index = 0; index < 100; index++)
                {
                    long mod = (long)index * merchantLen;

                    ushort itemShort = BitConverter.ToUInt16(new byte[] { shopData[merchantStart + mod + 0L], shopData[merchantStart + mod + 1L] }, 0);

                    if (settings.randMerchants && settings.randShopStocks && itemShort != 0)
                    {
                        itemShort = (ushort)randGeneralItem(settings, itemShort);
                        byte[] itemBytes = BitConverter.GetBytes(itemShort);
                        shopData[merchantStart + mod + 0L] = itemBytes[0]; // merchant items
                        shopData[merchantStart + mod + 1L] = itemBytes[1];

                        int stock = 255;
                        if (p(50))
                        {
                            stock = 1;
                            if (p(10))
                            {
                                stock = 5;
                                if (p(40))
                                    stock = 10;
                            }
                        }

                        int availability = 1;
                        if (p(5))
                        {
                            availability = 2;
                            stock = 1;
                        }

                        shopData[merchantStart + mod + 4L] = (byte)availability; // merchant item availability
                        shopData[merchantStart + mod + 5L] = (byte)stock; // merchant item stock
                    }
                }

                for (int index = 0; index < 50; index++)
                {
                    long mod = index * annaShopLen;

                    if (shopData[annaShopStart + mod + 6L] == 0)
                        continue;

                    if (settings.randAnnaShop && settings.randShopPrices)
                    {
                        ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[annaShopStart + mod + 0L], shopData[annaShopStart + mod + 1L] }, 0);
                        priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                        byte[] priceBytes = BitConverter.GetBytes(priceShort);
                        shopData[annaShopStart + mod + 0L] = priceBytes[0]; // Anna's shop item prices
                        shopData[annaShopStart + mod + 1L] = priceBytes[1];
                    }

                    if (settings.randAnnaShop && settings.randShopStocks)
                    {
                        ushort itemShort = BitConverter.ToUInt16(new byte[] { shopData[annaShopStart + mod + 4L], shopData[annaShopStart + mod + 5L] }, 0);
                        itemShort = (ushort)randGeneralItem(settings, itemShort);
                        byte[] itemBytes = BitConverter.GetBytes(itemShort);
                        shopData[annaShopStart + mod + 4L] = itemBytes[0]; // Anna's shop items
                        shopData[annaShopStart + mod + 5L] = itemBytes[1];

                        int stock = 255;
                        if (p(10))
                            stock = 1;

                        int availability = 1;
                        if (p(90))
                        {
                            availability = 2;
                            stock = 1;
                        }

                        shopData[annaShopStart + mod + 6L] = (byte)availability; // Anna's shop item availability
                        shopData[annaShopStart + mod + 7L] = (byte)stock; // Anna's shop item stock
                    }
                }

                if (settings.randInfluencerCosts)
                {
                    ushort[] costs = new ushort[6];
                    for (int i = 1; i < costs.Length; i++)
                        costs[i] = (ushort)roundTo(costs[i - 1] + rng.Next(i * 200, i * 600 + 1), 500);

                    for (int index = 0; index < 6; index++)
                    {
                        long mod = index * influencerLen;
                        byte[] costBytes = BitConverter.GetBytes(costs[index]);
                        shopData[influencerStart + mod + 0L] = costBytes[0]; // influencer renown costs
                        shopData[influencerStart + mod + 1L] = costBytes[1];
                    }
                }

                if (settings.randPaganAltar)
                {
                    for (int index = 0; index < 50; index++)
                    {
                        long mod = index * paganWeaponLen;

                        if (shopData[paganWeaponStart + mod + 12L] == 0)
                            continue;

                        if (settings.randShopPrices)
                        {
                            ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[paganWeaponStart + mod + 0L], shopData[paganWeaponStart + mod + 1L] }, 0);
                            priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                            byte[] priceBytes = BitConverter.GetBytes(priceShort);
                            shopData[paganWeaponStart + mod + 0L] = priceBytes[0]; // pagan altar weapon prices
                            shopData[paganWeaponStart + mod + 1L] = priceBytes[1];

                            priceShort = BitConverter.ToUInt16(new byte[] { shopData[paganWeaponStart + mod + 4L], shopData[paganWeaponStart + mod + 5L] }, 0);
                            priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                            priceBytes = BitConverter.GetBytes(priceShort);
                            shopData[paganWeaponStart + mod + 4L] = priceBytes[0]; // unk
                            shopData[paganWeaponStart + mod + 5L] = priceBytes[1];
                        }

                        if (settings.randShopStocks)
                        {
                            ushort itemShort = BitConverter.ToUInt16(new byte[] { shopData[paganWeaponStart + mod + 8L], shopData[paganWeaponStart + mod + 9L] }, 0);
                            itemShort = (ushort)randLocalItem(settings, itemShort, 0);
                            byte[] itemBytes = BitConverter.GetBytes(itemShort);
                            shopData[paganWeaponStart + mod + 8L] = itemBytes[0]; // pagan altar weapons
                            shopData[paganWeaponStart + mod + 9L] = itemBytes[1];

                            int availability = 1;
                            if (p(40))
                                availability = 2;
                            int[] stock = { 0, 0, 0 };
                            if (availability == 2)
                            {
                                stock[2] = rng.Next(1, 4);
                                if (p(40))
                                {
                                    stock[1] = rng.Next(1, stock[2] + 1);
                                    if (p(40))
                                        stock[0] = rng.Next(1, stock[1] + 1);
                                }
                            }
                            else
                            {
                                stock[2] = 255;
                                if (p(10))
                                    stock[2] = rng.Next(1, 4);
                                if (stock[2] == 255)
                                {
                                    stock[1] = 255;
                                    if (p(40))
                                        stock[1] = rng.Next(1, 4);
                                }
                                else
                                {
                                    stock[1] = 0;
                                    if (p(10))
                                        stock[1] = rng.Next(1, stock[2] + 1);
                                }
                                switch (stock[1])
                                {
                                    case 0:
                                        break;
                                    case 255:
                                        if (p(80))
                                        {
                                            stock[0] = 255;
                                            if (p(40))
                                                stock[0] = rng.Next(1, 4);
                                        }
                                        break;
                                    default:
                                        if (p(10))
                                            stock[0] = rng.Next(1, stock[1] + 1);
                                        break;
                                }
                            }

                            shopData[paganWeaponStart + mod + 12L] = (byte)availability; // pagan altar weapon availability
                            shopData[paganWeaponStart + mod + 15L] = (byte)stock[0]; // pagan altar weapon stock
                            shopData[paganWeaponStart + mod + 16L] = (byte)stock[1];
                            shopData[paganWeaponStart + mod + 17L] = (byte)stock[2];
                        }
                    }

                    for (int index = 0; index < 30; index++)
                    {
                        long mod = index * paganEquipmentLen;

                        if (shopData[paganEquipmentStart + mod + 10L] == 0)
                            continue;

                        if (settings.randShopPrices)
                        {
                            ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[paganEquipmentStart + mod + 0L], shopData[paganEquipmentStart + mod + 1L] }, 0);
                            priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 500);
                            byte[] priceBytes = BitConverter.GetBytes(priceShort);
                            shopData[paganEquipmentStart + mod + 0L] = priceBytes[0]; // unk
                            shopData[paganEquipmentStart + mod + 1L] = priceBytes[1];

                            priceShort = BitConverter.ToUInt16(new byte[] { shopData[paganEquipmentStart + mod + 4L], shopData[paganEquipmentStart + mod + 5L] }, 0);
                            priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 500);
                            priceBytes = BitConverter.GetBytes(priceShort);
                            shopData[paganEquipmentStart + mod + 4L] = priceBytes[0]; // pagan altar equipment prices
                            shopData[paganEquipmentStart + mod + 5L] = priceBytes[1];
                        }

                        if (settings.randShopStocks)
                        {
                            ushort itemShort = BitConverter.ToUInt16(new byte[] { shopData[paganEquipmentStart + mod + 8L], shopData[paganEquipmentStart + mod + 9L] }, 0);
                            itemShort = (ushort)randLocalItem(settings, itemShort, 1);
                            byte[] itemBytes = BitConverter.GetBytes(itemShort);
                            shopData[paganEquipmentStart + mod + 8L] = itemBytes[0]; // pagan altar equipment
                            shopData[paganEquipmentStart + mod + 9L] = itemBytes[1];

                            int availability = 1;
                            if (p(95))
                                availability = 2;
                            int[] stock = { 0, 0, 0 };
                            if (availability == 2)
                            {
                                stock[2] = 1;
                                if (p(40))
                                {
                                    stock[1] = 1;
                                    if (p(40))
                                        stock[0] = 1;
                                }
                            }
                            else
                            {
                                stock[2] = 255;
                                if (p(10))
                                    stock[2] = rng.Next(1, 4);
                                if (stock[2] == 255)
                                {
                                    stock[1] = 255;
                                    if (p(40))
                                        stock[1] = rng.Next(1, 4);
                                }
                                else
                                {
                                    stock[1] = 0;
                                    if (p(10))
                                        stock[1] = rng.Next(1, stock[2] + 1);
                                }
                                switch (stock[1])
                                {
                                    case 0:
                                        break;
                                    case 255:
                                        if (p(80))
                                        {
                                            stock[0] = 255;
                                            if (p(40))
                                                stock[0] = rng.Next(1, 4);
                                        }
                                        break;
                                    default:
                                        if (p(10))
                                            stock[0] = rng.Next(1, stock[1] + 1);
                                        break;
                                }
                            }

                            shopData[paganEquipmentStart + mod + 10L] = (byte)availability; // pagan altar equipment availability
                            shopData[paganEquipmentStart + mod + 12L] = (byte)stock[0]; // pagan altar equipment stock
                            shopData[paganEquipmentStart + mod + 13L] = (byte)stock[1];
                            shopData[paganEquipmentStart + mod + 14L] = (byte)stock[2];
                        }
                    }

                    for (int index = 0; index < 20; index++)
                    {
                        long mod = index * paganItemLen;

                        if (shopData[paganItemStart + mod + 10L] == 0)
                            continue;

                        if (settings.randShopPrices)
                        {
                            ushort priceShort = BitConverter.ToUInt16(new byte[] { shopData[paganItemStart + mod + 0L], shopData[paganItemStart + mod + 1L] }, 0);
                            priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                            byte[] priceBytes = BitConverter.GetBytes(priceShort);
                            shopData[paganItemStart + mod + 0L] = priceBytes[0]; // unk
                            shopData[paganItemStart + mod + 1L] = priceBytes[1];

                            priceShort = BitConverter.ToUInt16(new byte[] { shopData[paganItemStart + mod + 4L], shopData[paganItemStart + mod + 5L] }, 0);
                            priceShort = (ushort)roundTo(exponentialRng(priceShort, 2), 100);
                            priceBytes = BitConverter.GetBytes(priceShort);
                            shopData[paganItemStart + mod + 4L] = priceBytes[0]; // pagan altar item prices
                            shopData[paganItemStart + mod + 5L] = priceBytes[1];
                        }

                        if (settings.randShopStocks)
                        {
                            ushort itemShort = BitConverter.ToUInt16(new byte[] { shopData[paganItemStart + mod + 8L], shopData[paganItemStart + mod + 9L] }, 0);
                            itemShort = (ushort)randLocalItem(settings, itemShort, 2);
                            byte[] itemBytes = BitConverter.GetBytes(itemShort);
                            shopData[paganItemStart + mod + 8L] = itemBytes[0]; // pagan altar items
                            shopData[paganItemStart + mod + 9L] = itemBytes[1];

                            int availability = 1;
                            if (p(10))
                                availability = 2;
                            int[] stock = { 0, 0, 0 };
                            if (availability == 2)
                            {
                                stock[2] = rng.Next(3, 6);
                                if (p(40))
                                {
                                    stock[1] = rng.Next(3, stock[2] + 1);
                                    if (p(40))
                                        stock[0] = rng.Next(3, stock[1] + 1);
                                }
                            }
                            else
                            {
                                stock[2] = 255;
                                if (p(10))
                                    stock[2] = rng.Next(3, 6);
                                if (stock[2] == 255)
                                {
                                    stock[1] = 255;
                                    if (p(40))
                                        stock[1] = rng.Next(3, 6);
                                }
                                else
                                {
                                    stock[1] = 0;
                                    if (p(10))
                                        stock[1] = rng.Next(3, stock[2] + 1);
                                }
                                switch (stock[1])
                                {
                                    case 0:
                                        break;
                                    case 255:
                                        if (p(80))
                                        {
                                            stock[0] = 255;
                                            if (p(40))
                                                stock[0] = rng.Next(3, 6);
                                        }
                                        break;
                                    default:
                                        if (p(10))
                                            stock[0] = rng.Next(3, stock[1] + 1);
                                        break;
                                }
                            }

                            shopData[paganItemStart + mod + 10L] = (byte)availability; // pagan altar item availability
                            shopData[paganItemStart + mod + 12L] = (byte)stock[0]; // pagan altar item stock
                            shopData[paganItemStart + mod + 13L] = (byte)stock[1];
                            shopData[paganItemStart + mod + 14L] = (byte)stock[2];
                        }
                    }
                }
            }
            if (questLoaded)
            {
                Randomizer.questData = new byte[Randomizer.questDataV.Length];
                Randomizer.questDataV.CopyTo((Array)Randomizer.questData, 0);

                if (settings.randQuestRewards)
                {
                    for (int index = 0; index < 52; index++)
                    {
                        long mod = index * questLen;

                        ushort goldReward = BitConverter.ToUInt16(new byte[] { questData[questStart + mod + 0L], questData[questStart + mod + 1L] }, 0);
                        goldReward = (ushort)roundTo(exponentialRng(goldReward, 2), 100);
                        byte[] goldRewardBytes = BitConverter.GetBytes(goldReward);
                        questData[questStart + mod + 0L] = goldRewardBytes[0];
                        questData[questStart + mod + 1L] = goldRewardBytes[1];

                        ushort renownReward = BitConverter.ToUInt16(new byte[] { questData[questStart + mod + 2L], questData[questStart + mod + 3L] }, 0);
                        renownReward = (ushort)roundTo(exponentialRng(renownReward, 2), 100);
                        byte[] renownRewardBytes = BitConverter.GetBytes(renownReward);
                        questData[questStart + mod + 2L] = renownRewardBytes[0];
                        questData[questStart + mod + 3L] = renownRewardBytes[1];

                        for (int i = 0; i < 3; i++)
                        {
                            ushort battalionShort = BitConverter.ToUInt16(new byte[] { questData[questStart + mod + 26L + 2 * i], questData[questStart + mod + 27L + 2 * i] }, 0);
                            if (battalionShort < 65535)
                            {
                                battalionShort = (ushort)rng.Next(0, 200);
                                while (battalionNames[battalionShort] == "")
                                    battalionShort = (ushort)rng.Next(0, 200);
                                byte[] battalionBytes = BitConverter.GetBytes(battalionShort);
                                questData[questStart + mod + 26L + 2 * i] = battalionBytes[0];
                                questData[questStart + mod + 27L + 2 * i] = battalionBytes[1];
                            }
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            ushort itemShort = BitConverter.ToUInt16(new byte[] { questData[questStart + mod + 32L + 2 * i], questData[questStart + mod + 33L + 2 * i] }, 0);
                            if (itemShort < 65535)
                            {
                                itemShort = (ushort)randGeneralItem(settings, itemShort);
                                byte[] itemBytes = BitConverter.GetBytes(itemShort);
                                questData[questStart + mod + 32L + 2 * i] = itemBytes[0];
                                questData[questStart + mod + 33L + 2 * i] = itemBytes[1];
                            }
                        }
                    }

                    for (int index = 0; index < 10; index++)
                    {
                        long mod = index * annaQuestLen;

                        ushort renownReward = BitConverter.ToUInt16(new byte[] { questData[annaQuestStart + mod + 0L], questData[annaQuestStart + mod + 1L] }, 0);
                        renownReward = (ushort)roundTo(exponentialRng(renownReward, 2), 100);
                        byte[] renownRewardBytes = BitConverter.GetBytes(renownReward);
                        questData[annaQuestStart + mod + 0L] = renownRewardBytes[0];
                        questData[annaQuestStart + mod + 1L] = renownRewardBytes[1];

                        for (int i = 0; i < 3; i++)
                        {
                            ushort itemShort = BitConverter.ToUInt16(new byte[] { questData[annaQuestStart + mod + 4L + 2 * i], questData[annaQuestStart + mod + 5L + 2 * i] }, 0);
                            if (itemShort < 65535)
                            {
                                itemShort = (ushort)randGeneralItem(settings, itemShort);
                                byte[] itemBytes = BitConverter.GetBytes(itemShort);
                                questData[annaQuestStart + mod + 4L + 2 * i] = itemBytes[0];
                                questData[annaQuestStart + mod + 5L + 2 * i] = itemBytes[1];
                            }
                        }
                    }
                }
            }
            if (BGMLoaded)
            {
                Randomizer.BGMData = new byte[Randomizer.BGMDataV.Length];
                Randomizer.BGMDataV.CopyTo((Array)Randomizer.BGMData, 0);

                if (settings.shuffleBgm)
                {
                    List<List<byte>> tracks = new List<List<byte>>();
                    for (int i = 0; i < BGMLinkLocations.Length - 1; i++)
                    {
                        List<byte> track = new List<byte>();
                        for (int j = (int)BGMLinkLocations[i] - 8; j < (int)BGMLinkLocations[i] - 8 + 64 +
                            BGMData[BGMLinkLocations[i] - 4] +
                            BGMData[BGMLinkLocations[i] - 3] * 256 +
                            BGMData[BGMLinkLocations[i] - 2] * 256 * 256 +
                            BGMData[BGMLinkLocations[i] - 1] * 256 * 256 * 256; j++)
                            track.Add(BGMData[j]);
                        tracks.Add(track);
                    }

                    List<byte>[] newTracks = new List<byte>[tracks.Count];
                    List<List<byte>> tempTracks = new List<List<byte>>();
                    tempTracks.AddRange(tracks);

                    List<int> rn = new List<int>();
                    for (int i = 0; i < tracks.Count; i++)
                        rn.Add(i);
                    rn.Shuffle();

                    List<int> temprn = new List<int>();
                    for (int i = 0; i < tempTracks.Count; i++)
                        temprn.Add(i);
                    temprn.Shuffle();
                    int r = 0;

                    for (int i = 0; i < tracks.Count;)
                    {
                        int trackLocation = temprn[r];
                        if (tempTracks[trackLocation].Count <= tracks[rn[i]].Count)
                        {
                            newTracks[rn[i]] = tempTracks[trackLocation];
                            tempTracks.RemoveAt(trackLocation);
                            i++;
                            temprn.Remove(temprn.Count - 1);
                            temprn.Shuffle();
                            r = 0;
                        }
                        else
                        {
                            r++;
                            if (r >= temprn.Count)
                            {
                                tempTracks.AddRange(tracks);
                                temprn.Clear();
                                for (int j = 0; j < tempTracks.Count; j++)
                                    temprn.Add(j);
                                temprn.Shuffle();
                                r = 0;
                            }
                        }

                    }

                    for (int i = 0; i < newTracks.Length; i++)
                        for (int j = 0; j < newTracks[i].Count; j++)
                            BGMData[BGMLinkLocations[i] - 8 + j] = newTracks[i][j];
                }
            }
            if (msgLoaded && settings.changeMsg && settings.qolText)
            {
                msgStrings[1029] = "Growth Rates";
                msgStrings[1230] = "%s1 really values the following stat:\n• %s2\nRequirement lowered by 20% for each Support rank.";
                msgStrings[1231] = "%s1 really values the following stats:\n• %s2\n• %s3\nRequirement lowered by 20% for each Support rank.";
                msgStrings[1260] = "Rating";
                msgStrings[1261] = "Values";
                msgStrings[2670] = "Physical: Atk = Str + Weapon's Mt.\nMagic: Atk = Mag + Spell's Mt.";
                msgStrings[2671] = "Physical: Hit = Dex + Weapon's Hit.\nMagic: Hit = (Dex + Lck) / 2 + Spell's Hit.";
                msgStrings[2672] = "Crit = Dex + Lck / 2.";
                msgStrings[2673] = "AS = Spd + Str / 5 - Weapon or spell's Wt.";
                msgStrings[2674] = "Physical Avoid = AS.\nMagic Avoid = (Spd + Lck) / 2";
                msgStrings[2675] = "Prt = Def.";
                msgStrings[2676] = "Rsl = Res.";
                msgStrings[11888] = "Holder acquires the Crest of Ernest, granting\n5% chance to prevent counters with weapons.";
                msgStrings[11889] = "Holder acquires the Crest of Macuil, granting\n5% chance to raise Mt by 5 during magic attacks.";
                msgStrings[11890] = "Holder acquires the Crest of Seiros, granting\n20% chance to raise Mt by 5 with combat arts.";
                msgStrings[11891] = "Holder acquires the Crest of Dominic, granting\n5% chance to conserve uses of attack magic.";
                msgStrings[11892] = "Holder acquires the Crest of Fraldarius, granting\n10% chance to raise Mt by 5 with weapons.";
                msgStrings[11893] = "Holder acquires the Crest of Noa, granting\n5% chance to conserve uses of attack magic.";
                msgStrings[11894] = "Holder acquires the Crest of Cethleann, granting\n15% chance to raise Mt by 5 with recovery magic.";
                msgStrings[11895] = "Holder acquires the Crest of Daphnel, granting\n20% chance to raise Mt by 5 with combat arts.";
                msgStrings[11896] = "Holder acquires the Crest of Blaiddyd, granting\n5% chance of 2x combat art Atk and weapon uses.";
                msgStrings[11897] = "Holder acquires the Crest of Gloucester, granting\n5% chance to raise Mt by 5 during magic attacks.";
                msgStrings[11898] = "Holder acquires the Crest of Goneril, granting\n15% chance to prevent counters with combat arts.";
                msgStrings[11899] = "Holder acquires the Crest of Cichol, granting\n15% chance to prevent counters with combat arts.";
                msgStrings[11900] = "Holder acquires the Crest of Aubin, granting\n5% chance to prevent counters with weapons.";
                msgStrings[11901] = "Holder acquires the Crest of Gautier, granting\n20% chance to raise Mt by 5 with combat arts.";
                msgStrings[11902] = "Holder acquires the Crest of Indech, granting\n5% chance to strike twice with weapons.";
                msgStrings[11903] = "Holder acquires the Crest of the Beast, granting\n10% chance to raise Mt by 5 with weapons.";
                msgStrings[11904] = "Holder acquires the Crest of Charon, granting\n20% chance to raise Mt by 5 with combat arts.";
                msgStrings[11905] = "Holder acquires the Crest of Timotheos, granting\n5% chance to conserve uses of recovery magic.";
                msgStrings[11906] = "Holder acquires the Crest of Riegan, granting\n15% chance to heal 30% of combat art damage.";
                msgStrings[11907] = "Holder acquires the Crest of Chevalier, granting\n15% chance to heal 30% of combat art damage.";
                msgStrings[11908] = "Holder acquires the Crest of Lamine, granting\n5% chance to conserve uses of recovery magic.";
                msgStrings[16583] = "20% chance to prevent counters with weapons.";
                msgStrings[16584] = "20% chance to raise Mt by 5 during magic attacks.";
                msgStrings[16585] = "70% chance to raise Mt by 5 with combat arts.";
                msgStrings[16586] = "20% chance to conserve uses of attack magic.";
                msgStrings[16587] = "40% chance to raise Mt by 5 with weapons.";
                msgStrings[16588] = "20% chance to conserve uses of attack magic.";
                msgStrings[16589] = "50% chance to raise Mt by 5 with recovery magic.";
                msgStrings[16590] = "70% chance to raise Mt by 5 with combat arts.";
                msgStrings[16591] = "20% chance to heal 30% of combat art damage.";
                msgStrings[16592] = "20% chance to raise Mt by 5 during magic attacks.";
                msgStrings[16593] = "50% chance to prevent counters with combat arts.";
                msgStrings[16594] = "50% chance to prevent counters with combat arts.";
                msgStrings[16595] = "20% chance to prevent counters with weapons.";
                msgStrings[16596] = "70% chance to raise Mt by 5 with combat arts.";
                msgStrings[16597] = "20% chance to strike twice with weapons.";
                msgStrings[16598] = "40% chance to raise Mt by 5 with weapons.";
                msgStrings[16599] = "70% chance to raise Mt by 5 with combat arts.";
                msgStrings[16600] = "20% chance to conserve uses of recovery magic.";
                msgStrings[16601] = "50% chance to heal 30% of combat art damage.";
                msgStrings[16602] = "50% chance to heal 30% of combat art damage.";
                msgStrings[16603] = "20% chance to conserve uses of recovery magic.";
                msgStrings[16604] = "20% chance to heal 30% of damage dealt.\n5% chance to also raise Mt by 5 and stop counters.";
                msgStrings[16605] = "10% chance to prevent counters with weapons.";
                msgStrings[16606] = "10% chance to raise Mt by 5 during magic attacks.";
                msgStrings[16607] = "40% chance to raise Mt by 5 with combat arts.";
                msgStrings[16608] = "10% chance to conserve uses of attack magic.";
                msgStrings[16609] = "20% chance to raise Mt by 5 with weapons.";
                msgStrings[16610] = "10% chance to conserve uses of attack magic.";
                msgStrings[16611] = "30% chance to raise Mt by 5 with recovery magic.";
                msgStrings[16612] = "40% chance to raise Mt by 5 with combat arts.";
                msgStrings[16613] = "10% chance of 2x combat art Atk and weapon uses.";
                msgStrings[16614] = "10% chance to raise Mt by 5 during magic attacks.";
                msgStrings[16615] = "30% chance to prevent counters with combat arts.";
                msgStrings[16616] = "30% chance to prevent counters with combat arts.";
                msgStrings[16617] = "10% chance to prevent counters with weapons.";
                msgStrings[16618] = "40% chance to raise Mt by 5 with combat arts.";
                msgStrings[16619] = "10% chance to strike twice with weapons.";
                msgStrings[16620] = "20% chance to raise Mt by 5 with weapons.";
                msgStrings[16621] = "40% chance to raise Mt by 5 with combat arts.";
                msgStrings[16622] = "10% chance to conserve uses of recovery magic.";
                msgStrings[16623] = "30% chance to heal 30% of combat art damage.";
                msgStrings[16624] = "30% chance to heal 30% of combat art damage.";
                msgStrings[16625] = "10% chance to conserve uses of recovery magic.";
                msgStrings[16626] = "10% chance to heal 30% of damage dealt.\n2.5% chance to also raise Mt by 5 and stop counters.";

                string[] verbs = { "has", "possesses", "bears", "carries", "retains", "emits", "gives off" };
                string[] adjectives = { "the distinct", "a definite", "the unmistakable", "the recognizable", "a perceptible", "an apparent", "an obvious", "a noticeable", "the specific", "an evident", "the explicit", "the unambiguous" };
                string[] nouns = { "smell", "scent", "fragrance", "aroma", "odor" };
                for (int i = 2; i < 35; i++)
                    msgStrings[17339 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of " + inGameCharacterNames[i] + "...";
                msgStrings[17375] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                    " " + adjectives[rng.Next(0, adjectives.Length)] +
                    " " + nouns[rng.Next(0, nouns.Length)] + " of Rhea...";
                for (int i = 5; i < 35; i++)
                    msgStrings[17421 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of " + inGameCharacterNames[i] + "...";
                for (int i = 5; i < 35; i++)
                    msgStrings[17451 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of " + inGameCharacterNames[i] + "...";
                for (int i = 0; i < 2; i++)
                    msgStrings[17488 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Rhea...";
                for (int i = 2; i < 5; i++)
                    msgStrings[17511 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of " + inGameCharacterNames[i] + "...";
                for (int i = 2; i < 5; i++)
                    msgStrings[17514 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of " + inGameCharacterNames[i] + "...";
                for (int i = 0; i < 3; i++)
                    msgStrings[17528 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Jeritza...";
                for (int i = 0; i < 3; i++)
                    msgStrings[17531 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Anna...";
                for (int i = 0; i < 2; i++)
                    msgStrings[17539 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Yuri...";
                for (int i = 0; i < 2; i++)
                    msgStrings[17541 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Balthus...";
                for (int i = 0; i < 2; i++)
                    msgStrings[17543 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Constance...";
                for (int i = 0; i < 2; i++)
                    msgStrings[17545 + i] = "Hm... It " + verbs[rng.Next(0, verbs.Length)] +
                        " " + adjectives[rng.Next(0, adjectives.Length)] +
                        " " + nouns[rng.Next(0, nouns.Length)] + " of Hapi...";
                if (lobbyLoaded)
                {
                    string[] badSynonyms = { "Bad", "Substandard", "Poor", "Inferior", "Second-rate", "Second-class", "Unsatisfactory", "Inadequate",
                        "Unacceptable", "Deficient", "Imperfect", "Unpleasant", "Disagreeable", "Unwelcome", "Unfortunate", "Unfavourable", "Unlucky",
                        "Adverse", "Nasty", "Terrible", "Dreadful", "Awful", "Grim", "Distressing", "Regrettable", "Atrocious", "Cheap", "Crummy",
                        "Lousy", "Rough", "Sad", "Garbage", "Gross", "Abominable", "Cheesy", "Crappy", "Cruddy", "Defective", "Dissatisfactory",
                        "Erroneous", "Faulty", "Grody", "Icky", "Incorrect", "Not good", "Hurtful", "Wrong", "Disastrous", "Painful", "Grave",
                        "Discouraging", "Displeasing", "Troubling", "Unhappy" };
                    string[] goodSynonyms = { "Good", "Fine", "Quality", "Superior", "Satisfactory", "Acceptable", "Adequate", "Upright", "Upstanding",
                        "Exemplary", "Excellent", "Exceptional", "Favorable", "Great", "Marvelous", "Positive", "Satisfying", "Superb", "Valuable",
                        "Wonderful", "Choice", "Nice", "Pleasing", "Prime", "Sound", "Welcome", "Worthy", "Admirable", "Agreeable", "Commendable",
                        "Congenial", "First-class", "First-rate", "Gratifying", "Honorable", "Neat", "Precious", "Reputable", "Splendid", "Stupendous",
                        "Tip-top", "Respectable", "Innocent", "Right", "Charitable", "Estimable", "Ethical", "Pure", "Able", "Efficient", "Proper",
                        "Suitable", "Useful", "Qualified", "Advantageous", "Appropriate", "Beneficial", "Decent", "Fruitful", "Helpful", "Fitting",
                        "All right", "Apt", "Becoming", "Benignant", "Congruous", "Opportune", "Propitious", "Seemly", "Tolerable", "Wholesome",
                        "Flawless", "Perfect", "Safe", "Solid", "Friendly", "Benevolent", "Considerate", "Gracious", "Kindhearted", "Legitimate",
                        "Valid", "Genuine", "Polite", "Thoughtful", "Sufficient", "Worthwhile" };
                    for (int index = 0; index < 150; index++)
                    {
                        if ((index > 65 && index < 100) || index == 133 || index == 135 || index == 140 || index > 142)
                            continue;

                        long mod = index * teaTopicLen;
                        for (int i = 0; i < teaTopicLen; i++)
                            lobbyData[teaTopicStart + mod + i] = (byte)(index < 25 ? 0 : 1);
                        msgStrings[21687 + index] = (index < 25 ? badSynonyms[rng.Next(0, badSynonyms.Length)] : goodSynonyms[rng.Next(0, goodSynonyms.Length)]) + " topic...";
                        if (index >= 100)
                            msgStrings[21687 + index] = "Your specific smell...";
                    }
                    for (int index = 0; index < 392; index++)
                    {
                        long mod = index * teaResponseLen;
                        for (int i = 0; i < 10; i++)
                            lobbyData[teaResponseStart + mod + 4 + i] = (byte)(i < 7 ? 0 : 1);
                    }
                    msgStrings[21837] = "Insult";
                    msgStrings[21838] = "Complain";
                    msgStrings[21839] = "Ridicule";
                    msgStrings[21840] = "Offend";
                    msgStrings[21841] = "Ignore";
                    msgStrings[21842] = "Boast";
                    msgStrings[21843] = "Disturb";
                    msgStrings[21844] = "Support";
                    msgStrings[21845] = "Compliment";
                    msgStrings[21846] = "Empathize";
                }
            }
            if (scrLoaded && settings.changeScr && settings.qolText)
            {
                int[] rightAnswers = { 20118, 20121, 20127, 20131, 20133, 20138, 20142, 20146, 20151, 20153, 20157, 20163, 20167, 20169, 20173,
                    20177, 20183, 20185, 20190, 20194, 20199, 20201, 20205, 20209, 20214, 20219, 20221, 20226, 20229, 20234,
                    20237, 20243, 20245, 20250, 20255, 20258, 20261, 20267, 20269, 20275, 20279, 20281, 20287, 20289, 20294,
                    20299, 20301, 20306, 20310, 20314, 20318, 20322, 20326, 20330, 20335, 20339, 20347, 20350, 20353, 20358,
                    20362, 20365, 20369, 20373, 20377 };
                for (int i = 0; i < rightAnswers.Length; i++)
                    scrStrings[rightAnswers[i]] += "+";
            }
            if (msgLoaded && settings.changeMsg)
            {
                if (settings.baseText)
                {
                    msgf.setStrings(msgStrings, true);
                    msgData = msgf.getBytes();
                }
                if (settings.randText && !settings.randTextSource)
                {
                    TextBinFormatter tbf = new TextBinFormatter(msgData);
                    List<string> strings = tbf.getStrings(false);
                    stringShuffle(strings, settings);
                    tbf.setStrings(strings, false);
                    msgData = tbf.getBytes();
                }
            }
            if (scrLoaded && settings.changeScr)
            {
                if (settings.baseText)
                {
                    scrf.setStrings(scrStrings, true);
                    scrData = scrf.getBytes();
                }
                if (settings.randText && !settings.randTextSource)
                {
                    TextBinFormatter tbf = new TextBinFormatter(scrData);
                    List<string> strings = tbf.getStrings(false);
                    stringShuffle(strings, settings);
                    tbf.setStrings(strings, false);
                    scrData = tbf.getBytes();
                }
            }
            if (gwscrLoaded && settings.changeGwscr)
            {
                Randomizer.gwscrData = new byte[Randomizer.gwscrDataV.Length];
                Randomizer.gwscrDataV.CopyTo((Array)Randomizer.gwscrData, 0);
                if (settings.randText && !settings.randTextSource)
                {
                    TextBinFormatter tbf = new TextBinFormatter(gwscrData);
                    List<string> strings = tbf.getStrings(false);
                    stringShuffle(strings, settings);
                    tbf.setStrings(strings, false);
                    gwscrData = tbf.getBytes();
                }
            }
            if (tuscrLoaded && settings.changeTuscr)
            {
                Randomizer.tuscrData = new byte[Randomizer.tuscrDataV.Length];
                Randomizer.tuscrDataV.CopyTo((Array)Randomizer.tuscrData, 0);
                if (settings.randText && !settings.randTextSource)
                {
                    TextBinFormatter tbf = new TextBinFormatter(tuscrData);
                    List<string> strings = tbf.getStrings(false);
                    stringShuffle(strings, settings);
                    tbf.setStrings(strings, false);
                    tuscrData = tbf.getBytes();
                }
            }
            if (btlscrLoaded && settings.changeBtlscr)
            {
                Randomizer.btlscrData = new byte[Randomizer.btlscrDataV.Length];
                Randomizer.btlscrDataV.CopyTo((Array)Randomizer.btlscrData, 0);
                if (settings.randText && !settings.randTextSource)
                {
                    TextBinFormatter tbf = new TextBinFormatter(btlscrData);
                    List<string> strings = tbf.getStrings(false);
                    stringShuffle(strings, settings);
                    tbf.setStrings(strings, false);
                    btlscrData = tbf.getBytes();
                }
            }
            if (data1Loaded && settings.changeData1Text)
            {
                Randomizer.textSectionData = new byte[Randomizer.textSectionDataV.Length];
                Randomizer.textSectionDataV.CopyTo((Array)Randomizer.textSectionData, 0);
                if (settings.randText && !settings.randTextSource)
                {
                    Data1TextFormatter d1tf = new Data1TextFormatter(textSectionData);
                    List<string> strings = d1tf.getStrings(false);
                    stringShuffle(strings, settings);
                    d1tf.setStrings(strings, false);
                    textSectionData = d1tf.getBytes();
                }
            }
            if (settings.randText && settings.randTextSource)
            {
                List<TextFormatter> formatters = prepareFormatters(settings);
                List<string> strings = new List<string>();
                for (int i = 0; i < formatters.Count; i++)
                    strings.AddRange(formatters[i].getStrings(false));
                stringShuffle(strings, settings);
                for (int i = 0; i < formatters.Count; i++)
                    formatters[i].setStrings(strings, false);
                writeTextData(formatters, settings);
            }
            if (settings.baseText && personLoaded)
            {
                List<TextFormatter> formatters = prepareFormatters(settings);
                List<string> strings = new List<string>();
                for (int i = 0; i < formatters.Count; i++)
                    strings.AddRange(formatters[i].getStrings(false));
                for (int i = 0; i < inGameCharacterNames.Length; i++)
                    if (inGameCharacterNames[i] != null)
                        for (int j = 0; j < strings.Count; j++)
                            strings[j] = strings[j].Replace(inGameCharacterNames[i], "NameID" + i.ToString() + "←");
                for (int i = 0; i < inGameCharacterNames.Length; i++)
                    if (inGameCharacterNames[i] != null)
                        for (int j = 0; j < strings.Count; j++)
                            strings[j] = strings[j].Replace("NameID" + i.ToString() + "←", inGameCharacterNames[newAssetIDs[i]]);
                for (int i = 0; i < formatters.Count; i++)
                    formatters[i].setStrings(strings, false);
                writeTextData(formatters, settings);
            }
            if (data1Loaded)
            {
                Randomizer.baiSectionData = new byte[Randomizer.baiSectionDataV.Length];
                Randomizer.baiSectionDataV.CopyTo((Array)Randomizer.baiSectionData, 0);

                byte[] newMapClasses = new byte[100];
                for (int i = 0; i < newMapClasses.Length; i++)
                    newMapClasses[i] = (byte)i;

                if (classLoaded && settings.randMapClass && settings.mapGroupClass)
                {
                    if (settings.includeMonsterMapClass)
                    {
                        List<int> newMonsters = new List<int>();
                        newMonsters.AddRange(monsterClasses);
                        newMonsters.Shuffle();
                        for (int i = 0; i < monsterClasses.Count; i++)
                            newMapClasses[monsterClasses[i]] = (byte)newMonsters[i];
                    }

                    List<int> newBeg = new List<int>();
                    newBeg.AddRange(begClasses);
                    newBeg.Shuffle();
                    for (int i = 0; i < begClasses.Count; i++)
                        newMapClasses[begClasses[i]] = (byte)newBeg[i];

                    List<int> newInter = new List<int>();
                    newInter.AddRange(interClasses);
                    newInter.Shuffle();
                    for (int i = 0; i < interClasses.Count; i++)
                        newMapClasses[interClasses[i]] = (byte)newInter[i];

                    List<int> newAdv = new List<int>();
                    newAdv.AddRange(advClasses);
                    newAdv.Shuffle();
                    for (int i = 0; i < advClasses.Count; i++)
                        newMapClasses[advClasses[i]] = (byte)newAdv[i];

                    List<int> newMaster = new List<int>();
                    newMaster.AddRange(masterClasses);
                    newMaster.Shuffle();
                    for (int i = 0; i < masterClasses.Count; i++)
                        newMapClasses[masterClasses[i]] = (byte)newMaster[i];

                    List<int> newUni = new List<int>();
                    newUni.AddRange(uniClasses);
                    newUni.Shuffle();
                    for (int i = 0; i < uniClasses.Count; i++)
                        newMapClasses[uniClasses[i]] = (byte)newUni[i];
                }

                if (settings.randChestItem)
                    changelog += "\n\n\n---CHEST ITEMS---";

                for (int scenario = 0; scenario < baiOffsets.Length; scenario++)
                {
                    int baiStart = (int)(baiOffsets[scenario] - baiSectionOffset);
                    int headerLen = 24;

                    byte[] specialEntries = new byte[3];
                    specialEntries[0] = baiSectionData[baiStart + 4];
                    specialEntries[1] = baiSectionData[baiStart + 5];
                    specialEntries[2] = baiSectionData[baiStart + 6];

                    byte[] itemEntries = new byte[3];
                    itemEntries[0] = baiSectionData[baiStart + 7];
                    itemEntries[1] = baiSectionData[baiStart + 8];
                    itemEntries[2] = baiSectionData[baiStart + 9];

                    if (itemEntries[0] + itemEntries[1] + itemEntries[2] > 0)
                        changelog += "\n\n\t" + scenarioNames[scenario];

                    int[] routeStarts = new int[3];
                    routeStarts[0] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 12);
                    routeStarts[1] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 16);
                    routeStarts[2] = baiStart + headerLen + BitConverter.ToInt32(baiSectionData, baiStart + 20);

                    for (int route = 0; route < 3; route++)
                    {
                        int unitTableStart = routeStarts[route];
                        int specialTableStart = unitTableStart + baiUnitsLen * baiUnitEntries;
                        int itemTableStart = specialTableStart + baiSpecialsLen * specialEntries[route];

                        List<byte[]> genericEnemies = new List<byte[]>();
                        List<byte[]> occupiedPositions = new List<byte[]>();

                        byte[] minAllyPos = { 255, 255 };
                        byte[] maxAllyPos = { 0, 0 };

                        byte[] minEnemyPos = { 255, 255 };
                        byte[] maxEnemyPos = { 0, 0 };

                        int unitTotal = 0;
                        int enemyTotal = 0;
                        int allyTotal = 0;
                        for (int unit = 0; unit < baiUnitEntries; unit++)
                        {
                            int unitStart = unitTableStart + unit * baiUnitsLen;

                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            if (characterShort != 0)
                            {
                                unitTotal++;

                                occupiedPositions.Add(new byte[] { baiSectionData[unitStart + 25], baiSectionData[unitStart + 26] });

                                if (baiSectionData[unitStart + 29] == 0 || baiSectionData[unitStart + 29] == 2)
                                {
                                    minAllyPos[0] = Math.Min(minAllyPos[0], baiSectionData[unitStart + 25]);
                                    minAllyPos[1] = Math.Min(minAllyPos[1], baiSectionData[unitStart + 26]);
                                    maxAllyPos[0] = Math.Max(maxAllyPos[0], baiSectionData[unitStart + 25]);
                                    maxAllyPos[1] = Math.Max(maxAllyPos[1], baiSectionData[unitStart + 26]);

                                    if (baiSectionData[unitStart + 29] == 0)
                                        allyTotal++;
                                }

                                if (baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3)
                                {
                                    enemyTotal++;
                                    minEnemyPos[0] = Math.Min(minEnemyPos[0], baiSectionData[unitStart + 25]);
                                    minEnemyPos[1] = Math.Min(minEnemyPos[1], baiSectionData[unitStart + 26]);
                                    maxEnemyPos[0] = Math.Max(maxEnemyPos[0], baiSectionData[unitStart + 25]);
                                    maxEnemyPos[1] = Math.Max(maxEnemyPos[1], baiSectionData[unitStart + 26]);

                                    if (baiSectionData[unitStart + 33] == 3 && characterNames[characterShort - 1] == null)
                                    {
                                        byte[] unitData = new byte[baiUnitsLen];
                                        for (int i = 0; i < baiUnitsLen; i++)
                                            unitData[i] = baiSectionData[unitStart + i];
                                        genericEnemies.Add(unitData);
                                    }
                                }
                            }
                        }
                        for (int special = 0; special < specialEntries[route]; special++)
                        {
                            int specialStart = specialTableStart + special * baiSpecialsLen;
                            occupiedPositions.Add(new byte[] { baiSectionData[specialStart + 0], baiSectionData[specialStart + 1] });
                        }
                        for (int item = 0; item < itemEntries[route]; item++)
                        {
                            int itemStart = itemTableStart + item * baiItemsLen;
                            occupiedPositions.Add(new byte[] { baiSectionData[itemStart + 2], baiSectionData[itemStart + 3] });
                        }

                        int maxAllies = 36;
                        int extraAllies = 0;
                        if (settings.mapMaxAllies)
                            extraAllies = Math.Min(maxAllies - allyTotal, baiUnitEntries - unitTotal);

                        for (int i = 0; i < extraAllies; i++)
                        {
                            int unitStart = unitTableStart;
                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);

                            byte[] newUnitData = { 44, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                            byte[] newUnitPos = randPosition(minAllyPos, maxAllyPos, occupiedPositions);
                            newUnitData[25] = newUnitPos[0];
                            newUnitData[26] = newUnitPos[1];

                            while (characterShort != 0)
                            {
                                unitStart += baiUnitsLen;
                                characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            }

                            for (int j = 0; j < baiUnitsLen; j++)
                                baiSectionData[unitStart + j] = newUnitData[j]; // max deployment slots
                            occupiedPositions.Add(newUnitPos);
                            allyTotal++;
                            unitTotal++;
                        }

                        int extraEnemies = 0;
                        if (genericEnemies.Count > 0 && settings.mapExtraEnemies)
                            extraEnemies = Math.Min(enemyTotal * rng.Next(settings.mapExtraEnemiesMin, settings.mapExtraEnemiesMax + 1) / 100, baiUnitEntries - unitTotal);

                        for (int i = 0; i < extraEnemies; i++)
                        {
                            int unitStart = unitTableStart;
                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);

                            byte[] newUnitData = genericEnemies[rng.Next(0, genericEnemies.Count)];
                            byte[] newUnitPos = randPosition(minEnemyPos, maxEnemyPos, occupiedPositions);
                            newUnitData[25] = newUnitPos[0];
                            newUnitData[26] = newUnitPos[1];
                            newUnitData[30] = 0;

                            while (characterShort != 0)
                            {
                                unitStart += baiUnitsLen;
                                characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            }

                            for (int j = 0; j < baiUnitsLen; j++)
                                baiSectionData[unitStart + j] = newUnitData[j]; // additional enemies
                            occupiedPositions.Add(newUnitPos);
                            enemyTotal++;
                            unitTotal++;
                        }

                        for (int unit = 0; unit < baiUnitEntries; unit++)
                        {
                            int unitStart = unitTableStart + unit * baiUnitsLen;

                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            if (characterShort != 0)
                            {
                                bool ally = baiSectionData[unitStart + 29] == 0;
                                bool enemy = baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3;
                                bool npc = baiSectionData[unitStart + 29] == 2;
                                bool com = baiSectionData[unitStart + 33] == 0 && enemy;

                                int classId = baiSectionData[unitStart + 4] - 1;

                                if (classLoaded && settings.randMapClass && baiSectionData[unitStart + 4] != 0)
                                {
                                    bool monster = monsterClasses.Contains(classId);
                                    if ((!monster || settings.includeMonsterMapClass) && settings.mapIndividualClass)
                                    {
                                        if (monster)
                                            classId = (byte)monsterClasses[rng.Next(0, monsterClasses.Count)];
                                        if (begClasses.Contains(classId))
                                            classId = (byte)begClasses[rng.Next(0, begClasses.Count)];
                                        if (interClasses.Contains(classId))
                                            classId = (byte)interClasses[rng.Next(0, interClasses.Count)];
                                        if (advClasses.Contains(classId))
                                            classId = (byte)advClasses[rng.Next(0, advClasses.Count)];
                                        if (masterClasses.Contains(classId))
                                            classId = (byte)masterClasses[rng.Next(0, masterClasses.Count)];
                                        if (uniClasses.Contains(classId))
                                            classId = (byte)uniClasses[rng.Next(0, uniClasses.Count)];
                                    }

                                    baiSectionData[unitStart + 4] = (byte)(newMapClasses[classId] + 1); // class
                                    classId = baiSectionData[unitStart + 4] - 1;
                                }
                                int classTier = 0;
                                bool isMonster = false;
                                getUnitTier(characterShort - 1, ref classTier, ref isMonster);
                                if (classLoaded)
                                {
                                    if (begClasses.Contains(classId))
                                        classTier = 1;
                                    if (interClasses.Contains(classId))
                                        classTier = 2;
                                    if (advClasses.Contains(classId))
                                        classTier = 3;
                                    if (masterClasses.Contains(classId))
                                        classTier = 4;
                                    if (uniClasses.Contains(classId))
                                        classTier = 6;
                                }

                                if ((enemy || npc) && !isMonster)
                                {
                                    ushort[] baiInventory = new ushort[6];
                                    for (int i = 0; i < baiInventory.Length; i++)
                                        baiInventory[i] = BitConverter.ToUInt16(baiSectionData, unitStart + 6 + 2 * i);
                                    bool uniqueInventory = false;
                                    for (int i = 0; i < baiInventory.Length && !uniqueInventory; i++)
                                        uniqueInventory = baiInventory[i] != 0;

                                    if (settings.randMapInventory)
                                        uniqueInventory = p(settings.mapInventoryP) || (settings.mapInventoryForceCom && com);

                                    if (!uniqueInventory)
                                    {
                                        for (int i = 0; i < baiInventory.Length; i++)
                                            baiInventory[i] = 0;
                                        if (settings.randMapDrops)
                                        {
                                            baiSectionData[unitStart + 18] = 0;
                                            baiSectionData[unitStart + 19] = 0;
                                        }
                                    }
                                    else
                                    {
                                        List<ushort> newInventory = new List<ushort>();
                                        for (int i = 0; i < baiInventory.Length; i++)
                                            if (baiInventory[i] > 0)
                                                newInventory.Add((ushort)(baiInventory[i] - 1));

                                        for (int i = 0; i < baiInventory.Length; i++)
                                            baiInventory[i] = 0;

                                        if (settings.randMapWeapons && !(classId == -1 && settings.baseMapWeapons))
                                        {
                                            for (int i = 0; i < newInventory.Count; i++)
                                                if (findItemType(newInventory[i]) == 0)
                                                {
                                                    newInventory.Remove(newInventory[i]);
                                                    i--;
                                                }

                                            if (classLoaded && settings.baseMapWeapons)
                                            {
                                                List<int> physWeaponTypes = new List<int>();
                                                for (int i = 0; i < classWeaponTypes[classId].Count; i++)
                                                    if (classWeaponTypes[classId][i] < 5)
                                                        physWeaponTypes.Add(classWeaponTypes[classId][i]);

                                                int weaponPoolTier = 0;
                                                switch (classTier)
                                                {
                                                    case 0:
                                                        weaponPoolTier = 1;
                                                        break;
                                                    case 1:
                                                        weaponPoolTier = 2;
                                                        break;
                                                    case 2:
                                                        weaponPoolTier = 3;
                                                        break;
                                                    case 3:
                                                        weaponPoolTier = 4;
                                                        break;
                                                    case 4:
                                                    case 6:
                                                        weaponPoolTier = 5;
                                                        break;
                                                }

                                                List<int> weaponPool = new List<int>();
                                                for (int i = 0; i < physWeaponTypes.Count; i++)
                                                    for (int j = 0; j <= weaponPoolTier; j++)
                                                        weaponPool.AddRange(availableWeapons[physWeaponTypes[i]][j]);

                                                for (int i = 0; i < physWeaponTypes.Count; i++)
                                                    newInventory.Add((ushort)(weaponPool[rng.Next(0, weaponPool.Count)] + itemTypeIdOffsets[0]));
                                            }
                                            else
                                            {
                                                newInventory.Add((ushort)(obtainableWeapons[rng.Next(0, obtainableWeapons.Length)] + itemTypeIdOffsets[0]));
                                                if (p(30))
                                                    newInventory.Add((ushort)(obtainableWeapons[rng.Next(0, obtainableWeapons.Length)] + itemTypeIdOffsets[0]));
                                            }
                                        }

                                        if (settings.randMapEquipment)
                                        {
                                            for (int i = 0; i < newInventory.Count; i++)
                                                if (findItemType(newInventory[i]) == 1)
                                                {
                                                    newInventory.Remove(newInventory[i]);
                                                    i--;
                                                }

                                            if (p(settings.mapEquipmentP))
                                                newInventory.Add((ushort)(obtainableEquipment[rng.Next(0, obtainableEquipment.Length)] + itemTypeIdOffsets[1]));
                                        }

                                        if (settings.randMapItems)
                                        {
                                            for (int i = 0; i < newInventory.Count; i++)
                                                if (findItemType(newInventory[i]) == 2)
                                                {
                                                    newInventory.Remove(newInventory[i]);
                                                    i--;
                                                }

                                            if (p(settings.mapItemsP))
                                            {
                                                newInventory.Add((ushort)(obtainableItems[rng.Next(0, obtainableItems.Length)] + itemTypeIdOffsets[2]));
                                                if (p(50))
                                                {
                                                    newInventory.Add((ushort)(obtainableItems[rng.Next(0, obtainableItems.Length)] + itemTypeIdOffsets[2]));
                                                    if (p(30))
                                                        newInventory.Add((ushort)(obtainableItems[rng.Next(0, obtainableItems.Length)] + itemTypeIdOffsets[2]));
                                                }
                                            }
                                        }

                                        ushort drop = BitConverter.ToUInt16(baiSectionData, unitStart + 18);
                                        if (newInventory.Count == 0)
                                            drop = 0;
                                        else if (settings.randMapDrops)
                                        {
                                            drop = 0;

                                            if (p(settings.mapDropsP))
                                                drop = 2; // item drops
                                        }
                                        byte[] dropBytes = BitConverter.GetBytes(drop);
                                        baiSectionData[unitStart + 18] = dropBytes[0];
                                        baiSectionData[unitStart + 19] = dropBytes[1];

                                        newInventory.Shuffle();

                                        bool hasWeapon = false;
                                        for (int i = 0; i < newInventory.Count && !hasWeapon; i++)
                                            hasWeapon = findItemType(newInventory[i]) == 0;
                                        bool dropsItem = drop == 2;

                                        int itemSlot = hasWeapon || dropsItem ? 0 : 1;
                                        for (int i = 0; i < newInventory.Count && itemSlot < baiInventory.Length; i++)
                                        {
                                            baiInventory[itemSlot] = (ushort)(newInventory[i] + 1);
                                            itemSlot++;
                                        }
                                    }

                                    if (settings.randMapWeapons || settings.randMapEquipment || settings.randMapItems || settings.randMapDrops)
                                        for (int i = 0; i < baiInventory.Length; i++)
                                        {
                                            byte[] itemBytes = BitConverter.GetBytes(baiInventory[i]);
                                            baiSectionData[unitStart + 6 + 2 * i] = itemBytes[0]; // inventory
                                            baiSectionData[unitStart + 7 + 2 * i] = itemBytes[1];
                                        }
                                }

                                if ((enemy || npc) && settings.randMapAb)
                                {
                                    byte[] baiAbSet = new byte[5];

                                    bool uniqueAbSet = p(settings.mapAbP) || (settings.mapAbForceCom && com);

                                    if (uniqueAbSet)
                                    {
                                        List<int> abilityPool = new List<int>();

                                        if (classLoaded && settings.baseMapAb)
                                        {
                                            addMissingAbilities(ref abilityPool, genericAbilities);
                                            for (int i = 0; classId >= 0 && i < classWeaponTypes[classId].Count; i++)
                                                switch (classWeaponTypes[classId][i])
                                                {
                                                    case 0:
                                                        addMissingAbilities(ref abilityPool, swordAbilities);
                                                        break;
                                                    case 1:
                                                        addMissingAbilities(ref abilityPool, lanceAbilities);
                                                        break;
                                                    case 2:
                                                        addMissingAbilities(ref abilityPool, axeAbilities);
                                                        break;
                                                    case 3:
                                                        addMissingAbilities(ref abilityPool, bowAbilities);
                                                        break;
                                                    case 4:
                                                        addMissingAbilities(ref abilityPool, brawlAbilities);
                                                        break;
                                                    case 5:
                                                        addMissingAbilities(ref abilityPool, blackAbilities);
                                                        break;
                                                    case 6:
                                                        addMissingAbilities(ref abilityPool, faithAbilities);
                                                        break;
                                                    case 7:
                                                        addMissingAbilities(ref abilityPool, darkAbilities);
                                                        break;
                                                }
                                        }
                                        else
                                        {
                                            for (int i = 0; i < 252; i++)
                                                abilityPool.Add(i);
                                            for (int i = 0; i < badAbilities.Length; i++)
                                                abilityPool.Remove(badAbilities[i]);
                                        }

                                        int abCount = 0;

                                        switch (classTier)
                                        {
                                            case 0:
                                                abCount = rng.Next(0, 3);
                                                break;
                                            case 1:
                                                abCount = rng.Next(1, 4);
                                                break;
                                            case 2:
                                                abCount = rng.Next(2, 5);
                                                break;
                                            case 3:
                                                abCount = rng.Next(3, 6);
                                                break;
                                            case 4:
                                            case 6:
                                                abCount = 5;
                                                break;
                                        }

                                        for (int i = 0; i < abCount; i++)
                                            baiAbSet[i] = (byte)(abilityPool[rng.Next(0, abilityPool.Count)] + 1);
                                    }

                                    for (int i = 0; i < baiAbSet.Length; i++)
                                        baiSectionData[unitStart + 20 + i] = baiAbSet[i]; // abilities
                                }

                                if ((enemy || npc) && settings.randMapBattalionId && !isMonster)
                                {
                                    bool hasBattalion = baiSectionData[unitStart + 32] == 1;

                                    if (settings.randMapBattalion)
                                        hasBattalion = p(settings.mapBattalionP) || (settings.mapBattalionForceCom && com);

                                    if (!hasBattalion)
                                    {
                                        baiSectionData[unitStart + 32] = 0;
                                        baiSectionData[unitStart + 34] = 0;
                                    }
                                    else
                                    {
                                        int selectedBattalion = rng.Next(0, 200);
                                        while (battalionNames[selectedBattalion] == "")
                                            selectedBattalion = rng.Next(0, 200);
                                        baiSectionData[unitStart + 32] = 1;
                                        baiSectionData[unitStart + 34] = (byte)(selectedBattalion + 1); // battalion
                                        baiSectionData[unitStart + 35] = 5;
                                    }
                                }

                                if ((enemy || npc) && settings.randMapCa && !isMonster)
                                {
                                    if (p(settings.mapAbP) || (settings.mapAbForceCom && com))
                                    {
                                        if (classLoaded && settings.baseMapCa)
                                        {
                                            if (classId >= 0)
                                            {
                                                List<int> physWeaponTypes = new List<int>();
                                                for (int i = 0; i < classWeaponTypes[classId].Count; i++)
                                                    if (classWeaponTypes[classId][i] < 5)
                                                        physWeaponTypes.Add(classWeaponTypes[classId][i]);

                                                List<int> combatArtPool = new List<int>();
                                                for (int i = 0; i < physWeaponTypes.Count; i++)
                                                    combatArtPool.AddRange(availableArts[physWeaponTypes[i]]);

                                                if (combatArtPool.Count > 0)
                                                    baiSectionData[unitStart + 38] = (byte)(combatArtPool[rng.Next(0, combatArtPool.Count)] + 1); // combat art
                                            }
                                            else
                                                baiSectionData[unitStart + 38] = 0;
                                        }
                                        else
                                            baiSectionData[unitStart + 38] = (byte)(rng.Next(0, 80) + 1);
                                    }
                                    else
                                        baiSectionData[unitStart + 38] = 0;
                                }

                                if ((enemy || npc) && settings.randMapSpellId && !isMonster)
                                {
                                    bool hasSpells = baiSectionData[unitStart + 36] != 0 || baiSectionData[unitStart + 37] != 0;

                                    if (settings.randMapSpell)
                                        hasSpells = p(settings.mapSpellP) || (settings.mapSpellForceCom && com);

                                    baiSectionData[unitStart + 36] = 0;
                                    baiSectionData[unitStart + 37] = 0;

                                    if (hasSpells)
                                    {
                                        if (settings.baseMapSpell)
                                        {
                                            if (classId >= 0)
                                            {
                                                List<int> magWeaponTypes = new List<int>();
                                                for (int i = 0; i < classWeaponTypes[classId].Count; i++)
                                                    if (classWeaponTypes[classId][i] >= 5)
                                                        magWeaponTypes.Add(classWeaponTypes[classId][i]);

                                                int spellRank = 0;
                                                switch (classTier)
                                                {
                                                    case 0:
                                                        spellRank = 1;
                                                        break;
                                                    case 1:
                                                        spellRank = 2;
                                                        break;
                                                    case 2:
                                                        spellRank = 3;
                                                        break;
                                                    case 3:
                                                        spellRank = 4;
                                                        break;
                                                    case 4:
                                                    case 6:
                                                        spellRank = 5;
                                                        break;
                                                }

                                                if (magWeaponTypes.Count > 0)
                                                {
                                                    baiSectionData[unitStart + 36] = (byte)(getSpell(magWeaponTypes[rng.Next(0, magWeaponTypes.Count)], spellRank, false, true) + 1); // extra spells
                                                    if (p(30))
                                                        baiSectionData[unitStart + 37] = (byte)(getSpell(magWeaponTypes[rng.Next(0, magWeaponTypes.Count)], spellRank, false, true) + 1);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            baiSectionData[unitStart + 36] = (byte)(rng.Next(0, 38) + 1);
                                            if (p(30))
                                                baiSectionData[unitStart + 37] = (byte)(rng.Next(0, 38) + 1);
                                        }
                                    }
                                }

                                if (scenarioLoaded && settings.changeLv)
                                    baiSectionData[unitStart + 28] = (byte)(baiSectionData[unitStart + 28] * settings.lvMultiplier / 100);
                            }
                        }

                        List<int> randPosAllies = new List<int>();
                        List<int> randPosEnemies = new List<int>();

                        for (int unit = 0; unit < baiUnitEntries; unit++)
                        {
                            int unitStart = unitTableStart + unit * baiUnitsLen;

                            ushort characterShort = BitConverter.ToUInt16(baiSectionData, unitStart + 0);
                            if (characterShort != 0 && p(settings.randMapSpawnP))
                            {
                                bool ally = baiSectionData[unitStart + 29] == 0;
                                bool enemy = baiSectionData[unitStart + 29] == 1 || baiSectionData[unitStart + 29] == 3;
                                bool npc = baiSectionData[unitStart + 29] == 2;
                                bool com = baiSectionData[unitStart + 33] == 0 && enemy;

                                if (ally && settings.randAllyMapSpawn)
                                {
                                    randPosAllies.Add(unit);
                                    removePosition(occupiedPositions, new byte[] { baiSectionData[unitStart + 25], baiSectionData[unitStart + 26] });
                                }

                                if (npc && settings.randNpcMapSpawn)
                                {
                                    randPosAllies.Add(unit);
                                    removePosition(occupiedPositions, new byte[] { baiSectionData[unitStart + 25], baiSectionData[unitStart + 26] });
                                }

                                if (enemy && settings.randEnemyMapSpawn && (!com || settings.randComMapSpawn))
                                {
                                    randPosEnemies.Add(unit);
                                    removePosition(occupiedPositions, new byte[] { baiSectionData[unitStart + 25], baiSectionData[unitStart + 26] });
                                }
                            }
                        }

                        for (int unit = 0; unit < baiUnitEntries; unit++)
                        {
                            int unitStart = unitTableStart + unit * baiUnitsLen;

                            if (randPosAllies.Contains(unit))
                            {
                                byte[] newPos = randPosition(minAllyPos, maxAllyPos, occupiedPositions);
                                baiSectionData[unitStart + 25] = newPos[0];
                                baiSectionData[unitStart + 26] = newPos[1];
                                occupiedPositions.Add(newPos);
                            }

                            if (randPosEnemies.Contains(unit))
                            {
                                byte[] newPos = randPosition(minEnemyPos, maxEnemyPos, occupiedPositions);
                                baiSectionData[unitStart + 25] = newPos[0];
                                baiSectionData[unitStart + 26] = newPos[1];
                                occupiedPositions.Add(newPos);
                            }
                        }

                        for (int special = 0; special < specialEntries[route]; special++)
                        {
                            int specialStart = specialTableStart + special * baiSpecialsLen;
                            // Nothing worth doing here, it seems...
                        }

                        for (int item = 0; item < itemEntries[route]; item++)
                        {
                            int itemStart = itemTableStart + item * baiItemsLen;
                            
                            if (settings.randChestItem)
                            {
                                ushort itemShort = (ushort)(BitConverter.ToUInt16(baiSectionData, itemStart + 0) - 1);
                                int itemType = findItemType(itemShort);

                                if (settings.randChestItemType && p(settings.randChestItemTypeP))
                                    itemType = rng.Next(0, 5);
                                ushort baiItemShort = (ushort)(randSameTypeItem(itemType) + 1);

                                byte[] itemBytes = BitConverter.GetBytes(baiItemShort);
                                baiSectionData[itemStart + 0] = itemBytes[0];
                                baiSectionData[itemStart + 1] = itemBytes[1];

                                changelog += "\nItem " + (item + 1) + " on route " + (route + 1) + ":\t" + getGeneralItemName(baiItemShort - 1);
                            }
                        }
                    }
                }
            }

            if (scenarioLoaded)
            {
                Randomizer.scenarioData = new byte[Randomizer.scenarioDataV.Length];
                Randomizer.scenarioDataV.CopyTo((Array)Randomizer.scenarioData, 0);
            }
            if (growthdataLoaded)
            {
                Randomizer.growthdataData = new byte[Randomizer.growthdataDataV.Length];
                Randomizer.growthdataDataV.CopyTo((Array)Randomizer.growthdataData, 0);
            }
            if (scenarioLoaded && growthdataLoaded && settings.amplifyMaddening)
            {
                byte[][] expMultipliers = new byte[3][];
                for (int i = 0; i < expMultipliers.Length; i++)
                {
                    expMultipliers[i] = new byte[41];
                    for (int j = 0; j < expMultipliers[i].Length; j++)
                        expMultipliers[i][j] = growthdataData[expStart + j * expLen + i];
                }
                for (int i = 0; i < expMultipliers[2].Length; i++)
                    expMultipliers[2][i] = (byte)Math.Round(Math.Pow(Math.E, (Math.Log(expMultipliers[0][i]) - 3 * Math.Log(expMultipliers[1][i]) + 3 * Math.Log(expMultipliers[2][i])) * settings.amplifyMaddeningAmount / 100 + Math.Log(expMultipliers[2][i]) * (100 - settings.amplifyMaddeningAmount) / 100));
                Array.Sort(expMultipliers[2]);
                Array.Reverse(expMultipliers[2]);
                for (int i = 0; i < expMultipliers[2].Length; i++)
                    growthdataData[expStart + i * expLen + 2] = expMultipliers[2][i];

                byte[][] lvMultipliers = new byte[3][];
                for (int i = 0; i < lvMultipliers.Length; i++)
                {
                    lvMultipliers[i] = new byte[100];
                    for (int j = 0; j < lvMultipliers[i].Length; j++)
                        lvMultipliers[i][j] = scenarioData[scenarioStart + j * scenarioLen + 33 + i];
                }
                for (int i = 0; i < lvMultipliers[2].Length; i++)
                {
                    lvMultipliers[2][i] = (byte)Math.Round((lvMultipliers[0][i] - 3 * lvMultipliers[1][i] + 3 * lvMultipliers[2][i]) * settings.amplifyMaddeningAmount / 100 + lvMultipliers[2][i] * (100 - settings.amplifyMaddeningAmount) / 100);
                    scenarioData[scenarioStart + i * scenarioLen + 35] = lvMultipliers[2][i];
                }
            }
            if (scenarioLoaded && settings.ensureLowLvEarly)
            {
                byte[] firstBattleLvs = new byte[3];
                for (int i = 0; i < firstBattleLvs.Length; i++)
                    firstBattleLvs[i] = scenarioData[scenarioStart + 33 + i];
                for (int index = 0; index < 100; index++)
                {
                    long scenarioMod = index * scenarioLen;
                    for (int i = 0; i < firstBattleLvs.Length; i++)
                        scenarioData[scenarioStart + scenarioMod + 33 + i] = (byte)Math.Max(1, scenarioData[scenarioStart + scenarioMod + 33 + i] + 1 - firstBattleLvs[i]);
                }
            }
            if (scenarioLoaded && settings.changeLv)
                for (int index = 0; index < 100; index++)
                {
                    long scenarioMod = index * scenarioLen;
                    scenarioData[scenarioStart + scenarioMod + 28] = (byte)Math.Round(Math.Max(1, Math.Min(99, scenarioData[scenarioStart + scenarioMod + 28] * settings.lvMultiplier / 100)));
                    scenarioData[scenarioStart + scenarioMod + 33] = (byte)Math.Round(Math.Max(1, Math.Min(99, scenarioData[scenarioStart + scenarioMod + 33] * settings.lvMultiplier / 100)));
                    scenarioData[scenarioStart + scenarioMod + 34] = (byte)Math.Round(Math.Max(1, Math.Min(99, scenarioData[scenarioStart + scenarioMod + 34] * settings.lvMultiplier / 100)));
                    scenarioData[scenarioStart + scenarioMod + 35] = (byte)Math.Round(Math.Max(1, Math.Min(99, scenarioData[scenarioStart + scenarioMod + 35] * settings.lvMultiplier / 100)));
                }

            changelog += "\n\n\n---RANDOMIZATION SETTINGS---";
            changelog += "\n\n" + ObjectDumper.Dump(settings, 0);

            changelog += "\n\nTotal amount of random numbers generated during randomization: " + rng.GetRandomNumberCount();
            changelog += "\n\nEND";
        }

        private static List<TextFormatter> prepareFormatters(Settings settings)
        {
            List<TextFormatter> formatters = new List<TextFormatter>();
            if (settings.changeMsg)
                formatters.Add(new TextBinFormatter(msgData));
            if (settings.changeScr)
                formatters.Add(new TextBinFormatter(scrData));
            if (settings.changeGwscr)
                formatters.Add(new TextBinFormatter(gwscrData));
            if (settings.changeTuscr)
                formatters.Add(new TextBinFormatter(tuscrData));
            if (settings.changeBtlscr)
                formatters.Add(new TextBinFormatter(btlscrData));
            if (settings.changeData1Text)
                formatters.Add(new Data1TextFormatter(textSectionData));
            return formatters;
        }

        private static void writeTextData(List<TextFormatter> formatters, Settings settings)
        {
            if (settings.changeMsg)
            {
                msgData = formatters[0].getBytes();
                formatters.RemoveAt(0);
            }
            if (settings.changeScr)
            {
                scrData = formatters[0].getBytes();
                formatters.RemoveAt(0);
            }
            if (settings.changeGwscr)
            {
                gwscrData = formatters[0].getBytes();
                formatters.RemoveAt(0);
            }
            if (settings.changeTuscr)
            {
                tuscrData = formatters[0].getBytes();
                formatters.RemoveAt(0);
            }
            if (settings.changeBtlscr)
            {
                btlscrData = formatters[0].getBytes();
                formatters.RemoveAt(0);
            }
            if (settings.changeData1Text)
            {
                textSectionData = formatters[0].getBytes();
                formatters.RemoveAt(0);
            }
        }

        private static void stringShuffle(List<string> strings, Settings settings)
        {
            if (!settings.preserveStringLength)
            {
                strings.Shuffle();
                return;
            }

            List<string>[] lists = new List<string>[10];
            for (int i = 0; i < lists.Length; i++)
                lists[i] = new List<string>();
            List<int>[] posistions = new List<int>[10];
            for (int i = 0; i < posistions.Length; i++)
                posistions[i] = new List<int>();
            for (int i = 0; i < strings.Count; i++)
            {
                int targetList = 0;
                int newLines = strings[i].Length - strings[i].Replace("\n", "").Length;
                if (newLines < 1)
                {
                    if (strings[i].Length < 3)
                        targetList = 0;
                    else if (strings[i].Length < 8)
                        targetList = 1;
                    else if (strings[i].Length < 21)
                        targetList = 2;
                    else if (strings[i].Length < 55)
                        targetList = 3;
                    else
                        targetList = 4;
                }
                else if (newLines < 3)
                    targetList = 5;
                else if (newLines < 8)
                    targetList = 6;
                else if (newLines < 21)
                    targetList = 7;
                else if (newLines < 55)
                    targetList = 8;
                else
                    targetList = 9;
                lists[targetList].Add(strings[i]);
                posistions[targetList].Add(i);
            }
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i].Shuffle();
                for (int j = 0; j < lists[i].Count; j++)
                    strings[posistions[i][j]] = lists[i][j];
            }
        }

        private static int randCrit(double critP, int maxCrit)
        {
            List<int> critPool = new List<int>();
            if (critP > 50)
            {
                for (int i = maxCrit; i > 0; i -= 5)
                    critPool.Add(i);
                int poolSize = (int)Math.Round(Math.Max(100 * critPool.Count / critP, 1));
                while (critPool.Count < poolSize)
                    critPool.Add(0);
            }
            if (critP > 0)
            {
                critPool.Add(maxCrit);
                for (int i = maxCrit - 5; i >= 0; i -= 5)
                {
                    int poolSize = (int)Math.Round(100 * critPool.Count / critP);
                    while (critPool.Count < poolSize)
                    {
                        critPool.Add(i);
                        if (critPool.Count > 1000000)
                        {
                            poolSize--;
                            critPool.RemoveAt(rng.Next(0, critPool.Count));
                        }
                    }
                }
            }
            else
                critPool.Add(0);
            return critPool[rng.Next(0, critPool.Count)];
        }

        private static void removePosition(List<byte[]> list, byte[] pos)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i][0] == pos[0] && list[i][1] == pos[1])
                {
                    list.RemoveAt(i);
                    i--;
                }
        }

        private static byte[] randPosition(byte[] minPos, byte[] maxPos, List<byte[]> occupiedPositions)
        {
            bool mapFull = true;
            while (mapFull)
            {
                for (int i = minPos[0]; i <= maxPos[0] && mapFull; i++)
                    for (int j = minPos[1]; j <= maxPos[1] && mapFull; j++)
                    {
                        bool posFound = false;
                        for (int k = 0; k < occupiedPositions.Count && !posFound; k++)
                            if (occupiedPositions[k][0] == i && occupiedPositions[k][1] == j)
                                posFound = true;

                        mapFull = posFound;
                    }
                if (mapFull)
                {
                    minPos[0] = (byte)Math.Max(0, minPos[0] - 1);
                    minPos[1] = (byte)Math.Max(0, minPos[1] - 1);
                    maxPos[0] = (byte)Math.Min(255, maxPos[0] + 1);
                    maxPos[1] = (byte)Math.Min(255, maxPos[1] + 1);
                }
            }

            byte[] newPos = { 0, 0 };
            bool validPosFound = false;

            while (!validPosFound)
            {
                newPos[0] = (byte)rng.Next(minPos[0], maxPos[0] + 1);
                newPos[1] = (byte)rng.Next(minPos[1], maxPos[1] + 1);

                validPosFound = true;
                for (int i = 0; i < occupiedPositions.Count && validPosFound; i++)
                    if (newPos[0] == occupiedPositions[i][0] && newPos[1] == occupiedPositions[i][1])
                        validPosFound = false;
            }

            return newPos;
        }

        private static string getGambitAoeName(int gambitAoeId)
        {
            string[] gambitAoeNames = { "None", "1 Tile Radius", "2 Tile Forward Radius", "1x2 Box", "",
                "2 Tile Radius", "1x4 Box", "3x1 Box", "5x2 Box", "",
                "", "", "3x2 Box", "1x3 Box", "Infinite" };
            return gambitAoeNames[gambitAoeId];
        }

        private static string getGambitExtraEffectName(int gambitExtraEffectId)
        {
            string[] gambitExtraEffectNames = { "None", "Shove", "Draw Back", "Swap", "Reposition" };
            return gambitExtraEffectNames[gambitExtraEffectId];
        }

        private static string getStatueName(int statueId)
        {
            string[] statues = { "Saint Cethleann Statue", "Saint Cichol Statue", "Saint Macuil Statue", "Saint Indech Statue" };
            return statues[statueId];
        }

        private static string getFishRarityName(int fishRarityId)
        {
            string[] fishRarities = { "Cyan Fish", "Purple Fish", "Gold Fish", "Blue Fish", "Rainbow Fish", "Red Fish" };
            return fishRarities[fishRarityId];
        }

        private static string getGeneralItemName(int generalItemId)
        {
            int itemType = findItemType(generalItemId);
            return generalItemNames[itemType][generalItemId - itemTypeIdOffsets[itemType]];
        }

        private static int randLocalItem(Settings settings, int localItemId, int itemType)
        {
            return randGeneralItem(settings, localItemId, itemType, true) - itemTypeIdOffsets[itemType];
        }

        private static int randGeneralItem(Settings settings, int generalItemId)
        {
            int itemType = findItemType(generalItemId);
            return randGeneralItem(settings, generalItemId - itemTypeIdOffsets[itemType], itemType, false);
        }

        private static int findItemType(int generalItemId)
        {
            int itemType = 0;
            while (itemType + 1 < itemTypeIdOffsets.Length && generalItemId >= itemTypeIdOffsets[itemType + 1])
                itemType++;
            return itemType;
        }

        private static int randGeneralItem(Settings settings, int localItem, int itemType, bool lockType)
        {
            if (settings.sameFunctionItems)
            {
                int itemFunction = findItemFunction(localItem, itemType);
                int newItem = itemFunctionGroups[itemFunction][rng.Next(0, itemFunctionGroups[itemFunction].Length)];
                return newItem + itemTypeIdOffsets[itemType];
            }
            else if (settings.sameTypeItems)
            {
                return randSameTypeItem(itemType);
            }
            else if (settings.randTypeItems)
            {
                if (p(settings.randTypeItemP) && !lockType)
                    itemType = rng.Next(0, 5);
                return randSameTypeItem(itemType);
            }
            else
                throw new Exception();
        }

        private static int findItemFunction(int startItem, int itemType)
        {
            int functionGroup = 0;
            switch (itemType)
            {
                case 0:
                    functionGroup = 0;
                    break;
                case 1:
                    functionGroup = 5;
                    break;
                case 2:
                    functionGroup = 9;
                    break;
                case 3:
                    functionGroup = 15;
                    break;
                case 4:
                    functionGroup = 22;
                    break;
                default:
                    throw new Exception();
            }

            while (!itemFunctionGroups[functionGroup].Contains(startItem))
                functionGroup++;

            return functionGroup;
        }

        private static int randSameTypeItem(int itemType)
        {
            int newItem = 0;
            switch (itemType)
            {
                case 0:
                    newItem = obtainableWeapons[rng.Next(0, obtainableWeapons.Length)];
                    break;
                case 1:
                    newItem = obtainableEquipment[rng.Next(0, obtainableEquipment.Length)];
                    break;
                case 2:
                    newItem = obtainableItems[rng.Next(0, obtainableItems.Length)];
                    break;
                case 3:
                    newItem = obtainableMiscItems[rng.Next(0, obtainableMiscItems.Length)];
                    break;
                case 4:
                    newItem = obtainableGifts[rng.Next(0, obtainableGifts.Length)];
                    break;
                default:
                    throw new Exception();
            }
            return newItem + itemTypeIdOffsets[itemType];
        }

        private static void fixGenders()
        {
            List<int[]> youngMan = new List<int[]>();
            List<int[]> youngWoman = new List<int[]>();
            List<int[]> adultMan = new List<int[]>();
            List<int[]> adultWoman = new List<int[]>();
            List<int[]> oldMan = new List<int[]>();
            youngMan.Add(new int[1] { 0 });
            youngWoman.Add(new int[1] { 1 });
            youngWoman.Add(new int[3] { 2, 99, 643 });
            youngMan.Add(new int[2] { 3, 644 });
            youngMan.Add(new int[2] { 4, 645 });
            youngMan.Add(new int[1] { 5 });
            youngMan.Add(new int[1] { 6 });
            youngMan.Add(new int[1] { 7 });
            youngMan.Add(new int[1] { 8 });
            youngWoman.Add(new int[1] { 9 });
            youngWoman.Add(new int[1] { 10 });
            youngWoman.Add(new int[1] { 11 });
            youngMan.Add(new int[1] { 12 });
            youngMan.Add(new int[1] { 13 });
            youngMan.Add(new int[1] { 14 });
            youngMan.Add(new int[1] { 15 });
            youngWoman.Add(new int[1] { 16 });
            youngWoman.Add(new int[1] { 17 });
            youngWoman.Add(new int[1] { 18 });
            youngMan.Add(new int[1] { 19 });
            youngMan.Add(new int[1] { 20 });
            youngMan.Add(new int[1] { 21 });
            youngWoman.Add(new int[1] { 22 });
            youngWoman.Add(new int[1] { 23 });
            youngWoman.Add(new int[1] { 24 });
            youngWoman.Add(new int[1] { 25 });
            adultMan.Add(new int[1] { 26 });
            youngWoman.Add(new int[1] { 27 });
            oldMan.Add(new int[1] { 28 });
            adultWoman.Add(new int[1] { 29 });
            oldMan.Add(new int[2] { 30, 86 });
            adultMan.Add(new int[1] { 31 });
            adultWoman.Add(new int[1] { 32 });
            adultWoman.Add(new int[1] { 33 });
            youngMan.Add(new int[1] { 34 });
            adultMan.Add(new int[1] { 35 });
            adultWoman.Add(new int[1] { 36 });
            youngWoman.Add(new int[3] { 37, 679, 1005 });
            youngWoman.Add(new int[1] { 38 });
            oldMan.Add(new int[1] { 39 });
            adultMan.Add(new int[1] { 40 });
            adultWoman.Add(new int[1] { 41 });
            adultMan.Add(new int[1] { 42 });
            adultMan.Add(new int[1] { 43 });
            oldMan.Add(new int[1] { 44 });
            adultMan.Add(new int[1] { 45 });
            adultMan.Add(new int[1] { 46 });
            youngWoman.Add(new int[2] { 47, 98 });
            adultMan.Add(new int[1] { 49 });
            adultMan.Add(new int[1] { 50 });
            adultWoman.Add(new int[1] { 51 });
            adultMan.Add(new int[2] { 52, 565 });
            youngWoman.Add(new int[1] { 53 });
            adultMan.Add(new int[1] { 54 });
            oldMan.Add(new int[1] { 55 });
            oldMan.Add(new int[1] { 56 });
            adultWoman.Add(new int[1] { 58 });
            youngMan.Add(new int[1] { 70 });
            youngWoman.Add(new int[1] { 71 });
            oldMan.Add(new int[1] { 72 });
            oldMan.Add(new int[2] { 73, 559 });
            youngWoman.Add(new int[1] { 74 });
            adultMan.Add(new int[1] { 75 });
            adultMan.Add(new int[1] { 80 });
            adultWoman.Add(new int[1] { 81 });
            oldMan.Add(new int[1] { 82 });
            adultMan.Add(new int[1] { 83 });
            adultMan.Add(new int[2] { 84, 85 });
            adultWoman.Add(new int[1] { 220 });
            youngWoman.Add(new int[1] { 646 });
            adultMan.Add(new int[1] { 647 });
            adultWoman.Add(new int[1] { 681 });
            youngMan.Add(new int[1] { 1040 });
            adultMan.Add(new int[1] { 1041 });
            youngWoman.Add(new int[1] { 1042 });
            youngWoman.Add(new int[1] { 1043 });
            adultMan.Add(new int[3] { 1044, 167, 1168 });
            adultMan.Add(new int[1] { 1045 });
            adultWoman.Add(new int[3] { 1046, 48, 1038 });

            List<int[]> men = new List<int[]>();
            men.AddRange(youngMan);
            men.AddRange(adultMan);
            men.AddRange(oldMan);

            List<int[]> women = new List<int[]>();
            women.AddRange(youngWoman);
            women.AddRange(adultWoman);

            List<int[]> young = new List<int[]>();
            young.AddRange(youngMan);
            young.AddRange(youngWoman);

            List<int[]> adult = new List<int[]>();
            adult.AddRange(adultMan);
            adult.AddRange(adultWoman);

            List<int[]> all = new List<int[]>();
            all.AddRange(youngMan);
            all.AddRange(youngWoman);
            all.AddRange(adultMan);
            all.AddRange(adultWoman);
            all.AddRange(oldMan);


            List<int[]> numArrayList = new List<int[]>((IEnumerable<int[]>)women);
            foreach (int[] charIndexes in women)
            {
                foreach (int charIndex in charIndexes)
                {
                    Randomizer.personDataV[Randomizer.charBlockStart + (long)(charIndex * 80) + 38L] = (byte)1;
                }
            }
            List<int[]> numArrayList2 = new List<int[]>((IEnumerable<int[]>)men);
            foreach (int[] numArray in numArrayList2)
            {
                foreach (int num in numArray)
                {
                    Randomizer.personDataV[Randomizer.charBlockStart + (long)(num * 80) + 38L] = (byte)0;
                }
            }
        }

        private static int goodRng(int min, int max)
        {
            return rng.Next((2 * min + max) / 3, max + 1);
        }

        private static double doubleRng(double min, double max)
        {
            return min + (max - min) * rng.NextDouble();
        }

        private static int normalize(int target, int min, int max)
        {
            if (min > target)
                return min;
            if (max < target)
                return max;
            return target;
        }

        public static bool p(double percent)
        {
            return rng.NextDouble() < percent / 100;
        }

        private static int advancedRng(int target, bool binomial, bool linear, int linearDev, bool proportional, double proportionalDev, bool exponential, double exponentialDev, int roundIncrement)
        {
            if (binomial)
                return roundTo(binomialRng(target), roundIncrement);
            if (linear)
                return roundTo(linearRng(target, linearDev), roundIncrement);
            if (proportional)
                return roundTo(proportionalRng(target, proportionalDev), roundIncrement);
            if (exponential)
                return roundTo(exponentialRng(target, exponentialDev), roundIncrement);
            else
                throw new Exception();
        }

        private static int roundTo(int target, int roundIncrement)
        {
            return (int)Math.Round(target / (double)roundIncrement) * roundIncrement;
        }

        private static int linearRng(int target, int deviation)
        {
            return rng.Next(target - deviation, target + deviation + 1);
        }

        private static int proportionalRng(int target, double deviation)
        {
            return rng.Next((int)(target * (1 - deviation)), (int)(target * (1 + deviation) + 1));
        }

        private static int exponentialRng(int target, double deviation)
        {
            return (int)Math.Round(target * Math.Pow(deviation, 2 * rng.NextDouble() - 1));
        }

        private static int binomialRng(int target)
        {
            return binomialRng(target, 100);
        }
        private static int binomialRng(int target, int n)
        {
            int rnd = 0;
            while (target >= n)
            {
                rnd += n;
                target -= n;
            }
            for (int i = 0; i < n; i++)
                if (rng.Next(0, n) < target)
                    rnd++;
            return rnd;
        }

        private static string getGenderName(int id)
        {
            String[] genderNames = { "Male", "Female", "None" };
            return genderNames[id];
        }

        private static string getTurretName(int id)
        {
            String[] turretNames = { "Onager", "Ballista", "Fire Orb" };
            return turretNames[id];
        }

        private static string getStatName(int stat)
        {
            string[] statNames = { "Str", "Mag", "Dex", "Spd", "Lck", "Def", "Res", "Mv", "Cha" };
            return statNames[stat];
        }

        private static string getRankName(int i)
        {
            string[] rankNames = { "E", "E+", "D", "D+", "C", "C+", "B", "B+", "A", "A+", "S", "S+" };
            return rankNames[i];
        }

        private static string getSkillName(int i)
        {
            string[] skillNames = { "Sword",
                "Lance", "Axe", "Bow",
                "Brawl", "Reason", "Faith",
                "Authority", "Heavy Armor",
                "Riding", "Flying" };
            return skillNames[i];
        }

        private static string getMovementType(int id)
        {
            string[] movementTypes = { "Normal", "Heavy Armor", "Cavalry", "Heavy Armor Cavalry", "Caster", "Thief", "Flying", "Monster", "Monster", "Monster" };
            return movementTypes[id];
        }

        private static string getClassTyping(int i)
        {
            string[] ClassTypingNames = { "Infantry", "Heavy Armor", "Cavalry", "Flying", "Dragon", "Monster", "Reserve", "Reserve" };
            return ClassTypingNames[i];
        }

        public static int toGoalID(int[] skills)
        {
            if (skills[0] > skills[1])
            {
                int temp = skills[0];
                skills[0] = skills[1];
                skills[1] = temp;
            }

            int[] startPoints = { 0, 10, 19, 27, 34, 40, 45, 49, 52, 54, 55 };
            int goalID = startPoints[skills[0]];
            goalID += skills[1] - skills[0] - 1;

            return goalID;
        }

        public static byte toByte(int[] bits)
        {
            byte sum = 0;
            for (int i = 0; i < bits.Length; i++)
                if (bits[i] == 1)
                    sum += (byte)Math.Pow(2, i);

            return sum;
        }

        public static int[] toBits(byte b)
        {
            int[] bits = new int[8];
            for (int i = 0; i < 8; i++)
            {
                int selector = 7 - i;
                if (b >= (byte)Math.Pow(2, selector))
                {
                    bits[selector] = 1;
                    b -= (byte)Math.Pow(2, selector);
                }
            }
            return bits;
        }

        public static void addMissingAbilities(ref List<int> abilities, int[] newAbilities)
        {
            for (int i = 0; i < newAbilities.Length; i++)
                if (!abilities.Contains(newAbilities[i]))
                    abilities.Add(newAbilities[i]);
        }

        public static int getBestFittingClass(int classTier, int[] charProfs, List<int[][]> classCertReqs)
        {
            List<int[][]> eligibleClasses = new List<int[][]>();
            List<int> classScores = new List<int>();
            List<int> bestFitsInEligibleClasses = new List<int>();
            for (int clID = 0; clID < classCertReqs.Count; clID++)
                if (classCertReqs[clID][0][0] == classTier && classCertReqs[clID][2][0] == 1)
                    eligibleClasses.Add(new int[][] { new int[] { clID }, classCertReqs[clID][1] });
            for (int c = 0; c < eligibleClasses.Count; c++)
            {
                double score = 0.0;
                for (int skill = 0; skill < eligibleClasses[c][1].Length; skill++)
                    score += (charProfs[skill] * eligibleClasses[c][1][skill] / eligibleClasses[c][1].Average());
                classScores.Add((int)score);
            }
            for (int c = 0; c < classScores.Count; c++)
                if (classScores[c] == classScores.Max())
                    bestFitsInEligibleClasses.Add(c);
            int classOut = eligibleClasses[bestFitsInEligibleClasses[rng.Next(0, bestFitsInEligibleClasses.Count)]][0][0];
            return classOut;
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void getUnitTier(int index, ref int classTierOut, ref bool monsterOut)
        {
            if ((index >= 160 && index <= 163) || index == 191 || (index >= 200 && index <= 232))
                monsterOut = true;

            else if (index <= 25 || index == 34 || index == 37 || index == 48 || (index >= 53 && index <= 55) || index == 57 || (index >= 59 && index <= 85) || (index >= 87 && index <= 97)
                || index == 110 || index == 111 || index == 136 || index == 138 || (index >= 144 & index <= 148) || index == 152 || (index >= 154 && index <= 158) || index == 170 ||
                (index >= 195 && index <= 199) || (index >= 233 && index <= 280) || (index >= 290 && index <= 299) || index == 303 || (index >= 347 && index <= 350) || index == 392 ||
                index == 395 || (index >= 397 && index <= 399) || (index >= 402 && index <= 404) || (index >= 412 && index <= 419) || index == 437 || (index >= 463 && index <= 467) ||
                index == 469 || index == 477 || (index >= 481 && index <= 485) || index == 487 || (index >= 495 && index <= 498) || index == 500 || index == 501 || index == 512 ||
                (index >= 515 && index <= 544) || (index >= 547 && index <= 551) || index == 555 || index == 556 || index == 559 || index == 565 || index == 568 || index == 571 ||
                index == 579 || index == 580 || index == 582 || index == 584 || index == 592 || index == 596 || index == 598 || index == 600 || (index >= 605 && index <= 614) ||
                index == 619 || (index >= 621 && index <= 627) || (index >= 629 && index <= 639) || (index >= 641 && index <= 646) || index == 649 || index == 656 ||
                (index >= 658 && index <= 661) || index == 665 || (index >= 669 && index <= 681) || index == 687 || (index >= 689 && index <= 692) || index == 699 ||
                (index >= 705 && index <= 716) || (index >= 729 && index <= 732) || (index >= 738 && index <= 749) || (index >= 762 && index <= 765) || index == 772 || index == 773 ||
                (index >= 776 && index <= 778) || index == 791 || index == 793 || index == 795 || index == 796 || index == 798 || (index >= 809 && index <= 811) || index == 813 ||
                index == 819 || index == 823 || index == 825 || index == 828 || (index >= 830 && index <= 832) || index == 839 || index == 840 || index == 847 || index == 848 ||
                index == 850 || index == 853 || index == 857 || index == 859 || index == 865 || index == 868 || index == 869 || index == 874 || index == 878 || index == 879 ||
                index == 881 || index == 882 || index == 889 || (index >= 895 && index <= 898) || index == 908 || index == 910 || index == 913 || index == 925 || index == 927 ||
                index == 929 || index == 930 || index == 933 || (index >= 944 && index <= 946) || (index >= 949 && index <= 951) || (index >= 968 && index <= 976) || index == 985 ||
                index == 987 || index == 989 || index == 990 || index == 993 || index == 1004 || index == 1005 || index == 1008 || index == 1009 || index == 1011 || index == 1012 ||
                (index >= 1015 && index <= 1023) || (index >= 1031 && index <= 1034) || (index >= 1036 && index <= 1044) || index == 1046 || index == 1047 ||
                (index >= 1050 && index <= 1054) || index == 1059 || index == 1061 || index == 1062 || index == 1064 || index == 1067 || (index >= 1069 && index <= 1085) || index == 1088
                || index == 1090 || index == 1091 || index == 1093 || index == 1094 || index == 1096 || index == 1097 || (index >= 1099 && index <= 1129) ||
                (index >= 1142 && index <= 1153) || (index >= 1156 && index <= 1162) || (index >= 1168))
                classTierOut = 0;

            else if (index == 100 || index == 102 || index == 103 || index == 107 || index == 118 || index == 135 || index == 137 || (index >= 139 && index <= 142) ||
                (index >= 300 && index <= 302) || (index >= 304 && index <= 326) || index == 343 || index == 396 || index == 407 || index == 408 || index == 411 || index == 427 ||
                index == 435 || index == 443 || index == 445 || index == 458 || index == 460 || index == 478 || index == 494 || index == 509 || index == 552 || index == 554 ||
                (index >= 560 && index <= 564) || index == 566 || index == 567 || index == 569 || index == 570 || index == 573 || (index >= 576 && index <= 578) || index == 581 ||
                index == 583 || (index >= 586 && index <= 589) || index == 594 || index == 595 || index == 597 || index == 599 || (index >= 601 && index <= 604) || index == 620 ||
                index == 647 || index == 648 || index == 654 || index == 655 || index == 657 || (index >= 666 && index <= 668) || index == 688 || (index >= 700 && index <= 703) ||
                (index >= 717 && index <= 720) || (index >= 733 && index <= 736) || (index >= 750 && index <= 753) || index == 780 || index == 781 || index == 785 || index == 794 ||
                index == 805 || index == 812 || index == 815 || index == 816 || index == 818 || index == 843 || index == 844 || index == 846 || index == 855 || index == 872 ||
                index == 873 || (index >= 875 && index <= 877) || index == 884 || index == 885 || index == 915 || index == 931 || (index >= 935 && index <= 937) || index == 947 ||
                index == 948 || index == 961 || index == 992 || index == 1030 || index == 1035 || index == 1068 || index == 1130 || index == 1131)
                classTierOut = 1;

            else if ((index >= 27 && index <= 29) || index == 43 || index == 45 || index == 49 || index == 51 || index == 101 || index == 108 || index == 119 || index == 143 ||
                index == 149 || index == 150 || index == 159 || (index >= 164 && index <= 166) || index == 169 || index == 171 || index == 172 || (index >= 176 && index <= 178) ||
                (index >= 183 && index <= 185) || (index >= 282 && index <= 284) || index == 289 || (index >= 327 && index <= 342) || (index >= 351 && index <= 354) || index == 400 ||
                index == 401 || index == 405 || index == 406 || index == 409 || index == 410 || index == 426 || index == 433 || index == 434 || index == 441 ||
                (index >= 452 && index <= 457) || index == 459 || index == 461 || index == 462 || (index >= 471 && index <= 476) || index == 479 || index == 480 ||
                (index >= 490 && index <= 493) || index == 502 || index == 503 || index == 508 || index == 510 || index == 511 || index == 513 || index == 514 || index == 553 ||
                index == 557 || index == 558 || index == 572 || index == 574 || index == 575 || index == 585 || index == 590 || index == 591 || index == 593 ||
                (index >= 615 && index <= 618) || index == 628 || index == 640 || (index >= 651 && index <= 653) || (index >= 662 && index <= 664) || (index >= 682 && index <= 686) ||
                (index >= 693 && index <= 698) || (index >= 721 && index <= 724) || index == 727 || index == 728 || (index >= 754 && index <= 757) || index == 760 || index == 761 ||
                index == 766 || index == 767 || index == 769 || index == 779 || (index >= 782 && index <= 784) || index == 790 || index == 792 || index == 797 ||
                (index >= 802 && index <= 804) || index == 808 || index == 817 || index == 827 || index == 829 || index == 842 || index == 845 || index == 854 || index == 856 ||
                index == 858 || index == 866 || index == 870 || index == 871 || index == 883 || index == 886 || (index >= 904 && index <= 906) || index == 914 || index == 916 ||
                index == 917 || (index >= 920 && index <= 923) || index == 926 || index == 932 || index == 934 || index == 938 || index == 940 || index == 942 || index == 954 ||
                index == 955 || index == 959 || index == 960 || (index >= 962 && index <= 966) || index == 977 || index == 978 || index == 988 || index == 991 ||
                (index >= 994 && index <= 996) || index == 999 || index == 1001 || index == 1002 || index == 1006 || index == 1007 || (index >= 1026 && index <= 1029) ||
                (index >= 1055 && index <= 1058) || index == 1063 || index == 1066 || index == 1086 || index == 1087 || index == 1089 || index == 1092 || index == 1095 ||
                (index >= 1132 && index <= 1036) || index == 1164 || index == 1166 || index == 1167)
                classTierOut = 2;

            else if (index == 26 || (index >= 30 && index <= 33) || index == 35 || index == 38 || index == 39 || index == 44 || index == 46 || index == 52 || index == 86 ||
                (index >= 104 && index <= 106) || index == 109 || (index >= 112 && index <= 117) || index == 126 || index == 130 || index == 134 || index == 151 || index == 153 ||
                index == 168 || (index >= 173 && index <= 175) || (index >= 179 && index <= 182) || (index >= 186 && index <= 190) || (index >= 192 && index <= 194) || index == 281 ||
                (index >= 285 && index <= 288) || (index >= 344 && index <= 346) || (index >= 355 && index <= 376) || index == 393 || (index >= 420 && index <= 425) ||
                (index >= 428 && index <= 432) || (index >= 438 && index <= 440) || index == 442 || index == 444 || (index >= 446 && index <= 451) || index == 468 || index == 470 ||
                index == 486 || index == 488 || index == 489 || index == 499 || (index >= 504 && index <= 507) || index == 545 || index == 546 || index == 650 || index == 704 ||
                index == 725 || index == 726 || index == 737 || index == 758 || index == 759 || index == 768 || index == 770 || index == 771 || index == 774 || index == 775 ||
                (index >= 786 && index <= 789) || (index >= 799 && index <= 801) || index == 806 || index == 807 || index == 814 || (index >= 820 && index <= 822) || index == 824 ||
                index == 826 || (index >= 833 && index <= 838) || index == 841 || index == 849 || index == 851 || index == 852 || (index >= 860 && index <= 864) || index == 867 ||
                index == 880 || index == 887 || index == 888 || (index >= 890 && index <= 894) || (index >= 899 && index <= 903) || index == 907 || index == 909 || index == 911 ||
                index == 912 || index == 918 || index == 919 || index == 924 || index == 928 || index == 939 || index == 941 || index == 943 || index == 952 || index == 953 ||
                (index >= 956 && index <= 958) || index == 967 || (index >= 979 && index <= 984) || index == 986 || index == 997 || index == 998 || index == 1000 || index == 1003 ||
                index == 1010 || index == 1024 || index == 1025 || index == 1049 || index == 1065 || index == 1098 || (index >= 1137 && index <= 1139) || index == 1141 ||
                index == 1154 || index == 1155 || index == 1163 || index == 1165)
                classTierOut = 3;

            else if (index == 41 || index == 50 || (index >= 120 && index <= 125) || (index >= 127 && index <= 129) || (index >= 131 && index <= 133) || (index >= 377 && index <= 391) ||
                index == 436 || index == 1060 || index == 1140)
                classTierOut = 4;

            else if (index == 36 || index == 40 || index == 42 || index == 47 || index == 56 || index == 58 || index == 98 || index == 99 || index == 167 || index == 394 || index == 1013
                || index == 1014 || index == 1045 || index == 1048)
                classTierOut = 6;
        }

        public static bool isDigitsOnly(string str)
        {
            foreach (char ch in str)
            {
                if (ch < '0' || ch > '9')
                    return false;
            }
            return true;
        }

        public static byte ConvertToByte(BitArray bits)
        {
            if (bits.Count != 8)
                throw new ArgumentException(nameof(bits));
            byte[] numArray = new byte[1];
            bits.CopyTo((Array)numArray, 0);
            return numArray[0];
        }

        public static bool checkRanges()
        {
            return Randomizer.chBases && Randomizer.chBasesRange && (Randomizer.chMinBases > Randomizer.chMaxBases || Randomizer.chHPBases && Randomizer.chMinHPBases > Randomizer.chMaxHPBases) || Randomizer.chCaps && Randomizer.chCapsRange && (Randomizer.chMinCaps > Randomizer.chMaxCaps || Randomizer.chHPCaps && Randomizer.chMinHPCaps > Randomizer.chMaxHPCaps) || Randomizer.chGrowths && Randomizer.chGrowthsRange && (Randomizer.chMinGrowths > Randomizer.chMaxGrowths || Randomizer.chHPGrowths && Randomizer.chMinHPGrowths > Randomizer.chMaxHPGrowths || Randomizer.chMoveGrowths && Randomizer.chMinMoveGrowths > Randomizer.chMaxMoveGrowths);
        }

        public static void randBasesTrueRange(
          long mod,
          bool hpToggle,
          int min,
          int max,
          int minHP,
          int maxHP)
        {
            if (hpToggle)
                Randomizer.personData[Randomizer.charBlockStart + mod + 43L] = (byte)Randomizer.rng.Next(minHP, maxHP + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 51L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 52L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 53L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 54L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 55L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 56L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 57L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 59L] = (byte)Randomizer.rng.Next(min, max + 1);
        }

        public static void randCapsTrueRange(
          long mod,
          bool hpToggle,
          int min,
          int max,
          int minHP,
          int maxHP)
        {
            if (hpToggle)
                Randomizer.personData[Randomizer.charBlockStart + mod + 34L] = (byte)Randomizer.rng.Next(minHP, maxHP + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 69L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 70L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 71L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 72L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 73L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 74L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 75L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 77L] = (byte)Randomizer.rng.Next(min, max + 1);
        }

        public static void randGrowthsTrueRange(
          long mod,
          bool hpToggle,
          bool moveToggle,
          int min,
          int max,
          int minHP,
          int maxHP,
          int minMove,
          int maxMove)
        {
            if (hpToggle)
                Randomizer.personData[Randomizer.charBlockStart + mod + 41L] = (byte)Randomizer.rng.Next(minHP, maxHP + 1);
            if (moveToggle)
                Randomizer.personData[Randomizer.charBlockStart + mod + 67L] = (byte)Randomizer.rng.Next(minMove, maxMove + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 60L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 61L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 62L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 63L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 64L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 65L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 66L] = (byte)Randomizer.rng.Next(min, max + 1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 68L] = (byte)Randomizer.rng.Next(min, max + 1);
        }

        public static void randBasesRedistRange(
          long mod,
          bool hpToggle,
          int min,
          int max,
          int minHP,
          int maxHP,
          int hpWeight)
        {
            int num1 = 0;
            int num2 = 1;
            if (hpToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 43L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 43L] = (byte)0;
                num2 += hpWeight;
            }
            int num3 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 51L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 51L] = (byte)0;
            int num4 = num3 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 52L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 52L] = (byte)0;
            int num5 = num4 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 53L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 53L] = (byte)0;
            int num6 = num5 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 54L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 54L] = (byte)0;
            int num7 = num6 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 55L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 55L] = (byte)0;
            int num8 = num7 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 56L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 56L] = (byte)0;
            int num9 = num8 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 57L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 57L] = (byte)0;
            int num10 = num9 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 59L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 59L] = (byte)0;
            if (hpToggle)
            {
                Randomizer.personData[Randomizer.charBlockStart + mod + 43L] = (byte)minHP;
                num10 -= minHP;
            }
            Randomizer.personData[Randomizer.charBlockStart + mod + 51L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 52L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 53L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 54L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 55L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 56L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 57L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 59L] = (byte)min;
            int num11 = num10 - min * 8;
            while (num11 > 0)
            {
                if ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 51L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 52L] >= max && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 53L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 54L] >= max) && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 55L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 56L] >= max && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 57L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 59L] >= max)) && (hpToggle && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 43L] >= maxHP || !hpToggle))
                {
                    num11 = 0;
                    Randomizer.randBasesRedistRangeWarning = true;
                }
                int num12 = Randomizer.rng.Next(0, 7 + num2);
                if (num12 == 0 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 51L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 51L];
                    --num11;
                }
                else if (num12 == 1 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 52L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 52L];
                    --num11;
                }
                else if (num12 == 2 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 53L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 53L];
                    --num11;
                }
                else if (num12 == 3 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 54L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 54L];
                    --num11;
                }
                else if (num12 == 4 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 55L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 55L];
                    --num11;
                }
                else if (num12 == 5 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 56L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 56L];
                    --num11;
                }
                else if (num12 == 6 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 57L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 57L];
                    --num11;
                }
                else if (num12 == 7 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 59L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 59L];
                    --num11;
                }
                else if (num12 > 7 && num12 <= 7 + hpWeight && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 43L] < maxHP)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 43L];
                    --num11;
                }
            }
        }

        public static void randCapsRedistRange(
          long mod,
          bool hpToggle,
          int min,
          int max,
          int minHP,
          int maxHP,
          int hpWeight)
        {
            int num1 = 0;
            int num2 = 1;
            if (hpToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 34L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 34L] = (byte)0;
                num2 += hpWeight;
            }
            int num3 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 69L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 69L] = (byte)0;
            int num4 = num3 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 70L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 70L] = (byte)0;
            int num5 = num4 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 71L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 71L] = (byte)0;
            int num6 = num5 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 72L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 72L] = (byte)0;
            int num7 = num6 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 73L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 73L] = (byte)0;
            int num8 = num7 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 74L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 74L] = (byte)0;
            int num9 = num8 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 75L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 75L] = (byte)0;
            int num10 = num9 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 77L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 77L] = (byte)0;
            if (hpToggle)
            {
                Randomizer.personData[Randomizer.charBlockStart + mod + 34L] = (byte)minHP;
                num10 -= minHP;
            }
            Randomizer.personData[Randomizer.charBlockStart + mod + 69L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 70L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 71L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 72L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 73L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 74L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 75L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 77L] = (byte)min;
            int num11 = num10 - min * 8;
            while (num11 > 0)
            {
                if ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 69L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 70L] >= max && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 71L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 72L] >= max) && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 73L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 74L] >= max && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 75L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 77L] >= max)) && (hpToggle && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 34L] >= maxHP || !hpToggle))
                {
                    if (mod / Randomizer.charBlockLen == 1044L)
                    {
                        num11 = 0;
                        Randomizer.randCapsAelfricWarning = true;
                    }
                    else
                    {
                        num11 = 0;
                        Randomizer.randCapsRedistRangeWarning = true;
                    }
                }
                int num12 = Randomizer.rng.Next(0, 7 + num2);
                if (num12 == 0 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 69L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 69L];
                    --num11;
                }
                else if (num12 == 1 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 70L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 70L];
                    --num11;
                }
                else if (num12 == 2 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 71L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 71L];
                    --num11;
                }
                else if (num12 == 3 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 72L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 72L];
                    --num11;
                }
                else if (num12 == 4 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 73L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 73L];
                    --num11;
                }
                else if (num12 == 5 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 74L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 74L];
                    --num11;
                }
                else if (num12 == 6 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 75L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 75L];
                    --num11;
                }
                else if (num12 == 7 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 77L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 77L];
                    --num11;
                }
                else if (num12 > 7 && num12 <= 7 + hpWeight && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 34L] < maxHP)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 34L];
                    --num11;
                }
            }
        }

        public static void randGrowthsRedistRange(
          long mod,
          bool hpToggle,
          bool moveToggle,
          int min,
          int max,
          int minHP,
          int maxHP,
          int minMove,
          int maxMove,
          int hpWeight,
          int moveWeight)
        {
            int num1 = 0;
            int num2 = 1;
            double num3 = 0.0;
            if (hpToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 41L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 41L] = (byte)0;
                num2 += hpWeight;
            }
            if (moveToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 67L] = (byte)0;
                num2 += (int)((double)moveWeight / 100.0);
                num3 = (double)moveWeight / 100.0 - (double)(int)((double)moveWeight / 100.0);
            }
            int num4 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 60L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 60L] = (byte)0;
            int num5 = num4 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 61L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 61L] = (byte)0;
            int num6 = num5 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 62L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 62L] = (byte)0;
            int num7 = num6 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 63L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 63L] = (byte)0;
            int num8 = num7 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 64L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 64L] = (byte)0;
            int num9 = num8 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 65L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 65L] = (byte)0;
            int num10 = num9 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 66L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 66L] = (byte)0;
            int num11 = num10 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 68L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 68L] = (byte)0;
            if (hpToggle)
            {
                Randomizer.personData[Randomizer.charBlockStart + mod + 41L] = (byte)minHP;
                num11 -= minHP;
            }
            if (moveToggle)
            {
                Randomizer.personData[Randomizer.charBlockStart + mod + 67L] = (byte)minMove;
                num11 -= minMove;
            }
            Randomizer.personData[Randomizer.charBlockStart + mod + 60L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 61L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 62L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 63L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 64L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 65L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 66L] = (byte)min;
            Randomizer.personData[Randomizer.charBlockStart + mod + 68L] = (byte)min;
            int num12 = num11 - min * 8;
            while (num12 > 0)
            {
                if ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 60L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 61L] >= max && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 62L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 63L] >= max) && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 64L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 65L] >= max && ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 66L] >= max && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 68L] >= max)) && ((hpToggle && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 41L] >= maxHP || !hpToggle) && (moveToggle && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 67L] >= maxMove || !moveToggle)))
                {
                    num12 = 0;
                    Randomizer.randGrowthsRedistRangeWarning = true;
                }
                int num13 = Randomizer.rng.Next(0, 7 + num2);
                if (num13 == 0 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 60L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 60L];
                    --num12;
                }
                else if (num13 == 1 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 61L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 61L];
                    --num12;
                }
                else if (num13 == 2 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 62L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 62L];
                    --num12;
                }
                else if (num13 == 3 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 63L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 63L];
                    --num12;
                }
                else if (num13 == 4 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 64L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 64L];
                    --num12;
                }
                else if (num13 == 5 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 65L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 65L];
                    --num12;
                }
                else if (num13 == 6 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 66L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 66L];
                    --num12;
                }
                else if (num13 == 7 && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 68L] < max)
                {
                    ++Randomizer.personData[Randomizer.charBlockStart + mod + 68L];
                    --num12;
                }
                else if (hpToggle && !moveToggle)
                {
                    if (num13 > 7 && num13 <= 7 + hpWeight && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 41L] < maxHP)
                    {
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 41L];
                        --num12;
                    }
                }
                else if (moveToggle && !hpToggle)
                {
                    if (num13 > 7 && num13 <= 7 + moveWeight && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 67L] < maxMove)
                    {
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                        --num12;
                    }
                    else if ((double)Randomizer.rng.Next(0, 100) / 100.0 <= num3)
                    {
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                        --num12;
                    }
                }
                else if (hpToggle & moveToggle)
                {
                    if (num13 > 7 && num13 <= 7 + hpWeight && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 41L] < maxHP)
                    {
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 41L];
                        --num12;
                    }
                    else if (num13 > 7 + hpWeight && num13 <= 7 + hpWeight + moveWeight && (int)Randomizer.personData[Randomizer.charBlockStart + mod + 67L] < maxMove)
                    {
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                        --num12;
                    }
                    else if ((double)Randomizer.rng.Next(0, 100) / 100.0 <= num3)
                    {
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                        --num12;
                    }
                }
            }
        }

        public static void randBasesRedist(long mod, bool hpToggle, int hpWeight)
        {
            int num1 = 0;
            int num2 = 1;
            if (hpToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 43L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 43L] = (byte)0;
                num2 += hpWeight;
            }
            int num3 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 51L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 51L] = (byte)0;
            int num4 = num3 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 52L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 52L] = (byte)0;
            int num5 = num4 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 53L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 53L] = (byte)0;
            int num6 = num5 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 54L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 54L] = (byte)0;
            int num7 = num6 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 55L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 55L] = (byte)0;
            int num8 = num7 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 56L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 56L] = (byte)0;
            int num9 = num8 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 57L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 57L] = (byte)0;
            int num10 = num9 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 59L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 59L] = (byte)0;
            while (num10 > 0)
            {
                int num11 = Randomizer.rng.Next(0, 7 + num2);
                switch (num11)
                {
                    case 0:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 51L];
                        --num10;
                        continue;
                    case 1:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 52L];
                        --num10;
                        continue;
                    case 2:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 53L];
                        --num10;
                        continue;
                    case 3:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 54L];
                        --num10;
                        continue;
                    case 4:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 55L];
                        --num10;
                        continue;
                    case 5:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 56L];
                        --num10;
                        continue;
                    case 6:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 57L];
                        --num10;
                        continue;
                    case 7:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 59L];
                        --num10;
                        continue;
                    default:
                        if (num11 > 7 && num11 <= 7 + hpWeight)
                        {
                            ++Randomizer.personData[Randomizer.charBlockStart + mod + 43L];
                            --num10;
                            continue;
                        }
                        continue;
                }
            }
        }

        public static void randCapsRedist(long mod, bool hpToggle, int hpWeight)
        {
            int num1 = 0;
            int num2 = 1;
            if (hpToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 34L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 34L] = (byte)0;
                num2 += hpWeight;
            }
            int num3 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 69L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 69L] = (byte)0;
            int num4 = num3 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 70L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 70L] = (byte)0;
            int num5 = num4 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 71L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 71L] = (byte)0;
            int num6 = num5 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 72L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 72L] = (byte)0;
            int num7 = num6 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 73L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 73L] = (byte)0;
            int num8 = num7 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 74L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 74L] = (byte)0;
            int num9 = num8 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 75L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 75L] = (byte)0;
            int num10 = num9 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 77L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 77L] = (byte)0;
            while (num10 > 0)
            {
                int num11 = Randomizer.rng.Next(0, 7 + num2);
                switch (num11)
                {
                    case 0:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 69L];
                        --num10;
                        continue;
                    case 1:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 70L];
                        --num10;
                        continue;
                    case 2:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 71L];
                        --num10;
                        continue;
                    case 3:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 72L];
                        --num10;
                        continue;
                    case 4:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 73L];
                        --num10;
                        continue;
                    case 5:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 74L];
                        --num10;
                        continue;
                    case 6:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 75L];
                        --num10;
                        continue;
                    case 7:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 77L];
                        --num10;
                        continue;
                    default:
                        if (num11 > 7 && num11 <= 7 + hpWeight)
                        {
                            ++Randomizer.personData[Randomizer.charBlockStart + mod + 34L];
                            --num10;
                            continue;
                        }
                        continue;
                }
            }
        }

        public static void randGrowthsRedist(
          long mod,
          bool hpToggle,
          bool moveToggle,
          int hpWeight,
          int moveWeight)
        {
            int num1 = 0;
            int num2 = 1;
            double num3 = 0.0;
            if (hpToggle)
            {
                num1 += (int)Randomizer.personData[Randomizer.charBlockStart + mod + 41L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 41L] = (byte)0;
                num2 += hpWeight;
            }
            if (moveToggle)
            {
                int num4 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 67L] = (byte)0;
                int num5 = num2 + (int)((double)moveWeight / 100.0);
                double num6 = (double)moveWeight / 100.0 - (double)(int)((double)moveWeight / 100.0);
                num1 = num4 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                Randomizer.personData[Randomizer.charBlockStart + mod + 67L] = (byte)0;
                num2 = num5 + (int)((double)moveWeight / 100.0);
                num3 = (double)moveWeight / 100.0 - (double)(int)((double)moveWeight / 100.0);
            }
            int num7 = num1 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 60L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 60L] = (byte)0;
            int num8 = num7 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 61L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 61L] = (byte)0;
            int num9 = num8 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 62L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 62L] = (byte)0;
            int num10 = num9 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 63L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 63L] = (byte)0;
            int num11 = num10 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 64L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 64L] = (byte)0;
            int num12 = num11 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 65L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 65L] = (byte)0;
            int num13 = num12 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 66L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 66L] = (byte)0;
            int num14 = num13 + (int)Randomizer.personData[Randomizer.charBlockStart + mod + 68L];
            Randomizer.personData[Randomizer.charBlockStart + mod + 68L] = (byte)0;
            while (num14 > 0)
            {
                int num4 = Randomizer.rng.Next(0, 7 + num2);
                switch (num4)
                {
                    case 0:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 60L];
                        --num14;
                        continue;
                    case 1:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 61L];
                        --num14;
                        continue;
                    case 2:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 62L];
                        --num14;
                        continue;
                    case 3:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 63L];
                        --num14;
                        continue;
                    case 4:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 64L];
                        --num14;
                        continue;
                    case 5:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 65L];
                        --num14;
                        continue;
                    case 6:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 66L];
                        --num14;
                        continue;
                    case 7:
                        ++Randomizer.personData[Randomizer.charBlockStart + mod + 68L];
                        --num14;
                        continue;
                    default:
                        if (hpToggle && !moveToggle)
                        {
                            if (num4 > 7 && num4 <= 7 + hpWeight)
                            {
                                ++Randomizer.personData[Randomizer.charBlockStart + mod + 41L];
                                --num14;
                                continue;
                            }
                            continue;
                        }
                        if (moveToggle && !hpToggle)
                        {
                            if (num4 > 7 && num4 <= 7 + moveWeight)
                            {
                                ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                                --num14;
                                continue;
                            }
                            if ((double)Randomizer.rng.Next(0, 100) / 100.0 <= num3)
                            {
                                ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                                --num14;
                                continue;
                            }
                            continue;
                        }
                        if (hpToggle & moveToggle)
                        {
                            if (num4 > 7 && num4 <= 7 + hpWeight)
                            {
                                ++Randomizer.personData[Randomizer.charBlockStart + mod + 41L];
                                --num14;
                                continue;
                            }
                            if (num4 > 7 + hpWeight && num4 <= 7 + hpWeight + moveWeight)
                            {
                                ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                                --num14;
                                continue;
                            }
                            if ((double)Randomizer.rng.Next(0, 100) / 100.0 <= num3)
                            {
                                ++Randomizer.personData[Randomizer.charBlockStart + mod + 67L];
                                --num14;
                                continue;
                            }
                            continue;
                        }
                        continue;
                }
            }
        }

        public static void randFaculty(long mod, long rankMod)
        {
            int num1 = (int)BitConverter.ToUInt16(new byte[2]
            {
        Randomizer.personData[Randomizer.charFacultyStart + mod + 2L],
        Randomizer.personData[Randomizer.charFacultyStart + mod + 3L]
            }, 0);
            if (num1 == 49)
                num1 = 1045;
            if (num1 > 1039 && num1 <= 1046)
                num1 = 38 + (num1 - 1040);
            rankMod *= (long)num1;
            bool[] values1 = new bool[8];
            bool[] values2 = new bool[8];
            byte[] numArray = new byte[11]
            {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2
            };
            List<int> intList = new List<int>();
            for (int index = 0; index < 11; ++index)
            {
                if (Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)index] > (byte)0)
                    intList.Add(index);
            }
            int num2 = Randomizer.rng.Next(4) + 2;
            int num3 = Randomizer.rng.Next(5);
            while (num2 > 0)
            {
                if (intList.Count > 0)
                {
                    int index1 = Randomizer.rng.Next(intList.Count);
                    int index2 = intList[index1];
                    numArray[index2] = (byte)3;
                    intList.RemoveAt(index1);
                    --num2;
                }
                else
                {
                    int index = Randomizer.rng.Next(11);
                    if (numArray[index] == (byte)2)
                        numArray[index] = (byte)3;
                    --num2;
                }
            }
            for (; num3 > 0; --num3)
            {
                int index = Randomizer.rng.Next(11);
                if (numArray[index] == (byte)2)
                    numArray[index] = (byte)1;
            }
            for (int index = 0; index < 11; ++index)
            {
                if (numArray[index] == (byte)3)
                {
                    if (index < 8)
                        values1[index] = true;
                    else
                        values2[index - 8] = true;
                }
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 20L + (long)index] = numArray[index];
            }
            BitArray bits1 = new BitArray(values1);
            BitArray bits2 = new BitArray(values2);
            byte num4 = Randomizer.ConvertToByte(bits1);
            byte num5 = Randomizer.ConvertToByte(bits2);
            Randomizer.personData[Randomizer.charFacultyStart + mod] = num4;
            Randomizer.personData[Randomizer.charFacultyStart + mod + 1L] = num5;
        }

        public static void femBylethBoons()
        {
            long charWepRankLen = Randomizer.charWepRankLen;
            byte[] numArray = new byte[11]
            {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2
            };
            List<int> intList = new List<int>();
            for (int index = 0; index < 11; ++index)
            {
                if (Randomizer.personData[Randomizer.charWepRankStart + charWepRankLen + 9L + (long)index] > (byte)0)
                    intList.Add(index);
            }
            int num1 = Randomizer.rng.Next(4) + 2;
            int num2 = Randomizer.rng.Next(5);
            while (num1 > 0)
            {
                if (intList.Count > 0)
                {
                    int index1 = Randomizer.rng.Next(intList.Count);
                    int index2 = intList[index1];
                    numArray[index2] = (byte)3;
                    intList.RemoveAt(index1);
                    --num1;
                }
                else
                {
                    int index = Randomizer.rng.Next(11);
                    if (numArray[index] == (byte)2)
                        numArray[index] = (byte)3;
                    --num1;
                }
            }
            for (; num2 > 0; --num2)
            {
                int index = Randomizer.rng.Next(11);
                if (numArray[index] == (byte)2)
                    numArray[index] = (byte)1;
            }
            for (int index = 0; index < 11; ++index)
                Randomizer.personData[Randomizer.charWepRankStart + charWepRankLen + 20L + (long)index] = numArray[index];
        }

        public static void randSeminar(long mod, long rankMod)
        {
            int num1 = (int)BitConverter.ToUInt16(new byte[2]
            {
        Randomizer.personData[Randomizer.charSeminarStart + mod + 2L],
        Randomizer.personData[Randomizer.charFacultyStart + mod + 3L]
            }, 0);
            if (num1 == 49)
                num1 = 1045;
            if (num1 > 1039 && num1 <= 1046)
                num1 = 38 + (num1 - 1040);
            rankMod *= (long)num1;
            Randomizer.personData[Randomizer.charSeminarStart + mod] = (byte)0;
            Randomizer.personData[Randomizer.charSeminarStart + mod + 1L] = (byte)0;
            bool[] values1 = new bool[8];
            bool[] values2 = new bool[8];
            List<int> intList1 = new List<int>();
            int[] numArray = new int[11];
            for (int index = 0; index < 11; ++index)
                numArray[index] = (int)Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)index];
            int num2 = 0;
            for (int index = 0; index < numArray.Length; ++index)
            {
                if (numArray[index] > num2)
                {
                    intList1.Clear();
                    intList1.Add(index);
                    num2 = numArray[index];
                }
                else if (numArray[index] == num2)
                    intList1.Add(index);
            }
            int index1 = intList1[Randomizer.rng.Next(intList1.Count)];
            numArray[index1] = 0;
            List<int> intList2 = new List<int>();
            int num3 = 0;
            for (int index2 = 0; index2 < numArray.Length; ++index2)
            {
                if (numArray[index2] > num3)
                {
                    intList2.Clear();
                    intList2.Add(index2);
                    num3 = numArray[index2];
                }
                else if (numArray[index2] == num3)
                    intList2.Add(index2);
            }
            int index3 = intList2[Randomizer.rng.Next(intList2.Count)];
            while (index3 == index1)
                index3 = intList2[Randomizer.rng.Next(intList2.Count)];
            if (index1 < 8)
                values1[index1] = true;
            else
                values2[index1 - 8] = true;
            if (index3 < 8)
                values1[index3] = true;
            else
                values2[index3 - 8] = true;
            BitArray bits1 = new BitArray(values1);
            BitArray bits2 = new BitArray(values2);
            byte num4 = Randomizer.ConvertToByte(bits1);
            byte num5 = Randomizer.ConvertToByte(bits2);
            Randomizer.personData[Randomizer.charSeminarStart + mod] = num4;
            Randomizer.personData[Randomizer.charSeminarStart + mod + 1L] = num5;
        }

        public static void noCrest(long mod)
        {
            Randomizer.personData[Randomizer.charBlockStart + mod + 44L] = (byte)86;
            Randomizer.personData[Randomizer.charBlockStart + mod + 45L] = (byte)86;
        }

        public static void singleCrest(long mod)
        {
            Randomizer.personData[Randomizer.charBlockStart + mod + 44L] = (byte)Randomizer.rng.Next(48);
            Randomizer.personData[Randomizer.charBlockStart + mod + 45L] = (byte)86;
        }

        public static void doubleCrest(long mod)
        {
            Randomizer.personData[Randomizer.charBlockStart + mod + 44L] = (byte)Randomizer.rng.Next(48);
            Randomizer.personData[Randomizer.charBlockStart + mod + 45L] = (byte)Randomizer.rng.Next(48);
            while ((int)Randomizer.personData[Randomizer.charBlockStart + mod + 44L] == (int)Randomizer.personData[Randomizer.charBlockStart + mod + 45L])
                Randomizer.personData[Randomizer.charBlockStart + mod + 45L] = (byte)Randomizer.rng.Next(48);
        }

        public static void randSpells(long mod, bool enemyToggle)
        {
            int num1 = Randomizer.rng.Next(40);
            if (num1 < 3)
            {
                char[] path = new char[5] { 'd', 'e', 'c', 'a', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 6)
            {
                char[] path = new char[5] { 'd', 'c', 'b', 'a', 's' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 7)
            {
                char[] path = new char[5] { 'd', 'e', 'c', 'b', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 16)
            {
                char[] path = new char[5] { 'd', 'c', 'x', 'x', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 17)
            {
                char[] path = new char[5] { 'd', 'e', 'c', 'b', 'a' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 25)
            {
                char[] path = new char[5] { 'd', 'c', 'a', 'x', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 32)
            {
                char[] path = new char[5] { 'd', 'c', 'b', 'a', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 34)
            {
                char[] path = new char[5] { 'd', 'e', 'c', 'a', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 35)
            {
                char[] path = new char[5] { 'd', 'e', 'a', 'x', 'x' };
                Randomizer.randAnima(mod, path);
            }
            else if (num1 < 38)
            {
                char[] path = new char[5] { 'd', 'e', 'c', 'b', 'a' };
                if (enemyToggle)
                    Randomizer.randDarkEnemy(mod, path);
                Randomizer.randDark(mod, path);
            }
            else if (num1 < 39)
            {
                char[] path = new char[5] { 'd', 'c', 'b', 'a', 'x' };
                if (enemyToggle)
                    Randomizer.randMixedEnemy(mod, path);
                Randomizer.randMixed(mod, path);
            }
            else
            {
                char[] path = new char[5] { 'd', 'c', 'b', 'x', 'x' };
                if (enemyToggle)
                    Randomizer.randMixedEnemy(mod, path);
                Randomizer.randMixed(mod, path);
            }
            int num2 = Randomizer.rng.Next(40);
            if (num2 < 5)
            {
                char[] path = new char[3] { 'c', 'x', 'a' };
                Randomizer.randFaith(mod, path);
            }
            else if (num2 < 15)
            {
                char[] path = new char[3] { 'c', 'b', 'x' };
                Randomizer.randFaith(mod, path);
            }
            else if (num2 < 30)
            {
                char[] path = new char[3] { 'c', 'x', 'x' };
                Randomizer.randFaith(mod, path);
            }
            else if (num2 < 39)
            {
                char[] path = new char[3] { 'c', 'b', 'a' };
                Randomizer.randFaith(mod, path);
            }
            else
            {
                char[] path = new char[3] { 'b', 'a', 'x' };
                Randomizer.randFaith(mod, path);
            }
        }

        public static void randAnima(long mod, char[] path)
        {
            byte[] numArray1 = new byte[4]
            {
        (byte) 0,
        (byte) 3,
        (byte) 9,
        (byte) 6
            };
            byte[] numArray2 = new byte[3]
            {
        (byte) 3,
        (byte) 0,
        (byte) 6
            };
            byte[] numArray3 = new byte[4]
            {
        (byte) 1,
        (byte) 4,
        (byte) 11,
        (byte) 7
            };
            byte[] numArray4 = new byte[6]
            {
        (byte) 11,
        (byte) 1,
        (byte) 7,
        (byte) 2,
        (byte) 4,
        (byte) 10
            };
            byte[] numArray5 = new byte[6]
            {
        (byte) 2,
        (byte) 12,
        (byte) 10,
        (byte) 8,
        (byte) 13,
        (byte) 5
            };
            byte[] numArray6 = new byte[2] { (byte)13, (byte)12 };
            for (int index = 0; index < 5; ++index)
            {
                switch (path[index])
                {
                    case 'a':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)8;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                        break;
                    case 'b':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)6;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        break;
                    case 'c':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)4;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        break;
                    case 'd':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)2;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        break;
                    case 'e':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)3;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        break;
                    case 's':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)9;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray6[Randomizer.rng.Next(numArray6.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray6[Randomizer.rng.Next(numArray6.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray6[Randomizer.rng.Next(numArray6.Length)];
                        break;
                    case 'x':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)0;
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = byte.MaxValue;
                        break;
                }
            }
        }

        public static void randDark(long mod, char[] path)
        {
            byte[] numArray1 = new byte[1] { (byte)14 };
            byte[] numArray2 = new byte[2] { (byte)16, (byte)15 };
            byte[] numArray3 = new byte[2] { (byte)17, (byte)19 };
            byte[] numArray4 = new byte[2] { (byte)18, (byte)20 };
            byte[] numArray5 = new byte[2] { (byte)20, (byte)21 };
            for (int index = 0; index < 5; ++index)
            {
                switch (path[index])
                {
                    case 'a':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)8;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                        break;
                    case 'b':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)6;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        break;
                    case 'c':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)4;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        break;
                    case 'd':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)2;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        break;
                    case 'e':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)3;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        break;
                    case 'x':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)0;
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = byte.MaxValue;
                        break;
                }
            }
        }

        public static void randDarkEnemy(long mod, char[] path)
        {
            byte[] numArray1 = new byte[1] { (byte)14 };
            byte[] numArray2 = new byte[2] { (byte)16, (byte)15 };
            byte[] numArray3 = new byte[2] { (byte)17, (byte)19 };
            byte[] numArray4 = new byte[2] { (byte)18, (byte)20 };
            byte[] numArray5 = new byte[4]
            {
        (byte) 20,
        (byte) 21,
        (byte) 22,
        (byte) 23
            };
            for (int index = 0; index < 5; ++index)
            {
                switch (path[index])
                {
                    case 'a':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)8;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                        break;
                    case 'b':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)6;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        break;
                    case 'c':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)4;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        break;
                    case 'd':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)2;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        break;
                    case 'e':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)3;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        break;
                    case 'x':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)0;
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = byte.MaxValue;
                        break;
                }
            }
        }

        public static void randMixed(long mod, char[] path)
        {
            byte[] numArray1 = new byte[2] { (byte)0, (byte)3 };
            byte[] numArray2 = new byte[2] { (byte)1, (byte)4 };
            byte[] numArray3 = new byte[2] { (byte)19, (byte)18 };
            byte[] numArray4 = new byte[1] { (byte)21 };
            for (int index = 0; index < 5; ++index)
            {
                switch (path[index])
                {
                    case 'a':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)8;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        break;
                    case 'b':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)6;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        break;
                    case 'c':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)4;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        break;
                    case 'd':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)2;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        break;
                    case 'x':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)0;
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = byte.MaxValue;
                        break;
                }
            }
        }

        public static void randMixedEnemy(long mod, char[] path)
        {
            byte[] numArray1 = new byte[2] { (byte)0, (byte)3 };
            byte[] numArray2 = new byte[2] { (byte)1, (byte)4 };
            byte[] numArray3 = new byte[2] { (byte)19, (byte)18 };
            byte[] numArray4 = new byte[3]
            {
        (byte) 21,
        (byte) 22,
        (byte) 23
            };
            for (int index = 0; index < 5; ++index)
            {
                switch (path[index])
                {
                    case 'a':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)8;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray4[Randomizer.rng.Next(numArray4.Length)];
                        break;
                    case 'b':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)6;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        break;
                    case 'c':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)4;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        break;
                    case 'd':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)2;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        break;
                    case 'x':
                        Randomizer.personData[Randomizer.charSpellStart + mod + 15L + (long)index] = (byte)0;
                        Randomizer.personData[Randomizer.charSpellStart + mod + 5L + (long)index] = byte.MaxValue;
                        break;
                }
            }
        }

        public static void randFaith(long mod, char[] path)
        {
            mod += 2L;
            byte[] numArray1 = new byte[5]
            {
        (byte) 25,
        (byte) 26,
        (byte) 34,
        (byte) 33,
        (byte) 29
            };
            byte[] numArray2 = new byte[5]
            {
        (byte) 29,
        (byte) 33,
        (byte) 34,
        (byte) 35,
        (byte) 36
            };
            byte[] numArray3 = new byte[6]
            {
        (byte) 30,
        (byte) 36,
        (byte) 37,
        (byte) 27,
        (byte) 31,
        (byte) 35
            };
            for (int index = 0; index < 3; ++index)
            {
                switch (path[index])
                {
                    case 'a':
                        Randomizer.personData[Randomizer.charSpellStart + mod + (long)index] = (byte)8;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        break;
                    case 'b':
                        Randomizer.personData[Randomizer.charSpellStart + mod + (long)index] = (byte)6;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                        break;
                    case 'c':
                        Randomizer.personData[Randomizer.charSpellStart + mod + (long)index] = (byte)4;
                        if (index == 0)
                        {
                            Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                            break;
                        }
                        Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        while ((int)Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] == (int)Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index - 1L])
                            Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                        break;
                    case 'x':
                        Randomizer.personData[Randomizer.charSpellStart + mod + (long)index] = (byte)0;
                        Randomizer.personData[Randomizer.charSpellStart + mod + 10L + (long)index] = byte.MaxValue;
                        break;
                }
            }
        }

        public static void randHeight(long mod, bool tsToggle)
        {
            byte num1 = (byte)(Randomizer.rng.Next(70) + 135);
            Randomizer.personData[Randomizer.charBlockStart + mod + 47L] = num1;
            if (tsToggle && Randomizer.rng.Next(41) < 9)
            {
                double num2 = (double)Randomizer.rng.Next(16) / 100.0;
                num1 += (byte)((double)num1 * num2);
            }
            Randomizer.personData[Randomizer.charBlockStart + mod + 48L] = num1;
        }

        public static void randChest(long mod, bool tsToggle)
        {
            float num1 = (float)(0.9 + Randomizer.rng.NextDouble() * 0.2);
            byte[] bytes1 = BitConverter.GetBytes(num1);
            Randomizer.personData[Randomizer.charBlockStart + mod + 0L] = bytes1[0];
            Randomizer.personData[Randomizer.charBlockStart + mod + 1L] = bytes1[1];
            Randomizer.personData[Randomizer.charBlockStart + mod + 2L] = bytes1[2];
            Randomizer.personData[Randomizer.charBlockStart + mod + 3L] = bytes1[3];

            float num3 = (float)(1.0 + Randomizer.rng.NextDouble() * 2.0);
            byte[] bytes3 = BitConverter.GetBytes(num3);
            Randomizer.personData[Randomizer.charBlockStart + mod + 4L] = bytes3[0];
            Randomizer.personData[Randomizer.charBlockStart + mod + 5L] = bytes3[1];
            Randomizer.personData[Randomizer.charBlockStart + mod + 6L] = bytes3[2];
            Randomizer.personData[Randomizer.charBlockStart + mod + 7L] = bytes3[3];

            float num2 = (float)(0.95 + Randomizer.rng.NextDouble() * 0.1);
            byte[] bytes2 = BitConverter.GetBytes(num2);
            Randomizer.personData[Randomizer.charBlockStart + mod + 8L] = bytes2[0];
            Randomizer.personData[Randomizer.charBlockStart + mod + 9L] = bytes2[1];
            Randomizer.personData[Randomizer.charBlockStart + mod + 10L] = bytes2[2];
            Randomizer.personData[Randomizer.charBlockStart + mod + 11L] = bytes2[3];

            float num4 = (float)(1.0 + Randomizer.rng.NextDouble() * 2.0);
            if (num4 < num3)
                num4 = num3;
            byte[] bytes4 = BitConverter.GetBytes(num4);
            Randomizer.personData[Randomizer.charBlockStart + mod + 12L] = bytes4[0];
            Randomizer.personData[Randomizer.charBlockStart + mod + 13L] = bytes4[1];
            Randomizer.personData[Randomizer.charBlockStart + mod + 14L] = bytes4[2];
            Randomizer.personData[Randomizer.charBlockStart + mod + 15L] = bytes4[3];
        }

        public static void randClasses(
          long mod,
          long rankMod,
          long wepMod,
          long chGoalMod,
          bool beg,
          bool inter,
          bool ts,
          bool gender,
          bool dnc,
          bool png)
        {
            if (mod / Randomizer.charBlockLen > 37L)
                mod = (mod / Randomizer.charBlockLen - 38L + 1040L) * Randomizer.charBlockLen;
            byte[] numArray1 = new byte[2] { (byte)0, (byte)1 };
            byte[] numArray2 = new byte[4]
            {
        (byte) 2,
        (byte) 3,
        (byte) 4,
        (byte) 5
            };
            byte[] numArray3 = new byte[11]
            {
        (byte) 7,
        (byte) 8,
        (byte) 9,
        (byte) 10,
        (byte) 11,
        (byte) 12,
        (byte) 13,
        (byte) 14,
        (byte) 15,
        (byte) 16,
        (byte) 54
            };
            byte[] numArray4 = new byte[15]
            {
        (byte) 2,
        (byte) 3,
        (byte) 4,
        (byte) 5,
        (byte) 7,
        (byte) 8,
        (byte) 9,
        (byte) 10,
        (byte) 11,
        (byte) 12,
        (byte) 13,
        (byte) 14,
        (byte) 15,
        (byte) 16,
        (byte) 54
            };
            byte[] numArray5 = new byte[12]
            {
        (byte) 18,
        (byte) 19,
        (byte) 20,
        (byte) 21,
        (byte) 22,
        (byte) 24,
        (byte) 25,
        (byte) 26,
        (byte) 27,
        (byte) 28,
        (byte) 29,
        (byte) 30
            };
            byte[] numArray6 = new byte[9]
            {
        (byte) 31,
        (byte) 32,
        (byte) 33,
        (byte) 34,
        (byte) 35,
        (byte) 36,
        (byte) 37,
        (byte) 38,
        (byte) 39
            };
            if (!gender)
            {
                if (Randomizer.personData[Randomizer.charBlockStart + mod + 38L] == (byte)0)
                {
                    numArray3 = new byte[10]
                    {
            (byte) 7,
            (byte) 8,
            (byte) 9,
            (byte) 10,
            (byte) 11,
            (byte) 12,
            (byte) 13,
            (byte) 14,
            (byte) 15,
            (byte) 16
                    };
                    numArray4 = new byte[15]
                    {
            (byte) 2,
            (byte) 3,
            (byte) 4,
            (byte) 5,
            (byte) 6,
            (byte) 7,
            (byte) 8,
            (byte) 9,
            (byte) 10,
            (byte) 11,
            (byte) 12,
            (byte) 13,
            (byte) 14,
            (byte) 15,
            (byte) 16
                    };
                    numArray6 = new byte[7]
                    {
            (byte) 32,
            (byte) 33,
            (byte) 34,
            (byte) 35,
            (byte) 36,
            (byte) 37,
            (byte) 38
                    };
                }
                else
                {
                    numArray3 = new byte[9]
                    {
            (byte) 7,
            (byte) 8,
            (byte) 9,
            (byte) 10,
            (byte) 11,
            (byte) 12,
            (byte) 14,
            (byte) 16,
            (byte) 54
                    };
                    numArray4 = new byte[14]
                    {
            (byte) 2,
            (byte) 3,
            (byte) 4,
            (byte) 5,
            (byte) 6,
            (byte) 7,
            (byte) 8,
            (byte) 9,
            (byte) 10,
            (byte) 11,
            (byte) 12,
            (byte) 14,
            (byte) 16,
            (byte) 54
                    };
                    numArray5 = new byte[9]
                    {
            (byte) 19,
            (byte) 20,
            (byte) 21,
            (byte) 22,
            (byte) 24,
            (byte) 25,
            (byte) 26,
            (byte) 28,
            (byte) 30
                    };
                    numArray6 = new byte[8]
                    {
            (byte) 31,
            (byte) 32,
            (byte) 33,
            (byte) 34,
            (byte) 35,
            (byte) 36,
            (byte) 37,
            (byte) 39
                    };
                }
            }
            if (dnc)
            {
                byte[] numArray7 = new byte[1] { (byte)43 };
                byte[] numArray8 = new byte[numArray7.Length + numArray3.Length];
                byte[] numArray9 = new byte[numArray7.Length + numArray4.Length];
                numArray7.CopyTo((Array)numArray8, 0);
                numArray3.CopyTo((Array)numArray8, numArray7.Length);
                numArray7.CopyTo((Array)numArray9, 0);
                numArray4.CopyTo((Array)numArray9, numArray7.Length);
                numArray3 = new byte[numArray8.Length];
                numArray8.CopyTo((Array)numArray3, 0);
                numArray4 = new byte[numArray9.Length];
                numArray9.CopyTo((Array)numArray4, 0);
            }
            if (png && (gender || Randomizer.personData[Randomizer.charBlockStart + mod + 38L] == (byte)1))
            {
                byte[] numArray7 = new byte[1] { (byte)23 };
                byte[] numArray8 = new byte[numArray7.Length + numArray5.Length];
                numArray7.CopyTo((Array)numArray8, 0);
                numArray5.CopyTo((Array)numArray8, numArray7.Length);
                numArray5 = new byte[numArray8.Length];
                numArray8.CopyTo((Array)numArray5, 0);
            }
            if (Randomizer.chDLC)
            {
                byte[] numArray7 = new byte[4]
                {
          (byte) 84,
          (byte) 85,
          (byte) 86,
          (byte) 87
                };
                if (!gender && Randomizer.personData[Randomizer.charBlockStart + mod + 38L] == (byte)0)
                    numArray7 = new byte[2] { (byte)84, (byte)85 };
                byte[] numArray8 = new byte[numArray7.Length + numArray5.Length];
                numArray7.CopyTo((Array)numArray8, 0);
                numArray5.CopyTo((Array)numArray8, numArray7.Length);
                numArray5 = new byte[numArray8.Length];
                numArray8.CopyTo((Array)numArray5, 0);
            }
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            byte num1 = Randomizer.personData[Randomizer.charWepRankStart + rankMod + 3L];
            byte num2;
            if (((IEnumerable<byte>)numArray1).Contains<byte>(num1))
            {
                if (beg & inter)
                {
                    num2 = numArray4[Randomizer.rng.Next(numArray4.Length)];
                    if (((IEnumerable<byte>)numArray3).Contains<byte>(num2))
                        flag2 = true;
                    flag1 = true;
                }
                else if (beg)
                {
                    num2 = numArray2[Randomizer.rng.Next(numArray2.Length)];
                    flag1 = true;
                }
                else if (inter)
                {
                    num2 = numArray3[Randomizer.rng.Next(numArray3.Length)];
                    flag1 = true;
                    flag2 = true;
                }
                else
                    num2 = numArray1[Randomizer.rng.Next(numArray1.Length)];
            }
            else if (((IEnumerable<byte>)numArray2).Contains<byte>(num1))
            {
                if (beg & inter)
                {
                    num2 = numArray4[Randomizer.rng.Next(numArray4.Length)];
                    if (((IEnumerable<byte>)numArray3).Contains<byte>(num2))
                        flag2 = true;
                }
                else if (inter)
                {
                    num2 = numArray3[Randomizer.rng.Next(numArray3.Length)];
                    flag2 = true;
                }
                else
                    num2 = numArray2[Randomizer.rng.Next(numArray1.Length)];
                flag1 = true;
            }
            else if (((IEnumerable<byte>)numArray3).Contains<byte>(num1))
            {
                num2 = numArray3[Randomizer.rng.Next(numArray3.Length)];
                flag1 = true;
                flag2 = true;
            }
            else if (((IEnumerable<byte>)numArray5).Contains<byte>(num1))
            {
                num2 = numArray5[Randomizer.rng.Next(numArray5.Length)];
                flag1 = true;
                flag2 = true;
                flag3 = true;
            }
            else
            {
                num2 = numArray6[Randomizer.rng.Next(numArray6.Length)];
                flag1 = true;
                flag2 = true;
                flag3 = true;
            }
            Randomizer.personData[Randomizer.charBlockStart + mod + 26L] = num2;
            Randomizer.personData[Randomizer.charWepRankStart + rankMod + 3L] = num2;
            if (flag1)
            {
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 4L] = numArray1[Randomizer.rng.Next(numArray1.Length)];
                if (flag2)
                {
                    Randomizer.personData[Randomizer.charWepRankStart + rankMod + 5L] = numArray2[Randomizer.rng.Next(numArray2.Length)];
                    if (flag3)
                    {
                        Randomizer.personData[Randomizer.charWepRankStart + rankMod + 6L] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                        Randomizer.personData[Randomizer.charWepRankStart + rankMod + 31L] = Randomizer.personData[Randomizer.charWepRankStart + rankMod + 6L];
                    }
                    else
                        Randomizer.personData[Randomizer.charWepRankStart + rankMod + 6L] = byte.MaxValue;
                }
                else
                {
                    Randomizer.personData[Randomizer.charWepRankStart + rankMod + 5L] = byte.MaxValue;
                    Randomizer.personData[Randomizer.charWepRankStart + rankMod + 6L] = byte.MaxValue;
                }
            }
            else
            {
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 4L] = byte.MaxValue;
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 5L] = byte.MaxValue;
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 6L] = byte.MaxValue;
            }
            if (ts)
            {
                if (!flag3)
                    Randomizer.personData[Randomizer.charWepRankStart + rankMod + 31L] = numArray3[Randomizer.rng.Next(numArray3.Length)];
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 32L] = numArray5[Randomizer.rng.Next(numArray5.Length)];
                Randomizer.personData[Randomizer.charWepRankStart + rankMod + 33L] = numArray6[Randomizer.rng.Next(numArray6.Length)];
            }
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>((IEnumerable<int>)new int[11]
            {
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10
            });
            for (int index = 0; index < 11; ++index)
            {
                int num6 = (int)Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)index];
                if (num6 > 0)
                {
                    if (num6 > num3)
                        num3 = num6;
                    ++num4;
                    num5 += num6;
                    Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)index] = (byte)0;
                }
            }
            for (; num4 > 0; --num4)
            {
                int index = Randomizer.rng.Next(intList2.Count);
                intList1.Add(intList2[index]);
                intList2.RemoveAt(index);
            }
            while (num5 > 0)
            {
                int num6 = intList1[Randomizer.rng.Next(intList1.Count)];
                if ((int)Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)num6] < num3)
                {
                    ++Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)num6];
                    --num5;
                }
            }
            List<int> intList3 = new List<int>();
            int[] numArray10 = new int[5];
            for (int index = 0; index < 5; ++index)
                numArray10[index] = (int)Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)index];
            int num7 = 0;
            for (int index = 0; index < numArray10.Length; ++index)
            {
                if (numArray10[index] > num7)
                {
                    intList3.Clear();
                    intList3.Add(index);
                    num7 = numArray10[index];
                }
                else if (numArray10[index] == num7)
                    intList3.Add(index);
            }
            int index1 = intList3[Randomizer.rng.Next(intList3.Count)];
            numArray10[index1] = 0;
            List<int> intList4 = new List<int>();
            int num8 = 0;
            for (int index2 = 0; index2 < numArray10.Length; ++index2)
            {
                if (numArray10[index2] > num8)
                {
                    intList4.Clear();
                    intList4.Add(index2);
                    num8 = numArray10[index2];
                }
                else if (numArray10[index2] == num8)
                    intList4.Add(index2);
            }
            int num9 = intList4[Randomizer.rng.Next(intList4.Count)];
            while (num9 == index1)
                num9 = intList4[Randomizer.rng.Next(intList4.Count)];
            int[,] numArray11 = new int[2, 2]
            {
        {
          index1,
          (int) Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long) index1]
        },
        {
          num9,
          (int) Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long) num9]
        }
            };
            if (numArray11[0, 1] < numArray11[1, 1] || numArray11[0, 1] == numArray11[1, 1] && Randomizer.rng.Next(2) < 1)
            {
                int num6 = numArray11[1, 0];
                int num10 = numArray11[1, 1];
                numArray11[1, 0] = numArray11[0, 0];
                numArray11[1, 1] = numArray11[0, 1];
                numArray11[0, 0] = num6;
                numArray11[0, 1] = num10;
            }
            if (numArray11[0, 1] % 2 != 0)
                --numArray11[0, 1];
            if (numArray11[1, 1] % 2 != 0)
                --numArray11[1, 1];
            Dictionary<int[], int[]> dictionary1 = new Dictionary<int[], int[]>((IEqualityComparer<int[]>)new ArrayComparer());
            Dictionary<int, int[]> dictionary2 = new Dictionary<int, int[]>();
            int num11 = 1000;
            dictionary1.Add(new int[2], new int[1] { 158 });
            dictionary1.Add(new int[2] { 0, 2 }, new int[2]
            {
        157,
        163
            });
            dictionary1.Add(new int[2] { 0, 4 }, new int[5]
            {
        122,
        146,
        80,
        81,
        175
            });
            dictionary1.Add(new int[2] { 0, 6 }, new int[4]
            {
        8,
        9,
        53,
        58
            });
            dictionary1.Add(new int[2] { 0, 8 }, new int[4]
            {
        60,
        61,
        182,
        183
            });
            dictionary2.Add(0, new int[4] { 60, 61, 182, 183 });
            dictionary1.Add(new int[2] { 1, 0 }, new int[1] { 124 });
            dictionary1.Add(new int[2] { 1, 2 }, new int[2]
            {
        149,
        159
            });
            dictionary1.Add(new int[2] { 1, 4 }, new int[5]
            {
        128,
        150,
        161,
        170,
        176
            });
            dictionary1.Add(new int[2] { 1, 6 }, new int[4]
            {
        14,
        15,
        39,
        54
            });
            dictionary1.Add(new int[2] { 1, 8 }, new int[4]
            {
        63,
        67,
        68,
        89
            });
            dictionary2.Add(1, new int[6]
            {
        64,
        65,
        66,
        184,
        185,
        186
            });
            dictionary1.Add(new int[2] { 2, 0 }, new int[1] { 174 });
            dictionary1.Add(new int[2] { 2, 2 }, new int[3]
            {
        152,
        160,
        164
            });
            dictionary1.Add(new int[2] { 2, 4 }, new int[3]
            {
        134,
        153,
        177
            });
            dictionary1.Add(new int[2] { 2, 6 }, new int[4]
            {
        20,
        21,
        35,
        42
            });
            dictionary1.Add(new int[2] { 2, 8 }, new int[3]
            {
        72,
        73,
        90
            });
            dictionary2.Add(2, new int[5] { 70, 71, 82, 187, 188 });
            dictionary1.Add(new int[2] { 3, 0 }, new int[1] { 136 });
            dictionary1.Add(new int[2] { 3, 2 }, new int[1] { 156 });
            dictionary1.Add(new int[2] { 3, 4 }, new int[4]
            {
        140,
        155,
        162,
        178
            });
            dictionary1.Add(new int[2] { 3, 6 }, new int[3]
            {
        26,
        27,
        36
            });
            dictionary1.Add(new int[2] { 3, 8 }, new int[4]
            {
        74,
        75,
        76,
        91
            });
            dictionary2.Add(3, new int[2] { 77, 189 });
            dictionary1.Add(new int[2] { 4, 0 }, new int[1] { 142 });
            dictionary1.Add(new int[2] { 4, 2 }, new int[1] { 143 });
            dictionary1.Add(new int[2] { 4, 4 }, new int[1] { 143 });
            dictionary1.Add(new int[2] { 4, 6 }, new int[2]
            {
        32,
        92
            });
            dictionary1.Add(new int[2] { 4, 8 }, new int[2]
            {
        78,
        93
            });
            dictionary2.Add(4, new int[1] { 190 });
            int[,] numArray12 = new int[5, 2]
            {
        {
          0,
          11
        },
        {
          1,
          17
        },
        {
          2,
          23
        },
        {
          3,
          29
        },
        {
          4,
          33
        }
            };
            int[,] numArray13 = new int[5, 2]
            {
        {
          0,
          6
        },
        {
          1,
          12
        },
        {
          2,
          18
        },
        {
          3,
          24
        },
        {
          4,
          30
        }
            };
            int[,] numArray14 = new int[5, 2]
            {
        {
          0,
          7
        },
        {
          1,
          13
        },
        {
          2,
          19
        },
        {
          3,
          25
        },
        {
          4,
          31
        }
            };
            List<int> intList5 = new List<int>();
            int num12 = Randomizer.rng.Next(40);
            if (num12 < 1)
            {
                int[] numArray7 = dictionary1[new int[2]
                {
          numArray11[0, 0],
          numArray11[0, 1]
                }];
                intList5.Add(numArray7[Randomizer.rng.Next(numArray7.Length)]);
                int[] numArray8 = dictionary1[new int[2]
                {
          numArray11[1, 0],
          numArray11[1, 1]
                }];
                intList5.Add(numArray8[Randomizer.rng.Next(numArray8.Length)]);
                intList5.Add(1157);
            }
            else if (num12 < 2)
            {
                int[] numArray7 = dictionary2[numArray11[0, 0]];
                intList5.Add(numArray7[Randomizer.rng.Next(numArray7.Length)]);
            }
            else
            {
                int num6 = Randomizer.rng.Next(34);
                if (num6 >= 2)
                {
                    if (flag3 && numArray11[0, 1] >= 2)
                        intList5.Add(numArray14[numArray11[0, 0], 1]);
                    else if (num6 < 27)
                        intList5.Add(numArray13[numArray11[0, 0], 1]);
                    else
                        intList5.Add(numArray12[numArray11[0, 0], 1]);
                }
                if (Randomizer.rng.Next(39) >= 8)
                    intList5.Add(num11);
            }
            for (int index2 = 0; index2 < intList5.Count; ++index2)
            {
                if (intList5[index2] < 1000)
                    intList5[index2] += 10;
            }
            intList5.Add(0);
            intList5.Add(0);
            intList5.Add(0);
            for (int index2 = 0; index2 < intList5.Count && index2 < 3; ++index2)
            {
                if (intList5[index2] < 1000)
                {
                    Randomizer.personData[Randomizer.charWepStart + wepMod + 2L + (long)(index2 * 2)] = (byte)intList5[index2];
                    Randomizer.personData[Randomizer.charWepStart + wepMod + 2L + (long)(index2 * 2) + 1L] = (byte)0;
                }
                else if (intList5[index2] == 1000)
                {
                    Randomizer.personData[Randomizer.charWepStart + wepMod + 2L + (long)(index2 * 2)] = (byte)232;
                    Randomizer.personData[Randomizer.charWepStart + wepMod + 2L + (long)(index2 * 2) + 1L] = (byte)3;
                }
                else
                {
                    Randomizer.personData[Randomizer.charWepStart + wepMod + 2L + (long)(index2 * 2)] = (byte)232;
                    Randomizer.personData[Randomizer.charWepStart + wepMod + 2L + (long)(index2 * 2) + 1L] = (byte)3;
                }
            }
            List<int> intList6 = new List<int>();
            int[] numArray15 = new int[8];
            for (int index2 = 0; index2 < 8; ++index2)
                numArray15[index2] = (int)Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long)index2];
            int num13 = 0;
            for (int index2 = 0; index2 < numArray15.Length; ++index2)
            {
                if (numArray15[index2] > num13)
                {
                    intList6.Clear();
                    intList6.Add(index2);
                    num13 = numArray15[index2];
                }
                else if (numArray15[index2] == num13)
                    intList6.Add(index2);
            }
            int index3 = intList6[Randomizer.rng.Next(intList6.Count)];
            numArray15[index3] = 0;
            List<int> intList7 = new List<int>();
            int num14 = 0;
            for (int index2 = 0; index2 < numArray15.Length; ++index2)
            {
                if (numArray15[index2] > num14)
                {
                    intList7.Clear();
                    intList7.Add(index2);
                    num14 = numArray15[index2];
                }
                else if (numArray15[index2] == num14)
                    intList7.Add(index2);
            }
            int num15 = intList7[Randomizer.rng.Next(intList7.Count)];
            while (num15 == index3)
                num15 = intList7[Randomizer.rng.Next(intList7.Count)];
            int[,] numArray16 = new int[2, 2]
            {
        {
          index3,
          (int) Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long) index3]
        },
        {
          num15,
          (int) Randomizer.personData[Randomizer.charWepRankStart + rankMod + 9L + (long) num15]
        }
            };
            if (chGoalMod < 0L)
                return;
            if (numArray16[0, 0] > numArray16[1, 0])
            {
                int num6 = numArray16[1, 0];
                int num10 = numArray16[1, 1];
                numArray16[1, 0] = numArray16[0, 0];
                numArray16[1, 1] = numArray16[0, 1];
                numArray16[0, 0] = num6;
                numArray16[0, 1] = num10;
            }
            byte num16 = new Dictionary<int[], byte>((IEqualityComparer<int[]>)new ArrayComparer())
      {
        {
          new int[2]{ 0, 1 },
          (byte) 0
        },
        {
          new int[2]{ 0, 2 },
          (byte) 1
        },
        {
          new int[2]{ 0, 3 },
          (byte) 2
        },
        {
          new int[2]{ 0, 4 },
          (byte) 3
        },
        {
          new int[2]{ 0, 5 },
          (byte) 4
        },
        {
          new int[2]{ 0, 6 },
          (byte) 5
        },
        {
          new int[2]{ 0, 7 },
          (byte) 6
        },
        {
          new int[2]{ 1, 2 },
          (byte) 10
        },
        {
          new int[2]{ 1, 3 },
          (byte) 11
        },
        {
          new int[2]{ 1, 4 },
          (byte) 12
        },
        {
          new int[2]{ 1, 5 },
          (byte) 13
        },
        {
          new int[2]{ 1, 6 },
          (byte) 14
        },
        {
          new int[2]{ 1, 7 },
          (byte) 15
        },
        {
          new int[2]{ 2, 3 },
          (byte) 19
        },
        {
          new int[2]{ 2, 4 },
          (byte) 20
        },
        {
          new int[2]{ 2, 5 },
          (byte) 21
        },
        {
          new int[2]{ 2, 6 },
          (byte) 22
        },
        {
          new int[2]{ 2, 7 },
          (byte) 23
        },
        {
          new int[2]{ 3, 4 },
          (byte) 27
        },
        {
          new int[2]{ 3, 5 },
          (byte) 28
        },
        {
          new int[2]{ 3, 6 },
          (byte) 29
        },
        {
          new int[2]{ 3, 7 },
          (byte) 30
        },
        {
          new int[2]{ 4, 5 },
          (byte) 34
        },
        {
          new int[2]{ 4, 6 },
          (byte) 35
        },
        {
          new int[2]{ 4, 7 },
          (byte) 36
        },
        {
          new int[2]{ 5, 6 },
          (byte) 40
        },
        {
          new int[2]{ 5, 7 },
          (byte) 41
        },
        {
          new int[2]{ 6, 7 },
          (byte) 45
        }
      }[new int[2] { numArray16[0, 0], numArray16[1, 0] }];
            Randomizer.personData[Randomizer.charGoalStart + chGoalMod] = num16;
        }

        public static int getSpell(int type, int rank, bool forceRank, bool forceOffensive)
        {
            int localRank = rank / 2;
            int[][] blackSpells = new int[][]
            {
                new int[] { 0, 3, 6, 9 },
                new int[] { },
                new int[] { 1, 4, 7, 11 },
                new int[] { 2, 5, 8, 10, 12},
                new int[] { 13 },
                new int[] { }
            };
            int[][] faithSpells = new int[][]
            {
                new int[] { 24, 28 },
                new int[] { },
                new int[] { 25, 26, 29, 33, 34 },
                new int[] { 30, 35, 36, 37 },
                new int[] { 27, 31 },
                new int[] { }
            };
            int[][] offensiveFaithSpells = new int[][]
            {
                new int[] { 28 },
                new int[] { },
                new int[] { 29 },
                new int[] { 30 },
                new int[] { 31 },
                new int[] { }
            };
            int[][] darkSpells = new int[][]
            {
                new int[] { 14, 15, 16 },
                new int[] { },
                new int[] { 17, 18, 19 },
                new int[] { 20 },
                new int[] { 21, 22, 23 },
                new int[] { }
            };
            List<int> spellSelection = new List<int>();
            switch (type)
            {
                case 5:
                    if (forceRank)
                    {
                        while (blackSpells[localRank].Length == 0)
                            localRank--;
                        for (int a = 0; a < blackSpells[localRank].Length; a++)
                            spellSelection.Add(blackSpells[localRank][a]);
                    }
                    else
                        for (int i = 0; i < localRank + 1; i++)
                            for (int a = 0; a < blackSpells[i].Length; a++)
                                spellSelection.Add(blackSpells[i][a]);
                    return spellSelection[rng.Next(0, spellSelection.Count)];

                case 6:
                    if (forceOffensive)
                    {
                        if (forceRank)
                        {
                            while (offensiveFaithSpells[localRank].Length == 0)
                                localRank--;
                            for (int a = 0; a < offensiveFaithSpells[localRank].Length; a++)
                                spellSelection.Add(offensiveFaithSpells[localRank][a]);
                        }
                        else
                            for (int i = 0; i < localRank + 1; i++)
                                for (int a = 0; a < offensiveFaithSpells[i].Length; a++)
                                    spellSelection.Add(offensiveFaithSpells[i][a]);
                    }
                    else
                    {
                        if (forceRank)
                        {
                            while (faithSpells[localRank].Length == 0)
                                localRank--;
                            for (int a = 0; a < faithSpells[localRank].Length; a++)
                                spellSelection.Add(faithSpells[localRank][a]);
                        }
                        else
                            for (int i = 0; i < localRank + 1; i++)
                                for (int a = 0; a < faithSpells[i].Length; a++)
                                    spellSelection.Add(faithSpells[i][a]);
                    }
                    return spellSelection[rng.Next(0, spellSelection.Count)];

                case 7:
                    if (forceRank)
                    {
                        while (darkSpells[localRank].Length == 0)
                            localRank--;
                        for (int a = 0; a < darkSpells[localRank].Length; a++)
                        {
                            spellSelection.Add(darkSpells[localRank][a]);
                        }
                    }
                    else
                        for (int i = 0; i < localRank + 1; i++)
                        {
                            for (int a = 0; a < darkSpells[i].Length; a++)
                            {
                                spellSelection.Add(darkSpells[i][a]);
                            }
                        }
                    return spellSelection[rng.Next(0, spellSelection.Count)];

                default:
                    return 38;
            }
        }

        public static byte[] getModelAssets(int c)
        {
            byte[] numArray = new byte[16];
            for (int index = 0; index < numArray.Length; ++index)
                numArray[index] = Randomizer.personDataV[Randomizer.charBlockStart + (long)(c * 80) + (long)index];
            return numArray;
        }

        public static byte[] getInfoAssets(int c)
        {
            byte[] numArray = new byte[14]
            {
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 18L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 19L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 22L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 23L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 24L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 25L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 27L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 28L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 30L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 32L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 33L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 38L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 39L],
        Randomizer.personDataV[Randomizer.charBlockStart + (long) (c * 80) + 42L]
            };
            if (numArray[9] == byte.MaxValue)
                numArray[9] = (byte)0;
            if (numArray[7] > (byte)12 || numArray[7] < (byte)1)
                numArray[7] = (byte)Randomizer.rng.Next(1, 13);
            if (numArray[8] == (byte)99)
                numArray[8] = (byte)Randomizer.rng.Next(1, 30);
            return numArray;
        }

        public static int getNameID(int c)
        {
            int num = (int)BitConverter.ToUInt16(new byte[2]
            {
        Randomizer.personData[Randomizer.charBlockStart + (long) (c * 80) + 18L],
        Randomizer.personData[Randomizer.charBlockStart + (long) (c * 80) + 19L]
            }, 0);
            if (num == 317)
                num = 647;
            if (num == 331)
                num = 317;
            if (num == 332)
                num = 318;
            if (num == 357)
                num = 343;
            if (num == 361)
                num = 72;
            if (num >= 550 && num <= 554)
                num = num - 550 + 1040;
            if (num == 49)
                num = 1045;
            if (num == 48)
                num = 1046;
            return num;
        }

        public static int[] shuffleAssets(bool restrictGender, bool restrictAge, Settings settings)
        {
            List<int[]> youngMan = new List<int[]>();
            List<int[]> youngWoman = new List<int[]>();
            List<int[]> adultMan = new List<int[]>();
            List<int[]> adultWoman = new List<int[]>();
            List<int[]> oldMan = new List<int[]>();
            youngMan.Add(new int[1] { 0 });
            youngWoman.Add(new int[1] { 1 });
            youngWoman.Add(new int[3] { 2, 99, 643 });
            youngMan.Add(new int[2] { 3, 644 });
            youngMan.Add(new int[2] { 4, 645 });
            youngMan.Add(new int[1] { 5 });
            youngMan.Add(new int[1] { 6 });
            youngMan.Add(new int[1] { 7 });
            youngMan.Add(new int[1] { 8 });
            youngWoman.Add(new int[1] { 9 });
            youngWoman.Add(new int[1] { 10 });
            youngWoman.Add(new int[1] { 11 });
            youngMan.Add(new int[1] { 12 });
            youngMan.Add(new int[1] { 13 });
            youngMan.Add(new int[1] { 14 });
            youngMan.Add(new int[1] { 15 });
            youngWoman.Add(new int[1] { 16 });
            youngWoman.Add(new int[1] { 17 });
            youngWoman.Add(new int[1] { 18 });
            youngMan.Add(new int[1] { 19 });
            youngMan.Add(new int[1] { 20 });
            youngMan.Add(new int[1] { 21 });
            youngWoman.Add(new int[1] { 22 });
            youngWoman.Add(new int[1] { 23 });
            youngWoman.Add(new int[1] { 24 });
            youngWoman.Add(new int[1] { 25 });
            adultMan.Add(new int[1] { 26 });
            youngWoman.Add(new int[1] { 27 });
            oldMan.Add(new int[1] { 28 });
            adultWoman.Add(new int[1] { 29 });
            oldMan.Add(new int[2] { 30, 86 });
            adultMan.Add(new int[1] { 31 });
            adultWoman.Add(new int[1] { 32 });
            adultWoman.Add(new int[1] { 33 });
            youngMan.Add(new int[1] { 34 });
            adultMan.Add(new int[1] { 35 });
            adultWoman.Add(new int[1] { 36 });
            youngWoman.Add(new int[3] { 37, 679, 1005 });
            youngWoman.Add(new int[1] { 38 });
            oldMan.Add(new int[1] { 39 });
            adultMan.Add(new int[1] { 40 });
            adultWoman.Add(new int[1] { 41 });
            adultMan.Add(new int[1] { 42 });
            adultMan.Add(new int[1] { 43 });
            oldMan.Add(new int[1] { 44 });
            adultMan.Add(new int[1] { 45 });
            adultMan.Add(new int[1] { 46 });
            youngWoman.Add(new int[2] { 47, 98 });
            adultMan.Add(new int[1] { 49 });
            adultMan.Add(new int[1] { 50 });
            adultWoman.Add(new int[1] { 51 });
            adultMan.Add(new int[2] { 52, 565 });
            youngWoman.Add(new int[1] { 53 });
            adultMan.Add(new int[1] { 54 });
            oldMan.Add(new int[1] { 55 });
            oldMan.Add(new int[1] { 56 });
            adultWoman.Add(new int[1] { 58 });
            youngMan.Add(new int[1] { 70 });
            youngWoman.Add(new int[1] { 71 });
            oldMan.Add(new int[1] { 72 });
            oldMan.Add(new int[2] { 73, 559 });
            youngWoman.Add(new int[1] { 74 });
            adultMan.Add(new int[1] { 75 });
            adultMan.Add(new int[1] { 80 });
            adultWoman.Add(new int[1] { 81 });
            oldMan.Add(new int[1] { 82 });
            adultMan.Add(new int[1] { 83 });
            adultMan.Add(new int[2] { 84, 85 });
            adultWoman.Add(new int[1] { 220 });
            youngWoman.Add(new int[1] { 646 });
            adultMan.Add(new int[1] { 647 });
            adultWoman.Add(new int[1] { 681 });
            youngMan.Add(new int[1] { 1040 });
            adultMan.Add(new int[1] { 1041 });
            youngWoman.Add(new int[1] { 1042 });
            youngWoman.Add(new int[1] { 1043 });
            adultMan.Add(new int[3] { 1044, 167, 1168 });
            adultMan.Add(new int[1] { 1045 });
            adultWoman.Add(new int[3] { 1046, 48, 1038 });

            List<int[]> men = new List<int[]>();
            men.AddRange(youngMan);
            men.AddRange(adultMan);
            men.AddRange(oldMan);

            List<int[]> women = new List<int[]>();
            women.AddRange(youngWoman);
            women.AddRange(adultWoman);

            List<int[]> young = new List<int[]>();
            young.AddRange(youngMan);
            young.AddRange(youngWoman);

            List<int[]> adult = new List<int[]>();
            adult.AddRange(adultMan);
            adult.AddRange(adultWoman);

            List<int[]> all = new List<int[]>();
            all.AddRange(youngMan);
            all.AddRange(youngWoman);
            all.AddRange(adultMan);
            all.AddRange(adultWoman);
            all.AddRange(oldMan);

            int[] newAssetID = new int[1050];

            if (restrictGender)
            {
                if (restrictAge)
                {
                    shuffleAssets(youngMan, 0, ref newAssetID, settings);//17
                    shuffleAssets(youngWoman, 1, ref newAssetID, settings);//20
                    shuffleAssets(adultMan, 0, ref newAssetID, settings);//19
                    shuffleAssets(adultWoman, 1, ref newAssetID, settings);//10
                    shuffleAssets(oldMan, 0, ref newAssetID, settings);//9
                }
                else
                {
                    shuffleAssets(men, 0, ref newAssetID, settings);
                    shuffleAssets(women, 1, ref newAssetID, settings);
                }
            }
            else
            {
                if (restrictAge)
                {
                    shuffleAssets(young, -1, ref newAssetID, settings);
                    shuffleAssets(adult, -1, ref newAssetID, settings);
                    shuffleAssets(oldMan, -1, ref newAssetID, settings);
                }
                else
                    shuffleAssets(all, -1, ref newAssetID, settings);
            }

            return newAssetID;
        }

        public static void shuffleAssets(List<int[]> characterArrayList, int gender, ref int[] newAssetID, Settings settings)
        {
            List<int[]> numArrayList = new List<int[]>((IEnumerable<int[]>)characterArrayList);
            foreach (int[] numArray in numArrayList)
            {
                int index1 = Randomizer.rng.Next(characterArrayList.Count);
                byte[] modelAssets = Randomizer.getModelAssets(characterArrayList[index1][0]);
                byte[] infoAssets = Randomizer.getInfoAssets(characterArrayList[index1][0]);
                while (numArray[0] == 0 && infoAssets[11] != (byte)0)
                {
                    index1 = Randomizer.rng.Next(characterArrayList.Count);
                    modelAssets = Randomizer.getModelAssets(characterArrayList[index1][0]);
                    infoAssets = Randomizer.getInfoAssets(characterArrayList[index1][0]);
                }
                while (numArray[0] == 1 && infoAssets[11] != (byte)1)
                {
                    index1 = Randomizer.rng.Next(characterArrayList.Count);
                    modelAssets = Randomizer.getModelAssets(characterArrayList[index1][0]);
                    infoAssets = Randomizer.getInfoAssets(characterArrayList[index1][0]);
                }
                newAssetID[numArray[0]] = characterArrayList[index1][0];
                characterArrayList.RemoveAt(index1);
                foreach (int num in numArray)
                {
                    for (int index2 = 0; index2 < modelAssets.Length; ++index2)
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + (long)index2] = modelAssets[index2];
                    if (!(msgLoaded && settings.changeMsg && settings.baseText))
                    {
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 18L] = infoAssets[0];
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 19L] = infoAssets[1];
                    }
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 22L] = infoAssets[2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 23L] = infoAssets[3];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 24L] = infoAssets[4];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 25L] = infoAssets[5];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 27L] = infoAssets[6];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 28L] = infoAssets[7];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 30L] = infoAssets[8];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 38L] = infoAssets[11];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 39L] = infoAssets[12];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 42L] = infoAssets[13];
                }
            }
        }

        public static void assetsPlayable()
        {
            List<int[]> numArrayList = new List<int[]>();
            numArrayList.Add(new int[4] { 2, 71, 99, 643 });
            numArrayList.Add(new int[1] { 5 });
            numArrayList.Add(new int[1] { 6 });
            numArrayList.Add(new int[1] { 7 });
            numArrayList.Add(new int[1] { 8 });
            numArrayList.Add(new int[1] { 9 });
            numArrayList.Add(new int[1] { 10 });
            numArrayList.Add(new int[1] { 11 });
            numArrayList.Add(new int[3] { 3, 70, 644 });
            numArrayList.Add(new int[1] { 12 });
            numArrayList.Add(new int[1] { 13 });
            numArrayList.Add(new int[1] { 14 });
            numArrayList.Add(new int[1] { 15 });
            numArrayList.Add(new int[1] { 16 });
            numArrayList.Add(new int[1] { 17 });
            numArrayList.Add(new int[1] { 18 });
            numArrayList.Add(new int[2] { 4, 645 });
            numArrayList.Add(new int[1] { 19 });
            numArrayList.Add(new int[1] { 20 });
            numArrayList.Add(new int[1] { 21 });
            numArrayList.Add(new int[1] { 22 });
            numArrayList.Add(new int[1] { 23 });
            numArrayList.Add(new int[1] { 24 });
            numArrayList.Add(new int[1] { 25 });
            numArrayList.Add(new int[1] { 26 });
            numArrayList.Add(new int[1] { 27 });
            numArrayList.Add(new int[1] { 28 });
            numArrayList.Add(new int[1] { 29 });
            numArrayList.Add(new int[2] { 30, 86 });
            numArrayList.Add(new int[1] { 31 });
            numArrayList.Add(new int[1] { 32 });
            numArrayList.Add(new int[1] { 33 });
            numArrayList.Add(new int[1] { 34 });
            numArrayList.Add(new int[3] { 1045, 49, 1048 });
            if (Randomizer.includeDLC)
            {
                if (Randomizer.includeAnna)
                    numArrayList.Add(new int[3] { 1046, 48, 1038 });
                numArrayList.Add(new int[1] { 1040 });
                numArrayList.Add(new int[1] { 1041 });
                if (Randomizer.includeConstance)
                    numArrayList.Add(new int[1] { 1042 });
                numArrayList.Add(new int[1] { 1043 });
                numArrayList.Add(new int[1] { 1044 });
            }
            numArrayList.Add(new int[1]);
            numArrayList.Add(new int[1] { 1 });
            foreach (int[] numArray in new List<int[]>((IEnumerable<int[]>)numArrayList))
            {
                int index1 = Randomizer.rng.Next(numArrayList.Count);
                byte[] modelAssets = Randomizer.getModelAssets(numArrayList[index1][0]);
                byte[] infoAssets = Randomizer.getInfoAssets(numArrayList[index1][0]);
                if (numArray[0] == 0)
                {
                    for (; infoAssets[11] != (byte)0; infoAssets = Randomizer.getInfoAssets(numArrayList[index1][0]))
                    {
                        index1 = Randomizer.rng.Next(numArrayList.Count);
                        modelAssets = Randomizer.getModelAssets(numArrayList[index1][0]);
                    }
                }
                if (numArray[0] == 1)
                {
                    for (; infoAssets[11] != (byte)1; infoAssets = Randomizer.getInfoAssets(numArrayList[index1][0]))
                    {
                        index1 = Randomizer.rng.Next(numArrayList.Count);
                        modelAssets = Randomizer.getModelAssets(numArrayList[index1][0]);
                    }
                }
                numArrayList.RemoveAt(index1);
                foreach (int num in numArray)
                {
                    for (int index2 = 0; index2 < modelAssets.Length; ++index2)
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + (long)index2] = modelAssets[index2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 18L] = infoAssets[0];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 19L] = infoAssets[1];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 22L] = infoAssets[2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 23L] = infoAssets[3];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 24L] = infoAssets[4];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 25L] = infoAssets[5];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 27L] = infoAssets[6];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 28L] = infoAssets[7];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 30L] = infoAssets[8];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 38L] = infoAssets[11];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 39L] = infoAssets[12];
                }
            }
        }

        public static void assetsPlayableByGender()
        {
            List<int[]> numArrayList1 = new List<int[]>();
            List<int[]> numArrayList2 = new List<int[]>();
            numArrayList1.Add(new int[1]);
            numArrayList2.Add(new int[1] { 1 });
            numArrayList2.Add(new int[4] { 2, 71, 99, 643 });
            numArrayList1.Add(new int[3] { 3, 70, 644 });
            numArrayList1.Add(new int[2] { 4, 645 });
            numArrayList1.Add(new int[1] { 5 });
            numArrayList1.Add(new int[1] { 6 });
            numArrayList1.Add(new int[1] { 7 });
            numArrayList1.Add(new int[1] { 8 });
            numArrayList2.Add(new int[1] { 9 });
            numArrayList2.Add(new int[1] { 10 });
            numArrayList2.Add(new int[1] { 11 });
            numArrayList1.Add(new int[1] { 12 });
            numArrayList1.Add(new int[1] { 13 });
            numArrayList1.Add(new int[1] { 14 });
            numArrayList1.Add(new int[1] { 15 });
            numArrayList2.Add(new int[1] { 16 });
            numArrayList2.Add(new int[1] { 17 });
            numArrayList2.Add(new int[1] { 18 });
            numArrayList1.Add(new int[1] { 19 });
            numArrayList1.Add(new int[1] { 20 });
            numArrayList1.Add(new int[1] { 21 });
            numArrayList2.Add(new int[1] { 22 });
            numArrayList2.Add(new int[1] { 23 });
            numArrayList2.Add(new int[1] { 24 });
            numArrayList2.Add(new int[1] { 25 });
            numArrayList1.Add(new int[1] { 26 });
            numArrayList2.Add(new int[1] { 27 });
            numArrayList1.Add(new int[1] { 28 });
            numArrayList2.Add(new int[1] { 29 });
            numArrayList1.Add(new int[2] { 30, 86 });
            numArrayList1.Add(new int[1] { 31 });
            numArrayList2.Add(new int[1] { 32 });
            numArrayList2.Add(new int[1] { 33 });
            numArrayList1.Add(new int[1] { 34 });
            numArrayList1.Add(new int[3] { 1045, 49, 1048 });
            if (Randomizer.includeDLC)
            {
                if (Randomizer.includeAnna)
                    numArrayList2.Add(new int[3] { 1046, 48, 1038 });
                numArrayList1.Add(new int[1] { 1040 });
                numArrayList1.Add(new int[1] { 1041 });
                if (Randomizer.includeConstance)
                    numArrayList2.Add(new int[1] { 1042 });
                numArrayList2.Add(new int[1] { 1043 });
                numArrayList1.Add(new int[1] { 1044 });
            }
            List<int[]> numArrayList6 = new List<int[]>((IEnumerable<int[]>)numArrayList1);
            List<int[]> numArrayList7 = new List<int[]>((IEnumerable<int[]>)numArrayList2);
            foreach (int[] numArray in numArrayList6)
            {
                int index1 = Randomizer.rng.Next(numArrayList1.Count);
                byte[] modelAssets = Randomizer.getModelAssets(numArrayList1[index1][0]);
                byte[] infoAssets = Randomizer.getInfoAssets(numArrayList1[index1][0]);
                if (numArray[0] == 0)
                {
                    for (; infoAssets[11] != (byte)0; infoAssets = Randomizer.getInfoAssets(numArrayList1[index1][0]))
                    {
                        index1 = Randomizer.rng.Next(numArrayList1.Count);
                        modelAssets = Randomizer.getModelAssets(numArrayList1[index1][0]);
                    }
                }
                numArrayList1.RemoveAt(index1);
                foreach (int num in numArray)
                {
                    for (int index2 = 0; index2 < modelAssets.Length; ++index2)
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + (long)index2] = modelAssets[index2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 18L] = infoAssets[0];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 19L] = infoAssets[1];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 24L] = infoAssets[4];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 25L] = infoAssets[5];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 27L] = infoAssets[6];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 28L] = infoAssets[7];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 30L] = infoAssets[8];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 38L] = infoAssets[11];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 39L] = infoAssets[12];
                }
            }
            foreach (int[] numArray in numArrayList7)
            {
                int index1 = Randomizer.rng.Next(numArrayList2.Count);
                byte[] modelAssets = Randomizer.getModelAssets(numArrayList2[index1][0]);
                byte[] infoAssets = Randomizer.getInfoAssets(numArrayList2[index1][0]);
                if (numArray[0] == 1)
                {
                    for (; infoAssets[11] != (byte)1; infoAssets = Randomizer.getInfoAssets(numArrayList2[index1][0]))
                    {
                        index1 = Randomizer.rng.Next(numArrayList2.Count);
                        modelAssets = Randomizer.getModelAssets(numArrayList2[index1][0]);
                    }
                }
                numArrayList2.RemoveAt(index1);
                foreach (int num in numArray)
                {
                    for (int index2 = 0; index2 < modelAssets.Length; ++index2)
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + (long)index2] = modelAssets[index2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 18L] = infoAssets[0];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 19L] = infoAssets[1];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 24L] = infoAssets[4];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 25L] = infoAssets[5];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 27L] = infoAssets[6];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 28L] = infoAssets[7];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 30L] = infoAssets[8];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 38L] = infoAssets[11];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 39L] = infoAssets[12];
                }
            }
        }

        public static void assetsAll()
        {
            List<int[]> numArrayList = new List<int[]>();
            numArrayList.Add(new int[5] { 2, 71, 99, 643, 220 });
            numArrayList.Add(new int[1] { 5 });
            numArrayList.Add(new int[1] { 6 });
            numArrayList.Add(new int[1] { 7 });
            numArrayList.Add(new int[1] { 8 });
            numArrayList.Add(new int[1] { 9 });
            numArrayList.Add(new int[1] { 10 });
            numArrayList.Add(new int[1] { 11 });
            numArrayList.Add(new int[3] { 3, 70, 644 });
            numArrayList.Add(new int[1] { 12 });
            numArrayList.Add(new int[1] { 13 });
            numArrayList.Add(new int[1] { 14 });
            numArrayList.Add(new int[1] { 15 });
            numArrayList.Add(new int[1] { 16 });
            numArrayList.Add(new int[1] { 17 });
            numArrayList.Add(new int[1] { 18 });
            numArrayList.Add(new int[2] { 4, 645 });
            numArrayList.Add(new int[1] { 19 });
            numArrayList.Add(new int[1] { 20 });
            numArrayList.Add(new int[1] { 21 });
            numArrayList.Add(new int[1] { 22 });
            numArrayList.Add(new int[1] { 23 });
            numArrayList.Add(new int[1] { 24 });
            numArrayList.Add(new int[1] { 25 });
            numArrayList.Add(new int[1] { 26 });
            numArrayList.Add(new int[1] { 27 });
            numArrayList.Add(new int[1] { 28 });
            numArrayList.Add(new int[1] { 29 });
            numArrayList.Add(new int[2] { 30, 86 });
            numArrayList.Add(new int[1] { 31 });
            numArrayList.Add(new int[1] { 32 });
            numArrayList.Add(new int[1] { 33 });
            numArrayList.Add(new int[1] { 34 });
            numArrayList.Add(new int[3] { 1045, 49, 1048 });
            if (Randomizer.includeDLC)
            {
                if (Randomizer.includeAnna)
                    numArrayList.Add(new int[3] { 1046, 48, 1038 });
                numArrayList.Add(new int[1] { 1040 });
                numArrayList.Add(new int[1] { 1041 });
                if (Randomizer.includeConstance)
                    numArrayList.Add(new int[1] { 1042 });
                numArrayList.Add(new int[1] { 1043 });
                numArrayList.Add(new int[1] { 1044 });
            }
            numArrayList.Add(new int[1]);
            numArrayList.Add(new int[1] { 1 });
            numArrayList.Add(new int[1] { 35 });
            numArrayList.Add(new int[3] { 36, 58, 681 });
            numArrayList.Add(new int[3] { 37, 679, 1005 });
            numArrayList.Add(new int[1] { 38 });
            numArrayList.Add(new int[1] { 39 });
            numArrayList.Add(new int[1] { 40 });
            numArrayList.Add(new int[1] { 41 });
            numArrayList.Add(new int[1] { 42 });
            numArrayList.Add(new int[1] { 43 });
            numArrayList.Add(new int[1] { 44 });
            numArrayList.Add(new int[1] { 45 });
            numArrayList.Add(new int[1] { 46 });
            if (Randomizer.includeFEmp)
                numArrayList.Add(new int[1] { 47 });
            numArrayList.Add(new int[1] { 50 });
            numArrayList.Add(new int[1] { 51 });
            numArrayList.Add(new int[2] { 52, 565 });
            numArrayList.Add(new int[1] { 53 });
            numArrayList.Add(new int[1] { 54 });
            numArrayList.Add(new int[1] { 55 });
            numArrayList.Add(new int[1] { 56 });
            numArrayList.Add(new int[1] { 72 });
            numArrayList.Add(new int[2] { 73, 559 });
            numArrayList.Add(new int[1] { 74 });
            numArrayList.Add(new int[1] { 75 });
            numArrayList.Add(new int[1] { 80 });
            numArrayList.Add(new int[1] { 81 });
            numArrayList.Add(new int[1] { 82 });
            numArrayList.Add(new int[1] { 83 });
            numArrayList.Add(new int[2] { 84, 85 });
            if (Randomizer.includeMona)
            {
                numArrayList.Add(new int[1] { 300 });
                numArrayList.Add(new int[1] { 301 });
                numArrayList.Add(new int[1] { 302 });
                numArrayList.Add(new int[1] { 304 });
                numArrayList.Add(new int[1] { 305 });
                numArrayList.Add(new int[1] { 306 });
                numArrayList.Add(new int[1] { 307 });
                numArrayList.Add(new int[1] { 308 });
                numArrayList.Add(new int[1] { 309 });
                numArrayList.Add(new int[1] { 310 });
                numArrayList.Add(new int[1] { 311 });
                numArrayList.Add(new int[1] { 312 });
                numArrayList.Add(new int[1] { 313 });
                numArrayList.Add(new int[1] { 314 });
                numArrayList.Add(new int[1] { 315 });
                numArrayList.Add(new int[1] { 316 });
                numArrayList.Add(new int[1] { 317 });
                numArrayList.Add(new int[1] { 318 });
                numArrayList.Add(new int[1] { 647 });
                numArrayList.Add(new int[1] { 343 });
            }
            foreach (int[] numArray in new List<int[]>((IEnumerable<int[]>)numArrayList))
            {
                int index1 = Randomizer.rng.Next(numArrayList.Count);
                byte[] modelAssets = Randomizer.getModelAssets(numArrayList[index1][0]);
                byte[] infoAssets = Randomizer.getInfoAssets(numArrayList[index1][0]);
                if (numArray[0] == 0)
                {
                    for (; infoAssets[11] != (byte)0; infoAssets = Randomizer.getInfoAssets(numArrayList[index1][0]))
                    {
                        index1 = Randomizer.rng.Next(numArrayList.Count);
                        modelAssets = Randomizer.getModelAssets(numArrayList[index1][0]);
                    }
                }
                if (numArray[0] == 1)
                {
                    for (; infoAssets[11] != (byte)1; infoAssets = Randomizer.getInfoAssets(numArrayList[index1][0]))
                    {
                        index1 = Randomizer.rng.Next(numArrayList.Count);
                        modelAssets = Randomizer.getModelAssets(numArrayList[index1][0]);
                    }
                }
                numArrayList.RemoveAt(index1);
                foreach (int num in numArray)
                {
                    for (int index2 = 0; index2 < modelAssets.Length; ++index2)
                        Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + (long)index2] = modelAssets[index2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 18L] = infoAssets[0];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 19L] = infoAssets[1];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 22L] = infoAssets[2];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 23L] = infoAssets[3];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 24L] = infoAssets[4];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 25L] = infoAssets[5];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 27L] = infoAssets[6];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 28L] = infoAssets[7];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 30L] = infoAssets[8];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 38L] = infoAssets[11];
                    Randomizer.personData[Randomizer.charBlockStart + (long)(num * 80) + 39L] = infoAssets[12];
                }
            }
        }

        public static void fixConstance()
        {
            byte num1 = Randomizer.personData[105400];
            byte num2 = Randomizer.personData[105401];
            byte num3 = Randomizer.personData[105396];
            byte num4 = Randomizer.personData[105397];
            int uint16_1 = (int)BitConverter.ToUInt16(new byte[2]
            {
        num1,
        num2
            }, 0);
            int uint16_2 = (int)BitConverter.ToUInt16(new byte[2]
            {
        num3,
        num4
            }, 0);
            byte[] numArray1 = new byte[24];
            for (int index = 0; index < numArray1.Length; ++index)
                numArray1[index] = Randomizer.personData[Randomizer.charPortraitStart + 9972L + (long)index];
            byte[] numArray2 = new byte[24];
            for (int index = 0; index < numArray2.Length; ++index)
                numArray2[index] = Randomizer.personData[Randomizer.charPortraitStart + 10080L + (long)index];
            for (int index = 0; index < numArray1.Length; ++index)
                Randomizer.personData[Randomizer.charPortraitStart + 9990L + (long)index] = numArray1[index];
            for (int index = 0; index < numArray2.Length; ++index)
                Randomizer.personData[Randomizer.charPortraitStart + 10098L + (long)index] = numArray2[index];
        }

        public static void generateChangeLog()
        {
            if (Randomizer.personLoaded)
            {
                string[,] strArray = new string[42, 2]
                {
          {
            "Character Block 0: Male Byleth",
            ""
          },
          {
            "Character Block 1: Female Byleth",
            ""
          },
          {
            "Character Block 2: Edelgard",
            ""
          },
          {
            "Character Block 3: Dimitri",
            ""
          },
          {
            "Character Block 4: Claude/Khalid",
            ""
          },
          {
            "Character Block 5: Hubert",
            ""
          },
          {
            "Character Block 6: Ferdinand",
            ""
          },
          {
            "Character Block 7: Linhardt",
            ""
          },
          {
            "Character Block 8: Caspar",
            ""
          },
          {
            "Character Block 9: Bernadetta",
            ""
          },
          {
            "Character Block 10: Dorothea",
            ""
          },
          {
            "Character Block 11: Petra",
            ""
          },
          {
            "Character Block 12: Dedue",
            ""
          },
          {
            "Character Block 13: Felix",
            ""
          },
          {
            "Character Block 14: Ashe",
            ""
          },
          {
            "Character Block 15: Sylvain",
            ""
          },
          {
            "Character Block 16: Mercedes",
            ""
          },
          {
            "Character Block 17: Annette",
            ""
          },
          {
            "Character Block 18: Ingrid",
            ""
          },
          {
            "Character Block 19: Lorenz",
            ""
          },
          {
            "Character Block 20: Raphael",
            ""
          },
          {
            "Character Block 21: Ignatz",
            ""
          },
          {
            "Character Block 22: Lysithea",
            ""
          },
          {
            "Character Block 23: Marianne",
            ""
          },
          {
            "Character Block 24: Hilda",
            ""
          },
          {
            "Character Block 25: Leonie",
            ""
          },
          {
            "Character Block 26: Seteth",
            ""
          },
          {
            "Character Block 27: Flayn",
            ""
          },
          {
            "Character Block 28: Hanneman",
            ""
          },
          {
            "Character Block 29: Manuela",
            ""
          },
          {
            "Character Block 30: Gilbert",
            ""
          },
          {
            "Character Block 31: Alois",
            ""
          },
          {
            "Character Block 32: Catherine",
            ""
          },
          {
            "Character Block 33: Shamir",
            ""
          },
          {
            "Character Block 34: Cyril",
            ""
          },
          {
            "Character Block 1040: Yuri",
            ""
          },
          {
            "Character Block 1041: Balthus",
            ""
          },
          {
            "Character Block 1042: Constance",
            ""
          },
          {
            "Character Block 1043: Hapi",
            ""
          },
          {
            "Character Block 1044: Aelfric",
            ""
          },
          {
            "Character Block 1045: Jeritza",
            ""
          },
          {
            "Character Block 1046: Anna",
            ""
          }
                };
                if (Randomizer.chBases)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nBASES:\t\t" + Randomizer.personData[num + 43L].ToString() + " HP\t" + Randomizer.personData[num + 51L].ToString() + " STR\t" + Randomizer.personData[num + 52L].ToString() + " MAG\t" + Randomizer.personData[num + 53L].ToString() + " DEX\t" + Randomizer.personData[num + 54L].ToString() + " SPD\t" + Randomizer.personData[num + 55L].ToString() + " LCK\t" + Randomizer.personData[num + 56L].ToString() + " DEF\t" + Randomizer.personData[num + 57L].ToString() + " RES\t" + Randomizer.personData[num + 59L].ToString() + " CHA\t";
                    }
                    for (int index = 1040; index < 1047; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index - 1040 + 35, 1];
                        local = local + "\nBASES:\t\t" + Randomizer.personData[num + 43L].ToString() + " HP\t" + Randomizer.personData[num + 51L].ToString() + " STR\t" + Randomizer.personData[num + 52L].ToString() + " MAG\t" + Randomizer.personData[num + 53L].ToString() + " DEX\t" + Randomizer.personData[num + 54L].ToString() + " SPD\t" + Randomizer.personData[num + 55L].ToString() + " LCK\t" + Randomizer.personData[num + 56L].ToString() + " DEF\t" + Randomizer.personData[num + 57L].ToString() + " RES\t" + Randomizer.personData[num + 59L].ToString() + " CHA\t";
                    }
                }
                if (Randomizer.chCaps)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nCAPS:\t\t" + Randomizer.personData[num + 34L].ToString() + " HP\t" + Randomizer.personData[num + 69L].ToString() + " STR\t" + Randomizer.personData[num + 70L].ToString() + " MAG\t" + Randomizer.personData[num + 71L].ToString() + " DEX\t" + Randomizer.personData[num + 72L].ToString() + " SPD\t" + Randomizer.personData[num + 73L].ToString() + " LCK\t" + Randomizer.personData[num + 74L].ToString() + " DEF\t" + Randomizer.personData[num + 75L].ToString() + " RES\t" + Randomizer.personData[num + 77L].ToString() + " CHA\t";
                    }
                    for (int index = 1040; index < 1047; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index - 1040 + 35, 1];
                        local = local + "\nCAPS:\t\t" + Randomizer.personData[num + 34L].ToString() + " HP\t" + Randomizer.personData[num + 69L].ToString() + " STR\t" + Randomizer.personData[num + 70L].ToString() + " MAG\t" + Randomizer.personData[num + 71L].ToString() + " DEX\t" + Randomizer.personData[num + 72L].ToString() + " SPD\t" + Randomizer.personData[num + 73L].ToString() + " LCK\t" + Randomizer.personData[num + 74L].ToString() + " DEF\t" + Randomizer.personData[num + 75L].ToString() + " RES\t" + Randomizer.personData[num + 77L].ToString() + " CHA\t";
                    }
                }
                if (Randomizer.chGrowths)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nGROWTHS:\t" + Randomizer.personData[num + 41L].ToString() + " HP\t" + Randomizer.personData[num + 60L].ToString() + " STR\t" + Randomizer.personData[num + 61L].ToString() + " MAG\t" + Randomizer.personData[num + 62L].ToString() + " DEX\t" + Randomizer.personData[num + 63L].ToString() + " SPD\t" + Randomizer.personData[num + 64L].ToString() + " LCK\t" + Randomizer.personData[num + 65L].ToString() + " DEF\t" + Randomizer.personData[num + 66L].ToString() + " RES\t" + Randomizer.personData[num + 68L].ToString() + " CHA\t" + Randomizer.personData[num + 67L].ToString() + " MOV\t";
                    }
                    for (int index = 1040; index < 1047; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index - 1040 + 35, 1];
                        local = local + "\nGROWTHS:\t" + Randomizer.personData[num + 41L].ToString() + " HP\t" + Randomizer.personData[num + 60L].ToString() + " STR\t" + Randomizer.personData[num + 61L].ToString() + " MAG\t" + Randomizer.personData[num + 62L].ToString() + " DEX\t" + Randomizer.personData[num + 63L].ToString() + " SPD\t" + Randomizer.personData[num + 64L].ToString() + " LCK\t" + Randomizer.personData[num + 65L].ToString() + " DEF\t" + Randomizer.personData[num + 66L].ToString() + " RES\t" + Randomizer.personData[num + 68L].ToString() + " CHA\t" + Randomizer.personData[num + 67L].ToString() + " MOV\t";
                    }
                }
                if (Randomizer.chClasses)
                {
                    Dictionary<byte, string[]> dictionary = new Dictionary<byte, string[]>();
                    dictionary.Add((byte)0, new string[2]
                    {
            "Sword",
            "Lance"
                    });
                    dictionary.Add((byte)1, new string[2]
                    {
            "Sword",
            "Axe"
                    });
                    dictionary.Add((byte)2, new string[2]
                    {
            "Sword",
            "Bow"
                    });
                    dictionary.Add((byte)3, new string[2]
                    {
            "Sword",
            "Brawling"
                    });
                    dictionary.Add((byte)4, new string[2]
                    {
            "Sword",
            "Reason"
                    });
                    dictionary.Add((byte)5, new string[2]
                    {
            "Sword",
            "Faith"
                    });
                    dictionary.Add((byte)6, new string[2]
                    {
            "Sword",
            "Authority"
                    });
                    dictionary.Add((byte)10, new string[2]
                    {
            "Lance",
            "Axe"
                    });
                    dictionary.Add((byte)11, new string[2]
                    {
            "Lance",
            "Bow"
                    });
                    dictionary.Add((byte)12, new string[2]
                    {
            "Lance",
            "Brawling"
                    });
                    dictionary.Add((byte)13, new string[2]
                    {
            "Lance",
            "Reason"
                    });
                    dictionary.Add((byte)14, new string[2]
                    {
            "Lance",
            "Faith"
                    });
                    dictionary.Add((byte)15, new string[2]
                    {
            "Lance",
            "Authority"
                    });
                    dictionary.Add((byte)19, new string[2]
                    {
            "Axe",
            "Bow"
                    });
                    dictionary.Add((byte)20, new string[2]
                    {
            "Axe",
            "Brawling"
                    });
                    dictionary.Add((byte)21, new string[2]
                    {
            "Axe",
            "Reason"
                    });
                    dictionary.Add((byte)22, new string[2]
                    {
            "Axe",
            "Faith"
                    });
                    dictionary.Add((byte)23, new string[2]
                    {
            "Axe",
            "Authority"
                    });
                    dictionary.Add((byte)27, new string[2]
                    {
            "Bow",
            "Brawling"
                    });
                    dictionary.Add((byte)28, new string[2]
                    {
            "Bow",
            "Reason"
                    });
                    dictionary.Add((byte)29, new string[2]
                    {
            "Bow",
            "Faith"
                    });
                    dictionary.Add((byte)30, new string[2]
                    {
            "Bow",
            "Authority"
                    });
                    dictionary.Add((byte)34, new string[2]
                    {
            "Brawling",
            "Reason"
                    });
                    dictionary.Add((byte)35, new string[2]
                    {
            "Brawling",
            "Faith"
                    });
                    dictionary.Add((byte)36, new string[2]
                    {
            "Brawling",
            "Authority"
                    });
                    dictionary.Add((byte)40, new string[2]
                    {
            "Reason",
            "Faith"
                    });
                    dictionary.Add((byte)41, new string[2]
                    {
            "Reason",
            "Authority"
                    });
                    dictionary.Add((byte)45, new string[2]
                    {
            "Faith",
            "Authority"
                    });
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charWepRankStart + (long)index * Randomizer.charWepRankLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nCLASS:\t\t\t\t" + Randomizer.getClass((int)Randomizer.personData[num + 3L]) + "\nCERTIFIED CLASSES:\t" + Randomizer.getClass((int)Randomizer.personData[num + 4L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 5L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 6L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 7L]) + "\nPOST-TS CLASSES:\t" + Randomizer.getClass((int)Randomizer.personData[num + 31L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 32L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 33L]) + "\t\nWEAPON RANKS:\t\t" + Randomizer.rankOf((int)Randomizer.personData[num + 9L]) + " SWD\t" + Randomizer.rankOf((int)Randomizer.personData[num + 10L]) + " LNC\t" + Randomizer.rankOf((int)Randomizer.personData[num + 11L]) + " AXE\t" + Randomizer.rankOf((int)Randomizer.personData[num + 12L]) + " BOW\t" + Randomizer.rankOf((int)Randomizer.personData[num + 13L]) + " BRWL\t" + Randomizer.rankOf((int)Randomizer.personData[num + 14L]) + " REA\t" + Randomizer.rankOf((int)Randomizer.personData[num + 15L]) + " FAI\t" + Randomizer.rankOf((int)Randomizer.personData[num + 16L]) + " AUTH\t" + Randomizer.rankOf((int)Randomizer.personData[num + 17L]) + " ARM\t" + Randomizer.rankOf((int)Randomizer.personData[num + 18L]) + " RIDE\t" + Randomizer.rankOf((int)Randomizer.personData[num + 19L]) + " FLY\t";
                    }
                    for (int index = 38; index < 45; ++index)
                    {
                        long num = Randomizer.charWepRankStart + (long)index * Randomizer.charWepRankLen;
                        ref string local = ref strArray[index - 3, 1];
                        local = local + "\nCLASS:\t\t\t\t" + Randomizer.getClass((int)Randomizer.personData[num + 3L]) + "\nCERTIFIED CLASSES:\t" + Randomizer.getClass((int)Randomizer.personData[num + 4L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 5L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 6L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 7L]) + "\nPOST-TS CLASSES:\t" + Randomizer.getClass((int)Randomizer.personData[num + 31L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 32L]) + "\t" + Randomizer.getClass((int)Randomizer.personData[num + 33L]) + "\t\nWEAPON RANKS:\t\t" + Randomizer.rankOf((int)Randomizer.personData[num + 9L]) + " SWD\t" + Randomizer.rankOf((int)Randomizer.personData[num + 10L]) + " LNC\t" + Randomizer.rankOf((int)Randomizer.personData[num + 11L]) + " AXE\t" + Randomizer.rankOf((int)Randomizer.personData[num + 12L]) + " BOW\t" + Randomizer.rankOf((int)Randomizer.personData[num + 13L]) + " BRWL\t" + Randomizer.rankOf((int)Randomizer.personData[num + 14L]) + " REA\t" + Randomizer.rankOf((int)Randomizer.personData[num + 15L]) + " FAI\t" + Randomizer.rankOf((int)Randomizer.personData[num + 16L]) + " AUTH\t" + Randomizer.rankOf((int)Randomizer.personData[num + 17L]) + " ARM\t" + Randomizer.rankOf((int)Randomizer.personData[num + 18L]) + " RIDE\t" + Randomizer.rankOf((int)Randomizer.personData[num + 19L]) + " FLY\t";
                    }
                    for (int index = 0; index < 40; ++index)
                    {
                        ref string local = ref strArray[index + 2, 1];
                        local = local + "\nDEFAULT GOAL:\t\t" + dictionary[Randomizer.personData[Randomizer.charGoalStart + (long)index * Randomizer.charGoalLen]][0] + " " + dictionary[Randomizer.personData[Randomizer.charGoalStart + (long)index * Randomizer.charGoalLen]][1];
                    }
                }
                if (Randomizer.chFaculty)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charWepRankStart + (long)index * Randomizer.charWepRankLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nSTRENGTHS/FACULTY:\t" + Randomizer.getProfs(num + 20L, 3) + "\nWEAKNESSES:\t\t\t" + Randomizer.getProfs(num + 20L, 1);
                    }
                    for (int index = 38; index < 45; ++index)
                    {
                        long num = Randomizer.charWepRankStart + (long)index * Randomizer.charWepRankLen;
                        ref string local = ref strArray[index - 3, 1];
                        local = local + "\nSTRENGTHS/FACULTY:\t" + Randomizer.getProfs(num + 20L, 3) + "\nWEAKNESSES:\t\t\t" + Randomizer.getProfs(num + 20L, 1);
                    }
                }
                if (Randomizer.chSeminar)
                {
                    for (int index = 0; index < 42; ++index)
                    {
                        long iP = Randomizer.charSeminarStart + (long)index * Randomizer.charSeminarLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nSEMINAR STATS:\t\t" + Randomizer.getSeminar(iP);
                    }
                }
                if (Randomizer.chPersonalSkills)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charSkillStart + (long)index * Randomizer.charSkillLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nPRE-TS PERSONAL:\t" + Randomizer.getSkill((int)Randomizer.personData[num + 20L]) + "\nPOST-TS PERSONAL:\t" + Randomizer.getSkill((int)Randomizer.personData[num + 21L]);
                    }
                    for (int index = 38; index < 45; ++index)
                    {
                        long num = Randomizer.charSkillStart + (long)index * Randomizer.charSkillLen;
                        ref string local = ref strArray[index - 3, 1];
                        local = local + "\nPRE-TS PERSONAL:\t" + Randomizer.getSkill((int)Randomizer.personData[num + 20L]) + "\nPOST-TS PERSONAL:\t" + Randomizer.getSkill((int)Randomizer.personData[num + 21L]);
                    }
                }
                if (Randomizer.chMagic)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long learn = Randomizer.charSpellStart + (long)index * Randomizer.charSpellLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nFAITH SPELLS:\t" + Randomizer.getSpells(learn, learn + 10L) + "\nREASON SPELLS:\t" + Randomizer.getSpells(learn + 15L, learn + 5L);
                    }
                    for (int index = 38; index < 45; ++index)
                    {
                        long learn = Randomizer.charSpellStart + (long)index * Randomizer.charSpellLen;
                        ref string local = ref strArray[index - 3, 1];
                        local = local + "\nFAITH SPELLS:\t" + Randomizer.getSpells(learn, learn + 10L) + "\nREASON SPELLS:\t" + Randomizer.getSpells(learn + 15L, learn + 5L);
                    }
                }
                if (Randomizer.chCrests)
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nCRESTS:\t\t\t\t" + Randomizer.crestNames[(int)Randomizer.personData[num + 44L]] + "\t" + Randomizer.crestNames[(int)Randomizer.personData[num + 45L]];
                    }
                    for (int index = 1040; index < 1047; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index - 1040 + 35, 1];
                        local = local + "\nCRESTS:\t\t\t\t" + Randomizer.crestNames[(int)Randomizer.personData[num + 44L]] + "\t" + Randomizer.crestNames[(int)Randomizer.personData[num + 45L]];
                    }
                }
                if (Randomizer.chAge || Randomizer.chGender || (Randomizer.chBirthday || Randomizer.chHeight))
                {
                    for (int index = 0; index < 35; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index, 1];
                        local = local + "\nATTRIBUTES:\t\t\tAge:\t\t\t\t\t" + Randomizer.personData[num + 27L].ToString() + "\n\t\t\t\t\tGender:\t\t\t\t\t" + Randomizer.getGender((int)Randomizer.personData[num + 38L]) + "\n\t\t\t\t\tBirthday:\t\t\t\t" + Randomizer.personData[num + 30L].ToString() + "\n\t\t\t\t\tBirthmonth:\t\t\t\t" + Randomizer.personData[num + 28L].ToString() + "\n\t\t\t\t\tHeight (Pre-TS) (cm):\t" + Randomizer.personData[num + 47L].ToString() + "\n\t\t\t\t\tHeight (Post-TS) (cm):\t" + Randomizer.personData[num + 48L].ToString();
                    }
                    for (int index = 1040; index < 1047; ++index)
                    {
                        long num = Randomizer.charBlockStart + (long)index * Randomizer.charBlockLen;
                        ref string local = ref strArray[index - 1040 + 35, 1];
                        local = local + "\nATTRIBUTES:\t\t\tAge:\t\t\t\t\t" + Randomizer.personData[num + 27L].ToString() + "\n\t\t\t\t\tGender:\t\t\t\t\t" + Randomizer.getGender((int)Randomizer.personData[num + 38L]) + "\n\t\t\t\t\tBirthday:\t\t\t\t" + Randomizer.personData[num + 30L].ToString() + "\n\t\t\t\t\tBirthmonth:\t\t\t\t" + Randomizer.personData[num + 28L].ToString() + "\n\t\t\t\t\tHeight (Pre-TS) (cm):\t" + Randomizer.personData[num + 47L].ToString() + "\n\t\t\t\t\tHeight (Post-TS) (cm):\t" + Randomizer.personData[num + 48L].ToString();
                    }
                }
                Randomizer.changelog += "CHARACTER DATA\n\n";
                for (int index = 0; index < 42; ++index)
                    Randomizer.changelog = Randomizer.changelog + strArray[index, 0] + strArray[index, 1] + "\n\n";
                Randomizer.changelog += "\n";
            }
            if (Randomizer.classLoaded)
            {
                string[,] strArray = new string[92, 2]
                {
          {
            "Class Block 00: Noble",
            ""
          },
          {
            "Class Block 01: Commoner",
            ""
          },
          {
            "Class Block 02: Myrmidon",
            ""
          },
          {
            "Class Block 03: Soldier",
            ""
          },
          {
            "Class Block 04: Fighter",
            ""
          },
          {
            "Class Block 05: Monk",
            ""
          },
          {
            "Class Block 06: Lord",
            ""
          },
          {
            "Class Block 07: Mercenary",
            ""
          },
          {
            "Class Block 08: Thief",
            ""
          },
          {
            "Class Block 09: Armored Knight",
            ""
          },
          {
            "Class Block 10: Cavalier",
            ""
          },
          {
            "Class Block 11: Brigand",
            ""
          },
          {
            "Class Block 12: Archer",
            ""
          },
          {
            "Class Block 13: Brawler",
            ""
          },
          {
            "Class Block 14: Mage",
            ""
          },
          {
            "Class Block 15: Dark Mage",
            ""
          },
          {
            "Class Block 16: Priest",
            ""
          },
          {
            "Class Block 17: Barbarossa",
            ""
          },
          {
            "Class Block 18: Hero",
            ""
          },
          {
            "Class Block 19: Swordmaster",
            ""
          },
          {
            "Class Block 20: Assassin",
            ""
          },
          {
            "Class Block 21: Fortress Knight",
            ""
          },
          {
            "Class Block 22: Paladin",
            ""
          },
          {
            "Class Block 23: Pegasus Knight (Advanced)",
            ""
          },
          {
            "Class Block 24: Wyvern Rider",
            ""
          },
          {
            "Class Block 25: Warrior",
            ""
          },
          {
            "Class Block 26: Sniper",
            ""
          },
          {
            "Class Block 27: Grappler",
            ""
          },
          {
            "Class Block 28: Warlock",
            ""
          },
          {
            "Class Block 29: Dark Bishop",
            ""
          },
          {
            "Class Block 30: Bishop",
            ""
          },
          {
            "Class Block 31: Falcon Knight",
            ""
          },
          {
            "Class Block 32: Wyvern Lord",
            ""
          },
          {
            "Class Block 33: Mortal Savant",
            ""
          },
          {
            "Class Block 34: Great Knight",
            ""
          },
          {
            "Class Block 35: Bow Knight",
            ""
          },
          {
            "Class Block 36: Dark Knight",
            ""
          },
          {
            "Class Block 37: Holy Knight",
            ""
          },
          {
            "Class Block 38: War Master",
            ""
          },
          {
            "Class Block 39: Gremory",
            ""
          },
          {
            "Class Block 40: Emperor",
            ""
          },
          {
            "Class Block 41: Agastya",
            ""
          },
          {
            "Class Block 42: Enlightened One",
            ""
          },
          {
            "Class Block 43: Dancer",
            ""
          },
          {
            "Class Block 44: Great Lord",
            ""
          },
          {
            "Class Block 45: King of Liberation",
            ""
          },
          {
            "Class Block 46: Saint",
            ""
          },
          {
            "Class Block 47: Flame Emperor",
            ""
          },
          {
            "Class Block 48: Flame Emperor ",
            ""
          },
          {
            "Class Block 49: Thief ",
            ""
          },
          {
            "Class Block 50: Ruffian",
            ""
          },
          {
            "Class Block 51: Paladin ",
            ""
          },
          {
            "Class Block 52: Fortress Knight ",
            ""
          },
          {
            "Class Block 53: Lord ",
            ""
          },
          {
            "Class Block 54: Pegasus Knight (Intermediate)",
            ""
          },
          {
            "Class Block 55: Archbishop",
            ""
          },
          {
            "Class Block 56: Armored Lord",
            ""
          },
          {
            "Class Block 57: High Lord",
            ""
          },
          {
            "Class Block 58: Wyvern Master",
            ""
          },
          {
            "Class Block 59: Death Knight",
            ""
          },
          {
            "Class Block 60: Black Beast",
            ""
          },
          {
            "Class Block 61: Wandering Beast",
            ""
          },
          {
            "Class Block 62: Wild Demonic Beast",
            ""
          },
          {
            "Class Block 63: Demonic Beast",
            ""
          },
          {
            "Class Block 64: Exp Demonic Beast",
            ""
          },
          {
            "Class Block 65: Altered Demonic Beast",
            ""
          },
          {
            "Class Block 66: Giant Demonic Beast",
            ""
          },
          {
            "Class Block 67: Flying Demonic Beast",
            ""
          },
          {
            "Class Block 68: Golem",
            ""
          },
          {
            "Class Block 69: Altered Golem",
            ""
          },
          {
            "Class Block 70: Titanus",
            ""
          },
          {
            "Class Block 71: White Beast",
            ""
          },
          {
            "Class Block 72: The Immaculate One",
            ""
          },
          {
            "Class Block 73: The Immaculate One ",
            ""
          },
          {
            "Class Block 74: The Immaculate One  ",
            ""
          },
          {
            "Class Block 75: Lord of the Desert",
            ""
          },
          {
            "Class Block 76: Lord of the Lake",
            ""
          },
          {
            "Class Block 77: Giant Bird",
            ""
          },
          {
            "Class Block 78: Giant Crawler",
            ""
          },
          {
            "Class Block 79: Giant Wolf",
            ""
          },
          {
            "Class Block 80: Hegemon Husk",
            ""
          },
          {
            "Class Block 81: King of Beasts",
            ""
          },
          {
            "Class Block 82: King of Fangs",
            ""
          },
          {
            "Class Block 83: King of Wings",
            ""
          },
          {
            "Class Block 84: Trickster",
            ""
          },
          {
            "Class Block 85: War Monk",
            ""
          },
          {
            "Class Block 86: Dark Flier",
            ""
          },
          {
            "Class Block 87: Valkyrie",
            ""
          },
          {
            "Class Block 88: NONE",
            ""
          },
          {
            "Class Block 89: NONE",
            ""
          },
          {
            "Class Block 90: NONE",
            ""
          },
          {
            "Class Block 91: Death Knight",
            ""
          }
                };
                for (int index = 0; index < 92; ++index)
                {
                    if ((index < 59 || index > 83) && (index < 88 || index > 90))
                    {
                        long num = (long)((int)Randomizer.classCertStart + index * (int)Randomizer.classCertLen);
                        long blockMod = (long)((int)index * (int)Randomizer.classBlockLen);
                        long abMod = (long)((int)index * (int)Randomizer.classAbLen);
                        if (Randomizer.clWepRankReqs)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nCERTIFICATION REQS:\t" + Randomizer.rankOf((int)Randomizer.classData[num + 4L]) + " SWD\t" + Randomizer.rankOf((int)Randomizer.classData[num + 5L]) + " LNC\t" + Randomizer.rankOf((int)Randomizer.classData[num + 6L]) + " AXE\t" + Randomizer.rankOf((int)Randomizer.classData[num + 7L]) + " BOW\t" + Randomizer.rankOf((int)Randomizer.classData[num + 8L]) + " BRWL\t" + Randomizer.rankOf((int)Randomizer.classData[num + 9L]) + " REA\t" + Randomizer.rankOf((int)Randomizer.classData[num + 10L]) + " FAI\t" + Randomizer.rankOf((int)Randomizer.classData[num + 11L]) + " AUTH\t" + Randomizer.rankOf((int)Randomizer.classData[num + 12L]) + " ARM\t" + Randomizer.rankOf((int)Randomizer.classData[num + 13L]) + " RIDE\t" + Randomizer.rankOf((int)Randomizer.classData[num + 14L]) + " FLY\t";
                        }
                        if (Randomizer.clBoosts)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nSTAT BOOSTS:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 16L] + " HP\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 39L] + " STR\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 40L] + " MAG\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 41L] + " DEX\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 42L] + " SPD\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 43L] + " LCK\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 44L] + " DEF\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 45L] + " RES\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 47L] + " CHA\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 46L] + " MOV\t";
                        }
                        if (Randomizer.clEnemyGrowths)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nENEMY STAT GROWTHS:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 19L] + " HP\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 30L] + " STR\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 31L] + " MAG\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 32L] + " DEX\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 33L] + " SPD\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 34L] + " LCK\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 35L] + " DEF\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 36L] + " RES\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 38L] + " CHA\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 37L] + " MOV\t";
                        }
                        if (Randomizer.clPlayerGrowths)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nPLAYER STAT GROWTHS:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 20L] + " HP\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 21L] + " STR\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 22L] + " MAG\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 23L] + " DEX\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 24L] + " SPD\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 25L] + " LCK\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 26L] + " DEF\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 27L] + " RES\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 29L] + " CHA\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 28L] + " MOV\t";
                        }
                        if (Randomizer.clMountBoosts)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nMOUNTING BOOSTS:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 48L] + " STR\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 49L] + " MAG\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 50L] + " DEX\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 51L] + " SPD\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 52L] + " LCK\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 53L] + " DEF\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 54L] + " RES\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 56L] + " CHA\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 55L] + " MOV\t";
                        }
                        if (Randomizer.clPros)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nPROFICIENCIES:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 57L] + " SWD\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 58L] + " LNC\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 59L] + " AXE\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 60L] + " BOW\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 61L] + " BRWL\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 62L] + " REA\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 63L] + " FAI\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 64L] + " AUTH\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 65L] + " ARM\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 66L] + " RIDE\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 67L] + " FLY\t";
                        }
                        if (Randomizer.clMasteryReq)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nMASTERY EXP REQUIREMENT:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 74L];
                        }
                        if (Randomizer.clBases)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nBASE STATS:\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 75L] + " HP\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 85L] + " STR\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 86L] + " MAG\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 87L] + " DEX\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 88L] + " SPD\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 89L] + " LCK\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 90L] + " DEF\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 91L] + " RES\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 93L] + " CHA\t" +
                                              Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 92L] + " MOV\t";
                        }
                        if (Randomizer.clRemoveWeapon && Randomizer.clWeaponType)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nENEMY DEFAULT WEAPON TYPES:\t" +
                                              getWeaponType(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 79L]) + "\t" +
                                              getWeaponType(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 80L]) + "\t";
                            local = local + "\nENEMY DEFAULT SPELLS:\t" +
                                              getWeaponType(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 83L]) + "\t" +
                                              getWeaponType(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 84L]) + "\t";
                        }
                        if (Randomizer.clEnemyEqAb)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nENEMY DEFAULT EQUIPPED ABILITIES:\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 113L]) + "\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 114L]) + "\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 115L]) + "\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 116L]) + "\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classBlockStart + blockMod + 117L]) + "\t";
                        }
                        if (Randomizer.clMasteryAb)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nMASTERY ABILITY:\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classAbStart + abMod + 0L]) + "\t";
                        }
                        if (Randomizer.clAb)
                        {
                            ref string local = ref strArray[index, 1];
                            local = local + "\nCLASS ABILITIES:\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classAbStart + abMod + 2L]) + "\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classAbStart + abMod + 3L]) + "\t" +
                                              getSkill(Randomizer.classData[(long)Randomizer.classAbStart + abMod + 4L]) + "\t";
                        }
                    }
                }
                Randomizer.changelog += "CLASS DATA\n\n";
                for (int index = 0; index < 92; ++index)
                {
                    if ((index < 59 || index > 83) && (index < 88 || index > 90))
                    {
                        Randomizer.changelog = Randomizer.changelog + strArray[index, 0] + strArray[index, 1] + "\n\n";
                    }
                }
                Randomizer.changelog += "\n";
            }
            if (Randomizer.itemLoaded)
            {
                string[,] strArray1 = new string[191, 2]
                {
          {
            "Weapon Block 0: Unarmed",
            ""
          },
          {
            "Weapon Block 1: Broken Sword",
            ""
          },
          {
            "Weapon Block 2: Broken Lance",
            ""
          },
          {
            "Weapon Block 3: Broken Axe",
            ""
          },
          {
            "Weapon Block 4: Broken Bow",
            ""
          },
          {
            "Weapon Block 5: Broken Gauntlet",
            ""
          },
          {
            "Weapon Block 6: Iron Sword",
            ""
          },
          {
            "Weapon Block 7: Steel Sword",
            ""
          },
          {
            "Weapon Block 8: Silver Sword",
            ""
          },
          {
            "Weapon Block 9: Brave Sword",
            ""
          },
          {
            "Weapon Block 10: Killing Edge",
            ""
          },
          {
            "Weapon Block 11: Training Sword",
            ""
          },
          {
            "Weapon Block 12: Iron Lance",
            ""
          },
          {
            "Weapon Block 13: Steel Lance",
            ""
          },
          {
            "Weapon Block 14: Silver Lance",
            ""
          },
          {
            "Weapon Block 15: Brave Lance",
            ""
          },
          {
            "Weapon Block 16: Killer Lance",
            ""
          },
          {
            "Weapon Block 17: Training Lance",
            ""
          },
          {
            "Weapon Block 18: Iron Axe",
            ""
          },
          {
            "Weapon Block 19: Steel Axe",
            ""
          },
          {
            "Weapon Block 20: Silver Axe",
            ""
          },
          {
            "Weapon Block 21: Brave Axe",
            ""
          },
          {
            "Weapon Block 22: Killer Axe",
            ""
          },
          {
            "Weapon Block 23: Training Axe",
            ""
          },
          {
            "Weapon Block 24: Iron Bow",
            ""
          },
          {
            "Weapon Block 25: Steel Bow",
            ""
          },
          {
            "Weapon Block 26: Silver Bow",
            ""
          },
          {
            "Weapon Block 27: Brave Bow",
            ""
          },
          {
            "Weapon Block 28: Killer Bow",
            ""
          },
          {
            "Weapon Block 29: Training Bow",
            ""
          },
          {
            "Weapon Block 30: Iron Gauntlets",
            ""
          },
          {
            "Weapon Block 31: Steel Gauntlets",
            ""
          },
          {
            "Weapon Block 32: Silver Gauntlets",
            ""
          },
          {
            "Weapon Block 33: Training Gauntlets",
            ""
          },
          {
            "Weapon Block 34: Levin Sword",
            ""
          },
          {
            "Weapon Block 35: Bolt Axe",
            ""
          },
          {
            "Weapon Block 36: Magic Bow",
            ""
          },
          {
            "Weapon Block 37: Javalin",
            ""
          },
          {
            "Weapon Block 38: Short Spear",
            ""
          },
          {
            "Weapon Block 39: Spear",
            ""
          },
          {
            "Weapon Block 40: Hand Axe",
            ""
          },
          {
            "Weapon Block 41: Short Axe",
            ""
          },
          {
            "Weapon Block 42: Tomahawk",
            ""
          },
          {
            "Weapon Block 43: Longbow",
            ""
          },
          {
            "Weapon Block 44: Mini Bow",
            ""
          },
          {
            "Weapon Block 45: Armorslayer",
            ""
          },
          {
            "Weapon Block 46: Rapier",
            ""
          },
          {
            "Weapon Block 47: Horseslayer",
            ""
          },
          {
            "Weapon Block 48: Hammer",
            ""
          },
          {
            "Weapon Block 49: Blessed Lance",
            ""
          },
          {
            "Weapon Block 50: Blessed Bow",
            ""
          },
          {
            "Weapon Block 51: Devil Sword",
            ""
          },
          {
            "Weapon Block 52: Devil Axe",
            ""
          },
          {
            "Weapon Block 53: Wo Dao",
            ""
          },
          {
            "Weapon Block 54: Crescent Sickle",
            ""
          },
          {
            "Weapon Block 55: Sword of Seiros",
            ""
          },
          {
            "Weapon Block 56: Sword of Begalta",
            ""
          },
          {
            "Weapon Block 57: Sword of Moralta",
            ""
          },
          {
            "Weapon Block 58: Cursed Ashiya Sword",
            ""
          },
          {
            "Weapon Block 59: Sword or Zoltan",
            ""
          },
          {
            "Weapon Block 60: Thunderbrand",
            ""
          },
          {
            "Weapon Block 61: Blutgang",
            ""
          },
          {
            "Weapon Block 62: Sword of the Creator",
            ""
          },
          {
            "Weapon Block 63: Lance of Zoltan",
            ""
          },
          {
            "Weapon Block 64: Lance of Ruin",
            ""
          },
          {
            "Weapon Block 65: Areadbhar",
            ""
          },
          {
            "Weapon Block 66: Luin",
            ""
          },
          {
            "Weapon Block 67: Spear of Assal",
            ""
          },
          {
            "Weapon Block 68: Scythe of Sariel",
            ""
          },
          {
            "Weapon Block 69: Arrow of Indra",
            ""
          },
          {
            "Weapon Block 70: Freikugel",
            ""
          },
          {
            "Weapon Block 71: Crusher",
            ""
          },
          {
            "Weapon Block 72: Axe of Ukonvasara",
            ""
          },
          {
            "Weapon Block 73: Axe of Zoltan",
            ""
          },
          {
            "Weapon Block 74: Tathlum Bow",
            ""
          },
          {
            "Weapon Block 75: The Inexhaustiable",
            ""
          },
          {
            "Weapon Block 76: Bow of Zoltan",
            ""
          },
          {
            "Weapon Block 77: Failnaught",
            ""
          },
          {
            "Weapon Block 78: Dragon Claw",
            ""
          },
          {
            "Weapon Block 79: Mace",
            ""
          },
          {
            "Weapon Block 80: Athame",
            ""
          },
          {
            "Weapon Block 81: Ridill",
            ""
          },
          {
            "Weapon Block 82: Aymr",
            ""
          },
          {
            "Weapon Block 83: Dark Sword of The Creator",
            ""
          },
          {
            "Weapon Block 84: Venin Edge",
            ""
          },
          {
            "Weapon Block 85: Venin Lance",
            ""
          },
          {
            "Weapon Block 86: Venin Axe",
            ""
          },
          {
            "Weapon Block 87: Venin Bow",
            ""
          },
          {
            "Weapon Block 88: Mercurius",
            ""
          },
          {
            "Weapon Block 89: Gradivus",
            ""
          },
          {
            "Weapon Block 90: Hauteclere",
            ""
          },
          {
            "Weapon Block 91: Parthia",
            ""
          },
          {
            "Weapon Block 92: Killer Knuckles",
            ""
          },
          {
            "Weapon Block 93: Aura Knuckles",
            ""
          },
          {
            "Weapon Block 94: Rusted Sword Iron",
            ""
          },
          {
            "Weapon Block 95: Rusted Sword Steel",
            ""
          },
          {
            "Weapon Block 96: Rusted Sword Silver",
            ""
          },
          {
            "Weapon Block 97: Rusted Sword Brave",
            ""
          },
          {
            "Weapon Block 98: Rusted Sword Mercurius",
            ""
          },
          {
            "Weapon Block 99: Rusted Lance Iron",
            ""
          },
          {
            "Weapon Block 100: Rusted Lance Steel",
            ""
          },
          {
            "Weapon Block 101: Rusted Lance Silver",
            ""
          },
          {
            "Weapon Block 102: Rusted Lance Brave",
            ""
          },
          {
            "Weapon Block 103: Rusted Lance Gradivus",
            ""
          },
          {
            "Weapon Block 104: Rusted Axe Iron",
            ""
          },
          {
            "Weapon Block 105: Rusted Axe Steel",
            ""
          },
          {
            "Weapon Block 106: Rusted Axe Silver",
            ""
          },
          {
            "Weapon Block 107: Rusted Axe Brave",
            ""
          },
          {
            "Weapon Block 108: Rusted Axe Hauteclere",
            ""
          },
          {
            "Weapon Block 109: Rusted Bow Iron",
            ""
          },
          {
            "Weapon Block 110: Rusted Bow Steel",
            ""
          },
          {
            "Weapon Block 111: Rusted Bow Silver",
            ""
          },
          {
            "Weapon Block 112: Rusted Bow Brave",
            ""
          },
          {
            "Weapon Block 113: Rusted Bow Parthia",
            ""
          },
          {
            "Weapon Block 114: Rusted Gauntlets Iron",
            ""
          },
          {
            "Weapon Block 115: Rusted Gauntlets Steel",
            ""
          },
          {
            "Weapon Block 116: Rusted Gauntlets Silver",
            ""
          },
          {
            "Weapon Block 117: Rusted Gauntlets Dragon Claws",
            ""
          },
          {
            "Weapon Block 118: Iron Sword Plus",
            ""
          },
          {
            "Weapon Block 119: Steel Sword Plus",
            ""
          },
          {
            "Weapon Block 120: Silver Sword Plus",
            ""
          },
          {
            "Weapon Block 121: Brave Sword Plus",
            ""
          },
          {
            "Weapon Block 122: Killing Edge Plus",
            ""
          },
          {
            "Weapon Block 123: Training Sword Plus",
            ""
          },
          {
            "Weapon Block 124: Iron Lance Plus",
            ""
          },
          {
            "Weapon Block 125: Steel Lance Plus",
            ""
          },
          {
            "Weapon Block 126: Silver Lance Plus",
            ""
          },
          {
            "Weapon Block 127: Brave Lance Plus",
            ""
          },
          {
            "Weapon Block 128: Killer Lance Plus",
            ""
          },
          {
            "Weapon Block 129: Training Lance Plus",
            ""
          },
          {
            "Weapon Block 130: Iron Axe Plus",
            ""
          },
          {
            "Weapon Block 131: Steel Axe Plus",
            ""
          },
          {
            "Weapon Block 132: Silver Axe Plus",
            ""
          },
          {
            "Weapon Block 133: Brave Axe Plus",
            ""
          },
          {
            "Weapon Block 134: Killer Axe Plus",
            ""
          },
          {
            "Weapon Block 135: Training Axe Plus",
            ""
          },
          {
            "Weapon Block 136: Iron Bow Plus",
            ""
          },
          {
            "Weapon Block 137: Steel Bow Plus",
            ""
          },
          {
            "Weapon Block 138: Silver Bow Plus",
            ""
          },
          {
            "Weapon Block 139: Brave Bow Plus",
            ""
          },
          {
            "Weapon Block 140: Killer Bow Plus",
            ""
          },
          {
            "Weapon Block 141: Training Bow Plus",
            ""
          },
          {
            "Weapon Block 142: Iron Gauntlets Plus",
            ""
          },
          {
            "Weapon Block 143: Steel Gauntlets Plus",
            ""
          },
          {
            "Weapon Block 144: Silver Gauntlets Plus",
            ""
          },
          {
            "Weapon Block 145: Training Gauntlets Plus",
            ""
          },
          {
            "Weapon Block 146: Levin Sword Plus",
            ""
          },
          {
            "Weapon Block 147: Bolt Axe Plus",
            ""
          },
          {
            "Weapon Block 148: Magic Bow Plus",
            ""
          },
          {
            "Weapon Block 149: Javalin Plus",
            ""
          },
          {
            "Weapon Block 150: Short Spear Plus",
            ""
          },
          {
            "Weapon Block 151: Spear Plus",
            ""
          },
          {
            "Weapon Block 152: Hand Axe Plus",
            ""
          },
          {
            "Weapon Block 153: Short Axe Plus",
            ""
          },
          {
            "Weapon Block 154: Tomahawk Plus",
            ""
          },
          {
            "Weapon Block 155: Longbow Plus",
            ""
          },
          {
            "Weapon Block 156: Mini Bow Plus",
            ""
          },
          {
            "Weapon Block 157: Armorslayer Plus",
            ""
          },
          {
            "Weapon Block 158: Rapier Plus",
            ""
          },
          {
            "Weapon Block 159: Horseslayer Plus",
            ""
          },
          {
            "Weapon Block 160: Hammer Plus",
            ""
          },
          {
            "Weapon Block 161: Blessed Lance Plus",
            ""
          },
          {
            "Weapon Block 162: Blessed Bow Plus",
            ""
          },
          {
            "Weapon Block 163: Devil Sword Plus",
            ""
          },
          {
            "Weapon Block 164: Devil Axe Plus",
            ""
          },
          {
            "Weapon Block 165: Wo Dao Plus",
            ""
          },
          {
            "Weapon Block 166: Crescent Sickle Plus",
            ""
          },
          {
            "Weapon Block 167: Cursed Ashiya Sword Plus",
            ""
          },
          {
            "Weapon Block 168: Sword or Zoltan Plus",
            ""
          },
          {
            "Weapon Block 169: Lance of Zoltan Plus",
            ""
          },
          {
            "Weapon Block 170: Arrow of Indra Plus",
            ""
          },
          {
            "Weapon Block 171: Axe of Zoltan Plus",
            ""
          },
          {
            "Weapon Block 172: Bow of Zoltan Plus",
            ""
          },
          {
            "Weapon Block 173: Dragon Claw Plus",
            ""
          },
          {
            "Weapon Block 174: Mace Plus",
            ""
          },
          {
            "Weapon Block 175: Venin Edge Plus",
            ""
          },
          {
            "Weapon Block 176: Venin Lance Plus",
            ""
          },
          {
            "Weapon Block 177: Venin Axe Plus",
            ""
          },
          {
            "Weapon Block 178: Venin Bow Plus",
            ""
          },
          {
            "Weapon Block 179: Killer Knuckles Plus",
            ""
          },
          {
            "Weapon Block 180: Aura Knuckles Plus",
            ""
          },
          {
            "Weapon Block 181: Sublime Sword of the Creator",
            ""
          },
          {
            "Weapon Block 182: Dark Thunderbrand",
            ""
          },
          {
            "Weapon Block 183: Dark Blutgang",
            ""
          },
          {
            "Weapon Block 184: Dark Lance of Ruin",
            ""
          },
          {
            "Weapon Block 185: Dark Areadbhar",
            ""
          },
          {
            "Weapon Block 186: Dark Luin",
            ""
          },
          {
            "Weapon Block 187: Dark Freikugel",
            ""
          },
          {
            "Weapon Block 188: Dark Crusher",
            ""
          },
          {
            "Weapon Block 189: Dark Failnaught",
            ""
          },
          {
            "Weapon Block 190: Vajra-Mushti",
            ""
          }
                };
                string[,] strArray2 = new string[38, 2]
                {
          {
            "Spell Block 0: Fire",
            ""
          },
          {
            "Spell Block 1: Bolganone",
            ""
          },
          {
            "Spell Block 2: Ragnarok",
            ""
          },
          {
            "Spell Block 3: Thunder",
            ""
          },
          {
            "Spell Block 4: Thoron",
            ""
          },
          {
            "Spell Block 5: Bolting",
            ""
          },
          {
            "Spell Block 6: Wind",
            ""
          },
          {
            "Spell Block 7: Cutting Gale",
            ""
          },
          {
            "Spell Block 8: Excalibur",
            ""
          },
          {
            "Spell Block 9: Blizzard",
            ""
          },
          {
            "Spell Block 10: Fimbulvetr",
            ""
          },
          {
            "Spell Block 11: Sagittae",
            ""
          },
          {
            "Spell Block 12: Meteor",
            ""
          },
          {
            "Spell Block 13: Agneas Arrow",
            ""
          },
          {
            "Spell Block 14: Miasma Δ",
            ""
          },
          {
            "Spell Block 15: Mire Β",
            ""
          },
          {
            "Spell Block 16: Swarm Ζ",
            ""
          },
          {
            "Spell Block 17: Banshee Θ",
            ""
          },
          {
            "Spell Block 18: Death Γ",
            ""
          },
          {
            "Spell Block 19: Luna Λ",
            ""
          },
          {
            "Spell Block 20: Dark Spikes Τ",
            ""
          },
          {
            "Spell Block 21: Hades Ω",
            ""
          },
          {
            "Spell Block 22: Bohr Χ",
            ""
          },
          {
            "Spell Block 23: Quake Σ",
            ""
          },
          {
            "Spell Block 24: Heal",
            ""
          },
          {
            "Spell Block 25: Recover",
            ""
          },
          {
            "Spell Block 26: Physic",
            ""
          },
          {
            "Spell Block 27: Fortify",
            ""
          },
          {
            "Spell Block 28: Nosferatu",
            ""
          },
          {
            "Spell Block 29: Seraphim",
            ""
          },
          {
            "Spell Block 30: Aura",
            ""
          },
          {
            "Spell Block 31: Abraxas",
            ""
          },
          {
            "Spell Block 32: Torch",
            ""
          },
          {
            "Spell Block 33: Restore",
            ""
          },
          {
            "Spell Block 34: Ward",
            ""
          },
          {
            "Spell Block 35: Silence",
            ""
          },
          {
            "Spell Block 36: Rescue",
            ""
          },
          {
            "Spell Block 37: Warp",
            ""
          }
                };
                for (int index = 0; index < 191; ++index)
                {
                    long num = (long)((int)Randomizer.weaponBlockStart + index * (int)Randomizer.weaponBlockLen);
                    if (Randomizer.wepDura)
                    {
                        ref string local = ref strArray1[index, 1];
                        local = local + "\nDURABILITY:\t\t\t" + Randomizer.itemData[num + 11L].ToString();
                    }
                    if (Randomizer.wepMight)
                    {
                        ref string local = ref strArray1[index, 1];
                        local = local + "\nMIGHT:\t\t\t\t" + Randomizer.itemData[num + 16L].ToString();
                    }
                    if (Randomizer.wepHit)
                    {
                        ref string local = ref strArray1[index, 1];
                        local = local + "\nHIT:\t\t\t\t" + Randomizer.itemData[num + 17L].ToString();
                    }
                    if (Randomizer.wepCrit)
                    {
                        ref string local = ref strArray1[index, 1];
                        local = local + "\nCRIT:\t\t\t\t" + Randomizer.itemData[num + 18L].ToString();
                    }
                }
                for (int index = 0; index < 38; ++index)
                {
                    long num = (long)((int)Randomizer.magicBlockStart + index * (int)Randomizer.magicBlockLen);
                    if (Randomizer.splDura)
                    {
                        ref string local = ref strArray2[index, 1];
                        local = local + "\nDURABILITY:\t\t\t" + Randomizer.itemData[num + 11L].ToString();
                    }
                    if (Randomizer.splMight)
                    {
                        ref string local = ref strArray2[index, 1];
                        local = local + "\nMIGHT:\t\t\t\t" + Randomizer.itemData[num + 16L].ToString();
                    }
                    if (Randomizer.splHit)
                    {
                        ref string local = ref strArray2[index, 1];
                        local = local + "\nHIT:\t\t\t\t" + Randomizer.itemData[num + 17L].ToString();
                    }
                    if (Randomizer.splCrit)
                    {
                        ref string local = ref strArray2[index, 1];
                        local = local + "\nCRIT:\t\t\t\t" + Randomizer.itemData[num + 18L].ToString();
                    }
                }
                Randomizer.changelog += "WEAPON DATA\n\n";
                for (int index = 0; index < 191; ++index)
                    Randomizer.changelog = Randomizer.changelog + strArray1[index, 0] + strArray1[index, 1] + "\n\n";
                Randomizer.changelog += "\n";
                Randomizer.changelog += "SPELL DATA\n\n";
                for (int index = 0; index < 38; ++index)
                    Randomizer.changelog = Randomizer.changelog + strArray2[index, 0] + strArray2[index, 1] + "\n\n";
                Randomizer.changelog += "\n";
            }
            if (Randomizer.asGenderRestrict || Randomizer.asPlay || Randomizer.asAll)
            {
                Randomizer.changelog += "CHARACTER ASSETS\n\n";
                Dictionary<int, string> dictionary = new Dictionary<int, string>();
                dictionary.Add(0, "Male Byleth");
                dictionary.Add(1, "Female Byleth");
                dictionary.Add(2, "Edelgard");
                dictionary.Add(3, "Dimitri");
                dictionary.Add(4, "Claude/Khalid");
                dictionary.Add(5, "Hubert");
                dictionary.Add(6, "Ferdinand");
                dictionary.Add(7, "Linhardt");
                dictionary.Add(8, "Caspar");
                dictionary.Add(9, "Bernadetta");
                dictionary.Add(10, "Dorothea");
                dictionary.Add(11, "Petra");
                dictionary.Add(12, "Dedue");
                dictionary.Add(13, "Felix");
                dictionary.Add(14, "Ashe");
                dictionary.Add(15, "Sylvain");
                dictionary.Add(16, "Mercedes");
                dictionary.Add(17, "Annette");
                dictionary.Add(18, "Ingrid");
                dictionary.Add(19, "Lorenz");
                dictionary.Add(20, "Raphael");
                dictionary.Add(21, "Ignatz");
                dictionary.Add(22, "Lysithea");
                dictionary.Add(23, "Marianne");
                dictionary.Add(24, "Hilda");
                dictionary.Add(25, "Leonie");
                dictionary.Add(26, "Seteth");
                dictionary.Add(27, "Flayn");
                dictionary.Add(28, "Hanneman");
                dictionary.Add(29, "Manuela");
                dictionary.Add(30, "Gilbert");
                dictionary.Add(31, "Alois");
                dictionary.Add(32, "Catherine");
                dictionary.Add(33, "Shamir");
                dictionary.Add(34, "Cyril");
                dictionary.Add(1045, "Jeritza");
                dictionary.Add(1046, "Anna");
                dictionary.Add(1040, "Yuri");
                dictionary.Add(1041, "Balthus");
                dictionary.Add(1042, "Constance");
                dictionary.Add(1043, "Hapi");
                dictionary.Add(1044, "Aelfric");
                dictionary.Add(35, "Jeralt");
                dictionary.Add(36, "Rhea");
                dictionary.Add(37, "Sothis");
                dictionary.Add(38, "Kronya");
                dictionary.Add(39, "Solon");
                dictionary.Add(40, "Thales");
                dictionary.Add(41, "Cornelia");
                dictionary.Add(42, "Death Knight");
                dictionary.Add(43, "Kostas");
                dictionary.Add(44, "Lonato");
                dictionary.Add(45, "Miklan");
                dictionary.Add(46, "Randolph");
                dictionary.Add(47, "Flame Emperor");
                dictionary.Add(50, "Rodrigue");
                dictionary.Add(51, "Judith");
                dictionary.Add(52, "Nader/Nardel");
                dictionary.Add(53, "Monica");
                dictionary.Add(54, "Lord Arundel");
                dictionary.Add(55, "Tomas");
                dictionary.Add(56, "Nemesis");
                dictionary.Add(72, "Emperor Ionius IX");
                dictionary.Add(73, "Duke Aegir");
                dictionary.Add(74, "Fleche");
                dictionary.Add(75, "Lambert");
                dictionary.Add(80, "Metodey");
                dictionary.Add(81, "Ladislava");
                dictionary.Add(82, "Gwendal");
                dictionary.Add(83, "Acheron");
                dictionary.Add(84, "Pallardo");
                dictionary.Add(300, "Fishkeeper");
                dictionary.Add(301, "Greenhouse Keeper");
                dictionary.Add(302, "Head Chef");
                dictionary.Add(304, "Saint Statue Artisan");
                dictionary.Add(305, "Battalion Guildmaster");
                dictionary.Add(306, "Counselor");
                dictionary.Add(307, "Dining Hall Staff");
                dictionary.Add(308, "Stable Hand");
                dictionary.Add(309, "Choir Coordinator");
                dictionary.Add(310, "Tournament Organizer");
                dictionary.Add(311, "Trader");
                dictionary.Add(312, "Certification Proctor");
                dictionary.Add(313, "South Merchant");
                dictionary.Add(314, "East Merchant");
                dictionary.Add(315, "Dark Merchant");
                dictionary.Add(316, "Armorer");
                dictionary.Add(317, "Blacksmith");
                dictionary.Add(318, "Online Liason");
                dictionary.Add(343, "Item Shopkeeper");
                dictionary.Add(647, "Gatekeeper");
                foreach (KeyValuePair<int, string> keyValuePair in dictionary)
                    Randomizer.changelog = Randomizer.changelog + keyValuePair.Value + " --> " + dictionary[Randomizer.getNameID(keyValuePair.Key)] + "\n";
                Randomizer.changelog += "\n\n";
            }
            if (Randomizer.warnings.Equals(""))
                return;
            Randomizer.changelog += "WARNINGS\n\n";
            Randomizer.changelog += Randomizer.warnings.Substring(2);
        }

        public static string getGender(int i)
        {
            return i == 0 ? "Male" : "Female";
        }

        public static string getSpells(long learn, long spell)
        {
            string str = "";
            for (int index = 0; index < 5; ++index)
            {
                if (Randomizer.personData[spell + (long)index] == byte.MaxValue)
                    str = str + "\tNone @ " + Randomizer.rankOf((int)Randomizer.personData[learn + (long)index]);
                else
                    str = str + "\t" + Randomizer.spellNames[(int)Randomizer.personData[spell + (long)index]] + " @ " + Randomizer.rankOf((int)Randomizer.personData[learn + (long)index]);
            }
            return str;
        }

        public static string getClass(int id)
        {
            return id == (int)byte.MaxValue ? "None" : Randomizer.classNames[id];
        }

        public static string getProfs(long iP, int chk)
        {
            string str = "";
            if ((int)Randomizer.personData[iP] == chk)
                str += "Sword ";
            if ((int)Randomizer.personData[iP + 1L] == chk)
                str += "Lance ";
            if ((int)Randomizer.personData[iP + 2L] == chk)
                str += "Axe ";
            if ((int)Randomizer.personData[iP + 3L] == chk)
                str += "Bow ";
            if ((int)Randomizer.personData[iP + 4L] == chk)
                str += "Brawling ";
            if ((int)Randomizer.personData[iP + 5L] == chk)
                str += "Reason ";
            if ((int)Randomizer.personData[iP + 6L] == chk)
                str += "Faith ";
            if ((int)Randomizer.personData[iP + 7L] == chk)
                str += "Authority ";
            if ((int)Randomizer.personData[iP + 8L] == chk)
                str += "Armor ";
            if ((int)Randomizer.personData[iP + 9L] == chk)
                str += "Riding ";
            if ((int)Randomizer.personData[iP + 10L] == chk)
                str += "Flying ";
            return str == "" ? "None" : str;
        }

        public static string getSeminar(long iP)
        {
            string str = "";
            bool[] boolArray1 = Randomizer.ConvertByteToBoolArray(Randomizer.personData[iP]);
            bool[] boolArray2 = Randomizer.ConvertByteToBoolArray(Randomizer.personData[iP + 1L]);
            if (boolArray1[0])
                str += "Sword ";
            if (boolArray1[1])
                str += "Lance ";
            if (boolArray1[2])
                str += "Axe ";
            if (boolArray1[3])
                str += "Bow ";
            if (boolArray1[4])
                str += "Brawling ";
            if (boolArray1[5])
                str += "Reason ";
            if (boolArray1[6])
                str += "Faith ";
            if (boolArray1[7])
                str += "Authority ";
            if (boolArray2[0])
                str += "Armor ";
            if (boolArray2[1])
                str += "Riding ";
            if (boolArray2[2])
                str += "Flying ";
            return str == "" ? "None" : str;
        }

        public static string rankOf(int num)
        {
            string str = "";
            if (num < 2)
                str = "E";
            else if (num < 4)
                str = "D";
            else if (num < 6)
                str = "C";
            else if (num < 8)
                str = "B";
            else if (num < 10)
                str = "A";
            else if (num < 12)
                str = "S";
            if (num % 2 != 0)
                str += "+";
            return str;
        }

        private static bool[] ConvertByteToBoolArray(byte b)
        {
            bool[] flagArray = new bool[8];
            for (int index = 0; index < 8; ++index)
                flagArray[index] = ((int)b & 1 << index) != 0;
            return flagArray;
        }

        private static string getSkill(int id)
        {
            return id == (int)byte.MaxValue ? "Same^/None" : Randomizer.abilityNames[id];
        }

        private static string getWeaponType(int id)
        {
            string[] weaponTypes = { "Sword", "Lance", "Axe", "Bow", "Gauntlet", "Black Magic", "White Magic", "Dark Magic" };
            return weaponTypes[id];
        }
    }
}
