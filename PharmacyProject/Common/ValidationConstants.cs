namespace PharmacyProject.Common
{
    public static class ValidationConstants
    {
        public const string AdminId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd";

        public const byte MedicineNameMinLenght = 3;
        public const byte MedicineNameMaxLenght = 250;
        public const double MedicinePriceMinValue = 0;
        public const double MedicinePriceMaxValue = 10000;
        public const byte MedicineDescriptionMinValue = 0;
        public const int MedicineDescriptionMaxValue = 10000;

        public const byte MedicineTypeNameMinLenght = 0;
        public const byte MedicineTypeNameMaxLenght = 250;
        public const byte MedicineTypeMinCount = 1;
        public const byte MedicineTypeMaxCount = 5;

        public const byte PharmacyNameMinlenght = 0;
        public const int PharmacyNameMaxLebnght = 1000;
        public const byte PharmacyLocationMinLenght = 0;
        public const int PharmacyLocationMaxLenght = 1000;
    }
}
