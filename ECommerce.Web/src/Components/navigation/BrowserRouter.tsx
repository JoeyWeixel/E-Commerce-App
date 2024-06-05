import HomePage from "@/Pages/HomePage";

const BrowserRouter = createBrowserRouter([
	{
		path: '/',
		element: <HomePage />,
		errorElement: < />,
	},
	{
		path: '/',
		element: <AppLayout />,
		children: [
			{
				path: 'buttons',
				element: <ButtonsPage />,
			},
			{
				path: 'charts',
				element: <ChartsPage />,
			},
			{
				path: 'data-table',
				element: <DataTablePage />,
			},
			{
				path: 'cards',
				element: <CardsPage />,
			},
			{
				path: 'inputs',
				element: <InputsPage />,
			},
			{
				path: 'settings',
				element: <SettingsPage />,
			},
		],
		errorElement: <ErrorPage />,
	},
])