import ReactDOM from "react-dom/client";
import "./Styles/index.css";
import { ThemeProvider } from "./Components/theming/theme-provider.tsx";
import BrowserRouter from "./Components/navigation/BrowserRouter.tsx";
import { RouterProvider } from "react-router-dom";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
    <RouterProvider router={BrowserRouter}></RouterProvider>
  </ThemeProvider>
);
