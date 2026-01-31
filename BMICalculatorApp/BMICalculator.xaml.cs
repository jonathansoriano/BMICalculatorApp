namespace BMICalculatorApp;

public partial class BMICalculator : ContentPage
{
    string selectedGender = "Male";
    string UnderweightRecommendations = "- Increase calorie intake with nutrient-rich food(e.g., nuts, lean protein, whole grains).\n" +
                                "- Incorporate strength training to build muscle mass.\n" +
                                "- Consult a nutrintionist if needed.";
    string NormalWeightRecommendations = "- Maintain a balanced diet with proteins, healthy fats, and fiber.\n" +
                                         "- Stay physically active with at least 150 minutes of excerise per week.\n" +
                                         "- Keep regular check-ups to monitor overall health.";
    string OverweightRecommendations = "- Reduce processed foods and focus on portion control\n" +
                                       "- Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training.\n" +
                                       "- Drink plenty of water and track your progress";
    string ObesityRecommendations = "- Consult a doctor for personalized guidance.\n" +
                                    "- Start with low-impact exercises (e.g., walking, cycling).\n" +
                                    "- Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes\n" +
                                    "- Avoid sugary drinks and main a consistent sleep schedule.";
    public BMICalculator()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_MaleTapped(object sender, TappedEventArgs e)
    {
        selectedGender = "Male";
        FrameMale.BorderColor = Colors.LimeGreen;
        

    }

    private void TapGestureRecognizer_FemaleTapped(object sender, TappedEventArgs e)
    {
        selectedGender = "Female";
        FrameFemale.BorderColor = Colors.LimeGreen;
        

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        Person person = GetBMIResults(Math.Round(HeightSlider.Value, MidpointRounding.AwayFromZero), Math.Round(WeightSlider.Value, MidpointRounding.AwayFromZero), selectedGender);

        string HealthRecommendationMessage = $"Gender: {person.Gender}\n" +
                    $"BMI: {person.BMI}\n" +
                    $"Health Status: {person.HealthStatus}\n" +
                    "Recommednations:\n";

        if (person.HealthStatus == "Underweight")
        {
            HealthRecommendationMessage += UnderweightRecommendations;
            DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
        }
        else if (person.HealthStatus == "Normal Weight")
        {
            HealthRecommendationMessage += NormalWeightRecommendations;
            DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
        }
        else if (person.HealthStatus == "Overweight")
        {
            HealthRecommendationMessage += OverweightRecommendations;
            DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
        }
        else
        {
            HealthRecommendationMessage += ObesityRecommendations;
            DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
        }
    }

    private static Person GetBMIResults(double height, double weight, string gender)
    {
        double bmi = (weight / (height * height)) * 703;
        double roundedBmi = Math.Round(bmi, 1, MidpointRounding.AwayFromZero);
        if (gender == "Male")
        {
            if (bmi < 18.5)
            {
                return new Person(gender, roundedBmi, "Underweight");
            }
            else if (bmi >= 18.5 && bmi < 25.0)
            {
                return new Person(gender, roundedBmi, "Normal Weight");
            }
            else if (bmi >= 25.0 && bmi < 30.0)
            {
                return new Person(gender, roundedBmi, "Overweight");
            }
            else
            {
                return new Person(gender, roundedBmi, "Obesity");
            }
        }
        else
        {
            if (bmi < 18)
            {
                return new Person(gender, roundedBmi, "Underweight");
            }
            else if (bmi >= 18 && bmi < 24.0)
            {
                return new Person(gender, roundedBmi, "Normal Weight");
            }
            else if (bmi >= 24.0 && bmi < 29.0)
            {
                return new Person(gender, roundedBmi, "Overweight");
            }
            else
            {
                return new Person(gender, roundedBmi, "Obesity");
            }
        }
    }
}