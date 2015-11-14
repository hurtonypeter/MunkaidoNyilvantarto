using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    /// <summary>
    /// A szolgáltatások válasza create, update, delete, stb. esetén, 
    /// amik egyébként void-ok lennének és nem tudnánk mi történt belül
    /// </summary>
    public interface IServiceResult
    {
        /// <summary>
        /// Megmondja, hogy sikeres volt-e a művelet
        /// </summary>
        bool Succeeded { get; }

        /// <summary>
        /// Ha a művelet nem volt sikeres, akkor ezek a hibák következtek be
        /// </summary>
        IReadOnlyList<KeyValuePair<string, string>> Errors { get; }

        /// <summary>
        /// Ha a szolgáltatás visszatérése különböző hibákat tartalmazhat, 
        /// de szükség van siker esetén valamilyen objektum visszaadására, akkor
        /// azt ebben tehetjük meg. CSAK NAGYON INDOKOLT ESETBEN!
        /// </summary>
        dynamic Data { get; }

        /// <summary>
        /// Helper amivel egy új hibát tudunk hozzáadni a result-hoz
        /// </summary>
        /// <param name="key">Hiba "kulcsa", általában a viewmodel egy property-je, amihez a hiba tartozik</param>
        /// <param name="value">A hiba szövege</param>
        void AddError(string key, string value);

        /// <summary>
        /// Helper metódus, amivel több hiba adható hozzá egyszerre egy másik ServiceResult-ból
        /// </summary>
        /// <param name="errors">A hozzáadandó szövegek listája</param>
        void AddErrors(IReadOnlyList<KeyValuePair<string, string>> errors);
    }
}
