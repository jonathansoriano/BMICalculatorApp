namespace BMICalculatorApp;

public partial class BMICalculator : ContentPage
{
    string selectedGender = "Male";
	public BMICalculator()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_MaleTapped(object sender, TappedEventArgs e)
    {
        selectedGender = "Male";
        FrameMale.BorderColor = Colors.Black;
        FrameFemale.BorderColor = Colors.LightGray;

    }

    private void TapGestureRecognizer_FemaleTapped(object sender, TappedEventArgs e)
    {
        selectedGender = "Female";
        FrameFemale.BorderColor = Colors.Black;
        FrameMale.BorderColor = Colors.LightGray;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        Person person = GetBMIResults(HeightSlider.Value, WeightSlider.Value, selectedGender);

        string HealthRecommendationMessage = $"Gender: {person.Gender}\n" +
                    $"BMI: {person.BMI}\n" +
                    $"Health Status: {person.HealthStatus}\n" +
                    "Recommednations:\n";

        //DisplayAlert("BMI Results", $"You selected {selectedGender}" , "OK");
        if (selectedGender == "Male")
        {
            if(person.BMI < 18.5) // Underweight
            {
                HealthRecommendationMessage += 
                    "- Increase calorie intake with nutrient-rich food(e.g., nuts, lean protein, whole grains).\n" +
                    "- Incorporate strength training to build muscle mass.\n" +
                    "- Consult a nutrintionist if needed.";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
            }
            else if(person.BMI >= 18.5 && person.BMI < 25.0) // Normal weight
            {
                HealthRecommendationMessage +=
                    "- Maintain a balanced diet with proteins, healthy fats, and fiber.\n" +
                    "- Stay physically active with at least 150 minutes of excerise per week.\n" +
                    "- Keep regular check-ups to monitor overall health.";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
            }
            else if(person.BMI >= 25 && person.BMI < 30.0) // Overweight
            {
                HealthRecommendationMessage +=
                    "- Reduce processed foods and focus on portion control\n" +
                    "- Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training.\n" +
                    "- Drink plenty of water and track your progress";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
            }
            else // Obesity
            {
                HealthRecommendationMessage +=
                    "- Consult a doctor for personalized guidance.\n" +
                    "- Start with low-impact exercises (e.g., walking, cycling).\n" +
                    "- Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes\n" +
                    "- Avoid sugary drinks and main a consistent sleep schedule.";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");

            }
        }
        else
        {
            if (person.BMI < 18) // Underweight
            {
                HealthRecommendationMessage +=
                    "- Increase calorie intake with nutrient-rich food(e.g., nuts, lean protein, whole grains).\n" +
                    "- Incorporate strength training to build muscle mass.\n" +
                    "- Consult a nutrintionist if needed.";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
            }
            else if (person.BMI >= 18 && person.BMI < 24.0) // Normal weight
            {
                HealthRecommendationMessage +=
                    "- Maintain a balanced diet with proteins, healthy fats, and fiber.\n" +
                    "- Stay physically active with at least 150 minutes of excerise per week.\n" +
                    "- Keep regular check-ups to monitor overall health.";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
            }
            else if (person.BMI >= 24 && person.BMI < 29.0) // Overweight
            {
                HealthRecommendationMessage +=
                    "- Reduce processed foods and focus on portion control\n" +
                    "- Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training.\n" +
                    "- Drink plenty of water and track your progress";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");
            }
            else // Obesity
            {
                HealthRecommendationMessage +=
                    "- Consult a doctor for personalized guidance.\n" +
                    "- Start with low-impact exercises (e.g., walking, cycling).\n" +
                    "- Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes\n" +
                    "- Avoid sugary drinks and main a consistent sleep schedule.";
                DisplayAlert("Your calculated BMI Results are: ", HealthRecommendationMessage, "OK");

            }

        }
    }

    private static Person GetBMIResults(double height, double weight, string gender)
    {
        // You need to differentiate health status based on gender!!!! This is only for men.
        double bmi = (weight / (height * height)) * 703;
        double roundedBmi = Math.Round(bmi, 1, MidpointRounding.AwayFromZero);

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
}