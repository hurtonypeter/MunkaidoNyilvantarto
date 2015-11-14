using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL
{
    /// <summary>
    /// A szolgáltatások válasza create, update, delete, stb. esetén, 
    /// amik egyébként void-ok lennének és nem tudnánk mi történt belül
    /// </summary>
    public class ServiceResult : IServiceResult
    {
        private List<KeyValuePair<string, string>> _errors;

        /// <summary>
        /// Megmondja, hogy sikeres volt-e a művelet
        /// </summary>
        public bool Succeeded
        {
            get
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        /// Ha a művelet nem volt sikeres, akkor ezek a hibák következtek be
        /// </summary>
        public IReadOnlyList<KeyValuePair<string, string>> Errors
        {
            get { return _errors.AsReadOnly(); }
        }

        /// <summary>
        /// Ha a szolgáltatás visszatérése különböző hibákat tartalmazhat, 
        /// de szükség van siker esetén valamilyen objektum visszaadására, akkor
        /// azt ebben tehetjük meg. CSAK NAGYON INDOKOLT ESETBEN!
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// def ctor
        /// </summary>
        public ServiceResult()
        {
            _errors = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Helper amivel egy új hibát tudunk hozzáadni a result-hoz
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddError(string key, string value)
        {
            _errors.Add(new KeyValuePair<string, string>(key, value));
        }

        /// <summary>
        /// Helper metódus, amivel több hiba adható hozzá egyszerre egy másik ServiceResult-ból
        /// </summary>
        /// <param name="errors"></param>
        public void AddErrors(IReadOnlyList<KeyValuePair<string, string>> errors)
        {
            _errors.AddRange(errors);
        }

    }

    /// <summary>
    /// Típusos leszármazottja a ServiceResultnak, segítségével lambdán keresztül adható hiba a resulthoz
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ServiceResult<TModel> : ServiceResult
    {
        /// <summary>
        /// Helper metódus, amivel egy új hibát tudunk hozzáadni, 
        /// a viewmodel property-jeit használva key-ként lambdával
        /// </summary>
        /// <param name="expression">lambda kifejezés, hogy melyik propertyhez szeretnék a hibát adni</param>
        /// <param name="message">A hiba szövege</param>
        public void AddError(Expression<Func<TModel, object>> expression, string message)
        {
            AddError(GetMemberName(expression), message);
        }

        /// <summary>
        /// Helper metódus, amivel sok új hibát tudunk hozzáadni
        /// a viewmodel _EGY_ propertyjéhez lambda segítségével
        /// </summary>
        /// <param name="expression">lambda kifejezés, hogy melyik propertyhez szeretnék a hibát adni</param>
        /// <param name="errors">Hibák listája, mind az expression által meghatározott propertyhez fog kerülni</param>
        public void AddErrors(Expression<Func<TModel, object>> expression, IReadOnlyList<KeyValuePair<string, string>> errors)
        {
            var memberName = GetMemberName(expression);
            foreach (var item in errors)
            {
                AddError(memberName, item.Value);
            }
        }

        private string GetMemberName(Expression<Func<TModel, object>> expression)
        {
            var memberName = "";
            try
            {
                MemberExpression memberExpr = expression.Body as MemberExpression;
                if (memberExpr == null)
                {
                    UnaryExpression unaryExpr = expression.Body as UnaryExpression;
                    if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    {
                        memberExpr = unaryExpr.Operand as MemberExpression;
                    }
                }

                memberName = memberExpr.Member.Name;
            }
            catch (Exception) { }

            return memberName;
        }
    }
}
