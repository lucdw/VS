using Party;
using System;
using System.Collections.Generic;



namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            int keuze = 0;
            bool hasValidInput = false;
            while (!hasValidInput)
            {
                Console.WriteLine("Keuze 1 met exceptions of Keuze 2 met auto input:");
                string input = Console.ReadLine();
                bool isNummer = int.TryParse(input, out keuze);

                if (isNummer && (keuze == 1 || keuze == 2))
                    hasValidInput = true;
            }

            List<party> parties = new List<party>();
            switch (keuze)
            {
                case 1:
                    parties = CreatePartiesWithManualInput();
                    break;
                case 2:
                    parties = CreatePartiesWithAutoInput();
                    break;
            }

            foreach (party p in parties)
            {
                Console.WriteLine($"\n {p} \n      #######################");
            }

            Console.ReadLine();
        }

        static List<party> CreatePartiesWithAutoInput()
        {
            List<party> parties = new List<party>();

            DinnerParty dp1 = new DinnerParty(5, false, false);
            DinnerParty dp2 = new DinnerParty(15, true, true);
            DinnerParty dp3 = new DinnerParty(10, true, false);
            DinnerParty dp4 = new DinnerParty(10, false, true);

            BirthdayParty bp1 = new BirthdayParty(3, false);
            BirthdayParty bp2 = new BirthdayParty(15, true);
            BirthdayParty bp3 = new BirthdayParty(10, false);
            BirthdayParty bp4 = new BirthdayParty(3, true);
            BirthdayParty bp5 = new BirthdayParty(5, false, "Henk");
            BirthdayParty bp6 = new BirthdayParty(3, true, "Henk");
            BirthdayParty bp7 = new BirthdayParty(5, false, "Henk  ");
            BirthdayParty bp8 = new BirthdayParty(3, true, "Henk  ");


            parties.Add(dp1); parties.Add(dp2); parties.Add(dp3); parties.Add(dp4);
            parties.Add(bp1); parties.Add(bp2); parties.Add(bp3); parties.Add(bp4);
            parties.Add(bp5); parties.Add(bp6); parties.Add(bp7); parties.Add(bp8);

            return parties;
        }

        static List<party> CreatePartiesWithManualInput()
        {
            List<party> parties = new List<party>();

            bool stopCreatingParties = false;
            EParty partyKeuze;
            int aantal;
            bool isLuxe;

            while (!stopCreatingParties)
            {
                try
                {
                    Console.WriteLine("Wilt u een dinner(1) of birthday(2) party?");
                    String partyInputKeuze = Console.ReadLine();
                    if (partyInputKeuze == null || !(partyInputKeuze == "1" || partyInputKeuze == "2"))
                        throw new PartyException("Je moet kiezen tussen dinner (1) of birtday (2)");
                    partyKeuze = partyInputKeuze == "1" ? EParty.DINNER : EParty.BIRTHDAY;
                }
                catch (PartyException)
                {
                    continue;
                }

                try
                {
                    Console.WriteLine("Geef het aantal personen voor u feestje?");
                    String aantalPersonenKeuze = Console.ReadLine();
                    if (!int.TryParse(aantalPersonenKeuze, out aantal))
                        throw new PartyException("Geef het aantal personen voor uw feestje!");
                }
                catch (PartyException)
                {
                    continue;
                }

                try
                {
                    Console.WriteLine("Wilt u een luxe(Y) of geen luxe(N) party?");
                    String luxeInputKeuze = Console.ReadLine().ToUpper();
                    if (luxeInputKeuze == null || !(luxeInputKeuze == "Y" || luxeInputKeuze == "N"))
                        throw new PartyException("U moet Y of N invullen!");
                    isLuxe = luxeInputKeuze == "Y";
                }
                catch (PartyException)
                {
                    continue;
                }

                try
                {
                    if (partyKeuze == EParty.DINNER)
                    {
                        Console.WriteLine("Wilt u een gezonde(Y) of geen gezonde(N) party?");
                        String gezondeInputKeuze = Console.ReadLine().ToUpper();
                        if (gezondeInputKeuze == null || !(gezondeInputKeuze == "Y" || gezondeInputKeuze == "N"))
                            throw new PartyException("U moet Y of N invullen!");
                        bool isGezondeKeuze = gezondeInputKeuze == "Y";

                        DinnerParty dp = new DinnerParty(aantal, isGezondeKeuze, isLuxe);

                        parties.Add(dp);
                    }
                    else
                    {
                        //If Birtday party => Boodschap?.
                        //Maak nieuwe party aan en voeg toe aan lijst
                        Console.WriteLine("Welk bericht wilt u op de taart?(leeg laten indien geen)");
                        String taartInputKeuze = Console.ReadLine();

                        BirthdayParty bp = new BirthdayParty(aantal, isLuxe, taartInputKeuze);

                        parties.Add(bp);
                    }
                }
                catch (PartyException)
                {
                    continue;
                }

                try
                {
                    Console.WriteLine("Wilt u een feestje toevoegen(Y) of stoppen(N)?");
                    String nogFeestjeInputKeuze = Console.ReadLine().ToUpper();
                    if (nogFeestjeInputKeuze == null || !(nogFeestjeInputKeuze == "Y" || nogFeestjeInputKeuze == "N"))
                        throw new PartyException("U moet Y of N invullen!");
                    stopCreatingParties = nogFeestjeInputKeuze == "N";
                }
                catch (PartyException)
                {
                    continue;
                }

            }

            return parties;
        }
    }
}
