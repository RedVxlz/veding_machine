using vending_machine;

namespace veding_machine
{
    public partial class Form1 : Form
    {
        MenuItem blackCoffee = new MenuItem();
        MenuItem latte = new MenuItem();
        MenuItem mocca = new MenuItem();
        MenuItem chocolate = new MenuItem();
        MenuItem water = new MenuItem();
        MenuItem coffee = new MenuItem();
        MenuItem milk = new MenuItem();
        MenuItem chocolatMix = new MenuItem();

        public Form1()
        {
            InitializeComponent();
            showStock(this, EventArgs.Empty);

            blackCoffee.Name = "Black Coffee";
            blackCoffee.Price = 50;
            blackCoffee.Quantity = 0;
            blackCoffee.Ingredients.Add("Water", 300);
            blackCoffee.Ingredients.Add("Coffee", 20);

            latte.Name = "Latte";
            latte.Price = 60;
            latte.Quantity = 0;
            latte.Ingredients.Add("Water", 300);
            latte.Ingredients.Add("Coffee", 20);
            latte.Ingredients.Add("Milk", 10);

            mocca.Name = "Mocca";
            mocca.Price = 65;
            mocca.Quantity = 0;
            mocca.Ingredients.Add("Water", 300);
            mocca.Ingredients.Add("Coffee", 20);
            mocca.Ingredients.Add("Chocolate", 10);

            chocolate.Name = "Chocolate";
            chocolate.Price = 70;
            chocolate.Quantity = 0;
            chocolate.Ingredients.Add("Water", 300);
            chocolate.Ingredients.Add("Chocolate", 20);

        }
        public void showStock(object sender, EventArgs e)
        {
            tb_black_coffee_price.Text = blackCoffee.Price.ToString();
            tb_black_coffee_quantity.Text = blackCoffee.Quantity.ToString();

            tb_latte_price.Text = latte.Price.ToString();
            tb_latte_quantity.Text = latte.Quantity.ToString();

            tb_mocha_price.Text = mocca.Price.ToString();
            tb_mocha_quantity.Text = mocca.Quantity.ToString();

            tb_chocolat_price.Text = chocolate.Price.ToString();
            tb_chocolat_quantity.Text = chocolate.Quantity.ToString();

            water.Name = "Water Mix";
            water.Quantity = 1000;

            coffee.Name = "Coffee Mix";
            coffee.Quantity = 1000;

            milk.Name = "Milk Mix";
            milk.Quantity = 1000;

            chocolatMix.Name = "Chocolate Mix";
            chocolatMix.Quantity = 1000;

            tb_water_mix.Text = water.Quantity.ToString();
            tb_coffee_mix.Text = coffee.Quantity.ToString();
            tb_milk_mix.Text = milk.Quantity.ToString();
            tb_chocolat_mix.Text = chocolatMix.Quantity.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tb_crash.Text);
                double dTotal = 0;

                Dictionary<string, Ingredient> availableIngredients = new Dictionary<string, Ingredient>
                {
                    { "Water", new Ingredient("Water", 1000) },
                    { "Coffee", new Ingredient("Coffee", 1000) },
                    { "Milk", new Ingredient("Milk", 1000) },
                    { "Chocolate", new Ingredient("Chocolate", 1000) }
                };

                if (chb_blackcoffee.Checked)
                {
                    blackCoffee.Quantity = int.Parse(tb_black_coffee_quantity.Text);
                    dTotal += blackCoffee.GetTotalPrice();
                    blackCoffee.UseIngredients(availableIngredients);

                    tb_water_mix.Text = availableIngredients["Water"].Quantity.ToString();
                    tb_coffee_mix.Text = availableIngredients["Coffee"].Quantity.ToString();
                }

                if (chb_latte.Checked)
                {
                    latte.Quantity = int.Parse(tb_latte_quantity.Text);
                    dTotal += latte.GetTotalPrice();
                    latte.UseIngredients(availableIngredients);

                    tb_water_mix.Text = availableIngredients["Water"].Quantity.ToString();
                    tb_coffee_mix.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tb_milk_mix.Text = availableIngredients["Milk"].Quantity.ToString();
                }

                if (chb_mocha.Checked)
                {
                    mocca.Quantity = int.Parse(tb_mocha_quantity.Text);
                    dTotal += mocca.GetTotalPrice();
                    mocca.UseIngredients(availableIngredients);

                    tb_water_mix.Text = availableIngredients["Water"].Quantity.ToString();
                    tb_coffee_mix.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tb_chocolat_mix.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (chb_chocolat.Checked)
                {
                    chocolate.Quantity = int.Parse(tb_chocolat_quantity.Text);
                    dTotal += chocolate.GetTotalPrice();
                    chocolate.UseIngredients(availableIngredients);

                    tb_water_mix.Text = availableIngredients["Water"].Quantity.ToString();
                    tb_chocolat_mix.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (dCash < dTotal)
                {
                    MessageBox.Show("Insufficient cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dTotal;
                tb_total.Text = dTotal.ToString("F2");
                tb_change.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the numbers correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb_10.Text = changeCount[0].ToString();
            tb_5.Text = changeCount[1].ToString();
            tb_1.Text = changeCount[2].ToString();
            tb_05.Text = changeCount[3].ToString();
            tb_025.Text = changeCount[4].ToString();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void chb_mocha_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void increaseStock_Click(object sender, EventArgs e)
        {
            tb_water_mix.Text = water.Quantity.ToString();
            tb_coffee_mix.Text = coffee.Quantity.ToString();
            tb_milk_mix.Text = milk.Quantity.ToString();
            tb_chocolat_mix.Text = chocolatMix.Quantity.ToString();

            water.Name = "Water Mix";
            water.Quantity = 1000;

            coffee.Name = "Coffee Mix";
            coffee.Quantity = 1000;

            milk.Name = "Milk Mix";
            milk.Quantity = 1000;

            chocolatMix.Name = "Chocolate Mix";
            chocolatMix.Quantity = 1000;
        }
    }
}
