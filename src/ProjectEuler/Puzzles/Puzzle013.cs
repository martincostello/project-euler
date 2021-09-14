// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Numerics;

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=13</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle013 : Puzzle
{
    /// <summary>
    /// The numbers to use to solve the puzzle. This field is read-only.
    /// </summary>
    private static readonly BigInteger[] Numbers = BuildNumbers();

    /// <inheritdoc />
    public override string Question => "What are the first ten digits of the sum of the one-hundred 50-digit numbers?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        BigInteger sum = BigInteger.Zero;

        for (int i = 0; i < Numbers.Length; i++)
        {
            sum += Numbers[i];
        }

        Answer = sum
            .ToString(CultureInfo.InvariantCulture)
            .Substring(0, 10);

        return 0;
    }

    /// <summary>
    /// Returns an <see cref="Array"/> that contains the numbers to use to solve the puzzle.
    /// </summary>
    /// <returns>
    /// An <see cref="Array"/> that contains the numbers to use to solve the puzzle.
    /// </returns>
    private static BigInteger[] BuildNumbers()
    {
        return new[]
        {
            BigInteger.Parse("37107287533902102798797998220837590246510135740250", CultureInfo.InvariantCulture),
            BigInteger.Parse("46376937677490009712648124896970078050417018260538", CultureInfo.InvariantCulture),
            BigInteger.Parse("74324986199524741059474233309513058123726617309629", CultureInfo.InvariantCulture),
            BigInteger.Parse("91942213363574161572522430563301811072406154908250", CultureInfo.InvariantCulture),
            BigInteger.Parse("23067588207539346171171980310421047513778063246676", CultureInfo.InvariantCulture),
            BigInteger.Parse("89261670696623633820136378418383684178734361726757", CultureInfo.InvariantCulture),
            BigInteger.Parse("28112879812849979408065481931592621691275889832738", CultureInfo.InvariantCulture),
            BigInteger.Parse("44274228917432520321923589422876796487670272189318", CultureInfo.InvariantCulture),
            BigInteger.Parse("47451445736001306439091167216856844588711603153276", CultureInfo.InvariantCulture),
            BigInteger.Parse("70386486105843025439939619828917593665686757934951", CultureInfo.InvariantCulture),
            BigInteger.Parse("62176457141856560629502157223196586755079324193331", CultureInfo.InvariantCulture),
            BigInteger.Parse("64906352462741904929101432445813822663347944758178", CultureInfo.InvariantCulture),
            BigInteger.Parse("92575867718337217661963751590579239728245598838407", CultureInfo.InvariantCulture),
            BigInteger.Parse("58203565325359399008402633568948830189458628227828", CultureInfo.InvariantCulture),
            BigInteger.Parse("80181199384826282014278194139940567587151170094390", CultureInfo.InvariantCulture),
            BigInteger.Parse("35398664372827112653829987240784473053190104293586", CultureInfo.InvariantCulture),
            BigInteger.Parse("86515506006295864861532075273371959191420517255829", CultureInfo.InvariantCulture),
            BigInteger.Parse("71693888707715466499115593487603532921714970056938", CultureInfo.InvariantCulture),
            BigInteger.Parse("54370070576826684624621495650076471787294438377604", CultureInfo.InvariantCulture),
            BigInteger.Parse("53282654108756828443191190634694037855217779295145", CultureInfo.InvariantCulture),
            BigInteger.Parse("36123272525000296071075082563815656710885258350721", CultureInfo.InvariantCulture),
            BigInteger.Parse("45876576172410976447339110607218265236877223636045", CultureInfo.InvariantCulture),
            BigInteger.Parse("17423706905851860660448207621209813287860733969412", CultureInfo.InvariantCulture),
            BigInteger.Parse("81142660418086830619328460811191061556940512689692", CultureInfo.InvariantCulture),
            BigInteger.Parse("51934325451728388641918047049293215058642563049483", CultureInfo.InvariantCulture),
            BigInteger.Parse("62467221648435076201727918039944693004732956340691", CultureInfo.InvariantCulture),
            BigInteger.Parse("15732444386908125794514089057706229429197107928209", CultureInfo.InvariantCulture),
            BigInteger.Parse("55037687525678773091862540744969844508330393682126", CultureInfo.InvariantCulture),
            BigInteger.Parse("18336384825330154686196124348767681297534375946515", CultureInfo.InvariantCulture),
            BigInteger.Parse("80386287592878490201521685554828717201219257766954", CultureInfo.InvariantCulture),
            BigInteger.Parse("78182833757993103614740356856449095527097864797581", CultureInfo.InvariantCulture),
            BigInteger.Parse("16726320100436897842553539920931837441497806860984", CultureInfo.InvariantCulture),
            BigInteger.Parse("48403098129077791799088218795327364475675590848030", CultureInfo.InvariantCulture),
            BigInteger.Parse("87086987551392711854517078544161852424320693150332", CultureInfo.InvariantCulture),
            BigInteger.Parse("59959406895756536782107074926966537676326235447210", CultureInfo.InvariantCulture),
            BigInteger.Parse("69793950679652694742597709739166693763042633987085", CultureInfo.InvariantCulture),
            BigInteger.Parse("41052684708299085211399427365734116182760315001271", CultureInfo.InvariantCulture),
            BigInteger.Parse("65378607361501080857009149939512557028198746004375", CultureInfo.InvariantCulture),
            BigInteger.Parse("35829035317434717326932123578154982629742552737307", CultureInfo.InvariantCulture),
            BigInteger.Parse("94953759765105305946966067683156574377167401875275", CultureInfo.InvariantCulture),
            BigInteger.Parse("88902802571733229619176668713819931811048770190271", CultureInfo.InvariantCulture),
            BigInteger.Parse("25267680276078003013678680992525463401061632866526", CultureInfo.InvariantCulture),
            BigInteger.Parse("36270218540497705585629946580636237993140746255962", CultureInfo.InvariantCulture),
            BigInteger.Parse("24074486908231174977792365466257246923322810917141", CultureInfo.InvariantCulture),
            BigInteger.Parse("91430288197103288597806669760892938638285025333403", CultureInfo.InvariantCulture),
            BigInteger.Parse("34413065578016127815921815005561868836468420090470", CultureInfo.InvariantCulture),
            BigInteger.Parse("23053081172816430487623791969842487255036638784583", CultureInfo.InvariantCulture),
            BigInteger.Parse("11487696932154902810424020138335124462181441773470", CultureInfo.InvariantCulture),
            BigInteger.Parse("63783299490636259666498587618221225225512486764533", CultureInfo.InvariantCulture),
            BigInteger.Parse("67720186971698544312419572409913959008952310058822", CultureInfo.InvariantCulture),
            BigInteger.Parse("95548255300263520781532296796249481641953868218774", CultureInfo.InvariantCulture),
            BigInteger.Parse("76085327132285723110424803456124867697064507995236", CultureInfo.InvariantCulture),
            BigInteger.Parse("37774242535411291684276865538926205024910326572967", CultureInfo.InvariantCulture),
            BigInteger.Parse("23701913275725675285653248258265463092207058596522", CultureInfo.InvariantCulture),
            BigInteger.Parse("29798860272258331913126375147341994889534765745501", CultureInfo.InvariantCulture),
            BigInteger.Parse("18495701454879288984856827726077713721403798879715", CultureInfo.InvariantCulture),
            BigInteger.Parse("38298203783031473527721580348144513491373226651381", CultureInfo.InvariantCulture),
            BigInteger.Parse("34829543829199918180278916522431027392251122869539", CultureInfo.InvariantCulture),
            BigInteger.Parse("40957953066405232632538044100059654939159879593635", CultureInfo.InvariantCulture),
            BigInteger.Parse("29746152185502371307642255121183693803580388584903", CultureInfo.InvariantCulture),
            BigInteger.Parse("41698116222072977186158236678424689157993532961922", CultureInfo.InvariantCulture),
            BigInteger.Parse("62467957194401269043877107275048102390895523597457", CultureInfo.InvariantCulture),
            BigInteger.Parse("23189706772547915061505504953922979530901129967519", CultureInfo.InvariantCulture),
            BigInteger.Parse("86188088225875314529584099251203829009407770775672", CultureInfo.InvariantCulture),
            BigInteger.Parse("11306739708304724483816533873502340845647058077308", CultureInfo.InvariantCulture),
            BigInteger.Parse("82959174767140363198008187129011875491310547126581", CultureInfo.InvariantCulture),
            BigInteger.Parse("97623331044818386269515456334926366572897563400500", CultureInfo.InvariantCulture),
            BigInteger.Parse("42846280183517070527831839425882145521227251250327", CultureInfo.InvariantCulture),
            BigInteger.Parse("55121603546981200581762165212827652751691296897789", CultureInfo.InvariantCulture),
            BigInteger.Parse("32238195734329339946437501907836945765883352399886", CultureInfo.InvariantCulture),
            BigInteger.Parse("75506164965184775180738168837861091527357929701337", CultureInfo.InvariantCulture),
            BigInteger.Parse("62177842752192623401942399639168044983993173312731", CultureInfo.InvariantCulture),
            BigInteger.Parse("32924185707147349566916674687634660915035914677504", CultureInfo.InvariantCulture),
            BigInteger.Parse("99518671430235219628894890102423325116913619626622", CultureInfo.InvariantCulture),
            BigInteger.Parse("73267460800591547471830798392868535206946944540724", CultureInfo.InvariantCulture),
            BigInteger.Parse("76841822524674417161514036427982273348055556214818", CultureInfo.InvariantCulture),
            BigInteger.Parse("97142617910342598647204516893989422179826088076852", CultureInfo.InvariantCulture),
            BigInteger.Parse("87783646182799346313767754307809363333018982642090", CultureInfo.InvariantCulture),
            BigInteger.Parse("10848802521674670883215120185883543223812876952786", CultureInfo.InvariantCulture),
            BigInteger.Parse("71329612474782464538636993009049310363619763878039", CultureInfo.InvariantCulture),
            BigInteger.Parse("62184073572399794223406235393808339651327408011116", CultureInfo.InvariantCulture),
            BigInteger.Parse("66627891981488087797941876876144230030984490851411", CultureInfo.InvariantCulture),
            BigInteger.Parse("60661826293682836764744779239180335110989069790714", CultureInfo.InvariantCulture),
            BigInteger.Parse("85786944089552990653640447425576083659976645795096", CultureInfo.InvariantCulture),
            BigInteger.Parse("66024396409905389607120198219976047599490197230297", CultureInfo.InvariantCulture),
            BigInteger.Parse("64913982680032973156037120041377903785566085089252", CultureInfo.InvariantCulture),
            BigInteger.Parse("16730939319872750275468906903707539413042652315011", CultureInfo.InvariantCulture),
            BigInteger.Parse("94809377245048795150954100921645863754710598436791", CultureInfo.InvariantCulture),
            BigInteger.Parse("78639167021187492431995700641917969777599028300699", CultureInfo.InvariantCulture),
            BigInteger.Parse("15368713711936614952811305876380278410754449733078", CultureInfo.InvariantCulture),
            BigInteger.Parse("40789923115535562561142322423255033685442488917353", CultureInfo.InvariantCulture),
            BigInteger.Parse("44889911501440648020369068063960672322193204149535", CultureInfo.InvariantCulture),
            BigInteger.Parse("41503128880339536053299340368006977710650566631954", CultureInfo.InvariantCulture),
            BigInteger.Parse("81234880673210146739058568557934581403627822703280", CultureInfo.InvariantCulture),
            BigInteger.Parse("82616570773948327592232845941706525094512325230608", CultureInfo.InvariantCulture),
            BigInteger.Parse("22918802058777319719839450180888072429661980811197", CultureInfo.InvariantCulture),
            BigInteger.Parse("77158542502016545090413245809786882778948721859617", CultureInfo.InvariantCulture),
            BigInteger.Parse("72107838435069186155435662884062257473692284509516", CultureInfo.InvariantCulture),
            BigInteger.Parse("20849603980134001723930671666823555245252804609722", CultureInfo.InvariantCulture),
            BigInteger.Parse("53503534226472524250874054075591789781264330331690", CultureInfo.InvariantCulture),
        };
    }
}
