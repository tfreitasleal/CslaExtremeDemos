using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace CslaExtremeDemos.Rules
{

    #region Comparable Field Rules

    /// <summary>
    /// Validates that primary property is less than compareToProperty
    /// </summary>
    public class EnumNotZero : CommonBusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumNotZero"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        public EnumNotZero(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumNotZero"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        /// <param name="errorMessageDelegate">The error message function.</param>
        public EnumNotZero(IPropertyInfo primaryProperty, Func<string> errorMessageDelegate)
            : this(primaryProperty)
        {
            MessageDelegate = errorMessageDelegate;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value></value>
        protected override string GetMessage()
        {
            return HasMessageDelegate ? base.GetMessage() : "Must select an option";
        }

        /// <summary>
        /// Does the check for primary propert less than compareTo property
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            var value = (byte) context.InputPropertyValues[PrimaryProperty];

            if (value == 0)
            {
                var message = string.Format(GetMessage(), PrimaryProperty.FriendlyName);
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
            }
        }
    }

    #endregion
}