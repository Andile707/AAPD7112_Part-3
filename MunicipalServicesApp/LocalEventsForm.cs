
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();
        }

        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            LoadSampleEvents();
            LoadCategories();

            BuildUpcomingEventsQueue();

            DisplayAllEvents();
            DisplaySearchHistory();
            DisplayRecommendations();
            lstRecommendations.HorizontalScrollbar = true;
            lstRecommendations.HorizontalExtent = 650;
        }

        // Add events to the repository
        private void AddEvent(LocalEvent localEvent)
        {
            DateTime date = localEvent.EventDate.Date;

            if (!EventRepository.EventsByDate.ContainsKey(date))
            {
                EventRepository.EventsByDate[date] =
                    new List<LocalEvent>();
            }

            EventRepository.EventsByDate[date].Add(localEvent);

            EventRepository.Categories.Add(localEvent.Category);
        }

        // Load sample municipal events
        private void LoadSampleEvents()
        {
            if (EventRepository.EventsByDate.Count > 0)
                return;

            AddEvent(new LocalEvent
            {
                EventId = 1,
                Title = "Community Clean-Up",
                Description = "Community clean-up campaign.",
                Category = "Community",
                EventDate = DateTime.Today.AddDays(3),
                Location = "Community Hall"
            });

            AddEvent(new LocalEvent
            {
                EventId = 2,
                Title = "Municipal Sports Day",
                Description = "Sports activities for local residents.",
                Category = "Sports",
                EventDate = DateTime.Today.AddDays(7),
                Location = "Municipal Sports Ground"
            });

            AddEvent(new LocalEvent
            {
                EventId = 3,
                Title = "Water Supply Maintenance",
                Description = "Scheduled water infrastructure maintenance.",
                Category = "Utilities",
                EventDate = DateTime.Today.AddDays(2),
                Location = "Ward 5"
            });

            AddEvent(new LocalEvent
            {
                EventId = 4,
                Title = "Youth Career Workshop",
                Description = "Career development workshop for young residents.",
                Category = "Education",
                EventDate = DateTime.Today.AddDays(10),
                Location = "Civic Centre"
            });
        }

        // Load categories and allow custom input
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();

            cmbCategory.DropDownStyle =
                ComboBoxStyle.DropDown;

            cmbCategory.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cmbCategory.AutoCompleteSource =
                AutoCompleteSource.ListItems;

            cmbCategory.Items.Add("All Categories");

            List<string> sortedCategories =
                new List<string>(EventRepository.Categories);

            sortedCategories.Sort();

            foreach (string category in sortedCategories)
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }

        // Display upcoming events using the queue
        private void DisplayAllEvents()
        {
            lstEvents.Items.Clear();

            BuildUpcomingEventsQueue();

            foreach (LocalEvent localEvent
                in EventRepository.UpcomingEventsQueue)
            {
                lstEvents.Items.Add(localEvent);
            }
        }

        private void cmbCategory_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            // Category selection is handled when Search is clicked.
        }

        // Search events by category and date
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory =
                cmbCategory.Text.Trim();

            DateTime selectedDate =
                dtpEventDate.Value.Date;

            if (string.IsNullOrWhiteSpace(selectedCategory))
            {
                MessageBox.Show(
                    "Please select or enter a category.",
                    "Category Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Normalize the All Categories option
            if (selectedCategory.Equals(
                "All Categories",
                StringComparison.OrdinalIgnoreCase))
            {
                selectedCategory = "All Categories";
            }
            else
            {
                // Match typed categories with existing categories
                string existingCategory =
                    EventRepository.Categories.FirstOrDefault(c =>
                        c.Equals(
                            selectedCategory,
                            StringComparison.OrdinalIgnoreCase));

                if (existingCategory != null)
                {
                    selectedCategory = existingCategory;
                }
            }

            lstEvents.Items.Clear();

            bool found = false;

            foreach (var dateEntry
                in EventRepository.EventsByDate)
            {
                foreach (LocalEvent localEvent
                    in dateEntry.Value)
                {
                    bool categoryMatches =
                        selectedCategory == "All Categories" ||
                        string.Equals(
                            localEvent.Category,
                            selectedCategory,
                            StringComparison.OrdinalIgnoreCase);

                    bool dateMatches =
                        localEvent.EventDate.Date == selectedDate;

                    if (categoryMatches && dateMatches)
                    {
                        lstEvents.Items.Add(localEvent);
                        found = true;
                    }
                }
            }

            if (!found)
            {
                lstEvents.Items.Add(
                    "No events found for this search.");
            }

            RecordSearch(selectedCategory, selectedDate);
        }

        // Record searches using a stack and dictionary
        private void RecordSearch(string category, DateTime date)
        {
            // Normalize existing categories
            if (!category.Equals(
                "All Categories",
                StringComparison.OrdinalIgnoreCase))
            {
                string existingCategory =
                    EventRepository.Categories.FirstOrDefault(c =>
                        c.Equals(
                            category,
                            StringComparison.OrdinalIgnoreCase));

                if (existingCategory != null)
                {
                    category = existingCategory;
                }
            }

            string search =
                category + " - " +
                date.ToString("dd MMM yyyy");

            EventRepository.SearchHistory.Push(search);

            if (!category.Equals(
                "All Categories",
                StringComparison.OrdinalIgnoreCase))
            {
                // Normalize existing preference keys
                string preferenceKey =
                    EventRepository.SearchPreferences.Keys
                    .FirstOrDefault(k =>
                        k.Equals(
                            category,
                            StringComparison.OrdinalIgnoreCase));

                if (preferenceKey != null)
                {
                    EventRepository.SearchPreferences[preferenceKey]++;
                }
                else
                {
                    EventRepository.SearchPreferences[category] = 1;
                }
            }

            DisplaySearchHistory();
            DisplayRecommendations();
        }

        // Display recent searches
        private void DisplaySearchHistory()
        {
            lstSearchHistory.Items.Clear();

            foreach (string search
                in EventRepository.SearchHistory)
            {
                lstSearchHistory.Items.Add(search);
            }
        }

        // Recommend events based on previous searches
        private void DisplayRecommendations()
        {
            lstRecommendations.Items.Clear();

            if (EventRepository.SearchPreferences.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "Search for events to receive recommendations.");
                return;
            }

            string favouriteCategory = null;
            int highestCount = 0;

            foreach (var preference
                in EventRepository.SearchPreferences)
            {
                if (preference.Value > highestCount)
                {
                    highestCount = preference.Value;
                    favouriteCategory = preference.Key;
                }
            }

            bool recommendationFound = false;

            foreach (var dateEntry
                in EventRepository.EventsByDate)
            {
                foreach (LocalEvent localEvent
                    in dateEntry.Value)
                {
                    if (string.Equals(
                            localEvent.Category,
                            favouriteCategory,
                            StringComparison.OrdinalIgnoreCase)
                        &&
                        localEvent.EventDate.Date >= DateTime.Today)
                    {
                        lstRecommendations.Items.Add(localEvent);
                        recommendationFound = true;
                    }
                }
            }

            if (!recommendationFound)
            {
                lstRecommendations.Items.Add(
                    "No upcoming events available for " +
                    favouriteCategory + ".");
            }
        }

        // Build queue of upcoming events
        private void BuildUpcomingEventsQueue()
        {
            EventRepository.UpcomingEventsQueue.Clear();

            // Sort by date before adding to the queue
            var upcomingEvents =
                EventRepository.EventsByDate
                .SelectMany(entry => entry.Value)
                .Where(localEvent =>
                    localEvent.EventDate.Date >= DateTime.Today)
                .OrderBy(localEvent => localEvent.EventDate)
                .ToList();

            foreach (LocalEvent localEvent in upcomingEvents)
            {
                EventRepository.UpcomingEventsQueue.Enqueue(
                    localEvent);
            }
        }

        // Reset category and display all upcoming events
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            cmbCategory.Text = "All Categories";

            DisplayAllEvents();
        }

        // Return to main menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
