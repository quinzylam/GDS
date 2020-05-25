using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GDS.Core.Models.Enums
{
    public enum BookList
    {
        [Description("Genesis")]
        Genesis = 10,

        [Description("Exodus")]
        Exodus = 20,

        [Description("Leviticus")]
        Leviticus = 30,

        [Description("Numbers")]
        Numbers = 40,

        [Description("Deuteronomy")]
        Deuteronomy = 50,

        [Description("Joshua")]
        Joshua = 60,

        [Description("Judges")]
        Judges = 70,

        [Description("Ruth")]
        Ruth = 80,

        [Description("1 Samuel")]
        ISamuel = 90,

        [Description("2 Samuel")]
        IISamuel = 100,

        [Description("1 Kings")]
        IKings = 110,

        [Description("2 Kings")]
        IIKings = 120,

        [Description("1 Chronicles")]
        IChronicles = 130,

        [Description("2 Chronicles")]
        IIChronicles = 140,

        [Description("Ezra")]
        Ezra = 150,

        [Description("Nehemiah")]
        Nehemiah = 160,

        [Description("Esther")]
        Esther = 170,

        [Description("Job")]
        Job = 180,

        [Description("Psalms")]
        Psalms = 190,

        [Description("Proverbs")]
        Proverbs = 200,

        [Description("Ecclesiastes")]
        Ecclesiastes = 210,

        [Description("Song of Solomon")]
        Songs = 220,

        [Description("Isaiah")]
        Isaiah = 230,

        [Description("Jeremiah")]
        Jeremiah = 240,

        [Description("Lamentations")]
        Lamentations = 250,

        [Description("Ezekiel")]
        Ezekiel = 260,

        [Description("Daniel")]
        Daniel = 270,

        [Description("Hosea")]
        Hosea = 280,

        [Description("Joel")]
        Joel = 290,

        [Description("Amos")]
        Amos = 300,

        [Description("Obadiah")]
        Obadiah = 310,

        [Description("Jonah")]
        Jonah = 320,

        [Description("Micah")]
        Micah = 330,

        [Description("Nahum")]
        Nahum = 340,

        [Description("Habakkuk")]
        Habakkuk = 350,

        [Description("Zephaniah")]
        Zephaniah = 360,

        [Description("Haggai")]
        Haggai = 370,

        [Description("Zechariah")]
        Zechariah = 380,

        [Description("Malachi")]
        Malachi = 390,

        [Description("Matthew")]
        Matthew = 400,

        [Description("Mark")]
        Mark = 410,

        [Description("Luke")]
        Luke = 420,

        [Description("John")]
        John = 430,

        [Description("Acts")]
        Acts = 440,

        [Description("Romans")]
        Romans = 450,

        [Description("1 Corinthians")]
        ICorinthians = 460,

        [Description("2 Corinthians")]
        IICorinthians = 470,

        [Description("Galatians")]
        Galatians = 480,

        [Description("Ephesians")]
        Ephesians = 490,

        [Description("Philippians")]
        Philippians = 500,

        [Description("Colossians")]
        Colossians = 510,

        [Description("1 Thessalonians")]
        IThessalonians = 520,

        [Description("2 Thessalonians")]
        IIThessalonians = 530,

        [Description("1 Timothy")]
        ITimothy = 540,

        [Description("2 Timothy")]
        IITimothy = 550,

        [Description("Titus")]
        Titus = 560,

        [Description("Philemon")]
        Philemon = 570,

        [Description("Hebrews")]
        Hebrews = 580,

        [Description("James")]
        James = 590,

        [Description("1 Peter")]
        IPeter = 600,

        [Description("2 Peter")]
        IIPeter = 610,

        [Description("1 John")]
        IJohn = 620,

        [Description("2 John")]
        IIJohn = 630,

        [Description("3 John")]
        IIIJohn = 640,

        [Description("Jude")]
        Jude = 650,

        [Description("Revelation")]
        Revelation = 660,

        //Apochraphe

        [Description("Tobit")]
        Tobit = 261,

        [Description("Judith")]
        Judith = 172,

        [Description("Additions to Esther")]
        AdditionsToEster = 171,

        [Description("Wisdom of Solomon")]
        Wisdom = 181,

        [Description("Sirach")]
        Sirach = 182,

        [Description("Ecclesiasticus")]
        Ecclesiasticus = 211,

        [Description("Baruch")]
        IBaruk = 262,

        [Description("2 Baruch")]
        IIBaruk = 263,

        [Description("Letter of Jeremiah")]
        LetterOfJeremiah = 241,

        [Description("Susanna")]
        Susanna = 272,

        [Description("Bel and the Dragon")]
        Bel = 273,

        [Description("1 Maccabees")]
        IMaccabees = 161,

        [Description("2 Maccabees")]
        IIMaccabees = 162,

        [Description("3 Maccabees")]
        IIIMaccabees = 163,

        [Description("4 Maccabees")]
        IIIIMaccabees = 164,

        [Description("1 Esdras")]
        IEsdras = 151,

        [Description("2 Esdras")]
        IIEsdras = 152,

        [Description("Prayer of Manasseh")]
        PrayerOfManasseh = 264,

        [Description("Prayer of Azariah")]
        PrayerOfAzariah = 271,

        [Description("Additional Psalm")]
        AdditionalPsalm = 191,

        //Extended

        [Description("Jubilees")]
        Jubilees = 51,

        [Description("Enoch")]
        Enoch = 52,

        [Description("Jasher")]
        Jasher = 53,

        //Ethopian
        [Description("Josephus")]
        Josephus,

        [Description("Reproof Tsegats")]
        ReproofOfTegats,

        [Description("The Order of Zion")]
        OrderOfZion,

        [Description("Abtils")]
        Abtils,

        [Description("Gitzew")]
        Gitzew,

        [Description("1st Book of Covenant")]
        ICovenant,

        [Description("2nd Book of Covenant")]
        IICovenant,

        [Description("Didascalia")]
        Didascalia,

        //Lost Books
        [Description("The Gospel of the Birth of Mary")]
        GospelOfMary,

        [Description("The Protevangelion")]
        Protevangelion,

        [Description("The First Gospel of the Infancy of Jesus Christ")]
        IInfancyOfJesus,

        [Description("Thoma's Gospel of the Infancy of Jesus Christ")]
        IIInfancyOfJesus,

        [Description("The Epistle of Jesus Christ and Abgarus King of Edessa")]
        Abgarus,

        [Description("The Gospel of Nicodemus")]
        Nicodemus,

        [Description("The Apostles Creed")]
        ApostlesCreed,

        [Description("Epistle to the Laodiceans")]
        Laodiceans,

        [Description("Epistle to Seneca")]
        Seneca,

        [Description("The Acts of Paul and Thecla")]
        ActsOfPaul,

        [Description("The First Epistle of Clement to the Corinthians")]
        IClement,

        [Description("The Second Epistle of Clement to the Corinthians")]
        IIClement,

        [Description("The General Epistle of Barnabas")]
        Barnabas,

        [Description("The Epistle of Ignatius to the Ephesians")]
        IgnatiusToEphesians,

        [Description("The Epistle of Ignatius to the Magnesians")]
        IgnatiusToMagnesians,

        [Description("The Epistle of Ignatius to the Trallians")]
        IgnatiusToTraliians,

        [Description("The Epistle of Ignatius to the Romans")]
        IgnatiusToRomans,

        [Description("The Epistle of Ignatius to the Philadelphians")]
        IgnatiusToPhiladelphia,

        [Description("The Epistle of Ignatius to the Smyrnaeans")]
        IgnatiusToSmyrna,

        [Description("The Epistle of Ignatius to Polycarp")]
        IgnatiusToPolycarp,

        [Description("The Epistle of Polycarp to the Philippians")]
        PolycarpToPhilippians,

        [Description("The Shepard of Hermas")]
        Hermas,

        [Description("The Second book of Hermas, Called Commandments")]
        Commandments,

        [Description("The Third book of Hermas, Called Similitudes")]
        Similitudes,

        [Description("Letters of Herod and Pilate")]
        HerodAndPilate,

        [Description("Lost Gospel According to Peter")]
        Peter,

        [Description("First book of Adam and Eve")]
        IAdam,

        [Description("Second book of Adam and Eve")]
        IIAdam,

        [Description("Secrets of Enoch")]
        IIEnoch,

        [Description("Psalm of Solomon")]
        PsalmsOfSolomon,

        [Description("Odes of Solomon")]
        Ode,

        [Description("Letter of Aristeas")]
        Aristeas,

        [Description("Story of Ahikar")]
        Ahikar,

        [Description("Testamant of the Twelve Patriarchs")]
        Patriarchs,

        [Description("Testament of Reuben")]
        Reuben,

        [Description("Testament of Simeon")]
        Simeon,

        [Description("Testament of Levi")]
        Levi,

        [Description("Testament of Judah")]
        Judah,

        [Description("Testament of Issachar")]
        Issachar,

        [Description("Testament of Zebulun")]
        Zebulan,

        [Description("Testament of Dan")]
        Dan,

        [Description("Testament of Naphtali")]
        Naphtali,

        [Description("Testament of Gad")]
        Gad,

        [Description("Testament of Asher")]
        Asher,

        [Description("Testament of Joseph")]
        Joseph,

        [Description("Testament of Benjamin")]
        Benjamin,

        //Pseudepigrapha
        [Description("Apocalypse of Abraham")]
        Abraham,

        [Description("Apocalypse of Moses")]
        Moses,

        [Description("Martyrdom and Ascension of Isaiah")]
        MartyrdomIsaiah,

        [Description("Joseph and Aseneth")]
        JosephAndAseneth,

        [Description("Life of Adam and Eve")]
        AdamAndEve,

        [Description("Lives of the Prophets")]
        Prophets,

        [Description("Ladder of Jacob")]
        Jacob,

        [Description("Jannes and Jambres")]
        JannesAndJambres,

        [Description("History of the Captivity in Babylon")]
        Babylon,

        [Description("History of the Rechabites")]
        Rechabites,

        [Description("Eldad and Modad")]
        EldadAndModad,

        [Description("History of Joseph the Carpenter")]
        JosephTheCarpenter,

        [Description("Prayer of Joseph")]
        PrayerOfJoseph,

        [Description("Prayer of Jacob")]
        PrayerOfJacob,

        [Description("Vision of Ezra")]
        VisionOfEzra
    }
}