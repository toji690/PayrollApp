private void btnCalculate_Click(object sender, EventArgs e)
{
    try
    {
        // --- INPUTS ---
        decimal dailyRate = 755.00m; // or use monthly 19630 converted
        decimal hoursWorked = decimal.Parse(txtHoursWorked.Text);
        decimal otHours = decimal.Parse(txtOTHours.Text);
        decimal specialHolHours = decimal.Parse(txtSpecialHoliday.Text);
        decimal regularHolHours = decimal.Parse(txtHoliday.Text);
        decimal lateMinutes = decimal.Parse(txtLateMinutes.Text);
        decimal absencesDays = decimal.Parse(txtAbsencesDays.Text);

        // --- COMPUTATIONS ---
        // 1. Hourly pay
        decimal hourlyPay = dailyRate / 8.0m;

        // 2. OT Pay (+30%)
        decimal otPay = otHours * (hourlyPay * 1.30m);

        // 3. Special Holiday (+30%)
        decimal specialHolidayPay = specialHolHours * (hourlyPay * 1.30m);

        // 4. Holiday Pay (+100%)
        decimal regularHolidayPay = regularHolHours * (hourlyPay * 2.00m);

        // Regular earnings based on hours worked
        decimal regularEarnings = hoursWorked * hourlyPay;

        // Deduction values
        decimal lateDeduction = lateMinutes * (hourlyPay / 60.0m);
        decimal absenceDeduction = absencesDays * dailyRate;

        // 5. Gross Pay
        decimal grossPay = (regularEarnings + otPay + specialHolidayPay + regularHolidayPay) - (absenceDeduction + lateDeduction);

        // Statutory Deductions
        decimal sss = grossPay * 0.04m; // 4% of Gross Pay
        decimal hmdf = 200.00m;          // Fixed
        decimal phealth = 200.00m;       // Fixed
        decimal totalDeductions = sss + hmdf + phealth + lateDeduction + absenceDeduction;

        // 6. Net Pay = Gpay - Deductions (statutory + absences/late already handled or separate)
        decimal netPay = grossPay - (sss + hmdf + phealth);

        // --- DISPLAY RESULTS ---
        lblHourlyPay.Text = "1. Hourly Pay: ₱" + hourlyPay.ToString("N2");
        lblOTPay.Text = "2. OT Pay: ₱" + otPay.ToString("N2");
        lblSpecialHoliday.Text = "3. Special Holiday Pay: ₱" + specialHolidayPay.ToString("N2");
        lblHolidayPay.Text = "4. Holiday Pay: ₱" + regularHolidayPay.ToString("N2");
        lblGrossPay.Text = "5. Gross Pay: ₱" + grossPay.ToString("N2");
        lblNetPay.Text = "6. Net Pay: ₱" + netPay.ToString("N2");
    }
    catch (FormatException)
    {
        MessageBox.Show("Please enter valid numbers in all input fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
