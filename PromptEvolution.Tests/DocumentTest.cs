using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Channels;
using PromptEvolution;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System;
using Snapshooter.Xunit;
using Snapshooter;
using System.Globalization;
using PromptEvolution.Tests.Models;

namespace PromptEvolution.Tests
{
    public class DocumentTest
    {
        [Theory]
        [InlineData(
            """
                        ©

            — Sparkasse
            Vorderpfalz

            Sparkasse Vorderpfalz · Postfach 21 12 09 · 67012 Ludwigshafen am Rhein
            Depotnummer 710068669
            Kundennummer 1049799082
            Oliver Pierre Schmidt
            Auftragsnummer 504160/28.00
            Herrn Datum 28.08.2023
            Oliver Pierre Schmidt Ihr Berater Herr Uwe Seemann
            Daimlerstr. 3 Telefon 0621 5992-3231
            67346 Speyer Telefax 0621 5992-865076
            Rechnungsnummer W02018-0000029834/23
            Umsatzsteuer-ID DE149138080




            Wertpapier Abrechnung Kauf
            Nominale Wertpapierbezeichnung ISIN (WKN)
            Stück 4.383 VANECK MSTR.DM DIVIDEND.UC.ETF NL0011683594 (A2JAHJ)
            AANDELEN OOP TOONDER O.N.

            Handels-/Ausführungsplatz Tradegate (Best Execution)
            Börsensegment XGAT

            Market-Order
            Limit billigst
            Schlusstag/-Zeit 28.08.2023 16:42:19 Auftraggeber Oliver Pierre Schmidt
            Ausführungskurs 34,19 EUR Auftragserteilung/ -ort Online-Banking




            Girosammelverwahrung Sammelurkunde

            Kurswert 149.854,77- EUR

            Provision 599,42- EUR

            Ausmachender Betrag 150.454,19- EUR



            Den Gegenwert buchen wir mit Valuta 30.08.2023 zu Lasten des Kontos 193529864 (IBAN DE26 5455 0010 0193 5298 64),
            BLZ 54550010 (BIC LUHSDE6AXXX).
            Die Wertpapiere schreiben wir Ihrem Depotkonto gut.

            Sofern keine Umsatzsteuer ausgewiesen ist, handelt es sich um eine umsatzsteuerbefreite Finanzdienstleistung.

            Für das Geschäft wurde keine Anlageberatung erbracht.
            2018.08282036.0000013OR07




            Dieses Dokument wurde maschinell erstellt und wird nicht unterschrieben.
            Sparkasse Vorderpfalz Vorstand: Telefon +49 621 5992-0 BIC (SWIFT-Code): LUHSDE6AXXX
            Ludwigstraße 52 Thomas Traue (Vorsitzender) Telefax +49 621 5992-865992
            67059 Ludwigshafen am Rhein Oliver Kolb www.sparkasse-vorderpfalz.de
            HRA 3647 (AG Ludwigshafen) Uli Sauer kontakt@sparkasse-vorderpfalz.de
            Anstalt des öffentlichen Rechts
             
            Sparkassen-Finanzgruppe
            """
            )]
        [InlineData("""
                        MR 

            Bundesministerium 
            für Familie, Senioren, Frauen 
            und Jugend 

            Musterbescheinigung: Nachweis über Nicht-Inanspruchnahme von 
            Kita/Kindertagespflege/Schule bei Beantragung von Kinderkrankengeld 

            Mit dieser Musterbescheinigung zur Beantragung von Kinderkrankengeld kann bestätigt werden, dass. 
            eine Betreuungseinrichtung aus Gründen des Infektionsschutzes schließen oder ihren Zugang beschrän- 
            ken musste. Sollten Krankenkassen einen Nachweis durch die Einrichtung verlangen, kann diese Muster- 
            bescheinigung verwendet werden. 

            Hiermit wird bestätigt, dass das Kind 
            Schr, Caro 

            | 

            : 

            En 

            Name, Vorname 

            Ei AoA%E 

            Geburtsdatum 

            an folgenden Tagen bzw. im folgenden Zeitraum (ggf. halbtags) 

            ee 

            _ 

            a 

            En aufgrund der Schließung der Betreuungseinrichtung/Schule aus Gründen des Infektionsschutzes 

            ® aufgrund der Untersagung des Betretens der Betreuungseinrichtung/Schule aus Gründen des 
            | 

            Infektionsschutzes 

            () aufgrund der Anordnung bzw. Verlängerung von Betriebsferien/Schulferien aus Gründen des 

            Infektionsschutzes 

            () aufgrund einer Beschränkung des Zugangs zum Kinderbetreuungsangebot aus Gründen des 

            Infektionsschutzes 

            en) aufgrund einer Empfehlung von behördlicher Seite, die Betreuungseinrichtung aus Gründen des 

            Infektionsschutzes nicht zu besuchen 

            Or aufgrund einer ee der a aus Gründen des Infektionsschutzes 

            lvech sefv: Am 

            die 

            _ GRUNDSCHULE SPEYER - SIEDLUNGSSCHULE. 

            Name der Kindertageseinrichtung/der Kindertagespflegestelle 

            nicht besucht hat. 
            Speyer a 2 er F 

            m Hmm = - 

            z if luuncıs Schu!e - 

            mr Igeratst neh 

            Birkenweg 10 

            Ort, D atufm m 

            ee 

            Unterschrift, Stempel | 

            07346 Speyer 

            Grundschule Speyer 

            Diese Mustervorlage ist Teil der Öffentlichkeitsarbeit der Bundesregierung. Sie dient der Ergänzung des formellen Antrags auf Kinder- 

            krankengeld bei einer gesetzlichen Krankenkasse.
            """)]
        [InlineData("""
                        BARMER - 73523 Schwäbisch Gmünd 

            Herrn 
            Oliver Schmidt 
            Daimlerstr. 3 
            67346 Speyer 

            Vielen Dank für Ihr Vertrauen 

            Sehr geehrter Herr Schmidt, 

            Ich bin persönlich für Sie erreichbar: 
            Thorsten Tapenko 
            Tel 
            0800 333004 405-601 *) 
            Fax 0800 333004 405-649 *) 
            thorsten.tapenko@barmer.de 

            Bitte angeben: 
            Unser Zeichen 

            R632538775 

            Datum 

            20.07.2022 

            wir freuen uns, dass Sie bei der BARMER versichert bleiben. Bei uns sind Sie bestens aufgehoben. Wir 
            arbeiten mit erstklassigen Medizinern zusammen und unsere Vorsorge- und Therapieangebote sind 
            vielfältig und flexibel. So profitieren Sie von höchster Behandlungsqualität. 

            Wenden Sie sich gern an uns: Natürlich sind wir persönlich oder telefonisch für Ihre Fragen da. Denn 
            Ihre Gesundheit liegt uns am Herzen - rufen Sie uns einfach an. Oder besuchen Sie uns in Ihrer 
            BARMER Geschäftsstelle. Auf Wunsch besuchen wir Sie auch zu Hause. Mit der BARMER-App können 
            Sie viele Services online nutzen: zum Beispiel Arbeitsunfähigkeitsbescheinigung (AU-Bescheinigung) 
            hochladen oder Leistungen beantragen. Mehr dazu unter www.barmer.de/barmer-app. 

            Mit freundlichen Grüßen 

            Thorsten Tapenko 
            Ihre BARMER 

            b
            5
            0
            3
            d
            c
            2
            4
            f
            5
            4
            0
            -
            2
            d
            f
            9
            -
            5
            7
            3
            4
            -
            2
            e
            9
            3
            -
            d
            e
            b
            a
            d
            e
            3
            d

            4
            O
            V
            \

            0
            0
            6
            0
            1

            Postanschrift 
            BARMER 
            Armbruststr. 24 
            67346 Speyer 

            Alles Wichtige online erledigen: 
            Der persönliche Mitgliederbereich 
            www.barmer.de/meine-barmer 

            Schon gewusst? Bei Fragen zum Datenschutz oder Einspruch 
            gegen die Datenverarbeitung hilft unser Datenschutzbeauftragter: 
            datenschutz@barmer.de, BARMER, Lichtscheider Str.89, 42285 Wuppertal. 
            Oder der Bundesbeauftragte für Datenschutz und Informationsfreiheit. 

            Bankverbindung IBAN: DE29 2005 0550 1235 1218 50 BIC: HASPDEHH (Haspa). Weitere Bankkonten: www.barmer.de/bako 
            *) Anrufe aus dem deutschen Fest- und Mobilfunknetz sind kostenfrei
            """)]
        [InlineData("""
                        Absender: 

            Hinweis: 
            Legen Sie diese Anzeige 
            bitte zwei Wochen vor 
            dem betreffenden Termin 
            bei der Unteren Bauauf- 
            sichtsbehörde vor! 

            Aktenzeichen 

            00549-2019 

            Bauherr/in 

            Hans-Jürgen Schmidt, Draisstraße 35b, 67346 Speyer 

            Vorhaben 

            Neubau einer Garage 

            Lage 

            Speyer, Daimlerstraße 3 

            Flurstück/e 

            5697/28 

            Anzeige über die abschließende Fertigstellung 

            Hiermit zeige ich gemäß $ 78 Abs. 2 Landesbauordnung Rheinland-Pfalz die abschließende Fertigstellung der 
            baulichen Anlage bis zum 

            an 

            4.5, 102] 

            s 

            an. Ich erkläre, dass die bauliche Anlage in Übereinstimmung mit den bauaufsichtlich genehmigten Plänen fer- 
            tiggestellt wurde. 

            [_] Antrag auf Ausstellung einer Abnahmebescheinigung 

            Sofern eine im Ermessen der Bauaufsichtsbehörde stehende Bauzustandsbesichtigung durchgeführt wird, 
            beantrage ich die Ausstellung einer gebührenpflichtigen Bescheinigung über das Ergebnis der Bauzu- 
            standsbesichtigung 

            2140F2022 

            AH 

            Datum, Unterschrift der Bauherrin/des Bauherrn 

            Bestätigung der bauleitenden Person 
            Als von der Bauherrin/dem Bauherrn nach $ 55 LBauO mit der Bauleitung beauftragte Person bestätige ich 
            hiermit, dass dieses Vorhaben von mir überwacht wurde und nach den genehmigten Bauunterlagen sowie unter 
            Beachtung der baurechtlichen und sonstigen öffentlich-rechtlichen Vorschriften durchgeführt worden ist. 

            Vermerke (z.B. Abweichungen, ggf. Rückseite benutzen) 

            Datum, Unterschrift der bauleitenden Person 

            Empfänger 

            Stadtverwaltung 
            - Untere Bauaufsichtsbehörde - 
            Maximilianstr. 100 

            67346 Speyer
            """)]
        public async Task Document_Test(string request)
        {
            var testResult = new TestResult<DocumentMetaData>()
            {
                Request = request,
                Result = await Translator.Translate<DocumentMetaData>(request, $"Lese Metadaten aus dem Inhalt.")
            };

            Snapshot.Match(testResult, SnapshotNameExtension.Create(request.MakeFileSystemReady()));
        }


        

    }
}