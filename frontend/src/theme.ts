import { createSystem, defaultConfig, defineConfig } from "@chakra-ui/react";

const config = defineConfig({
  globalCss: {
    html: {
      colorPalette: "green", // Change this to any color palette you prefer
    },
  },
  theme: {
    tokens: {
      colors: {
        brown: { value: "#8B5A2B" },
        green: {
          50: { value: "#e5f6e7" },
          100: { value: "#ccecd1" },
          200: { value: "#99d9a3" },
          300: { value: "#66c675" },
          400: { value: "#4CAF50" },
          500: { value: "#409a45" },
          600: { value: "#337f39" },
          700: { value: "#26652d" },
          800: { value: "#194b21" },
          900: { value: "#0c3115" },
        },
      },
    },
  },
});

export const system = createSystem(defaultConfig, config);
