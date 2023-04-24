using Humanizer;

namespace NuGetGems.NugetGems;

public class HumanizerExamples {

    string camelCaseExample = "LoremIpsumDolorSitAmetConsecteturAdipiscingElitNuncQuisLigulaVelIpsumRhoncusLuctusPraesentDapibusNuncAcLiberoConsequatElementumNamMaximusEgetJustoVitaeMalesuadaSedOrnareNullaSedDictumCongueLiberoAugueMalesuadaTellusEuVariusNequeMiVelNislDonecAMetusSemFusceCursusPlaceratTinciduntMaurisOrnareVehiculaAugueQuisVestibulumDonecExExTristiqueSedAuctorNonPretiumVelRisus";

    string kebabCase = "lorem-ipsum-dolor-sit-amet-consectetur-adipiscing-elit-nunc-quis-ligula-vel-ipsum-rhoncus-luctus";

    string snakeCase = "lorem_ipsum_dolor_sit_amet_consectetur_adipiscing_elit_nunc_quis_ligula_vel_ipsum_rhoncus_luctus";

    string upperCase = "LOREM IPSUM DOLOR SIT AMET, CONSECTETUR ADIPISCING ELIT. NUNC QUIS LIGULA VEL IPSUM RHONCUS LUCTUS. PRAESENT DAPIBUS NUNC AC LIBERO CONSEQUAT ELEMENTUM.";

    public string Examples(int number) {

        return number switch {
            1 => camelCaseExample.Humanize().ApplyCase(LetterCasing.Title),
            2 => kebabCase.Humanize(),
            3 => snakeCase.Humanize(),
            4 => upperCase.Humanize()
        };
    }
}
