using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiDentalPro.Core;

namespace ApiDentalPro.Models.Eligibility;

/// <summary>
/// Eligibility response wrapped in a WunderGraph data envelope. The actual eligibility
/// data is under data.apidental_post_eligibility.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EligibilityRequestResponse, EligibilityRequestResponseFromRaw>)
)]
public sealed record class EligibilityRequestResponse : JsonModel
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

    public EligibilityRequestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EligibilityRequestResponse(EligibilityRequestResponse eligibilityRequestResponse)
        : base(eligibilityRequestResponse) { }
#pragma warning restore CS8618

    public EligibilityRequestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EligibilityRequestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EligibilityRequestResponseFromRaw.FromRawUnchecked"/>
    public static EligibilityRequestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EligibilityRequestResponseFromRaw : IFromRawJson<EligibilityRequestResponse>
{
    /// <inheritdoc/>
    public EligibilityRequestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EligibilityRequestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Eligibility verification results. Contains patient, subscriber, payer, provider,
    /// plan, limitations, deductibles, maximums, coinsurance, active_coverage, and
    /// not_covered sections. Structure varies by payer.
    /// </summary>
    public ApidentalPostEligibility? ApidentalPostEligibility
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApidentalPostEligibility>(
                "apidental_post_eligibility"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apidental_post_eligibility", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ApidentalPostEligibility?.Validate();
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
/// Eligibility verification results. Contains patient, subscriber, payer, provider,
/// plan, limitations, deductibles, maximums, coinsurance, active_coverage, and not_covered
/// sections. Structure varies by payer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ApidentalPostEligibility, ApidentalPostEligibilityFromRaw>)
)]
public sealed record class ApidentalPostEligibility : JsonModel
{
    public IReadOnlyList<JsonElement>? ActiveCoverage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("active_coverage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "active_coverage",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<JsonElement>? Coinsurance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("coinsurance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "coinsurance",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<JsonElement>? Deductible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("deductible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "deductible",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<JsonElement>? Limitations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("limitations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "limitations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<JsonElement>? Maximums
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("maximums");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "maximums",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<JsonElement>? NotCovered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("not_covered");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "not_covered",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JsonElement? Patient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("patient");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("patient", value);
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
        _ = this.ActiveCoverage;
        _ = this.Coinsurance;
        _ = this.Deductible;
        _ = this.Limitations;
        _ = this.Maximums;
        _ = this.NotCovered;
        _ = this.Patient;
        _ = this.Payer;
        _ = this.Plan;
        _ = this.Provider;
        _ = this.Subscriber;
    }

    public ApidentalPostEligibility() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApidentalPostEligibility(ApidentalPostEligibility apidentalPostEligibility)
        : base(apidentalPostEligibility) { }
#pragma warning restore CS8618

    public ApidentalPostEligibility(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApidentalPostEligibility(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApidentalPostEligibilityFromRaw.FromRawUnchecked"/>
    public static ApidentalPostEligibility FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApidentalPostEligibilityFromRaw : IFromRawJson<ApidentalPostEligibility>
{
    /// <inheritdoc/>
    public ApidentalPostEligibility FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApidentalPostEligibility.FromRawUnchecked(rawData);
}
