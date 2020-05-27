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

        [Description("Ecclesiasticus")]
        Ecclesiasticus = 211,

        [Description("Baruch")]
        IBaruk = 262,

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
        [Description("Sirach")]
        Sirach = 182,

        [Description("2 Baruch")]
        IIBaruk = 263,

        [Description("Josephus")]
        Josephus = 700,

        [Description("Reproof Tsegats")]
        ReproofOfTegats = 701,

        [Description("The Order of Zion")]
        OrderOfZion = 702,

        [Description("Abtils")]
        Abtils = 703,

        [Description("Gitzew")]
        Gitzew = 704,

        [Description("1st Book of Covenant")]
        ICovenant = 705,

        [Description("2nd Book of Covenant")]
        IICovenant = 706,

        [Description("Didascalia")]
        Didascalia = 707,

        //Lost Books
        [Description("The Gospel of the Birth of Mary")]
        GospelOfMary = 800,

        [Description("The Protevangelion")]
        Protevangelion = 801,

        [Description("The First Gospel of the Infancy of Jesus Christ")]
        IInfancyOfJesus = 802,

        [Description("Thoma's Gospel of the Infancy of Jesus Christ")]
        IIInfancyOfJesus = 803,

        [Description("The Epistle of Jesus Christ and Abgarus King of Edessa")]
        Abgarus = 804,

        [Description("The Gospel of Nicodemus")]
        Nicodemus = 805,

        [Description("The Apostles Creed")]
        ApostlesCreed = 806,

        [Description("Epistle to the Laodiceans")]
        Laodiceans = 807,

        [Description("Epistle to Seneca")]
        Seneca = 809,

        [Description("The Acts of Paul and Thecla")]
        ActsOfPaul = 810,

        [Description("The First Epistle of Clement to the Corinthians")]
        IClement = 811,

        [Description("The Second Epistle of Clement to the Corinthians")]
        IIClement = 812,

        [Description("The General Epistle of Barnabas")]
        Barnabas = 813,

        [Description("The Epistle of Ignatius to the Ephesians")]
        IgnatiusToEphesians = 814,

        [Description("The Epistle of Ignatius to the Magnesians")]
        IgnatiusToMagnesians = 815,

        [Description("The Epistle of Ignatius to the Trallians")]
        IgnatiusToTraliians = 816,

        [Description("The Epistle of Ignatius to the Romans")]
        IgnatiusToRomans = 817,

        [Description("The Epistle of Ignatius to the Philadelphians")]
        IgnatiusToPhiladelphia = 818,

        [Description("The Epistle of Ignatius to the Smyrnaeans")]
        IgnatiusToSmyrna = 819,

        [Description("The Epistle of Ignatius to Polycarp")]
        IgnatiusToPolycarp = 820,

        [Description("The Epistle of Polycarp to the Philippians")]
        PolycarpToPhilippians = 821,

        [Description("The Shepard of Hermas")]
        Hermas = 822,

        [Description("The Second book of Hermas, Called Commandments")]
        Commandments = 823,

        [Description("The Third book of Hermas, Called Similitudes")]
        Similitudes = 824,

        [Description("Letters of Herod and Pilate")]
        HerodAndPilate = 825,

        [Description("Lost Gospel According to Peter")]
        Peter = 826,

        [Description("First book of Adam and Eve")]
        IAdam = 827,

        [Description("Second book of Adam and Eve")]
        IIAdam = 828,

        [Description("Secrets of Enoch")]
        IIEnoch = 829,

        [Description("Psalm of Solomon")]
        PsalmsOfSolomon = 830,

        [Description("Odes of Solomon")]
        Ode = 831,

        [Description("Letter of Aristeas")]
        Aristeas = 832,

        [Description("Story of Ahikar")]
        Ahikar = 833,

        [Description("Testamant of the Twelve Patriarchs")]
        Patriarchs = 834,

        [Description("Testament of Reuben")]
        Reuben = 835,

        [Description("Testament of Simeon")]
        Simeon = 836,

        [Description("Testament of Levi")]
        Levi = 837,

        [Description("Testament of Judah")]
        Judah = 838,

        [Description("Testament of Issachar")]
        Issachar = 839,

        [Description("Testament of Zebulun")]
        Zebulan = 840,

        [Description("Testament of Dan")]
        Dan = 841,

        [Description("Testament of Naphtali")]
        Naphtali = 842,

        [Description("Testament of Gad")]
        Gad = 843,

        [Description("Testament of Asher")]
        Asher = 844,

        [Description("Testament of Joseph")]
        Joseph = 845,

        [Description("Testament of Benjamin")]
        Benjamin = 846,

        //Pseudepigrapha
        [Description("Apocalypse of Abraham")]
        Abraham = 900,

        [Description("Apocalypse of Moses")]
        Moses = 901,

        [Description("Martyrdom and Ascension of Isaiah")]
        MartyrdomIsaiah = 902,

        [Description("Joseph and Aseneth")]
        JosephAndAseneth = 903,

        [Description("Life of Adam and Eve")]
        AdamAndEve = 904,

        [Description("Lives of the Prophets")]
        Prophets = 905,

        [Description("Ladder of Jacob")]
        Jacob = 906,

        [Description("Jannes and Jambres")]
        JannesAndJambres = 907,

        [Description("History of the Captivity in Babylon")]
        Babylon = 908,

        [Description("History of the Rechabites")]
        Rechabites = 909,

        [Description("Eldad and Modad")]
        EldadAndModad = 910,

        [Description("History of Joseph the Carpenter")]
        JosephTheCarpenter = 911,

        [Description("Prayer of Joseph")]
        PrayerOfJoseph = 912,

        [Description("Prayer of Jacob")]
        PrayerOfJacob = 913,

        [Description("Vision of Ezra")]
        VisionOfEzra = 914
    }
}