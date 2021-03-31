<script lang="ts" context="module">
  export const contextKey = {};
</script>

<script lang="ts">
  import { onMount, setContext } from 'svelte';
  import Section from './components/section.svelte';

  export let valueBinding: HTMLInputElement;
  export let resources: { [key: string]: string };

  let section = JSON.parse(valueBinding.value);

  setContext(contextKey, {
    resources,
    updateValue: () => {
      valueBinding.value = JSON.stringify(section);
    },
  });

  onMount(() => {
    let shadowRoot = undefined;
    let parent = valueBinding.parentElement;

    while (shadowRoot === undefined) {
      if (parent.shadowRoot !== null) {
        shadowRoot = parent.shadowRoot;
      } else {
        if (parent.classList.contains('ktc-form-wrapper')) {
          parent.classList.add('xpanded');
        }

        parent = parent.parentElement;
      }
    }

    try {
      shadowRoot.querySelector('.ktc-form-wrapper').style.width = '90%';
      shadowRoot.querySelector('.ktc-modal-dialog').style.width = 'auto';
    } catch (error) {}
  });
</script>

<main>
  <Section {section} />
</main>

<style>
  main {
    overflow: auto;
  }
</style>
