using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiDentalPro.Core;

namespace ApiDentalPro.Models.ClearCoverage;

/// <summary>
/// ClearCoverage response wrapped in a WunderGraph data envelope. The actual data
/// is under data.clearcoverage_post_enhanced_eligibility.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ClearCoverageRequestResponse, ClearCoverageRequestResponseFromRaw>)
)]
public sealed record class ClearCoverageRequestResponse : JsonModel
{
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
    }

    public ClearCoverageRequestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClearCoverageRequestResponse(ClearCoverageRequestResponse clearCoverageRequestResponse)
        : base(clearCoverageRequestResponse) { }
#pragma warning restore CS8618

    public ClearCoverageRequestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClearCoverageRequestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClearCoverageRequestResponseFromRaw.FromRawUnchecked"/>
    public static ClearCoverageRequestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClearCoverageRequestResponseFromRaw : IFromRawJson<ClearCoverageRequestResponse>
{
    /// <inheritdoc/>
    public ClearCoverageRequestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClearCoverageRequestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Enhanced eligibility data with standardized benefit breakdowns. Contains
    /// benefits (with network tiers), coverages (13 categories with subcategories),
    /// rules (policy flags), limitation, service_history, and fees sections. Response
    /// size varies significantly by payer (10KB-550KB).
    /// </summary>
    public ClearcoveragePostEnhancedEligibility? ClearcoveragePostEnhancedEligibility
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClearcoveragePostEnhancedEligibility>(
                "clearcoverage_post_enhanced_eligibility"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("clearcoverage_post_enhanced_eligibility", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ClearcoveragePostEnhancedEligibility?.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Enhanced eligibility data with standardized benefit breakdowns. Contains benefits
/// (with network tiers), coverages (13 categories with subcategories), rules (policy
/// flags), limitation, service_history, and fees sections. Response size varies
/// significantly by payer (10KB-550KB).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClearcoveragePostEnhancedEligibility,
        ClearcoveragePostEnhancedEligibilityFromRaw
    >)
)]
public sealed record class ClearcoveragePostEnhancedEligibility : JsonModel
{
    /// <summary>
    /// Benefit entries with 0-3 network tiers (IN_NETWORK, OUT_OF_NETWORK, plus PPO/PREMIER
    /// for Delta Dental).
    /// </summary>
    public IReadOnlyList<JsonElement>? Benefits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("benefits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "benefits",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// 13 fixed coverage categories (diagnostic, preventive, basic_restorative, major_restorative,
    /// endodontics, periodontics, oral_surgery, prosthodontics, orthodontics, implants,
    /// adjunctive, TMJ, misc), each containing variable subcategories with coinsurance
    /// and limitations.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Coverages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "coverages"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "coverages",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Individual and family deductible amounts by network tier.
    /// </summary>
    public JsonElement? Deductible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("deductible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deductible", value);
        }
    }

    /// <summary>
    /// Annual and lifetime maximum amounts by network tier.
    /// </summary>
    public JsonElement? Maximums
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("maximums");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maximums", value);
        }
    }

    public JsonElement? Payer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("payer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("payer", value);
        }
    }

    /// <summary>
    /// Plan identification and effective dates.
    /// </summary>
    public JsonElement? Plan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("plan");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("plan", value);
        }
    }

    public JsonElement? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <summary>
    /// Policy-level flags including missing_tooth clause, seat/prep date rules,
    /// waiting periods, and COB (coordination of benefits) information.
    /// </summary>
    public JsonElement? Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("rules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rules", value);
        }
    }

    public JsonElement? Subscriber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("subscriber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscriber", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Benefits;
        _ = this.Coverages;
        _ = this.Deductible;
        _ = this.Maximums;
        _ = this.Payer;
        _ = this.Plan;
        _ = this.Provider;
        _ = this.Rules;
        _ = this.Subscriber;
    }

    public ClearcoveragePostEnhancedEligibility() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClearcoveragePostEnhancedEligibility(
        ClearcoveragePostEnhancedEligibility clearcoveragePostEnhancedEligibility
    )
        : base(clearcoveragePostEnhancedEligibility) { }
#pragma warning restore CS8618

    public ClearcoveragePostEnhancedEligibility(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClearcoveragePostEnhancedEligibility(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClearcoveragePostEnhancedEligibilityFromRaw.FromRawUnchecked"/>
    public static ClearcoveragePostEnhancedEligibility FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClearcoveragePostEnhancedEligibilityFromRaw
    : IFromRawJson<ClearcoveragePostEnhancedEligibility>
{
    /// <inheritdoc/>
    public ClearcoveragePostEnhancedEligibility FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClearcoveragePostEnhancedEligibility.FromRawUnchecked(rawData);
}
