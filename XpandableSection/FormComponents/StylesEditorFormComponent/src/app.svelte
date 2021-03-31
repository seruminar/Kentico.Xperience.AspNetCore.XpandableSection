<script lang="ts" context="module">
  export const contextKey = {};
</script>

<script lang="ts">
  import { setContext } from 'svelte';
  import Editor from './components/editor.svelte';

  export let valueBinding: HTMLInputElement;
  export let resources: { [key: string]: string };

  let value = JSON.parse(valueBinding.value);

  setContext(contextKey, {
    resources,
    updateValue: (value: string) => {
      valueBinding.value = JSON.stringify(value);
    },
  });
</script>

<main>
  <Editor {value} />
</main>

<style>
  main {
    overflow: auto;
  }
</style>
