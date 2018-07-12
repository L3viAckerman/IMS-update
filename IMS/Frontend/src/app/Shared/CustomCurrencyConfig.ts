import { CurrencyMaskModule } from "ng2-currency-mask";
import { CurrencyMaskConfig, CURRENCY_MASK_CONFIG } from "ng2-currency-mask/src/currency-mask.config";

export const CustomCurrencyConfig: CurrencyMaskConfig = {
    align: "right",
    allowNegative: true,
    decimal: ".",
    precision: 0,
    prefix: "",
    suffix: "",
    thousands: ","
};
